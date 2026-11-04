# Lesson 4 Pilot — Screenshot Manifest

All files below are genuine Unity Editor Scene View captures produced by Unity MCP and stored outside `Assets/`.

| File | What it shows | Use |
|---|---|---|
| `Lesson4_Work/Screenshots/L4_BaselineScene.png` | Scene View before adding the Lesson 4 target | Baseline comparison |
| `Lesson4_Work/Screenshots/L4_DistanceGrab_Scene.png` | Selected capsule close-up on the existing floor, with its collider outline | Geometry/placement illustration |
| `Lesson4_Work/Screenshots/L4_DistanceGrab_Context.png` | Capsule in the broader teaching scene and floor context | Scene context; target appears small at this zoom |

The active Editor was also viewed through Computer Use with the capsule selected and the Quick Action/Inspector visible. That transient Computer Use image was not exported to a project file. No fake or generated Unity interface image was used.

## SCREENSHOT_NOT_AVAILABLE — manual captures for slide use

Unity MCP’s screenshot API saved Scene View images but cannot save a complete Editor screenshot containing Hierarchy, Inspector, Quick Action and Console. If those exact panels are needed in the slide deck, manually capture:

- **Quick Action setup:** select `Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule`; open **GameObject > Interaction SDK > Add Distance Grab Interaction**; show `Add Required Interactor(s)=Hands`, `Distance Grab Type=Pull Interactable To Hand`, `Supported Grab Types=All`, and the required Rigidbody/Grabbable status. Suggested filename: `L4_DistanceGrab_QuickAction.png`.
- **Target Inspector:** select `L4_DistanceGrabCapsule`; show Transform, Capsule Collider, Rigidbody and Grabbable. Suggested filename: `L4_DistanceGrab_Capsule_Inspector.png`.
- **Interactable Inspector:** select child `ISDK_DistanceHandGrabInteraction`; show DistanceHandGrabInteractable’s Rigidbody, Supported Grab Types, Movement Provider and Pointable Element references. Suggested filename: `L4_DistanceGrab_Interactable_Inspector.png`.
- **Rig hierarchy:** expand `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft` and `...Right` to show existing `Hand and No Controller/DistanceHandGrabInteractor`; keep the new capsule hierarchy visible. Suggested filename: `L4_DistanceGrab_Rig_Hierarchy.png`.
- **Console:** show the current messages and filters without clearing them. Suggested filename: `L4_DistanceGrab_Console.png`.

Quest interaction evidence requires a real headset capture after the pending Quest checklist is performed. Suggested filename: `L4_DistanceGrab_Quest_Pull.png`.

## Unity Editor capture from the Windows Screenshots folder

The original user-provided Windows capture was copied unchanged from `C:\Users\Scianso\Pictures\Screenshots\Screenshot 2026-11-03 143316.png` to `Lesson4_Work/Screenshots/Screenshot_2026-11-03_143316_Original.png` (6000×1508). Two pixel-preserving crops were created from that genuine capture:

| File | What it shows | Dimensions | Use |
|---|---|---:|---|
| `Lesson4_Work/Screenshots/L4_Unity_Monitor_Crop.png` | Right-hand monitor containing Unity, with taskbar/bottom monitor area retained | 3440×1508 | Monitor-level context |
| `Lesson4_Work/Screenshots/L4_Unity_Editor_Window.png` | Unity editor area only; second monitor and desktop taskbar excluded | 3440×1370 | General Unity Editor slide image; can be cropped further for Hierarchy/Inspector details |

The image was inspected after cropping. No Unity UI was fabricated or redrawn. These are static Editor screenshots only; they do not prove runtime or Quest behavior.
