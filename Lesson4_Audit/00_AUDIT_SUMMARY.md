# Lesson 4 — Static Audit Summary

**Scope:** read-only inspection. No Unity project state was changed. **Runtime:** `EDITOR_PLAY_MODE_NOT_TESTED`; `QUEST_NOT_TESTED`.

## Environment

| Item | Confirmed value |
|---|---|
| Unity | `6000.3.9f1` (Unity 6.3 LTS) |
| Project path | `C:/Users/Scianso/Documents/GitHub/XRInteractionLab` |
| Target | Android |
| Active/loaded scene | `Assets/Scenes/SampleScene.unity` (`SampleScene`) |
| Scene state | Unity MCP reports `isDirty=true`; unsaved Editor changes exist. Audit did not save. Live MCP state may differ from disk YAML. |
| Build scenes | `SampleScene`, enabled, index 0 |
| XR | OpenXR `1.18.0` plus Meta Core/OVR integration `207.0.1`; actual runtime loader was not exercised |
| Render pipeline | URP `17.3.0`; GraphicsSettings contains non-null custom pipeline reference |
| Input | Input System `1.18.0`; `activeInputHandler: 1` |
| OVR target device flags | Quest 2, Quest Pro, Quest 3, Quest 3S and VR Glasses configured in `Assets/Oculus/OculusProjectConfig.asset` |
| Hand/controller setting | OVR config serializes `ControllersAndHands`; simultaneous hands/controllers disabled in OVRManager. Runtime active mode is unknown. |
| Samples | Meta XR Interaction SDK `207.0.1` Example Scenes imported under `Assets/Samples/Meta XR Interaction ​SDK/207.0.1/Example Scenes`; directory contains a zero-width space after “Interaction”. Samples are not Build Settings scenes. |

## Package versions

- `com.meta.xr.sdk.core` **207.0.1** (direct)
- `com.meta.xr.sdk.interaction.ovr` **207.0.1** (direct OVR integration)
- `com.meta.xr.sdk.interaction` **207.0.1** (transitive)
- `com.unity.xr.hands` **1.7.3** resolved; Core lock dependency requests **1.7.2**
- `com.unity.xr.openxr` **1.18.0**; `com.unity.inputsystem` **1.18.0**
- `com.unity.render-pipelines.universal` **17.3.0**
- Separate Meta Haptics SDK: **not installed/resolved**. Core package metadata mentions an OVR Haptics sample, but it is not imported. No clip `HapticSource`/`HapticClipPlayer` was found.

Sources: `Packages/manifest.json`, `Packages/packages-lock.json`, PackageCache, ProjectSettings, Unity MCP project/editor/scene/build-settings queries.

## Git status before report writes

```text
 M Assets/Oculus/OculusProjectConfig.asset
 M Assets/Plugins/Android/AndroidManifest.xml
 M Assets/Scenes/SampleScene.unity
 M ProjectSettings/ProjectSettings.asset
 M ProjectSettings/TagManager.asset
?? Assets/Screenshots/screenshot-20261102-113456.png
?? Assets/Screenshots/screenshot-20261102-113456.png.meta
```

These pre-existing changes were not touched. No reset, checkout, clean or commit was run.

## Top findings

1. The active scene’s OVR Comprehensive Interaction Rig already includes bilateral bare-hand `DistanceHandGrabInteractor` components. The separate controller path uses `DistanceGrabInteractor`.
2. No `DistanceHandGrabInteractable` target is configured in active `SampleScene`; the rig source is present, but the exercise is not ready there.
3. Samples for Distance Grab, hand poses, gestures, transformers, touch grab, gaze and Hand Grab Use are imported locally; availability does not verify runtime behavior.
4. `SampleScene` is dirty. Preserve it and use a separate scene copy for future pilot work.
5. Separate Meta Haptics SDK is absent; do not teach clip playback as locally installed or claim hand vibration.

`STATIC_AUDIT_PASSED`; `EDITOR_PLAY_MODE_NOT_TESTED`; `QUEST_NOT_TESTED`. No genuine Unity screenshots captured; see `04_SCREENSHOT_MANIFEST.md`.

## Superseding follow-up - 2026-11-04

This read-only audit reflects the project before Haptics SDK installation and before the instructor saved the later scene state. The instructor installed Meta XR Haptics SDK 207.0.1; `L4_ThrowStone` now uses `HapticSource` and the official `switch_on.haptic` sample. The instructor reported left/right controller feedback, perceptible amplitude/frequency adjustments, BasicOvrInput comparison and throw regression tested on Quest. The instructor considers the haptics exercise complete. Hand interactions were tested in their dedicated exercises; hands are not expected to produce controller vibration, and no separate hand-only or event-count test is required. A follow-up Unity MCP query after the instructor saved reports `SampleScene` `isDirty=false`. Current implementation details are in `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md` and test results in `Lesson4_Work/Reports/QUEST_TEST_CHECKLIST_FINAL.md`.
