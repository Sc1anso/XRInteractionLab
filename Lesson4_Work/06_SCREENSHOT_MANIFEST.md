# Screenshot manifest

The user requested screenshots that teach the **sequence of menu clicks and Inspector setup**, not only the finished Scene View. The current folder contains genuine screenshots, but most are result views. Menu/wizard/Inspector evidence is separately marked missing below and must not be implied by a result image.

| File | Module / step | Selected object / component shown | Fields or action actually visible | English slide caption | Evidence status |
|---|---|---|---|---|---|
| `Screenshots/01_DistanceGrab_ExistingTarget.png` | Distance Hand Grab / target result | `L4_DistanceGrabCapsule` in Scene View | Capsule placement only; no wizard fields | “Distance-grab target placed in the teaching area.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/01_DistanceGrab_ExistingTarget-1.png` | Distance Hand Grab / retake | Capsule target in Scene View | Placement only; near-duplicate | “Distance-grab target.” | REAL_FINAL_EDITOR, redundant retake |
| `Screenshots/02_HandTrackingStatus_Overview.png` | Hand status / layout | `L4_HandTrackingStatus` group in Scene View | Indicator positions only | “Two indicators visualize left and right hand tracking status.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/02_HandTrackingStatus_Indicators.png` | Hand status / result detail | Left/right indicator spheres in Scene View | No source Hand or script references visible | “Tracking-state indicators in the scene.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/03_CustomGrabPose_TorchTarget.png` | Grab pose / target setup | `L4_GrabPoseTool` in Scene View | Torch sample object only | “Reuse the Meta Torch sample as a pose-authoring target.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/03_CustomGrabPose_TorchTarget_Detail.png` | Grab pose / target detail | Torch sample in Scene View | Mesh and placement only | “Sample tool used for hand-grab pose practice.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/03_CustomGrabPose_TorchTarget-1.png` | Grab pose / retake | Torch sample in Scene View | Near-duplicate result view | “Torch target.” | REAL_FINAL_EDITOR, redundant retake |
| `Screenshots/04_ThumbsUp_Indicators_SceneView.png` | Thumbs-up / result | Thumbs-up exercise in Scene View | Scene result; wide framing | “Separate left and right indicators provide pose feedback.” | REAL_FINAL_EDITOR, Scene View only; low detail |
| `Screenshots/05_TwoHandedObject_SceneView.png` | Two-hand / object result | `L4_TwoHandedObject` in Scene View | Object placement only; transformer fields not visible | “Two-hand sample target kept separate from the movable UI.” | REAL_FINAL_EDITOR, Scene View only |
| `Screenshots/06_EditorWindow_Lesson4Hierarchy.png` | Hierarchy overview | `L4_ThumbsUp_Exercise`; Inspector shows its Transform | Unity Hierarchy and full Scene View; no wizard or component fields | “Lesson 4 exercise hierarchy in the Unity Editor.” | REAL_FINAL_EDITOR, Unity-only crop from Snipping Tool capture; not a menu-step image |

## Required operational captures still missing

All requested menu and Inspector proof below remains **SCREENSHOT_MISSING**. Capture only the full-screen Unity window, with labels legible. If showing a dialog reopened after the original action, label it **RECONSTRUCTED_WIZARD_VIEW** and never click Create/Fix All on an already configured object.

| Filename to capture | Select / expose | Required visible operation or properties | Caption for slide |
|---|---|---|---|
| `UI_01_DistanceGrab_Menu.png` | Select `L4_DistanceGrabCapsule` | Expand **GameObject > Interaction SDK** and show **Add Distance Grab Interaction** | “Open the Meta Interaction SDK Distance Grab action.” |
| `UI_02_DistanceGrab_Wizard.png` | Wizard targeting capsule | Local v207 device type, distance grab type, supported grab type, and collider options | “Choose the hand-driven pull interaction in the installed wizard.” |
| `UI_03_HandData_References.png` | `L4_HandTrackingStatus` | Script Inspector with existing left/right Hand references and each Renderer assignment | “Connect the indicators to the existing hand data sources.” |
| `UI_04_GrabPose_Recorder.png` | Hand Grab Pose Recorder | **Window > Meta > Interaction SDK > Hand Grab Pose Recorder** and Hand, Item, Ghost Provider, Poses Collection controls | “Prepare the pose recorder for a live tracked-hand session.” |
| `UI_05_ThumbsUp_Recognizer_Providers.png` | `L4_ThumbsUpRecognizer_Left`, then Right | Matching `HandRef`, `FingerFeatureStateProvider`, `TransformFeatureStateProvider` | “Assign each recognizer to the matching hand and feature providers.” |
| `UI_06_ThumbsUp_Events.png` | Both recognizer event wrapper components | Selected/unselected UnityEvent targets and `OnPoseRecognized` / `OnPoseLost` | “Wire recognition and pose loss to visible feedback.” |
| `UI_07_TwoHand_Grabbable.png` | `L4_TwoHandedObject` | `Grabbable`: Max Grab Points, One Grab Transformer and Two Grab Transformer | “Set two grab points and assign the transformers.” |
| `UI_08_TwoHand_Constraints.png` | `L4_TwoHandedObject` | `GrabFreeTransformer` position, rotation, scale axes and min/max constraints | “Inspect the two-hand transform and scale limits.” |
| `UI_09_Existing_Hand_Interactors.png` | Existing left/right hand branches | Hierarchy paths and `DistanceHandGrabInteractor` component identity | “Reuse the tracked-hand interactors already present in the rig.” |

Package-installation UI is not applicable in this configuration: required Meta ISDK/Core/OVR packages are already present at 207.0.1, and no package was installed or changed during this task. Do not create a fictitious installation screenshot.

The unmodified default source screenshot remains at `C:\Users\Scianso\Pictures\Screenshots\Screenshot 2026-11-03 154828.png`. Its Unity-display crop is the `06_EditorWindow_Lesson4Hierarchy.png` copy in this repository. The source is a dual-display capture; use only the Unity-only crop for teaching.
