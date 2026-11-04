# Quest checkpoint

Instructor-reported Quest results are marked below. Unreported checks remain pending. No diagnostics or logs are part of the lesson procedure.

After the initial readback reported `isDirty=true`, the instructor saved the scene. A follow-up Unity MCP check confirms `SampleScene` is now `isDirty=false`. Haptics fields match the documented defaults.

## Hand tracking status indicators
- [x] Both indicators are green when hands are tracked and dark when hidden behind the back.
- [ ] Observe the optional low-confidence color and verify left/right mapping independently.

## Distance Hand Grab
- [x] Left and right bare-hand targeting, pull, movement and release work.
- [x] Targeting has a finite range; beyond it the capsule is not targeted.
- [ ] Test Palm mode separately; the reported test used Pinch.
- [ ] Decide whether to reduce the capsule visual/collider size.
- [ ] Verify controller distance route separately.

## Custom Hand Grab Pose
- [x] Existing Torch sample grab pose works on Quest.
- [ ] Record a new course-owned pose collection with tracked hands using Hand Grab Pose Recorder.
- [ ] Save, reload and verify the new pose; do not overwrite the imported sample.
- [ ] Test mirroring if used.

## Thumbs-up pose detection
- [x] Instructor reports that thumbs-up recognition works on Quest.
- [ ] Verify left/right indicator mapping, release behavior, and false positives separately if not covered by the reported test.
- [ ] Tracking-loss behavior.

## Two-handed manipulation — instructor reports test successful
- [x] Instructor confirms two-hand translation, rotation and scaling work.
- [x] Instructor confirms the release/reset behavior works after lowering the threshold to Y=-1.0.
- [ ] Verify scale-limit extremes and both release orders separately.

The Floor uses a static BoxCollider; a Rigidbody is not required on a static floor. `RespawnOnDrop` on both targets is now set to Y=-1.0; the instructor reports the two-hand exercise now behaves correctly.
## Hand Grab Use (SprayBottle) — completed Quest check
Hold the bottle with a tracked hand, then curl/squeeze the index and middle fingers to activate its use interaction. Observe the spray and stream responses; release the use gesture and confirm the effect stops. The sample maps finger flexion to use strength. Test left and right hands if time permits.

## Remaining Lesson 4 checks
- [x] Hand Grab Use: instructor confirms spray and audio work on Quest.
- [x] Grab Surface: instructor reports both torches grab at multiple points and follow hand orientation; no perceptible difference observed.
- [x] Throw interaction: instructor reports it works on Quest.
- [ ] Optional microgesture UI / sequence, if included in the lesson scope.
- [x] Test the Meta Haptics SDK clip and Basic OVRInput comparison using left/right Touch controllers. Instructor reports side-specific feedback, perceptible parameter changes, no new feedback on release, and successful throw regression; see the detailed checklist. The implementation selects one mode per grab.

## Haptics hardware test — instructor reported complete, 2026-11-04
The instructor confirmed sound plus light vibration on left and right controller grabs, no new feedback on release, perceptible differences at amplitude 0.2 versus 1.0 and frequency shift -0.5 versus +0.5, successful comparison with BasicOvrInput, restoration of the documented MetaHapticsSdk defaults (amplitude 0.6, frequency shift 0), and successful throw regression. The instructor considers this exercise complete. Hand interactions were tested separately; hands do not provide controller vibration. See QUEST_TEST_CHECKLIST_FINAL.md for results.

## Lesson 1–3 regression checks
- [ ] ControlCanvas Poke and Ray; move/rotate the panel and retest both.
- [ ] Floor and hotspot teleport.
- [x] Smooth locomotion: left-stick movement works on Quest after adding the floor's `Teleportable` layer (6) to `PlayerController/CharacterController.LayerMask`; the project mask is 87. See `Reports/LOCOMOTION_RUNTIME_DIAGNOSTIC.md` for the technical root-cause record.
- [ ] PowerCell/BatteryDock snap and task state.
- [ ] ISDKExampleMenu and VR/MR switching.

Record Quest model, build identifier, date, tester and evidence with each result. Static Inspector values do not count as a runtime pass.









