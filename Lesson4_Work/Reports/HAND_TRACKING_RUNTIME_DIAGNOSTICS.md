# Runtime diagnostics for the hand status indicators

Date: 2026-11-04. Instrumentation is configured in `Assets/Scenes/SampleScene.unity`; no build or headset test was run by Codex.

## What the log reports

`L4_HandTrackingStatusIndicator` writes one `[L4HandStatus]` line per second while the app is running. Each line contains left and right raw `OVRHand` data and Interaction SDK `Hand` wrapper values for technical diagnosis. Sphere colors use the raw OVR values.

- Raw OVR: `IsTracked`, `IsDataValid`, `IsDataHighConfidence`, `HandConfidence`.
- Interaction SDK wrapper: `IsConnected`, `IsTrackedDataValid`, `IsHighConfidence`.
- `t=` is Unity unscaled runtime time in seconds.

The serialized references on `L4_HandTrackingStatus` point to:

- `_leftOVRHand` → `OVRCameraRig/OVRComprehensiveInteractionRig/OVRHands/OVRHandDataSourceLeft` → `OVRHand`.
- `_rightOVRHand` → `OVRCameraRig/OVRComprehensiveInteractionRig/OVRHands/OVRHandDataSourceRight` → `OVRHand`.
- `_leftHand` and `_rightHand` remain the existing Interaction SDK `Hand` components and are logged for comparison.
- `_logRuntimeState=true`; `_logIntervalSeconds=1`.

## Why the green indicators can persist

The original indicator read the filtered Interaction SDK `Hand`. In the local Meta Interaction SDK 207.0.1 rig, each OVR source includes `LastKnownGoodHand`. Its source states that it preserves the last valid hand data when input becomes invalid or tracking quality drops. If a previous good state exists and the source remains connected, it copies the cached pose and marks the wrapper data valid, tracked and high-confidence. The original color script could therefore remain green after raw tracking was lost. This is intentional smoothing/fallback behavior in the interaction data chain; it is not evidence that raw tracking continues.

The diagnostic logs both sides of that chain. Sphere colors now follow the raw OVR flags: invalid or untracked is dark; tracked but not high-confidence is orange; tracked with high confidence is green. The filtered `Hand` values remain in the logs so students can see the cached-pose fallback. Do not remove or disable `LastKnownGoodHand`; it is part of the existing interaction rig and could affect hand interactions.

## Instructor log result

The instructor's 2026-11-04 log shows both raw OVR hands becoming tracked/high-confidence, then reporting `tracked=false`, `dataValid=true`, `highConfidence=false`, `confidence=Low` while the filtered Interaction SDK wrappers continued to report connected/valid/high-confidence. Raw tracking briefly returned high around `t=21.63–23.66`, then returned to false/low from approximately `t=24.67` through `t=46.97`. This confirms the last-known-good fallback explains the old green indicators. The corrected raw-color behavior has compiled but still needs a new Quest build and visual confirmation by the instructor.

## Reading the next test

Compare `OVR(...)` with `ISDK(...)` for the same side:

- Raw OVR says tracked/data valid/high confidence: the indicator should be green.
- Raw OVR says tracked but low-confidence: the indicator should be orange.
- Raw OVR says invalid or untracked, while the wrapper remains valid/high-confidence: `LastKnownGoodHand` is holding a synthetic last-known pose; the indicator should be dark.
- Raw OVR says invalid/untracked but the sphere remains green: check that the updated build is installed and that the raw OVR reference is assigned.
- `OVRHand=null` or `Hand=null`: the serialized diagnostics reference is missing; check the current Inspector wiring.

## Get logs from Windows

Build and install a new Android app after this instrumentation is saved. Codex did not build or deploy it. With the Quest connected by USB and USB debugging authorized, open PowerShell and run:

```powershell
$adb = 'C:\Program Files\Unity\Hub\Editor\6000.3.9f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK\platform-tools\adb.exe'
& $adb devices
& $adb logcat -s Unity | Select-String '\[L4HandStatus\]'
```

Leave the second command running, start the app, test with hands in tracking view, hands covered/in a pocket, then controllers. Stop collection with Ctrl+C and paste the lines containing `[L4HandStatus]` here. Do not use `adb logcat -c`; clearing the device log is unnecessary. If `adb devices` reports `unauthorized`, approve the USB debugging prompt in the headset and run it again.

Unity's `Debug.Log` output is also visible in the Editor Console during a Play Mode test, but the Quest values require logs from the updated app running on the device.

## Code and scene changes

- `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`: added serialized raw OVRHand references and interval-controlled runtime logging; sphere colors now use raw OVR tracking/confidence fields.
- `Assets/Scenes/SampleScene.unity`: assigned the left and right raw `OVRHand` references and retained the existing filtered `Hand` references.
- Backup of prior script: `Lesson4_Work/backup/L4_HandTrackingStatusIndicator_pre_diagnostics_20261104.cs` (SHA-256 `7AACE5D13199EEEE92F15907A3EEAEAD94B551D72B9ED8D8982360B34CADE058`).
- Final Editor check: script compile completed, Unity Console errors 0, scene validation issues 0, scene saved and `isDirty=false`. The instructor supplied runtime logs for the old color logic; the corrected visual behavior still needs Quest confirmation.
