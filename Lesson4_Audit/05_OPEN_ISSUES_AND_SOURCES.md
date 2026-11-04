# Open Issues, Version Notes and Sources

## Unresolved facts and limitations

1. Unity MCP reports active `SampleScene` is dirty (`isDirty=true`). Live Editor scene may differ from disk. Preserve it; future work should confirm baseline and use a disposable copy.
2. No Play Mode, build, install, Quest deployment, headset test or haptics output test occurred. All runtime behavior is unverified.
3. Separate Meta Haptics SDK is absent. Core metadata advertises an unimported OVR Haptics sample; this is not a local clip player workflow. A future separately authorized package/import phase must check compatible version, sample and event bridge. No bare-hand vibration claims.
4. Unity window was minimized during Computer Use screenshot attempt. No audit screenshots exist; see `04_SCREENSHOT_MANIFEST.md`.
5. `packages-lock.json`: Meta Core 207.0.1 requests Unity XR Hands 1.7.2 but resolved entry is 1.7.3. No package change is proposed.
6. Use v207 local labels rather than newer docs labels. Local menu is `Window/Meta/Interaction SDK/Hand Grab Pose Recorder`; newer references may say Hand Pose Recorder Wizard. `HandsDebugOverlay` is documented as v209+ and was not found locally.
7. No active GazeInteractor in SampleScene; GazeExamples is imported and menu interactables exist, but they do not prove a gaze input source. Eye tracking disabled. Distinguish head gaze from eye gaze.
8. Current ControlCanvas has a One Grab Transformer and null Two Grab Transformer, with active Poke/Ray UI children. Do not turn it into the first two-hand test object; scaling/moving may regress UI hit alignment.
9. No DistanceHandGrabInteractable target is set up in active scene. Existing hand interactor does not prove a target is ready.
10. Pre-audit Git changes are listed in `00_AUDIT_SUMMARY.md`; they were not touched.

## Official Meta documentation checked

The docs below may be newer than local v207. Use local sample, package source and Inspector to author version-exact instructions.

- Requirements: https://developers.meta.com/vr/documentation/unity/unity-isdk-packages-and-requirements/
- Comprehensive/cameraless rig: https://developers.meta.com/vr/documentation/unity/unity-isdk-cameraless-rig/
- Choosing grab type: https://developers.meta.com/vr/documentation/unity/unity-isdk-choosing-grab-type/
- Distance Grab Quick Action: https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-grab-quick-action/
- Create distance grabbable object: https://developers.meta.com/vr/documentation/unity/unity-isdk-create-distance-grabbable-object/
- Distance Hand Grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-hand-grab-interaction/
- Hand grabbable / pose authoring: https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-grabbable-object/
- Hand pose detection: https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-pose-detection/
- Pose detection concepts: https://developers.meta.com/vr/documentation/unity/unity-isdk-detecting-poses/
- Grabbable: https://developers.meta.com/vr/documentation/unity/unity-isdk-grabbable/
- Two-handed grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-two-handed-grab-interaction/
- Transformer examples: https://developers.meta.com/vr/documentation/unity/unity-isdk-transformer-examples-scene/
- Example scenes: https://developers.meta.com/vr/documentation/unity/unity-isdk-example-scenes/
- Hand Grab Use: https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-grab-use-interaction/
- Touch Hand Grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-touch-hand-grab-interaction/
- Custom hand models: https://developers.meta.com/vr/documentation/unity/unity-isdk-customize-hand-model/
- Gaze/microgesture scroll: https://developers.meta.com/vr/documentation/unity/unity-isdk-gaze-microgesture-scroll/
- HandsDebugOverlay version: https://developers.meta.com/vr/documentation/unity/unity-isdk-hands-debug-overlay/
- Meta Haptics SDK: https://developers.meta.com/vr/documentation/unity/unity-haptics-sdk-integrate/
- OVRHand API: https://developers.meta.com/vr/reference/unity/v71/class_o_v_r_hand/

## Recommended next implementation step — not executed

In a separately authorized implementation phase, create a disposable pilot scene from a preserved copy of the teaching scene. Use its existing bare-hand distance interactors and configure one new Capsule with local v207 `Add Distance Grab Interaction`, Hands + Pull mode. Inspect generated references before any Play Mode; request/obtain authorization for runtime and Quest verification separately. Do not edit the active dirty SampleScene for the pilot.

## Status update - 2026-11-04

The audit items stating that SampleScene is dirty and Meta Haptics SDK is absent are historical observations from the read-only audit. The instructor installed Meta XR Haptics SDK 207.0.1 and later saved the scene; Unity MCP now reports `isDirty=false`. Haptics is configured and the instructor-reported Quest test is complete. Hand interactions were tested in their dedicated modules; hands do not produce controller vibration, and no separate event-count test is required. See the current Lesson4_Work reports for details.
