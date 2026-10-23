# Handoff — XR Interaction Lab, Lessons 3 and 4

**Last updated:** 2026-10-23, after completing Lesson 3 slide 13.  
**Read this file first when resuming on another computer.**

## Current status and exact resume point

- Lesson 3 working deck `LabXR-ClassProject-pt3.pptx` is saved with **13 slides** and Italian speaker notes on instructional slides.
- The last completed slide is **13 — Teleport Quick Action**. It uses the real screenshot supplied by the instructor, cropped to show the context-menu path and the highlighted `Add Teleport Interaction` entry. The slide was rendered and visually checked.
- **Resume by creating slide 14 — Teleport Wizard: Configure Plane.** The instructor already supplied its screenshot. Use `Documentation/PresentationAssets/Lesson3/L3_14_Teleport_Plane_Hierarchy_Inspector_Cropped.png`. Show only properties that are visible: `Allow Teleport` is checked and `Surface` is `Plane (Plane Surface)`. The Inspector's Options foldout is closed; do not claim screenshot evidence for Eye Level, Face Target Direction, or other hidden fields. Add Italian speaker notes and inspect the rendered slide.
- After slide 14, continue with slide 15. Its screenshot is still needed when that slide is reached. Then continue through the supplied Lesson 3 sequence, requesting manual screenshots progressively at the specified shotlist steps.
- Lesson 4 has not been authored. Its working copy is an untouched 10-slide copy of the original template baseline.

## Files and transfer between computers

### PowerPoint files

PowerPoint MCP created and edited the working deck at:

`C:\Users\Scianso\Documents\Slides Lab XR\LabXR-ClassProject-pt3.pptx`

Other files in that external folder:

- Original open template/source: `XR_Lesson_3_Locomotion_Movable_UI.pptx` (10 slides; left unchanged).
- Pre-edit backup: `XR_Lesson_3_Locomotion_Movable_UI_BACKUP_before_L3_L4.pptx`.
- Lesson 4 baseline: `LabXR-ClassProject-pt4.pptx` (10 slides; derived from the original baseline, not from pt3).

These PPTX files are **outside the Git repository**. Copy them to the other computer (or make the folder available there) before resuming PowerPoint work. Continue editing pt3 for Lesson 3 and pt4 for Lesson 4. Preserve the original and backup. Do not choose a different template or import masters from other decks.

### Project reports and screenshot assets in this repository

- `PRESENTATION_QA_REPORT.md` — slide progress and validation status.
- `UNITY_VERIFICATION_REPORT.md` — current Unity configuration findings and technical corrections.
- `ASSET_QUALITY_REPORT.md` — audit of supplied teaching illustrations.
- `Documentation/PresentationAssets/Lesson3/` — durable copies of screenshot crops, including the pending L3-14 asset. These are inside the repository so the next computer can use them.

The teaching package itself is at `C:\Users\Scianso\Documents\Slides Lab XR\XR_Lessons_3_4_IMAGEGEN_KIT` and is also outside the Git repository. Make it accessible on the other computer. It contains the 43-slide Lesson 3 specification, 42-slide Lesson 4 specification, screenshot shotlist, asset map, images, references, and workflow instructions.

## Instructions from the instructor

### PowerPoint template and editing

- The **presentation that was open in PowerPoint** is the only authorized template. It is the UniBo template and must not be replaced or reconstructed.
- The original file was inspected and backed up before editing. Work in the separate pt3 and pt4 copies. Preserve masters, layouts, logos, theme, slide dimensions, typography, footer, and slide numbering.
- The instructor explicitly authorized all necessary edits and deletion of slides in the working presentations. The original presentation and backup remain recoverable.
- Slide copy is in **English**. Instructional speaker notes are in **Italian** and should tell the instructor what to explain, demonstrate, watch for, and test.
- Continue the supplied slide order and learning progression. Do not redesign the course or omit planned activities.
- Use PowerPoint MCP for supported editing. Use the actual open/working presentation; inspect each new slide render and notes.

### Unity, evidence, and technical accuracy

- Verify procedures against the actual Unity project through **Unity MCP** and current official Meta/Unity documentation. The supplied specifications alone are not proof that a component or workflow exists in the installed SDK.
- Distinguish `VERIFIED_EDITOR`, `VERIFIED_RUNTIME`, `DOCUMENTED`, `UNVERIFIED`, and `INCORRECT`. No Quest or Play Mode verification has been completed in this session.
- Genuine Unity screenshots must come from the instructor or actual Unity Editor. Never fabricate an Inspector, Hierarchy, Quick Action, or Wizard screenshot. The instructor supplies screenshots progressively; when requested, specify the exact object, view, fields, and suggested filename.
- For the instructor’s wide screenshots, crop the central Scene View when asked, preserving the original Hierarchy and Inspector pixels. For context menus, preserve the actual menu path and selected command. Do not crop meaningful labels or stretch images.
- The instructor requested Unity verification/implementation through MCP and scene materials/colors during the larger task. Preserve existing interactions and rigs. Inspect the current live scene before making a change; do not repeat Quick Actions that would create duplicate components.

### Overall deliverables

1. `LabXR-ClassProject-pt3.pptx` — full Lesson 3.
2. `LabXR-ClassProject-pt4.pptx` — full Lesson 4.
3. `UNITY_VERIFICATION_REPORT.md`.
4. `ASSET_QUALITY_REPORT.md`.
5. `PRESENTATION_QA_REPORT.md`.

Do not call the decks complete until content, notes, technical claims, image use, actual PowerPoint files, and slide renders have been checked. Keep runtime claims unverified until the Quest is actually tested.

## Lesson 3 progress

The current pt3 slide order is:

1. Lesson 3 — Locomotion & Movable UI
2. Where We Start
3. Learning Outcomes
4. Why Locomotion in VR?
5. Physical vs Artificial Movement
6. Locomotion Methods
7. Comfort in Virtual Movement
8. Our OVR Locomotion Architecture
9. Check the Active Rig
10. Teleport: Interactor and Destination
11. Teleport to a Plane
12. Prepare the Teleport Floor
13. Teleport Quick Action

The L3-04 concept image is explicitly used as concept art, not as a Unity screenshot. Other supplied illustrations were audited; most are cropped composites, contain clipped labels, or depict fabricated Unity interfaces, so do not insert them just because the filenames match. See `ASSET_QUALITY_REPORT.md`.

### Screenshots received and used

| Step | State | Asset in repository |
|---|---|---|
| L3-02 | Inserted in slide 2. Shows Hierarchy + Scene View, no Inspector; claims are limited accordingly. | Embedded in pt3 |
| L3-09 | Inserted in slide 9. Shows OVR rig/Locomotor and LeftStickLocomotion Inspector. | `Documentation/PresentationAssets/Lesson3/L3_09_Active_OVR_Rig_Locomotor_Cropped.png` |
| L3-12 | Inserted in slide 12. Shows Floor Transform and Box Collider. | `Documentation/PresentationAssets/Lesson3/L3_12_Floor_Inspector_Cropped.png` |
| L3-13 | Inserted in slide 13. Shows the real Interaction SDK context menu and highlighted Add Teleport Interaction command. | `Documentation/PresentationAssets/Lesson3/L3_13_Add_Teleport_Action_Cropped.png` |
| L3-14 | Received and cropped, pending insertion in slide 14. | `Documentation/PresentationAssets/Lesson3/L3_14_Teleport_Plane_Hierarchy_Inspector_Cropped.png` |

Other screenshot-required Lesson 3 steps from the shotlist include L3-15, L3-20, L3-23, L3-24, L3-28, L3-31, L3-32, L3-33, L3-34, and L3-41. Request each when the lesson sequence reaches it; do not ask for all screenshots at once.

## Unity project facts at last inspection

- Project: `XRInteractionLab`, Unity `6000.3.9f1`, Android target. Meta XR Core and Interaction SDK `207.0.1`.
- Active scene: `Assets/Scenes/SampleScene.unity`. Unity MCP was connected and Editor ready, Play Mode off.
- Active root rig: `OVRCameraRig` with `OVRManager`, `OVRHeadsetEmulator`, and child `OVRComprehensiveInteractionRig`. The old `UnityXRCameraRig` is **absent** from the active hierarchy, not present as a disabled backup.
- The Environment `Floor` is at position `(0,0,0)`, scale `(10,0.1,10)`, with an enabled Box Collider. Its `ISDK_TeleportInteraction` child has a `TeleportInteractable`, `Allow Teleport = true`, and a Plane surface. Thus do not add a second Plane target to the same Floor.
- No station Hotspots were found. These are a future implementation/lesson step, not an existing scene feature.
- The latest instructor L3-09 screenshot shows `LeftStickLocomotion` with `Controller = OVRControllers`, `Axis = Primary 2D Axis`, and `Slide Locomotion Broadcaster` referencing that axis. The broadcaster component checkbox is **unchecked in the screenshot**. Treat that captured state as disabled and do not claim slide locomotion is enabled or runtime-working. Reinspect live Unity before any change because the project may have changed since the screenshot.
- Earlier Unity MCP inspection found no Quest/Play Mode test. Keep all headset-dependent outcomes `UNVERIFIED_RUNTIME` until tested.
- The Floor screenshot shows the cube mesh's top at approximately world Y=0.05 while its transform origin is Y=0; verify arrival height during runtime testing before changing alignment.

## Resume checklist

1. Open `HANDOFF_LEZIONE_3_4.md` and `PRESENTATION_QA_REPORT.md`.
2. Ensure the external `Slides Lab XR` PowerPoint files and teaching kit are available on this computer.
3. Connect PowerPoint MCP, open `LabXR-ClassProject-pt3.pptx`, confirm it has 13 slides, then make slide 14 with the L3-14 crop and Italian notes.
4. Render/inspect slide 14 and save pt3. Then continue to slide 15 and request the next screenshot at that point.
5. Connect Unity MCP to this project's active Editor and re-read Editor state and scene objects before any Unity changes. Never treat the old screenshot as proof of current live state.
6. Keep QA and Unity/asset reports current as work proceeds. Later author Lesson 4 from pt4's original-baseline copy.
