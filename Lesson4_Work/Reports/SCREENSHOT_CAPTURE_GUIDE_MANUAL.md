# Lesson 4 — manual Unity screenshot capture guide

**Codex did not acquire screenshots.** This guide is for the instructor to capture genuine Unity Editor views after opening the project. Every listed image has status `MISSING_MANUAL_CAPTURE`; the filename is an intended filename, not an existing file.

## Capture procedure

1. Open `XRInteractionLab` in Unity `6000.3.9f1` and open `Assets/Scenes/SampleScene.unity`. Do not save unexpected changes just to match this guide.
2. Manually maximize the Unity Editor on the chosen monitor. Keep the Hierarchy, Scene view and Inspector visible. Do not use Maximize on Play.
3. Use the Hierarchy path listed for the requested ID. Click the named object/component, expand relevant Inspector components, widen the Inspector internally and scroll as needed. For long components, make the indicated A/B screenshots rather than hiding field labels.
4. Capture only the Unity window on one monitor with Windows Snipping Tool or the instructor's configured capture tool. Include the visible object name and full relevant property labels. Do not include desktop, taskbar, another monitor or other application. Do not crop away component/field names.
5. Save the original PNG under `C:\Users\Scianso\Pictures\Screenshots` if using the configured Windows default; copy it, without deleting or overwriting, into `C:\Users\Scianso\Documents\GitHub\XRInteractionLab\Lesson4_Work\Screenshots`. Keep the original full image; optional crops belong in `Screenshots\Crops`.
6. Open each saved PNG and verify it is legible and matches the caption. Record its actual filename, path, dimensions and SHA-256 in `SCREENSHOT_MANIFEST_COMPLETE.csv/.md`; only then change its status from `MISSING_MANUAL_CAPTURE`.
7. Do not use Inspector screenshots as proof of runtime behavior. Quest evidence must be separately captured during the later acceptance session and labeled `QUEST_RUNTIME`.

## Shared view requirements

- **Hierarchy shots:** expand only the relevant branch enough to show the complete target and its parent. Select the target so its Inspector is visible where useful.
- **Inspector shots:** ensure the selected GameObject name, component type, field labels and values/references are legible. Use sequential suffixes `_A`, `_B` for long components.
- **Sample provenance shots:** show the actual local sample object/prefab or scene hierarchy. Label it as sample provenance, not a course-authored asset.
- **Wizard/Recorder shots:** never click Create/Apply/Fix All on an already configured target. If a historical wizard state cannot be safely reproduced, capture the resulting setup and mark the original step unavailable/reconstructed. The Pose Recorder view must not start Play Mode or record a pose for this static evidence pass.
- **Console shot Q01:** show the Unity Console and its filters/status without clearing the Console. It is an Editor diagnostic, not a runtime test.

## Evidence map

All statuses below start at `MISSING_MANUAL_CAPTURE`. The English captions are slide-ready. Inspector values reflect the current static scene report; verify the displayed value in Unity before treating the image as valid.

### A — Distance Hand Grab

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| A01 `A01_DistanceGrab_Hierarchy.png` | Hierarchy: `Lesson4_AdvancedInteractions > DistanceHandGrab_Exercise > L4_DistanceGrabCapsule`; select capsule, frame in Scene view | Exercise parent, target and scene placement | “Distance-grab capsule in the existing teaching scene.” Current Editor state only. |
| A02 `A02_DistanceGrab_Capsule_Inspector.png` | Select `.../L4_DistanceGrabCapsule`; Inspector Transform, CapsuleCollider, Rigidbody, Grabbable | Position `(2.3,1.05,2.8)`; collider radius `.5`, height `2`; mass `1`; gravity off; kinematic on; Grabbable target/Rigidbody self | “Inspect the target collider, body and Grabbable.” |
| A03 `A03_DistanceGrab_Interactable_Inspector.png` | Expand capsule child `ISDK_DistanceHandGrabInteraction`; select `DistanceHandGrabInteractable` | Supported Grab Types `3` (Pinch+Palm); root relative/pointable/Rigidbody refs; child `MoveTowardsTargetProvider`; generic `DistanceGrabInteractable` also visible | “Connect the distance interactable to the target and pull provider.” |
| A04 `A04_DistanceGrab_Wizard.png` | Do not rerun Quick Action on configured target. If a safe, disposable unconfigured object is available in an isolated copy, open `GameObject > Interaction SDK > Add Distance Grab Interaction` and do not click Create | Actual local v207 option labels; mark `RECONSTRUCTED_WIZARD_VIEW` if reopened | “Review the installed distance-grab setup options.” Historical Hands/Pull selections are not verified. Otherwise mark unavailable. |
| A05 `A05_Existing_Hand_Interactors.png` | Expand `OVRCameraRig > OVRComprehensiveInteractionRig > ComprehensiveInteractorsLeft/Right > Interactors > Hand and No Controller`; select each `DistanceHandGrabInteractor` in turn | Both existing bare-hand interactor branches and component names | “Reuse the tracked-hand distance interactors already in the rig.” Distinguish controller routes. |

### B — Hand Tracking foundations

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| B01 `B01_OVRHands_DataSources.png` | Expand `OVRCameraRig > OVRComprehensiveInteractionRig > OVRHands`; select left/right OVRHand data sources | `Hand`, `HandSkeletonOVR`, `OVRHandDataSourceLeft/Right`, matching serialized references | “Trace tracked hand data through the rig.” Static wiring only. |
| B02 `B02_HandVisuals.png` | Select `OVRHandVisualLeft`, then `OVRHandVisualRight`; expand `HandVisual` components | Each visual's hand/skeleton/provider references and left/right names | “Left and right visuals use the existing hand data.” |
| B03 `B03_Status_Indicator_Inspector.png` | Select `Lesson4_AdvancedInteractions/L4_HandTrackingStatus` | `L4_HandTrackingStatusIndicator`; existing left/right `Hand` refs, raw `OVRHand` refs, matching renderer refs and colors | “Connect each status indicator to its raw tracked hand.” Colors: invalid/untracked `.22,.25,.30,1`; tracked/low-confidence `1,.58,.08,1`; tracked/high-confidence `.16,.82,.36,1`. |
| B04 `B04_Status_Indicators_Scene.png` | Expand `L4_HandTrackingStatus`; select left then right indicator; frame both in Scene view | Both sphere objects and their parent grouping | “Two isolated indicators visualize hand tracking state.” No live status proof. |

### C — Custom Hand Grab Pose

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| C01 `C01_GrabPose_Target.png` | Select `Lesson4_AdvancedInteractions/L4_GrabPose_Exercise/L4_GrabPoseTool` | Hierarchy, Torch sample origin, Rigidbody/Grabbable and hand-grab branches | “Prepare a sample tool as a hand-grab pose target.” |
| C02 `C02_Pose_Recorder.png` | Unity menu `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`; open the window only, do not enter Play Mode/record | Local v207 fields Hand, Item, Ghost Provider, Poses Collection | “Prepare the pose recorder for a later tracked-hand session.” If it cannot open safely, mark missing/unavailable. |
| C03 `C03_Torch_Sample_Poses.png` | Expand `L4_GrabPoseTool` normal/mirrored pose children; select a `HandGrabPose` | Existing six preauthored sample pose points and their references | “Inspect the sample's existing grasp poses.” Explicitly not course-recorded. |

### D — Thumbs-Up Pose Detection

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| D01 `D01_ThumbsUp_Prefab.png` | Project window: `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab`; select/open prefab for inspection only | Real local prefab hierarchy and recognizer component names | “Inspect the installed thumbs-up pose recognizer.” Sample provenance. |
| D02 `D02_ThumbsUp_Left_References.png` | Hierarchy select `L4_ThumbsUp_Exercise/L4_ThumbsUpRecognizer_Left` | Left `HandRef`, matching left feature providers, shape assets and transform recognizer | “Bind the left pose recognizer to left-hand features.” |
| D03 `D03_ThumbsUp_Right_References.png` | Select `L4_ThumbsUp_Exercise/L4_ThumbsUpRecognizer_Right` | Right `HandRef` and right-side providers/assets | “Bind the right pose recognizer to right-hand features.” |
| D04 `D04_ThumbsUp_Events.png` | Select left and right `SelectorUnityEventWrapper` in separate shots if needed | `WhenSelected` -> same-side `OnPoseRecognized`; `WhenUnselected` -> same-side `OnPoseLost` | “Connect pose recognition and pose loss to feedback.” |
| D05 `D05_ThumbsUp_Feedback.png` | Select `L4_ThumbsUpIndicator_Left/Right`, then parent `L4_ThumbsUpFeedback` | Renderer refs; gray `(0.28,.31,.36,1)` and green `(.12,.88,.38,1)` | “Show feedback for recognized and released poses.” Static wiring; no live pose claim. |

### E — Two-Handed Manipulation

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| E01 `E01_TwoHand_Target.png` | Select `Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject`; frame in Scene view | Target and distinct exercise parent; `ControlCanvas` not selected | “Keep the two-hand target separate from movable UI.” |
| E02 `E02_TwoHand_Grabbable.png` | Select target root and expand `Grabbable` | Max Grab Points `2`; Transfer On Second Selection `false`; Add New Points To Front; One/Two transformer refs | “Allow two selections and assign the transformers.” |
| E03 `E03_TwoHand_Transformers.png` | Select the referenced local `GrabFreeTransformer` | Relative scale constraints for X/Y/Z, min `1`, max `3`; position/rotation constraint fields | “Inspect two-hand transform and scale limits.” |
| E04 `E04_TwoHand_Interactables.png` | Expand target children; select `GrabInteractable`, then `HandGrabInteractable` | Controller route vs tracked-hand route; hand Supported Grab Types `1` (Pinch) | “Verify controller and tracked-hand grab interactables.” |

### Q — General Editor diagnostic

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| Q01 `Q01_Console.png` | Select Console tab in Unity; retain existing messages and filters | Error/warning counts and relevant Console entries | “Review Editor diagnostics without treating them as runtime results.” Do not clear Console. |

### F — Additional Lesson 4 modules

| ID / intended filename | Exact navigation and selected object | Must be visible | Caption / caveat |
|---|---|---|---|
| F01 `F01_HandGrabUse_Hierarchy.png` | Expand `Lesson4_AdvancedInteractions/L4_HandGrabUse_Exercise/L4_HandGrabUse_SprayBottle`; select bottle | Complete exercise branch and recognizable copied sample object | “The use exercise extends a local Meta spray-bottle example.” |
| F02 `F02_HandGrabUse_Interactables.png` | Select `UseInteractable`, then `UseInteractable_mirror`; Inspector | HandGrabUseInteractable delegate `WaterSpray`, Strength Deadzone `.2`, 3 relaxed/3 tight poses; paired SecondaryInteractorFilter refs and Select Required `true` | “Separate holding an object from activating its held function.” |
| F03 `F03_HandGrabUse_Response.png` | Select root `WaterSpray`; Inspector/events | release `.3`, fire `.7`, spread `40°/20°`, strength `5`, hits `6`, max distance `2`; particle/audio persistent callbacks | “Use events drive visible spray and audio responses.” |
| F04 `F04_HandGrabUse_Interactors.png` | Expand existing left/right rig `Interactors/Hand and No Controller/HandGrabUseInteractor` | Both existing hand-use interactor paths; no added interactor | “Reuse the existing hand-use interactors.” |
| F05 `F05_GrabSurface_Hierarchy.png` | Expand `L4_GrabSurface_Exercise/L4_GrabSurface_Torch`; frame target | Exercise target and sample provenance from `HandGrabExamples/Interactables/SimpleGrab2PalmGrab` | “A sample object demonstrates authored hand-grab surfaces.” |
| F06 `F06_GrabSurface_Interactable.png` | Select target `HandGrabInteractable` | Supported Grab Types `2` (Palm); Rigidbody and Pointable Element refer to new root | “Select the target through the palm hand-grab route.” |
| F07 `F07_GrabSurface_PoseReference.png` | Expand one `HandGrab Point`; select `HandGrabPose` | Relative To points to target root; Snap Surface points to sibling `CylinderGrabSurface` | “Attach an authored surface to a hand pose.” |
| F08 `F08_GrabSurface_CylinderSurface.png` | Select the `CylinderGrabSurface` on same pose child; repeat mirrored side if needed | Surface type and Relative To target root; hierarchy context | “Define the cylinder region used by the sample pose.” |
| F09 `F09_Throw_Hierarchy.png` | Expand `L4_Throw_Exercise/L4_ThrowStone`; frame it | Independent target and package prefab origin | “A dedicated sample-derived target demonstrates throwing.” |
| F10 `F10_Throw_Grabbable.png` | Select `L4_ThrowStone`; expand Grabbable | Max points `1`; transfer false; One transformer local; Two transformer None; target self; Rigidbody self; Kinematic While Selected true; Throw When Unselected true; Force Kinematic Disabled false | “Configure release behavior on a one-hand target.” |
| F11 `F11_Throw_Rigidbody_Recovery.png` | Select target; expand Rigidbody and `RespawnOnDrop` | mass `.2`, gravity true, kinematic false, damping `.1/.05`, Continuous; respawn Y threshold `.3` | “Pair release physics with a recovery threshold.” |
| F12 `F12_Throw_Input_Routes.png` | Expand target children and select controller `GrabInteractable`, then `HandGrabInteractable` | Distinct controller/hand paths; hand grab type `1` (Pinch) | “Keep controller and tracked-hand throw routes distinct.” |
| F13 F13_Controller_Vibration.png | Select L4_ThrowStone; expand L4_ControllerGrabHaptics | Controller Grab Interactable ref; Feedback Mode=MetaHapticsSdk (default) or BasicOvrInput; OVR frequency .5, amplitude .2, pulse .12 s; HapticSource ref | Choose one controller feedback path for each grab. |
| F14 `F14_Microgesture_Existing_Hierarchy.png` | Expand left/right `Hand and No Controller/MicroGesturesLocomotionHandInteractorGroup` | Existing OVRMicrogestureEventSource and wrapper groups | “Inspect the microgestures already used for locomotion.” |
| F15 `F15_Microgesture_Event_Wiring.png` | Select `TurnerMicrogesture`, `StepMicrogesture`, `TeleportMicrogestureInteractor/Selector`, `LocomotionActionsMicrogesture`; separate images as needed | Tap center gate/teleport; left/right snap turn; up/down step and jump/crouch callbacks | “Existing microgesture callbacks are preserved.” |
| F16 F16_Haptics_Package_Status.png | Window > Package Manager; select Meta XR Haptics SDK | Installed package version 207.0.1; do not update | Meta XR Haptics SDK is installed in this project. |
| F17 `F17_GestureSequence_Sample.png` | Project/sample scene inspection: local `GestureExamples` `SequenceActiveState`/`Sequence` and swipe prefab | Actual sample sequence and ordered steps, clearly marked sample-only | “Temporal gesture sequences are available as a separate sample.” Not configured in SampleScene. |

| F18 F18_HapticSource_Clip_Settings.png | Select L4_ThrowStone; expand HapticSource | Clip=switch_on; amplitude .6; frequency shift 0; Loop=false; Priority=128; component Controller default Both | Assign a short authored haptic clip and tune its playback. Static Inspector only; runtime uses side-specific Play. |
| F19 F19_Haptic_Event_Routing.png | Select L4_ThrowStone; show L4_ControllerGrabHaptics and child GrabInteractable | Feedback Mode=MetaHapticsSdk; HapticSource ref; controller GrabInteractable ref | Connect controller grab selection to the haptics mode and source. Static setup only; instructor-reported left/right Quest results are recorded separately; this screenshot cannot prove runtime behavior. |
| F20 F20_Haptic_Clip_Asset.png | Project window: select Assets/Samples/Meta XR Haptics SDK/207.0.1/HapticPacks/Haptics/Objects/switch_on.haptic | Imported asset type HapticClip and sample-pack path | Use an imported Meta Haptics sample clip. Asset evidence only; not playback proof. |

## Status convention

Until manually supplied and inspected, all 42 IDs (A01-A05, B01-B04, C01-C03, D01-D05, E01-E04, Q01, F01-F20) are MISSING_MANUAL_CAPTURE. A Unity screenshot shows serialized Editor configuration only. Runtime verification remains separate.
