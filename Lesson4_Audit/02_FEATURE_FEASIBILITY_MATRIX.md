# Feature Feasibility Matrix — Lesson 4

Statuses describe local package and active scene, not runtime success. Imported examples live under `Assets/Samples/Meta XR Interaction ​SDK/207.0.1/Example Scenes` (zero-width space in folder name). For every row, `editor_verification=STATIC_AUDIT_PASSED`; `quest_verification=QUEST_NOT_TESTED`.

## Major-lab matrix

| Module | Status | Local evidence / dependencies | Recommendation |
|---|---|---|---|
| Hand tracking/source | `PRESENT_AND_CONFIGURED` | OVRHandDataSource, OVRHand, HandSkeletonOVR, HandVisual; Meta rig | Intro; tracking confidence still needs Quest runtime evidence |
| Distance Hand Grab | `INSTALLED_NOT_CONFIGURED` | Bare-hand DistanceHandGrabInteractor exists both sides; no target in SampleScene; DistanceGrabExamples imported | Primary lab in disposable scene |
| Hand Grab Pose authoring | `INSTALLED_NOT_CONFIGURED` | Local Pose Recorder wizard; active HandGrabInteractable pose lists empty | Primary if time/device available; future recording requires Play Mode |
| Thumbs Up Pose Detection | `AVAILABLE_SAMPLE_ONLY` | PoseExamples and `ThumbsUpPose.prefab`; no active scene chain | Primary, based on sample and explicit event wiring |
| Two-Hand Manipulation | `AVAILABLE_SAMPLE_ONLY` | TransformerExamples and transformer scripts; current canvas Two Grab Transformer null | Primary on separate target |
| Dynamic Sequence Gesture | `AVAILABLE_SAMPLE_ONLY` | GestureExamples and SequenceActiveState; not in main scene | Bonus/sample demo; not verified as experimental |
| Hand Grab Use | `AVAILABLE_SAMPLE_ONLY` | HandGrabUseExamples imported | Short demo |
| Grab Surface | `INSTALLED_NOT_CONFIGURED` | Sphere/Box/Collider/Bezier surface classes exist; none assigned to inspected poses | Short overview |
| Throw | `INSTALLED_NOT_CONFIGURED` | Rigidbody/Grabbable exist; no throw runtime verification | Short demo after inspector check |
| Touch Grab | `AVAILABLE_SAMPLE_ONLY` | TouchGrabExamples and components; official docs call Touch Hand Grab experimental | Overview/demo only |
| Microgestures | `PRESENT_AND_CONFIGURED` | Per-hand OVRMicrogestureEventSource and teleport/turn listeners | Short demo; static wiring only |
| Microgesture scrolling UI | `AVAILABLE_SAMPLE_ONLY` | `MicrogestureScroll.prefab` in OVR package; not active scene | Conditional, inspect prefab dependencies first |
| Haptics clips | `NEEDS_PACKAGE_OR_IMPORT` | Separate SDK absent; Core metadata advertises unimported OVR Haptics Sample | Prerequisite only; no bare-hand vibration claim |
| Gaze | `AVAILABLE_SAMPLE_ONLY` | GazeExamples imported; menu has GazeInteractables but active scene has no GazeInteractor; eye tracking disabled | Overview; distinguish head gaze from eye gaze |
| Custom hand models | `INSTALLED_NOT_CONFIGURED` | Standard HandVisual only; no custom model sample/config found | Overview; requires separate mesh/rig/reference setup |

## Module evidence and local fields

### Hand tracking
- **exact_local_path:** `OVRCameraRig/OVRComprehensiveInteractionRig/OVRHands/OVRHandDataSourceLeft|Right`.
- **component_type:** `FromOVRHandDataSource`, `LastKnownGoodHand`, `OVRHand`, ISDK `Hand`, `HandSkeletonOVR`, `HandVisual`.
- **inspector_fields:** hand-source/HMD/hand refs assigned; Editor-idle tracking/confidence booleans false, not runtime evidence.
- **dependencies/potential_steps:** Meta rig, Quest permission/runtime; explain data-source→skeleton/visual→interactor flow.
- **hazards:** `HandsDebugOverlay` is documented for v209+, not present in local v207.
- **screenshots_needed:** source hierarchy and OVRHand Inspector; later actual headset tracking.
- **official_source_url:** https://developers.meta.com/vr/documentation/unity/unity-isdk-packages-and-requirements/ ; https://developers.meta.com/vr/reference/unity/v71/class_o_v_r_hand/

### Distance Hand Grab (distinct from controller Distance Grab)
- **exact_local_path:** both bare-hand paths `.../ComprehensiveInteractorsLeft|Right/Interactors/Hand and No Controller/DistanceHandGrabInteractor`; controller path `.../Controller and No Hand/ControllerDistanceGrabInteractor`.
- **component_type:** hand `Oculus.Interaction.HandGrab.DistanceHandGrabInteractor`; controller `Oculus.Interaction.DistanceGrab.DistanceGrabInteractor`; target `DistanceHandGrabInteractable` plus Grabbable/Rigidbody/collider.
- **scene_or_sample:** DistanceGrabExamples imported; no DistanceHandGrabInteractable in SampleScene.
- **inspector_fields:** hand/HMD, origin/wrist, pinch/palm point/frustums, HandGrabApi assigned; Movement null. Local Quick Action `GameObject/Interaction SDK/Add Distance Grab Interaction`, source `Library/PackageCache/com.meta.xr.sdk.interaction@b0ce09a959ae/Editor/QuickActions/Scripts/DistanceGrabWizard.cs`. Wizard exposes `Add Required Interactor(s)` (`DeviceTypes`), `Rigidbody`, `Grabbable` (`IPointableElement`), optional `Time Out Snap Zone`, optional `Hologram Mesh` for Pull, `Distance Grab Type` (`Grab Relative To Hand`, `Pull Interactable To Hand`, `Manipulate In Place`), `Supported Grab Types`, `Auto Generate Collider`.
- **dependencies/potential_steps:** existing bare-hand interactor; configure disposable Capsule target using Hands + Pull mode; see pilot plan.
- **hazards:** don’t select controller-only interactor for bare hands; wizard mutates scene, so not run during audit.
- **screenshots_needed:** both interactor paths; wizard before Create; generated Capsule Inspector; Quest pull.
- **official_source_url:** https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-hand-grab-interaction/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-grab-quick-action/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-create-distance-grabbable-object/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-choosing-grab-type/

### Custom Hand Grab Poses vs Pose Detection
- **availability:** authoring `INSTALLED_NOT_CONFIGURED`; Thumbs Up detection `AVAILABLE_SAMPLE_ONLY`.
- **exact_local_path:** local menu `Window/Meta/Interaction SDK/Hand Grab Pose Recorder`; source `.../Editor/.../HandGrabPoseWizard.cs`; `PoseExamples.unity`; `.../Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab`.
- **component_type:** HandGrabPose/HandGrabInteractable for grasp pose; ShapeRecognizerActiveState, TransformRecognizerActiveState, ActiveStateGroup/Selector and SelectorUnityEventWrapper for recognition.
- **inspector_fields:** recorder fields `Hand`, `Item (Rigidbody)`, `Ghost Provider`, `Poses Collection`, record key Space; requires Play Mode to record. Inspected active HandGrabInteractable pose arrays empty. No recognizer/event wiring in main scene.
- **dependencies/potential_steps:** record pose on duplicate in future authorized runtime; for detection copy sample to disposable scene, wire activation and deactivation events explicitly.
- **hazards:** grasp pose ≠ recognized gesture. Shape pose does not imply velocity/dynamic gesture. Do not claim runtime.
- **screenshots_needed:** recorder window; pose-list asset; PoseExamples recognizer and event receiver; headset recognition.
- **official_source_url:** https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-grabbable-object/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-pose-detection/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-detecting-poses/

### Gesture Sequence
- **exact_local_path:** `GestureExamples.unity`; `SequenceActiveState.cs` in Interaction SDK runtime.
- **component_type/fields:** SequenceActiveState and sample recognizer/event wiring; no active scene instance. Inspect ordering, timing/reset and events from sample before lesson steps.
- **dependencies/hazards:** hand tracking and ordered states; optional bonus because unverified setup, not claimed “experimental”.
- **screenshots_needed:** sample sequence object/Inspector and actual response.
- **official_source_url:** https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-pose-detection/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-example-scenes/

### Two-Handed Manipulation
- **exact_local_path:** `TransformerExamples.unity`; transformer scripts in local Interaction package.
- **component_type:** Grabbable, GrabFreeTransformer, TwoGrabRotateTransformer, TwoGrabPlaneTransformer (local legacy/superseded note), OneGrabTranslateTransformer.
- **inspector_fields:** inspect `Max Grab Points` (>=2), One/Two Grab Transformer refs, Target Transform, transfer-on-second-selection, GrabFreeTransformer position/rotation/scale constraints. Current docs describe using GrabFreeTransformer in both slots for general two-hand manipulation; TwoGrabRotateTransformer exposes axis, min/max angle, pivot. Verify exact v207 capitalization in Editor. ControlCanvas has one transformer and null two transformer.
- **dependencies/potential_steps:** use separate disposable object; translation/rotation first, unlock scale axes only if intended.
- **hazards:** transfer-on-second-selection can cause takeover rather than two-point transform; scale constraints may be locked; Canvas movement/scale can regress Poke/Ray.
- **screenshots_needed:** TransformerExamples hierarchy and exact Inspector; later Quest two-hand result.
- **official_source_url:** https://developers.meta.com/vr/documentation/unity/unity-isdk-grabbable/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-two-handed-grab-interaction/ ; https://developers.meta.com/vr/documentation/unity/unity-isdk-transformer-examples-scene/

### Other ISDK interactions

- **Hand Grab Use:** `AVAILABLE_SAMPLE_ONLY`; `HandGrabUseExamples.unity`; inspect use pose/events. https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-grab-use-interaction/
- **Grab Surface:** `INSTALLED_NOT_CONFIGURED`; local Sphere/Box/Collider/Bezier surface classes; no custom surface assigned in active pose. https://developers.meta.com/vr/documentation/unity/unity-isdk-create-handgrab-poses-mac/
- **Throw:** `INSTALLED_NOT_CONFIGURED`; Rigidbody/Grabbable exist; inspect `Throw When Unselected`/physics in disposable target and test later. https://developers.meta.com/vr/documentation/unity/unity-isdk-grabbable/
- **Touch Grab:** `AVAILABLE_SAMPLE_ONLY`; TouchGrabExamples; official docs mark Touch Hand Grab experimental. https://developers.meta.com/vr/documentation/unity/unity-isdk-touch-hand-grab-interaction/
- **Microgestures:** left/right groups include OVRMicrogestureEventSource, MicroGestureUnityEventWrapper, teleport/turn broadcasters. `MicrogestureScroll.prefab` at `Library/PackageCache/com.meta.xr.sdk.interaction.ovr@74fbc962f91e/Runtime/Prefabs/Microgestures/`; includes DiscreteScrollInputProvider and needs ScrollRect/PointableCanvas wiring. https://developers.meta.com/vr/documentation/unity/unity-isdk-gaze-microgesture-scroll/
- **Haptics:** no separate package, HapticSource or HapticClipPlayer found. Core sample not imported. Future install/import and event bridge needed; controller hardware required for vibration; no bare-hand vibration. https://developers.meta.com/vr/documentation/unity/unity-haptics-sdk-integrate/
- **Gaze:** GazeExamples imported, menu interactables exist, but no GazeInteractor in main scene; eye tracking disabled. Do not equate head gaze and eye gaze. https://developers.meta.com/vr/documentation/unity/unity-isdk-packages-and-requirements/
- **Custom models:** standard HandVisual only; no custom sample/config. https://developers.meta.com/vr/documentation/unity/unity-isdk-customize-hand-model/

## Suggested ~3 hour sequence

Primary: Distance Hand Grab; Pose Recorder authoring if Quest/time available; Thumbs Up detection; two-hand manipulation on separate target. Conditional: Haptics only after compatible package prerequisite. Short demos: Hand Grab Use, Grab Surface, Throw, existing Microgestures; Sequence as optional bonus. Final overview: Touch Grab (experimental), Gaze, Custom Hand Models and other capabilities.

**Quality flags:** `STATIC_AUDIT_PASSED`; `EDITOR_PLAY_MODE_NOT_TESTED`; `QUEST_NOT_TESTED`.

## Superseding Haptics status - 2026-11-04

The earlier `NEEDS_PACKAGE_OR_IMPORT` row describes the pre-install audit only. The instructor installed Meta XR Haptics SDK 207.0.1; the package sample `switch_on.haptic` is imported and configured on `L4_ThrowStone`. Instructor-reported Quest checks covered both controller sides, amplitude/frequency adjustments, BasicOvrInput comparison and throw regression. The instructor considers the controller-haptics exercise complete. Hand interactions were tested separately; no separate hand-only haptic or event-count test is required. Current configuration and results are in `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md` and `QUEST_TEST_CHECKLIST_FINAL.md`.
