# Lesson 4 final configuration matrix

All paths below are in the saved Assets/Scenes/SampleScene.unity unless marked package/sample source. Status distinguishes static Editor configuration from user-reported Quest observations; Codex did not run Play Mode or build/deploy.

## Lesson 4 scene content

| Module | Current scene path | Origin | Key serialized setup | Static status | Runtime |
|---|---|---|---|---|---|
| Distance Hand Grab | Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule | Existing project primitive + v207 Quick Action result | CapsuleCollider, Rigidbody, Grabbable; child has DistanceHandGrabInteractable AND generic DistanceGrabInteractable, MoveTowardsTargetProvider and reticles. Hand path is present; not hands-only. | STATIC_CONFIGURED; wizard history partial | QUEST_NOT_TESTED |
| Hand tracking status | Lesson4_AdvancedInteractions/L4_HandTrackingStatus | Existing L4 script and two sphere indicators | Existing left/right Hand refs retained; matching raw OVRHand refs drive dark/untracked, orange/low-confidence, green/high-confidence colors; matching MeshRenderers. | STATIC_VERIFIED; raw tracking loss reported by instructor | Updated sphere colors need new-build visual confirmation |
| Custom grab pose | Lesson4_AdvancedInteractions/L4_GrabPose_Exercise/L4_GrabPoseTool | Meta Torch sample prefab | Root Rigidbody/Grabbable; normal and mirrored HandGrabInteractables; six sample HandGrabPose points. No course collection. | PARTIAL; real recording pending | QUEST_NOT_TESTED; POSE_RECORDING_PENDING_QUEST_OR_LINK |
| Thumbs-up detection | Lesson4_AdvancedInteractions/L4_ThumbsUp_Exercise/L4_ThumbsUpRecognizer_Left and _Right | v207 ThumbsUpPose sample instances + existing feedback script | Same-side HandRef/feature providers; shape/orientation active states; selected/unselected UnityEvents call side-matched indicator methods. | STATIC_VERIFIED | QUEST_NOT_TESTED |
| Two-handed manipulation | Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject | Meta StonePolyhedron sample | Grabbable Max Grab Points=2; both transformer fields point to local GrabFreeTransformer; relative scale X/Y/Z constrained 1..3; Rigidbody gravity enabled; RespawnOnDrop threshold Y=-1.0. | STATIC_CONFIGURED | Instructor reports scale/rotation/translation and post-threshold release behavior work |
| Hand Grab Use | Lesson4_AdvancedInteractions/L4_HandGrabUse_Exercise/L4_HandGrabUse_SprayBottle | Scene-object copy from imported v207 HandGrabUseExamples | Root WaterSpray delegate; paired normal/mirror HandGrabInteractable and HandGrabUseInteractable; SecondaryInteractorFilter primary/secondary refs and Select Required; spray particles/audio events. | STATIC_CONFIGURED; sample behavior wired | Instructor confirms spray and audio work on Quest |
| Grab Surface | Lesson4_AdvancedInteractions/L4_GrabSurface_Exercise/L4_GrabSurface_Torch | Scene-object copy from imported v207 HandGrabExamples | Normal/mirror HandGrabInteractable; each authored HandGrabPose has CylinderGrabSurface; each surface and pose use the new target root as relative transform. | STATIC_CONFIGURED; instructor reports same visible behavior as Torch pose sample | QUEST_TESTED_BY_INSTRUCTOR; no perceptible distinction observed |
| Throw | Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone | Package StonePolyhedron prefab instance | Grabbable Max Grab Points=1; Throw When Unselected; Rigidbody mass .2/gravity/dynamic; RespawnOnDrop threshold -1.0; controller and hand interactables retained. | STATIC_CONFIGURED | Instructor reports Throw works; input route detail not specified |
| Existing microgestures | OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft|Right/Interactors/Hand and No Controller/MicroGesturesLocomotionHandInteractorGroup | Existing OVRMicrogestureEventSource and wrapper callbacks for gate, teleport, snap turn, step, jump/crouch. Unmodified. | STATIC_INVENTORIED; no new Lesson 4 scroll | QUEST_NOT_TESTED |
| Temporal swipe sequence | Imported GestureExamples scene only | Meta v207 example | HandSwipeGestureLeft/Right SequenceActiveState and Sequence with ordered forward-pose + hand-swipe steps. Not added to SampleScene because its provider chain needs additional rig wiring. | AVAILABLE_SAMPLE_ONLY | NOT_TESTED |
| Controller haptics | Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone | Existing OVRInput example plus Meta XR Haptics SDK 207.0.1 sample clip | `L4_ControllerGrabHaptics` listens to the child controller `GrabInteractable`; mode defaults to Meta Haptics SDK and routes through the selecting interactor's `ControllerRef.Handedness`. `HapticSource` uses `switch_on.haptic`, amplitude .6, frequency shift 0, loop false, priority 128. Basic OVRInput mode remains selectable at .5 frequency, .2 amplitude, .12 s. | STATIC_CONFIGURED; compilation passed; scene saved | QUEST_TESTED_BY_INSTRUCTOR: left/right sound + light vibration, amplitude/frequency comparisons, basic-mode comparison, no release feedback, throw regression. Haptics exercise complete. Hand interaction is a separate tested route and does not produce controller vibration. |
| Beyond-the-lab overview | No new scene objects | Documentation only | Local TouchGrabExamples, GazeExamples and GestureExamples are available; gaze mode and custom hand models are not newly configured. | DOCUMENTED_ONLY | NOT_TESTED |

## Exact component/reference summary

### Distance Hand Grab

- Capsule root: Transform, MeshFilter, CapsuleCollider (center 0, radius .5, height 2, Y direction), MeshRenderer, Rigidbody (mass 1, gravity off, kinematic on), Grabbable (Max Grab Points -1, target/Rigidbody root, Kinematic While Selected and Throw When Unselected on).
- Child ISDK_DistanceHandGrabInteraction: DistanceHandGrabInteractable, generic DistanceGrabInteractable, MoveTowardsTargetProvider and reticle components.
- DistanceHandGrabInteractable flags value 3 = Pinch + Palm. Relative To, Rigidbody, Pointable Element and target references are capsule-root scoped. MovementProvider is assigned by v207 runtime initialization and is null in Edit Mode.
- Existing bare-hand DistanceHandGrabInteractor sources exist on both sides. Also present: controller-driven hand routes and controller-only DistanceGrabInteractor routes.

### Hand tracking status

- Script: Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs.
- Hand refs point to the corresponding OVRHands Hand components and remain part of the ISDK interaction data path. Raw OVRHand refs point to existing OVRHand components on OVRHandDataSourceLeft/Right; these raw refs drive the indicator colors. Renderer refs point to the matching indicator children.
- Not tracked color (.22,.25,.30,1); low confidence (1,.58,.08,1); high confidence (.16,.82,.36,1).
- The script colors from raw OVRHand IsDataValid, IsTracked and IsDataHighConfidence. It does not read pinch strength or controller/hand mode. LastKnownGoodHand stays enabled for interactions and can preserve a filtered pose after raw tracking drops.

### Custom grab pose

- Local source: Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/Torch/Torch.prefab.
- Existing sample root Rigidbody mass 1, gravity off, kinematic on. Sample Grabbable Transfer On Second Selection on. It contains six package-authored pose points across normal/mirrored interactables.
- Hand Grab Pose Recorder local menu: Window > Meta > Interaction SDK > Hand Grab Pose Recorder. A new saved pose collection is absent; real recording needs a tracked hand.

### Thumbs-up

- Each recognizer has HandRef, SelectorUnityEventWrapper, ActiveStateSelector, ActiveStateGroup, ShapeRecognizerActiveState and TransformRecognizerActiveState.
- Shape inputs: FingersAllClosed.asset and ThumbUp.asset. Normal left/right event targets are side-matched.
- WhenSelected -> L4_ThumbsUpFeedback.OnPoseRecognized(); WhenUnselected -> OnPoseLost(). Indicator inactive gray (.28,.31,.36,1), recognized green (.12,.88,.38,1).

### Two-handed target

- Source: Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/StonePolyhedra/StonePolyhedron.prefab.
- Root local position (0,.45,0), scale (.6,.6,.6); Rigidbody mass .2, gravity on, kinematic off.
- Grabbable: Max Grab Points 2; Transfer On Second Selection false; Add New Points To Front false; local Rigidbody assigned; Kinematic While Selected and Throw When Unselected on; Force Kinematic Disabled false.
- One Grab Transformer and Two Grab Transformer both refer to the object's local GrabFreeTransformer. Position/rotation unconstrained; scale relative, axes X/Y/Z constrained, each range 1..3.
- RespawnOnDrop Y Threshold For Respawn = -1.0; changed from 0.3 after repeated premature resets. Quest retest pending.
- Controller GrabInteractable is separate from hand HandGrabInteractable; hand Supported Grab Types = 1 (Pinch). Do not place this scale configuration on ControlCanvas.

### Hand Grab Use target

- Source scene: Assets/Samples/Meta XR Interaction [zero-width space in directory]SDK/207.0.1/Example Scenes/HandGrabUseExamples.unity, root SprayBottle.
- New root components: Transform, Rigidbody (mass 1, gravity on, kinematic on), Grabbable, WaterSpray.
- Descendants include bottle meshes/colliders, normal/mirror HandGrabInteractables, normal/mirror HandGrabUseInteractables, SecondaryInteractorFilters, HandGrabPose points, nozzle Grabbable/HandGrabInteractable/MoveFromTargetProvider, particle systems and audio.
- Normal and mirror use filter: Primary Interactable points to its paired HandGrabInteractable; Secondary Interactable points to its paired HandGrabUseInteractable; Select Required true.
- Use component: delegate = root WaterSpray; strength deadzone .2; three relaxed + three tight pose points.
- WaterSpray events: WhenSpray -> Particle_Spray.Play and WaterSprayAudio.PlayAudio; WhenStream -> Particle_Stream.Play and WaterStreamAudio.PlayAudio. Thresholds: release .3, fire .7.
- No new HandGrabUseInteractor was added; both existing bare-hand routes remain the input source.

### Grab Surface target

- Source scene: imported HandGrabExamples.unity, root Interactables/SimpleGrab2PalmGrab.
- Root: Transform, Rigidbody (mass 1, gravity off, kinematic on), Grabbable, PointableUnityEventWrapper; visual and collision children; normal/mirror HandGrabInteractables.
- Hand interactable Supported Grab Types = 2 (Palm); Rigidbody and Pointable Element refer to the root.
- Each normal/mirror HandGrabPose point has a CylinderGrabSurface. HandGrabPose Relative To and CylinderGrabSurface Relative To point to the copied root. This uses the example's authoring; no component was guessed or generated by merely adding a collider.

### Throw target and controller vibration

- Source: Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/StonePolyhedra/StonePolyhedron.prefab.
- Root transform: local position (0,.65,0), local scale (.55,.55,.55) beneath L4_Throw_Exercise at (3.5,0,.5).
- Grabbable: Max Grab Points 1; Transfer On Second Selection false; One Grab Transformer = local GrabFreeTransformer; Two Grab Transformer none; Rigidbody = self; Target Transform none; Kinematic While Selected true; Throw When Unselected true; Force Kinematic Disabled false.
- Rigidbody: mass .2; gravity true; kinematic false; linear damping .1; angular damping .05; Collision Detection Continuous.
- RespawnOnDrop threshold -1.0. Controller GrabInteractable and hand HandGrabInteractable both remain; hand supports Pinch.
- Script `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs` listens to the controller `GrabInteractable.WhenSelectingInteractorViewAdded` event. The event's `IInteractorView.Data` is the concrete v207 `GrabInteractor`; each local controller grab interactor has a same-object `ControllerRef` delegating to the left/right controller data source. The script maps that handedness to `HapticSource.Play(Oculus.Haptics.Controller.Left|Right)` or the matching `OVRInput.Controller.LTouch|RTouch`.
- The feedback mode enum defaults to `MetaHapticsSdk`; its alternate `BasicOvrInput` branch is mutually exclusive. `HapticSource` is on the `L4_ThrowStone` root and references `Assets/Samples/Meta XR Haptics SDK/207.0.1/HapticPacks/Haptics/Objects/switch_on.haptic`. Serialized values: `_controller=Both` (SDK component default; the event handler calls the handed `Play(controller)` overload), `_loop=false`, `_amplitude=0.6`, `_frequencyShift=0`, `_priority=128` (SDK default).
- The separate tracked-hand `HandGrabInteractable` is not listened to. If the event payload is not a component with a `ControllerRef`, the script safely skips controller feedback rather than guessing.
- The sample clip was copied from the installed SDK's `Samples~/HapticPacks/Haptics/Objects/switch_on.haptic` into the project's versioned `Assets/Samples/Meta XR Haptics SDK/207.0.1/...` folder; the installed importer produced a `HapticClip` asset. No package was installed or upgraded in this implementation.

## Validation legend

- STATIC_VERIFIED: observed serialized object/component references and values through Unity Editor/MCP.
- COMPILATION_PASSED: the new script compiled and Unity Console Error query returned zero entries.
- EDITOR_PLAY_MODE_NOT_TESTED: deliberately not entered.
- QUEST_NOT_TESTED: applies to interaction outcomes without an instructor-reported Quest result in the tables above. User-reported observations are distinguished from Codex-run tests; Codex did not run Play Mode or hardware tests.








