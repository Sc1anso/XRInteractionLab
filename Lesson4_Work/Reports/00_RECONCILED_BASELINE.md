# Lesson 4 — reconciled baseline before remaining features

Date: 2026-11-03. Unity MCP recheck; static inspection only.

Current-state update, 2026-11-04: the original indicator used filtered Hand values. It now retains those references for the interaction chain and uses raw left/right OVRHand flags for sphere colors. See `02_CONFIGURATION_MATRIX_FINAL.md` for the corrected setup and `HAND_TRACKING_RUNTIME_DIAGNOSTICS.md` for the separate engineering diagnosis.

## Environment and protection checkpoint

- Project: `C:\Users\Scianso\Documents\GitHub\XRInteractionLab`
- Unity: `6000.3.9f1`; active scene: `Assets/Scenes/SampleScene.unity`; build index 0; loaded; `isDirty=false`; not in Play Mode.
- Target platform: Android. Meta XR Core / Interaction / OVR integration: `207.0.1`; XR Hands `1.7.3`; OpenXR `1.18.0`; URP `17.3.0`. At this 2026-11-03 baseline, separate `com.meta.xr.sdk.haptics` was not installed; it was installed by the instructor before the 2026-11-04 implementation and is now configured/tested as described in the current-state update below.
- Existing Git status (read-only, using per-command `safe.directory`; no Git config changed): modified `Assets/Oculus/OculusProjectConfig.asset`, `Assets/Plugins/Android/AndroidManifest.xml`, `Assets/Scenes/SampleScene.unity`, `ProjectSettings/ProjectSettings.asset`, `ProjectSettings/TagManager.asset`; untracked previous screenshot in `Assets/Screenshots/`, `Assets/Scripts/Lesson4/`, `Lesson4_Audit/`, `Lesson4_Work/`. These predate the remaining-feature implementation. No reset/clean/checkout/commit.
- Pre-edit scene SHA-256: `DFABBB2B7138AFBAE2CC7A9B5C1234DAD078C97479214661E666637E948FBCBD`.
- Byte-identical backup plus .meta: `Lesson4_Work/backup/SampleScene_pre_remaining_20261103_213316.unity` and matching `.meta`. No scene backup is being overwritten.
- Unity MCP root inventory: 12 roots, one `OVRCameraRig`, one `OVRComprehensiveInteractionRig`, one `Locomotor`, one root `EventSystem`. The EventSystem has `EventSystem`, `InputSystemUIInputModule`, `PointableCanvasModule`, `BaseInput`. Existing `ControlCanvas`, `PowerCell`, `BatteryDock`, `FloorTeleportSurface`, `ISDKExampleMenu`, lighting and input wiring are protected.
- Screenshot evidence: no files in `Lesson4_Work/Screenshots/`; all previous planned shots remain missing. Older midpoint manifests claiming PNGs conflict with the most recent audit and actual folder check. No screenshots will be acquired in this task.

## Existing Lesson 4 module inventory

Evidence status applies to the current serialized Editor state only; no Play Mode or Quest interaction was tested. Historical clicks are not available and are not represented as an action log.

### A — Distance Hand Grab
Path: `Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule` (local position/world position reported `(2.3, 1.05, 2.8)`).
- Root components: `Transform`, `MeshFilter`, `CapsuleCollider`, `MeshRenderer`, `Rigidbody`, `Grabbable`.
- Collider: center `(0,0,0)`, radius `0.5`, height `2`, direction Y, enabled, not trigger.
- Rigidbody: mass `1`, Use Gravity `false`, Is Kinematic `true`.
- Grabbable: Max Grab Points `-1`; Target Transform and Rigidbody refer to the root; Kinematic While Selected and Throw When Unselected enabled; transformer references null.
- Child `ISDK_DistanceHandGrabInteraction`: `Transform`, `DistanceHandGrabInteractable`, generic `DistanceGrabInteractable`, `MoveTowardsTargetProvider`, reticle-related components. Hand interactable supports grab flags `3` = Pinch + Palm; Relative To and Rigidbody/Pointable references target the capsule; movement provider object is the child provider. Edit Mode public MovementProvider is null because v207 initializes it at runtime; not tested.
- Existing bare-hand DistanceHandGrabInteractor paths exist on each comprehensive hand branch. Separate controller-only DistanceGrabInteractor and controller-driven hand routes also exist. Do not claim this target is exclusively hand-routed.
- Previous reports claim Quick Action choices Hands + Pull Interactable To Hand; actual history not captured. Wizard must not be rerun on this target.
- Status: `STATIC_CONFIGURED`; wizard history partial; `QUEST_NOT_TESTED`.

### B — Hand Tracking Foundations
Path: `Lesson4_AdvancedInteractions/L4_HandTrackingStatus`.
- Children: `L4_LeftTrackingIndicator`, `L4_RightTrackingIndicator` (each Transform, MeshFilter, MeshRenderer; small sphere indicators).
- Script: `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`; two same-side Hand refs and same-side MeshRenderer refs.
- Colors: not tracked `(0.22,0.25,0.30,1)`; low confidence `(1,0.58,0.08,1)`; high confidence `(0.16,0.82,0.36,1)`.
- Reads `IsTrackedDataValid` and `IsHighConfidence`; not pinch/input modality. Existing rig data path is OVRHands, OVRHandDataSource left/right, HandSkeletonOVR and OVRHandVisual left/right.
- Status: `STATIC_VERIFIED`; visual updates `QUEST_NOT_TESTED`.

### C — Custom Hand Grab Pose
Path: `Lesson4_AdvancedInteractions/L4_GrabPose_Exercise/L4_GrabPoseTool`.
- Origin: scene instance of v207 sample `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/Torch/Torch.prefab`.
- Root components: Transform, Rigidbody, Grabbable, PointableUnityEventWrapper; children include the normal/mirrored HandGrabInteractables and six package-authored HandGrabPose points.
- Rigidbody mass `1`, gravity false, kinematic true. Grabbable Transfer On Second Selection true; root serialized Rigidbody and Target Transform are null; child interactables reference the root rigidbody/transform.
- Recorder menu source: `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`; source `Editor/Utils/HandGrabPoseWizard.cs`; controls Hand, Item Rigidbody, Ghost Provider, Poses Collection. Recording requires Play Mode and tracked hands. No course-authored collection or recorded pose exists.
- Status: `PARTIAL`; `POSE_RECORDING_PENDING_QUEST_OR_LINK`; `QUEST_NOT_TESTED`.

### D — Thumbs-Up Pose Detection
Path: `Lesson4_AdvancedInteractions/L4_ThumbsUp_Exercise/L4_ThumbsUpRecognizer_Left` and `.../L4_ThumbsUpRecognizer_Right`.
- Each recognizer contains Transform, HandRef, SelectorUnityEventWrapper, ActiveStateSelector, ActiveStateGroup, ShapeRecognizerActiveState, TransformRecognizerActiveState. These are scene instances of matching v207 ThumbsUpPose prefab data.
- HandRef and feature providers are side-matched. Shape assets are FingersAllClosed.asset and ThumbUp.asset. Wrapper WhenSelected and WhenUnselected target the matching indicator feedback methods.
- Feedback children `L4_ThumbsUpIndicator_Left/Right`: Transform, MeshFilter, MeshRenderer and `L4_ThumbsUpFeedback`; gray `(0.28,0.31,0.36,1)`, green `(0.12,0.88,0.38,1)`.
- Static pose recognition, not temporal gesture sequence.
- Status: `STATIC_VERIFIED`; `QUEST_NOT_TESTED`.

### E — Two-Handed Manipulation
Path: `Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject`.
- Origin: local package sample `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/StonePolyhedra/StonePolyhedron.prefab`.
- Root components: Transform, Grabbable, Rigidbody, RespawnOnDrop, GrabFreeTransformer; children include controller GrabInteractable and hand HandGrabInteractable and other sample visuals.
- Position local `(0,0.45,0)`, scale `(0.6,0.6,0.6)`; Rigidbody mass `0.2`, gravity on, kinematic off.
- Grabbable Max Grab Points `2`; Transfer On Second Selection off; Add New Points To Front off; Rigidbody assigned; Kinematic While Selected and Throw When Unselected enabled; Force Kinematic Disabled off; Target Transform None.
- One Grab Transformer and Two Grab Transformer both reference this object''s GrabFreeTransformer. Position/rotation unconstrained; relative scale X/Y/Z constrained with min `1`, max `3`.
- Keep separate from ControlCanvas (working Poke/Ray UI).
- Status: `STATIC_CONFIGURED`; hand motion/scale `QUEST_NOT_TESTED`.

## Known discrepancies and interpretation

1. Current saved scene and newest audit override older reports that describe a clean pre-L4 scene.
2. Previous screenshot manifest claims are not image evidence: latest audit plus disk check found zero files in the lesson screenshot folder. The separate older Game View image does not evidence steps.
3. Distance wizard choices are not historically proven. Do not imply historical capture.
4. Sample Torch pose points are not a new instructor-authored pose.
5. Every interaction statement above describes static configuration. No runtime success is asserted.
6. The original Git status contains pre-existing project modifications. The task will add only scoped Lesson 4 scene instances/scripts/reports, then record a fresh status/diff without rewriting old work.



## Current haptics update - 2026-11-04

The Meta XR Haptics SDK is now installed at 207.0.1 (user-installed before this implementation). The earlier baseline's package-absent note is historical. The instructor reported the left/right controller checks, parameter and mode comparisons, release behavior and throw regression passed on Quest; see QUEST_TEST_CHECKLIST_FINAL.md. The haptics exercise is controller-specific; tracked-hand interactions were tested separately in their own exercises, and no hand-vibration test is required. No separate event-count instrumentation is required for course completion.
