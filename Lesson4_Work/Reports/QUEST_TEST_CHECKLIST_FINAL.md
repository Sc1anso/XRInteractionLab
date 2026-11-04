# Lesson 4 — cumulative Quest acceptance test (instructor use only)

**Test status:** instructor-run Quest testing is in progress. Results explicitly reported by the instructor are recorded below. Do not use Meta Quest Link as a substitute for confirming the actual deployed hand-tracking behavior. Record device, build identifier, date, input mode and observations for each run.

## Preconditions and safe setup

- [ ] Instructor has captured the required Unity Editor evidence manually and confirmed current scene/project state.
- [ ] A new Android build is created and installed by the instructor after this implementation; record build/version and Quest model.
- [ ] Clear a safe area; use wrist straps for controllers. Keep thrown objects away from people/fragile surfaces.
- [ ] Confirm Quest hand tracking and controller tracking are available in system settings. Test one input mode at a time and record whether hands, controllers, or both are active.
- [ ] Start at the scene's normal spawn point. Confirm menu mode switch and passthrough/VR switching before beginning interaction tests.
- [ ] Capture short video or screenshots of visible results where practical; note Unity logcat/Android logs only if separately collected by the instructor.
- [ ] Do not call a static Inspector reference a pass. A pass requires the expected behavior to be observed in the headset.

Result key: `PASS / FAIL / NOT TESTED`. Only instructor-observed outcomes are recorded as results. Add notes and evidence filename beside each result.

## A. Hand tracking status indicators

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Both tracked hands | Both indicators are green with hands visible and stable. | PASS — instructor observed on Quest, 2026-11-04 |
| Tracking loss | Hiding hands behind the back turns both indicators dark. | PASS — instructor observed on Quest, 2026-11-04 |
| Low-confidence color | Yellow/orange state was not observed; it requires tracked data with low confidence and may not occur when hands are fully hidden. | NOT TESTED — optional state not observed |
| Side mapping and controller mode | Verify left/right independently and note controller-mode behavior if tested. Indicators report hand tracking state, not input modality. | NOT TESTED |

## B. Distance Hand Grab capsule

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Left-hand distance grab | Capsule can be targeted, pulled, moved and released with the left hand; targeting stops beyond its effective range. | PASS — instructor observed on Quest, 2026-11-04 |
| Right-hand distance grab | Capsule can be targeted, pulled, moved and released with the right hand. | PASS — instructor observed on Quest, 2026-11-04 |
| Pinch and palm | Pinch was used successfully. Palm mode was not tested; current Supported Grab Types value 3 allows Pinch + Palm. | PARTIAL — pinch observed; palm not tested |
| Release and recovery | Capsule can be moved and released. | PASS — instructor observed on Quest, 2026-11-04 |
| Controller distinction | Test controller distance grab separately. Confirm controller interactor does not appear at a hand ray endpoint or get mistaken for the bare-hand route. | ______ |

## C. Grab pose sample and course pose recording

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Existing Torch sample poses | Near-grab the scene instance `L4_GrabPoseTool` and observe hand conformity to its preauthored sample pose. | PASS — instructor observed on Quest, 2026-11-04 |
| Pose authoring preconditions | In a later approved session, enter Play Mode with actual tracked hands and use Hand Grab Pose Recorder. Create a new course-owned collection; do not overwrite package sample data. | ______ |
| Save/reload | Save a newly recorded pose, exit/re-enter as appropriate, reload collection and verify the pose remains assigned. | ______ |
| Mirroring | If mirrored pose support is used, verify the opposite hand pose and references independently. | ______ |

Do not mark the course pose authored until a new project-owned collection and recorded asset exist and have been loaded/tested.

## D. Thumbs-up pose detection — test complete

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Thumbs-up recognition | Instructor reports that thumbs-up recognition works on Quest; hand side, release behavior and false-positive checks were not specified. | PASS — general recognition observed; subchecks not detailed |

| False positives | Neutral hand, fist and other non-target pose do not persistently activate thumbs-up. | ______ |
| Tracking loss | Move hand out of view; active state clears or follows the documented recognizer behavior without stale feedback. | ______ |
| Pose vs gesture | Confirm it recognizes a static pose, not a swipe/ordered temporal sequence. | ______ |

## E. Two-handed manipulation — test successful

**Spawn behavior:** After lowering RespawnOnDrop to Y=-1.0, the instructor reports that the two-hand test works correctly without repeated resets.

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| One-hand selection | Target can be held with one hand before adding the second. | PASS — instructor observed manipulation on Quest |
| Second hand | Second hand joins and two-hand manipulation works. | PASS — instructor observed on Quest |
| Translation | Two-hand translation works; instructor notes translation is also easy with one hand. | PASS — instructor observed on Quest |
| Rotation | Two-hand rotation works; instructor notes rotation is also easy with one hand. | PASS — instructor observed on Quest |
| Scaling | Two-hand scale manipulation works. | PASS — instructor observed on Quest |
| Scale limits | If scaling is active, verify each axis remains within configured relative range 1–3; record overshoot or snapping. | ______ |
| Release/reset behavior | After lowering the threshold to Y=-1.0, the object settles and no longer repeatedly resets. | PASS — instructor observed on Quest, 2026-11-04 |
| UI isolation | Confirm no changes to `ControlCanvas` Poke/Ray and no collision with UI task. | ______ |

## F. Hand Grab Use — test complete

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Near grab | Hold the SprayBottle with a tracked hand. | PASS — instructor observed on Quest, 2026-11-04 |
| Use action | While holding, flex/squeeze the use fingers; spray/stream activates and stops when released. | PASS — instructor reports spray works |
| Event response | Spray/stream particle and audio responses occur. | PASS — instructor confirmed spray and audio |
| Release | Release the use gesture; spray/stream stops. | PASS — instructor reports interaction works |
| Input distinction | Confirm simply holding does not falsely imply the use function is continuously active. | ______ |

## G. Grab Surface — test complete; no perceptible difference from Torch sample

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Grab Surface comparison | Both Torch objects grab at multiple points and rotate with the hand; instructor reports no perceptible difference between them. | PASS — behavior works; no visible distinction observed |
| Multiple points | Both objects can be grabbed at different points. | PASS — instructor observed on Quest |
| Hand orientation | A vertical Torch follows the horizontal hand orientation during grab. | PASS — instructor observed on Quest |
| Regression | Confirm PowerCell near grab and Snap to BatteryDock still work. | ______ |

## H. Throw and controller vibration

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Throw interaction | Instructor reports the throw interaction works on Quest. | PASS — controller throw/regression reported complete 2026-11-04; hand route not separately tested |
| Controller throw | Grab with controller, move, release with a controlled motion; observe object velocity and gravity. | PASS — instructor completed requested controller throw regression, 2026-11-04 |
| Hand throw | Repeat using hand route; record whether velocity behavior differs. | ______ |
| Recovery | Let target fall below Y threshold; confirm RespawnOnDrop returns it. | ______ |
| Controller vibration | Test the selected feedback mode and confirm only the controller that grabbed vibrates. | PASS — instructor reported sound and light vibration on the respective left/right controller grabs, 2026-11-04 |
| Hand-only selection | Tracked-hand interaction remains separate from controller haptics; hands have no controller actuator. | NOT APPLICABLE to haptic output — hand interactions were tested in their dedicated exercises |
| Haptics SDK clip | In Meta Haptics mode, confirm switch_on.haptic plays through the grabbing Touch controller. | PASS — both controller sides reported working; no hand vibration is expected |

## Meta XR Haptics SDK test — instructor-reported results and remaining checks

Use the current L4_ThrowStone setup. The default is MetaHapticsSdk; BasicOvrInput is the mutually exclusive alternative. PASS entries below are instructor-reported Quest observations from 2026-11-04; no Codex runtime test was performed.

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Left controller route | Grab with left Touch; only left controller plays one clip. | PASS — instructor reports sound and light vibration on the grabbing controller, 2026-11-04 |
| Right controller route | Grab with right Touch; only right controller plays one clip. | PASS — instructor reports the same side-specific behavior on the right, 2026-11-04 |
| Release / throw | Releasing does not start another grab clip; throwing and Rigidbody recovery still work. | PASS — no release feedback; instructor completed the requested throw check, 2026-11-04 |
| Repeated grabs | Each new grab starts one short clip; no duplicate playback. | NOT A SEPARATE COURSE CHECK — one event subscription is configured; instructor reported expected feedback during repeated trials. No event counter is required |
| Amplitude | Compare 0.2, 0.6, 1.0; intensity changes while pattern remains recognizable. | PASS — instructor reports perceptible differences at 0.2 and 1.0; restored 0.6, 2026-11-04 |
| Frequency shift | Compare -0.5, 0, +0.5 as relative modulation, not hertz. | PASS — instructor reports perceptible differences at -0.5 and +0.5; restored 0, 2026-11-04 |
| Basic OVRInput mode | Switch to BasicOvrInput; only matching controller receives the 0.12 s pulse. | PASS — instructor completed the basic-mode comparison and restored MetaHapticsSdk, 2026-11-04 |
| Mutually exclusive modes | Confirm basic pulse and SDK clip do not start together. | STATIC VERIFIED — the code selects one branch per grab; the instructor compared modes separately, but simultaneous output was not independently instrumented |
| Hand-only interaction | Use the separate hand grab path; it remains usable and does not send controller haptics. | NOT APPLICABLE to this controller-haptics exercise — hand interactions were tested separately |

## I. Microgesture and optional sequence

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Existing locomotion microgestures | Verify current tap, teleport selection, snap turn, step and jump/crouch actions as configured; do not change bindings during the test. | ______ |
| Lesson 3 control regression | Confirm controller locomotion and turning remain available and do not trigger unexpectedly from hand gestures. | ______ |
| Optional Sequence sample | Only if separately integrated in a future authorized change: verify ordered swipe sequence and reset/cooldown. It is not currently configured in SampleScene. | ______ |

## J. Lesson 1–3 regression suite

| Check | Expected observation | Result / evidence / notes |
|---|---|---|
| Scene and tracking origin | Scene loads, passthrough/VR switch works, head rotation and positional tracking are stable. | ______ |
| Floor teleport | Teleport to `FloorTeleportSurface` succeeds with supported controller/hand route. | ______ |
| Hotspot teleport | Teleport to each configured hotspot succeeds and lands at intended location. | ______ |
| Smooth locomotion | Runtime logs localized the issue to ground collision filtering: `CharacterController.LayerMask` omitted the floor's `Teleportable` layer. Mask corrected from 23 to 87. Instructor then confirmed the player moves with the left controller stick. | PASS — instructor confirmed Quest movement after the correction, 2026-11-04 |
| Turning | Snap/smooth turning works as configured, including hand/controller mode switching. | ______ |
| ControlCanvas Poke | Poke buttons and slider work at multiple panel positions after moving the panel. | ______ |
| ControlCanvas Ray | Ray interaction works on the same controls; no two-hand exercise object overlaps the canvas. | ______ |
| Canvas manipulation | Grab/move/rotate the panel; Poke and Ray remain functional. | ______ |
| PowerCell grab and snap | Grab PowerCell and dock to BatteryDock; snap is centered and task state updates. | ______ |
| Existing menu | ISDKExampleMenu opens and VR/MR toggle behaves as expected. | ______ |
| EventSystem and input | No duplicate events, stuck selection, UI click-through or missing input routes. | ______ |

## Completion record

- Quest model / OS: ____________________
- Build version / package identifier: ____________________
- Test date and operator: ____________________
- Overall result: `PASS / FAIL / PARTIAL / NOT TESTED`
- Blocking failures and reproduction steps: ____________________
- Evidence files/video paths: ____________________
- Follow-up changes approved: ____________________

## Hand tracking indicator result — 2026-11-04

The instructor retested the updated Quest build and confirmed that both indicators are green when hands are tracked and turn dark when the hands are hidden behind the back. The yellow/orange low-confidence state was not observed; this is expected when tracking is lost fully and is not required to close the basic indicator test. Left/right independence was not separately reported.

**Status:** basic tracked/untracked indicator test closed. Proceed to Distance Hand Grab. The remaining checks for side mapping and low-confidence display are optional follow-up observations. Detailed diagnostics are maintained separately and are not part of lesson instructions.





## Distance Hand Grab result — 2026-11-04

The instructor confirmed left- and right-hand distance selection, pull, movement and release on Quest. A finite targeting range was observed; objects outside that range are not targeted. Pinch was used. Palm support is enabled in the current static configuration but has not been tested. The capsule was reported to look large during pull-in; this is a visual/scale concern, not evidence of a grab failure.




## Torch sample result — 2026-11-04

The instructor confirmed that the existing Torch sample grab pose works correctly on Quest. This verifies the preauthored sample pose only; no custom pose was recorded. The Hand Grab Pose Recorder is the tool for recording and saving project-specific hand poses while using tracked hands.



## Thumbs-up result — 2026-11-04

The instructor confirmed that thumbs-up pose recognition works on Quest. This is a static pose recognition test; temporal gesture sequences remain separate and are not included in this pass.






## Two-handed Quest observation — 2026-11-04

Instructor reports that two-hand translation, rotation and scaling work. After release, the object returns to its original position, rotation and scale. The scene has a static floor BoxCollider (no Rigidbody required) and the target had RespawnOnDrop threshold Y=0.3, which could reset it before floor contact. This was changed to Y=-1.0 in SampleScene; Quest retest is pending.





## Two-handed retest result — 2026-11-04

After the RespawnOnDrop threshold change from 0.3 to -1.0 on both exercise objects, the instructor reports that the two-handed exercise now works correctly. The previous repeated reset was resolved. Scale-limit extremes and every release order were not separately reported.





## Hand Grab Use result — 2026-11-04

The instructor confirmed Hand Grab Use works correctly, including spray and audio.




## Grab Surface result — 2026-11-04

The instructor compared L4_GrabSurface_Torch with the earlier L4_GrabPoseTool. Both support grabs at multiple points and follow the hand orientation; no perceptible interaction difference was observed. The Grab Surface sample's CylinderGrabSurface configuration is statically present, but its practical distinction is not apparent in this scene/test. Do not present it as a visibly different grab gesture.



## Throw result — 2026-11-04

The instructor reports that the controller throw regression works on Quest and that side-specific haptics were tested separately with both controller routes. The hand throw route remains untested.



