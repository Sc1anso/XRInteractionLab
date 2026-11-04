# Screenshot Manifest

**Audit captures:** none. No fake Unity screenshots were generated. Unity MCP provided scene/component evidence but not a reliable complete Inspector screenshot. Computer Use reported Unity’s window minimized; it was not activated or manipulated. All interface captures below are `SCREENSHOT_NOT_AVAILABLE` and must be captured manually. The pre-existing untracked `Assets/Screenshots/screenshot-20261102-113456.png` and `.meta` were not inspected or used.

| Suggested filename | Exact view to capture | Purpose |
|---|---|---|
| `L4_01_OVR_Rig_HandSources.png` | SampleScene Hierarchy expanded `OVRCameraRig > OVRComprehensiveInteractionRig > OVRHands > OVRHandDataSourceLeft/Right`; select each source; Inspector shows `FromOVRHandDataSource`, `LastKnownGoodHand`, `OVRHand`. | Hand source chain, not runtime tracking status. |
| `L4_02_DistanceHandInteractors.png` | Expand both `ComprehensiveInteractorsLeft/Right > Interactors > Hand and No Controller > DistanceHandGrabInteractor`; show Hand/HMD/origin/pinch/palm/HandGrabApi refs. | Confirms bare-hand interactor. |
| `L4_03_ControllerDistanceInteractor.png` | Select `.../Controller and No Hand/ControllerDistanceGrabInteractor`; show component and ControllerRef. | Distinguishes controller route. |
| `L4_04_PoseExamples_ThumbsUp.png` | Open imported `PoseExamples.unity`, select Thumbs Up recognizer; show active-state fields, referenced hand, activation/deactivation events. | Needed to write exact detection/event steps. |
| `L4_05_HandGrabPoseRecorder_v207.png` | Show `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`, fields `Hand`, `Item`, `Ghost Provider`, `Poses Collection`, record key. Do not enter Play for this audit. | Exact local recorder labels. |
| `L4_06_TransformerExamples.png` | Open imported `TransformerExamples.unity`; select two-hand sample; show Grabbable, Max Grab Points, One/Two Grab Transformer, constraints and transfer-on-second-selection. | Exact version-specific transform setup. |
| `L4_07_Microgesture_Wiring.png` | SampleScene Hierarchy expanded left/right microgesture groups; Inspector on OVRMicrogestureEventSource and event wrappers. | Existing teleport/turn wiring. |
| `L4_08_DistanceGrabWizard.png` | Only in future disposable scene: select test Capsule, open `GameObject > Interaction SDK > Add Distance Grab Interaction`; show Hands/Pull settings and references before Create. | Reproducible wizard configuration. Do not run on teaching scene. |
| `L4_09_PilotCapsule_Inspector.png` | Only after authorized pilot: Capsule Inspector with Rigidbody, collider, Grabbable, DistanceHandGrabInteractable and references. | Resulting static configuration. |
| `L4_10_Quest_DistanceHandGrab.png` | Genuine Quest capture of bare-hand pinch/pull/release, labeled with capture method, headset and app build. | Runtime evidence. |
| `L4_11_TwoHand_Runtime.png` | Genuine headset evidence of two-hand manipulation on disposable object. | Runtime evidence. |
| `L4_12_Regression_Runtime.png` | Genuine separate results for near grab, ControlCanvas Poke/Ray, teleport, stick locomotion and PowerCell snap. | Only after tests actually run. |

For Inspector screenshots, include selected GameObject and field labels. Scene view is optional unless layout is being taught. Do not crop away relevant labels. No runtime evidence should be inferred from static screenshots.
