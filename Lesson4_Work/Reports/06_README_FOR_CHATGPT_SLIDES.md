# Lesson 4 — handoff for slide authoring

## Teachable order

1. Hand-tracking data and confidence indicators (B01–B04), using raw OVR tracking flags for the sphere colors.
2. Distance Hand Grab and existing bare-hand interactor paths (A01–A05).
3. Hand Grab Pose authoring: explain existing sample poses first; record a new course pose only during a later Quest/Link session (C01–C03).
4. Static Thumbs-Up pose recognition and event feedback (D01–D05).
5. Two-handed manipulation using the separate StonePolyhedron target (E01–E04).
6. Hand Grab Use: selecting/holding versus using the SprayBottle (F01–F04).
7. Authored Grab Surface points on a sample-derived palm-grab target (F05–F08).
8. Throw/recovery, then compare basic OVRInput vibration with Meta Haptics SDK clips (F09-F13, F18-F20).
9. Existing locomotion microgestures; then show GestureExamples sequence and Touch/Gaze samples only as overview material (F14–F17).

## Most reliable procedures

- Use local Meta XR Interaction SDK 207.0.1 examples as the source for Hand Grab Use, Grab Surface and StonePolyhedron rather than teaching guessed component wiring.
- Keep student explanations tied to exact object paths and Inspector fields in `02_CONFIGURATION_MATRIX_FINAL.md` and `04_SLIDE_INSTRUCTIONS_FULL.md`.
- The interactive implementations are configured in the existing `SampleScene`. The instructor has reported Quest results for hand tracking status, left/right Distance Hand Grab, the Torch sample pose, thumbs-up recognition, two-hand translation/rotation/scaling, Hand Grab Use, Grab Surface, Throw and controller slide locomotion after the layer-mask correction. Open follow-up checks remain documented in `QUEST_TEST_CHECKLIST_FINAL.md`; do not mark unreported subchecks as passed.
- Use `SCREENSHOT_CAPTURE_GUIDE_MANUAL.md` and `SCREENSHOT_MANIFEST_COMPLETE.csv` to acquire slide evidence. All 42 IDs (including F18-F20) are currently missing. No old claimed PNG should be presented as current evidence without locating and checking the file.

## Content distinctions to preserve

- Distance Hand Grab's current object has both `DistanceHandGrabInteractable` and generic `DistanceGrabInteractable`; do not claim it is exclusively hand-only. The previous wizard's Hands/Pull selection is historical, not verified by a capture.
- The hand-status spheres read the raw `OVRHand` tracking/confidence fields. Keep `LastKnownGoodHand` enabled in the rig because it provides a filtered fallback pose to interactions; it must not be used as the status signal.
- `HandGrabPose` shapes the hand around an object while grabbing. `ThumbsUpPose` recognizes a static hand pose. They are different systems.
- The Torch's six poses are Meta sample poses; no course-owned pose collection has been recorded.
- The static thumbs-up recognizer is not a temporal swipe/sequence gesture.
- Two-hand target is sample-derived and separate from `ControlCanvas`; the instructor reports translation, rotation and scaling work. Both exercise targets use `RespawnOnDrop` threshold Y=-1.0 after the original 0.3 threshold caused premature resets. Scale-limit extremes and release-order checks remain open.
- Hand Grab Use distinguishes holding from invoking a function while held; show WaterSpray event callbacks.
- A `CylinderGrabSurface` is authored and referenced by a `HandGrabPose`; a collider alone does not create this mapping.
- Throw uses Grabbable release and Rigidbody settings plus RespawnOnDrop; configuration is not proof of a successful physical throw.
- L4_ControllerGrabHaptics defaults to Meta Haptics SDK playback and offers BasicOvrInput as an exclusive comparison mode. It maps the selecting ControllerRef.Handedness to only the matching Touch controller. It does not produce bare-hand vibration.
- Meta XR Haptics SDK 207.0.1 is installed; switch_on.haptic is configured through HapticSource on L4_ThrowStone. The instructor reports left/right feedback, amplitude and frequency-shift comparisons, BasicOvrInput comparison, no release feedback, and throw regression passed on Quest on 2026-11-04. The controller haptics exercise is complete; hand interactions were tested separately and do not produce controller vibration.
- All three project-owned Lesson 4 C# scripts are reproduced in full in the code appendix of 04_SLIDE_INSTRUCTIONS_FULL.md. Include complete source listings in the slide appendix; do not present the hand-tracking logger as lesson content.
- After the instructor saved, Unity MCP confirmed SampleScene `isDirty=false`; the expected haptics defaults remain configured.
- Existing microgesture locomotion bindings were preserved. Gesture Sequence is available in the local sample but not wired into SampleScene.
- If a slide recaps smooth locomotion setup, include this required collision-layer step: keep `Environment/Floor` on `Teleportable` (layer 6), then on `OVRCameraRig > OVRComprehensiveInteractionRig > Locomotor > PlayerController > CharacterController`, include `Teleportable` in **Layer Mask**. The project uses value 87; the previous value 23 excluded the floor and prevented slide locomotion. The instructor confirmed the fix works on Quest on 2026-11-04. Do not include the temporary runtime logger in lesson slides.
- Presence of GazeExamples does not mean eye gaze or an active gaze interactor is configured. Custom hand models and eye tracking were not added.

## Evidence and status

- Scene: `Assets/Scenes/SampleScene.unity`, Unity 6000.3.9f1, Meta XR packages 207.0.1.
- Static validation: the earlier full static QA found 0 compile errors, scene validation issues, missing scripts and broken prefabs. After the locomotion mask correction and removal of the temporary logger, the scene was saved and the Console showed 0 compile errors.
- Quest: instructor-reported tests are summarized above and in `QUEST_TEST_CHECKLIST_FINAL.md`. This documentation update did not run Play Mode or a new device test.
- Screenshot evidence: zero captured in this task; 39 manual evidence records are pending.
- Custom grab pose recording: pending Quest/Link.
- Meta Haptics SDK: Editor configuration and instructor-reported Quest checks complete.

## Files to consult

- `00_RECONCILED_BASELINE.md`
- `01_REMAINING_FEATURES_IMPLEMENTATION_LOG.md`
- `02_CONFIGURATION_MATRIX_FINAL.md`
- `03_GAPS_BLOCKERS_AND_DECISIONS.md`
- `04_SLIDE_INSTRUCTIONS_FULL.md`
- `SCREENSHOT_CAPTURE_GUIDE_MANUAL.md`
- `SCREENSHOT_MANIFEST_COMPLETE.csv` and `.md`
- `QUEST_TEST_CHECKLIST_FINAL.md`
- `05_FINAL_STATIC_QA.md`


## Haptics implementation handoff - 2026-11-04

Use 04_SLIDE_INSTRUCTIONS_FULL.md for the English slide-ready procedure. The current scene defaults to MetaHapticsSdk, uses the official 207.0.1 sample switch_on.haptic, and routes to the controller identified by the selecting interactor's ControllerRef. BasicOvrInput is an exclusive alternate. Static setup and compilation are verified; the instructor reports the controller feedback, modulation, mode comparison, release and throw checks passed on Quest. Do not present this as a Codex-run test.
