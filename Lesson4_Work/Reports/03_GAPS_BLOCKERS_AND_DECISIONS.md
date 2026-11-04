# Lesson 4 — gaps, blockers and decisions

Audit date: 2026-11-03. All interaction outcomes remain `QUEST_NOT_TESTED`.

## Decisions made

- Work remains in `Assets/Scenes/SampleScene.unity`; three new independent exercise groups were placed below the existing `Lesson4_AdvancedInteractions` root.
- Hand Grab Use and Grab Surface use scene-object configurations copied from the locally imported Meta XR Interaction SDK 207.0.1 example scenes. Throw uses a scene instance of the installed StonePolyhedron prefab. Package sample sources were not edited.
- Existing Lesson 1–3 systems, rig, interactor hierarchy, locomotion, EventSystem, `ControlCanvas`, `PowerCell`, `BatteryDock`, menu and teleport objects were retained.
- Existing hand/controller pathways are kept distinct. Distance Hand Grab still contains both the generic `DistanceGrabInteractable` and `DistanceHandGrabInteractable`; do not describe it as hands-only.
- No Play Mode, Link, Quest build or deployment was performed. Static references and script compilation do not establish tracked-hand runtime behavior.
- No screenshots were acquired. The screenshot guide and manifest are instructions and missing-evidence records only.

## Open gaps and blockers

| Topic | Current status | Exact outstanding action |
|---|---|---|
| Custom grab pose | `PARTIAL`, `POSE_RECORDING_PENDING_QUEST_OR_LINK` | In a later instructor-led tracked-hand session, use the local Hand Grab Pose Recorder in Play Mode, record a course-owned pose, save it to a new project-owned collection, reload it and verify both hands if intended. Existing six Torch poses are Meta sample data, not course-authored data. |
| Thumbs-up and hand-grab outcomes | `STATIC_CONFIGURED`, `QUEST_NOT_TESTED` | Verify left and right tracking, hand references, recognition activation/deactivation, and target feedback on the Quest. |
| Two-hand manipulation | `STATIC_CONFIGURED`, `QUEST_NOT_TESTED` | Check two-hand translation/rotation and whether the sample `GrabFreeTransformer` scale behavior is reachable through the hand/controller selection combination. Test limits and releases. |
| Distance Hand Grab | Static configuration present; wizard history incomplete | Test hands left/right and inspect whether the generic controller route causes any unintended selection. Do not rerun the Quick Action on the configured capsule. |
| Throw | Static release/physics configuration present | Test real release velocity and RespawnOnDrop threshold on device; verify that Kinematic While Selected and Throw When Unselected cooperate as intended. |
| Meta Haptics SDK clips | SDK 207.0.1 installed; sample clip configured and instructor-tested on L4_ThrowStone | Haptics Quest exercise complete. No package update was performed. |
| Controller haptics | Instructor reports side-specific sound/vibration for both controller routes, amplitude/frequency comparisons, BasicOvrInput comparison, no release feedback and throw regression | Complete for the course. Tracked-hand interactions were tested separately; controller vibration is not expected from hands. No separate event-count instrumentation is required. |
| Microgesture sequence | `AVAILABLE_SAMPLE_ONLY`, not configured | Optional future implementation requires deliberate inspection and wiring of the sample's feature providers and sequence references. Current locomotion microgesture bindings were left unchanged. |
| New microgesture UI scroll | Not implemented | A separate scroll exercise needs a verified v207 `MicrogestureScroll` configuration and a dedicated ScrollRect/PointableCanvas path; no UI or locomotion changes were made. |
| Manual screenshots | 0 accepted in this work | Instructor captures the IDs in `SCREENSHOT_CAPTURE_GUIDE_MANUAL.md`; older screenshot claims conflict with the checked empty `Lesson4_Work/Screenshots` folder. |

## Warnings and uncertainty

- Unity's MCP Console reported one existing WebSocket-not-initialized warning. No Unity Console errors were returned after script compilation.
- Edit Mode runtime-populated provider references can appear null before initialization in this SDK; where the scene report notes this behavior, treat it as initialization-dependent and confirm on Quest rather than wiring speculative references.
- The one-sample-derived use/surface/throw setups are structurally copied from local v207 content. Their behavior has not been exercised by a real hand or controller.
- Current script maps the selecting interactor's ControllerRef.Handedness to one Touch controller; the older both-controller behavior is historical and was replaced.
- The old manifest IDs A01–Q01 remain missing. Older midpoint reports naming images are historical claims, not proof that files currently exist.

## Official and local sources

- Meta XR Interaction SDK package requirements: https://developers.meta.com/vr/documentation/unity/unity-isdk-packages-and-requirements/
- Meta Distance Hand Grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-hand-grab-interaction/
- Meta hand-grab poses: https://developers.meta.com/horizon/documentation/unity/unity-isdk-creating-handgrab-poses/
- Meta hand pose detection: https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-pose-detection/
- Meta two-handed grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-two-handed-grab-interaction/
- Meta transformer example: https://developers.meta.com/vr/documentation/unity/unity-isdk-transformer-examples-scene/
- Local v207 HandGrabUseExamples and HandGrabExamples scenes, and StonePolyhedron prefab: see exact provenance and final object paths in `01_REMAINING_FEATURES_IMPLEMENTATION_LOG.md` and `02_CONFIGURATION_MATRIX_FINAL.md`.
- Local source: `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`, `Assets/Scripts/Lesson4/L4_ThumbsUpFeedback.cs`, `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs`.

## Suggested next decision

Continue with the remaining Quest checks in `QUEST_TEST_CHECKLIST_FINAL.md` and acquire the missing Editor screenshots manually. Meta XR Haptics SDK 207.0.1 is already installed; no further package approval or package change is needed for the configured haptics exercise.


## Current haptics update - 2026-11-04

The user had installed com.meta.xr.sdk.haptics 207.0.1 before this implementation, superseding the earlier package-absent / approval-required status. No package was installed or upgraded here. HapticSource with the official switch_on.haptic sample is configured on L4_ThrowStone. Static routing resolves the actual selecting ISDK ControllerRef.Handedness; the instructor subsequently reported left/right output, perceptual tuning, BasicOvrInput comparison, no release feedback and throw regression tested on Quest. The controller haptics exercise is complete. Hand tracking/grab interactions were tested in their dedicated exercises; bare hands do not produce controller vibration, so a hand-only haptics test is not required. A separate event-count measurement is not part of course acceptance.
