# Slide instructions reconciled (English)

These procedures describe how students can reproduce the current static configuration from the end-of-Lesson-3 project state. They do not prove which historical clicks were made. All screenshot references are currently missing. Local v207 menu labels below were checked against installed SDK source.

## Cross-lesson setup correction — smooth controller locomotion

If the slides recap or ask students to configure smooth locomotion, include this step:

1. Keep `Environment/Floor` on layer `Teleportable`.
2. Select `OVRCameraRig > OVRComprehensiveInteractionRig > Locomotor > PlayerController`.
3. In its Meta `CharacterController`, include `Teleportable` (layer 6) in **Layer Mask**, preserving the existing layers. The verified project value is **87**. Value 23 omitted the floor layer, preventing the locomotor from grounding on the floor and applying slide movement.
4. Leave controller movement set to **Slide** while testing the left thumbstick; do not remove Teleport to resolve this layer-mask issue.

The instructor confirmed Quest locomotion works after this correction on 2026-11-04. Temporary diagnostic code/logs are not lesson content.

## 1. Distance Hand Grab
1. Select Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule.
2. The local action is GameObject > Interaction SDK > Add Distance Grab Interaction. Its v207 wizard exposes Add Required Interactor(s), Distance Grab Type, Supported Grab Types, Auto Generate Collider, Rigidbody and Grabbable options. Hands and Pull Interactable To Hand are described in earlier notes as the selected options, but that history is not photographically verified. Do not rerun the action on the configured capsule.
3. Current target: position (2.3,1.05,2.8); CapsuleCollider radius 0.5, height 2, Y direction; Rigidbody mass 1, Use Gravity off, Is Kinematic on; Grabbable target/Rigidbody point to the target itself.
4. Child ISDK_DistanceHandGrabInteraction: DistanceHandGrabInteractable SupportedGrabTypes=3 (Pinch + Palm), RelativeTo=self, Rigidbody=self, PointableElement=self, MovementProvider=child MoveTowardsTargetProvider. Generic DistanceGrabInteractable is also present.
5. Reuse existing left/right bare-hand DistanceHandGrabInteractor under OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft|Right/Interactors/Hand and No Controller. Do not substitute ControllerDistanceGrabInteractor.
6. Evidence A02/A03/A05 missing; A04 wizard view would be reconstructed. Status: static configuration inspected, wizard history partial, QUEST_NOT_TESTED.

## 2. Hand Tracking Foundations
1. Expand OVRCameraRig/OVRComprehensiveInteractionRig/OVRHands. Inspect Hand, HandSkeletonOVR and OVRHandDataSourceLeft/Right.
2. Verify FromOVRHandDataSource references the matching OVRHand and the shared tracking-to-world/skeleton providers. Inspect OVRHandVisualLeft/Right HandVisual branches.
3. Select Lesson4_AdvancedInteractions/L4_HandTrackingStatus. The component references the existing left/right Hand components, raw OVRHand components and matching indicator MeshRenderers.
4. Sphere colors use raw OVRHand data: dark when invalid/untracked (0.22,0.25,0.30,1), orange when tracked with low confidence (1,0.58,0.08,1), green when tracked with high confidence (0.16,0.82,0.36,1). Keep LastKnownGoodHand enabled for the interaction pipeline; it preserves hand poses but is not the status signal. The indicator does not report pinch or controller modality.
5. Evidence B01-B04 missing. The instructor confirmed raw tracking loss behind the back; the corrected color behavior still requires a new Quest build and visual confirmation.

## 3. Custom Hand Grab Pose
1. Select Lesson4_AdvancedInteractions/L4_GrabPose_Exercise/L4_GrabPoseTool, an instance of installed Meta Torch sample prefab.
2. Inspect root Rigidbody/Grabbable and child normal/mirrored HandGrabInteractables. Six preauthored HandGrabPose points exist in the sample.
3. Open Window > Meta > Interaction SDK > Hand Grab Pose Recorder. Local v207 controls include Hand, Item (Rigidbody), optional Ghost Provider, Poses Collection (HandGrabInteractableDataCollection).
4. New recording requires a tracked hand in Play Mode. Record/save/reload/mirror in a separate tracked-hand session. No course-authored collection found.
5. Evidence C01-C03 missing. POSE_RECORDING_PENDING_QUEST_OR_LINK; QUEST_NOT_TESTED.

## 4. Thumbs-Up Pose Detection
1. Inspect the local sample Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab and scene instances L4_ThumbsUpRecognizer_Left/Right.
2. Verify HandRef and feature providers match the same side. ShapeRecognizerActiveState references FingersAllClosed.asset and ThumbUp.asset; TransformRecognizerActiveState supplies orientation recognition.
3. SelectorUnityEventWrapper WhenSelected calls matching L4_ThumbsUpFeedback.OnPoseRecognized(); WhenUnselected calls .OnPoseLost(). Feedback renderer changes from gray (0.28,0.31,0.36,1) to green (0.12,0.88,0.38,1).
4. This is static pose recognition, not a swipe/temporal gesture sequence.
5. Evidence D01-D05 missing; runtime recognition QUEST_NOT_TESTED.

## 5. Two-Handed Manipulation
1. Select Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject, an instance of the installed StonePolyhedron sample.
2. Rigidbody: mass 0.2, gravity on, kinematic off. Grabbable: Max Grab Points=2; Transfer On Second Selection=false; Add New Points To Front=false; Rigidbody=self.
3. One Grab Transformer and Two Grab Transformer both reference this object's GrabFreeTransformer.
4. GrabFreeTransformer position/rotation axes are unconstrained. Scale is relative; X/Y/Z constrained, Min=1, Max=3.
5. Child GrabInteractable serves controller route; HandGrabInteractable serves hand route, SupportedGrabTypes=1 (Pinch). Keep it separate from ControlCanvas.
6. Evidence E01-E04 missing. Confirm two-hand translation, rotation and scale on Quest; static configuration is not runtime proof.

No Lesson4_Work screenshots were accepted. Do not use planned filenames as if images exist. Every interaction claim remains static-only until runtime testing.
