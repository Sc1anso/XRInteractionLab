# Screenshot manifest

Manifest status at 2026-11-03: no current Lesson4_Work screenshot was found. Every required image below is SCREENSHOT_MISSING, not accepted. Intended filenames are not claims that files exist.

| Step ID | Module | Intended filename | Selected path / component | Evidence and values to show | English caption | Evidence type | QA |
|---|---|---|---|---|---|---|---|
| A01 | Distance Hand Grab | A01_DistanceGrab_Hierarchy.png | Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule | Target hierarchy and scene placement | Distance-grab capsule in the existing teaching scene. | SCREENSHOT_MISSING | MISSING |
| A02 | Distance Hand Grab | A02_DistanceGrab_Capsule_Inspector.png | L4_DistanceGrabCapsule / CapsuleCollider, Rigidbody, Grabbable | Position (2.3,1.05,2.8); radius .5, height 2; mass 1; gravity off; kinematic on; target/Rigidbody self | Inspect the capsule collider, Rigidbody and Grabbable setup. | SCREENSHOT_MISSING | MISSING |
| A03 | Distance Hand Grab | A03_DistanceGrab_Interactable_Inspector.png | .../ISDK_DistanceHandGrabInteraction / DistanceHandGrabInteractable | SupportedGrabTypes=3 (Pinch+Palm); RelativeTo root; provider child; Pointable/Rigidbody root | Connect the hand distance interactable to its target and pull provider. | SCREENSHOT_MISSING | MISSING |
| A04 | Distance Hand Grab | A04_DistanceGrab_Wizard.png | Selected capsule / Add Distance Grab Interaction | Local v207 options; Hands and Pull Interactable To Hand are historical claims only | Choose hand input and pull-to-hand behavior in the installed wizard. | RECONSTRUCTED_WIZARD_VIEW | MISSING |
| A05 | Distance Hand Grab | A05_Existing_Hand_Interactors.png | OVRComprehensiveInteractionRig left/right Hand and No Controller branches | Existing bare-hand DistanceHandGrabInteractor components | Reuse the tracked-hand distance interactors already in the rig. | SCREENSHOT_MISSING | MISSING |
| B01 | Hand Tracking | B01_OVRHands_DataSources.png | OVRCameraRig/OVRComprehensiveInteractionRig/OVRHands | Hand, HandSkeletonOVR, left/right OVRHandDataSource and matching refs | Trace hand data from OVRHands to each tracked hand. | SCREENSHOT_MISSING | MISSING |
| B02 | Hand Tracking | B02_HandVisuals.png | OVRHandVisualLeft/Right / HandVisual | Existing visual components and references | Separate left and right visuals use the existing hand tracking data. | SCREENSHOT_MISSING | MISSING |
| B03 | Hand Tracking | B03_Status_Indicator_Inspector.png | Lesson4_AdvancedInteractions/L4_HandTrackingStatus | Existing left/right Hand refs; raw OVRHand refs; matching renderer refs; dark invalid/untracked, orange tracked/low-confidence, green tracked/high-confidence | Connect each status indicator to its raw tracked hand. | SCREENSHOT_MISSING | MISSING |
| B04 | Hand Tracking | B04_Status_Indicators_Scene.png | L4_LeftTrackingIndicator and L4_RightTrackingIndicator | Existing indicator pair and placement | Two isolated indicators visualize hand tracking status. | SCREENSHOT_MISSING | MISSING |
| C01 | Grab Pose | C01_GrabPose_Target.png | L4_GrabPoseTool / Rigidbody, Grabbable, HandGrabInteractable | Torch sample origin; root body and child grab interactables | Prepare a sample tool as a hand-grab pose target. | SCREENSHOT_MISSING | MISSING |
| C02 | Grab Pose | C02_Pose_Recorder.png | Hand Grab Pose Recorder window | Hand, Item, Ghost Provider, Poses Collection; do not record | Prepare the pose recorder for a later tracked-hand session. | SCREENSHOT_MISSING | MISSING |
| C03 | Grab Pose | C03_Torch_Sample_Poses.png | L4_GrabPoseTool normal/mirrored children / HandGrabPose | Six preauthored sample points, not course-recorded | Inspect the sample's existing grasp poses. | SCREENSHOT_MISSING | MISSING |
| D01 | Thumbs-Up | D01_ThumbsUp_Prefab.png | local ThumbsUpPose prefab source | Genuine local recognizer chain | Inspect the installed thumbs-up pose recognizer prefab. | SCREENSHOT_MISSING | MISSING |
| D02 | Thumbs-Up | D02_ThumbsUp_Left_References.png | L4_ThumbsUpRecognizer_Left | Left HandRef, matching feature providers and shape assets | Assign the left recognizer to left-hand pose features. | SCREENSHOT_MISSING | MISSING |
| D03 | Thumbs-Up | D03_ThumbsUp_Right_References.png | L4_ThumbsUpRecognizer_Right | Right HandRef, matching feature providers and shape assets | Assign the right recognizer to right-hand pose features. | SCREENSHOT_MISSING | MISSING |
| D04 | Thumbs-Up | D04_ThumbsUp_Events.png | SelectorUnityEventWrapper left/right | WhenSelected/WhenUnselected -> side-matched feedback methods | Connect pose recognition and pose loss to visible feedback. | SCREENSHOT_MISSING | MISSING |
| D05 | Thumbs-Up | D05_ThumbsUp_Feedback.png | L4_ThumbsUpIndicator_Left/Right / L4_ThumbsUpFeedback | Renderer refs; gray/green colors | Show feedback for recognized and released poses. | SCREENSHOT_MISSING | MISSING |
| E01 | Two-Hand | E01_TwoHand_Target.png | L4_TwoHandedObject | StonePolyhedron target separate from ControlCanvas | Keep the manipulation target separate from the movable UI. | SCREENSHOT_MISSING | MISSING |
| E02 | Two-Hand | E02_TwoHand_Grabbable.png | L4_TwoHandedObject / Grabbable | Max Grab Points=2; transfer false; transformer refs | Allow two selections and assign the transformers. | SCREENSHOT_MISSING | MISSING |
| E03 | Two-Hand | E03_TwoHand_Transformers.png | local GrabFreeTransformer | Position/rotation unconstrained; relative scale axes constrained 1..3 | Inspect two-hand transform and scale limits. | SCREENSHOT_MISSING | MISSING |
| E04 | Two-Hand | E04_TwoHand_Interactables.png | L4_TwoHandedObject children | Controller GrabInteractable vs hand HandGrabInteractable, Pinch=1 | Verify controller and tracked-hand interactables. | SCREENSHOT_MISSING | MISSING |
| Q01 | General QA | Q01_Console.png | Unity Console | Current messages and filters; no clearing | Review Editor diagnostics without treating them as runtime results. | SCREENSHOT_MISSING | MISSING |

## Existing images reviewed
- Lesson4_Work/Screenshots: zero files recursively; no file available for image QA or hash.
- Assets/Screenshots/screenshot-20261102-113456.png: older Game View, 1968x760, SHA256 0F8A4D8AEFDC77FD7EE92E0AD9125B0C5523E8B30C8AA3F441663AC2106B7E1B. Excluded; it does not show a Lesson 4 setup step.
- Previous manifests refer to PNGs absent from the checked folder; those references are stale.
