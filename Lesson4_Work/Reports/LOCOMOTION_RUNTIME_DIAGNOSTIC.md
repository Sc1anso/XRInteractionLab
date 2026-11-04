# Controller slide locomotion — runtime diagnostic

## Cause found

The instructor's Quest logs show that the left thumbstick reaches OVR and ISDK, and that slide events reach the player handler. Thus the input and event-forwarding chain is working. During those same samples the player velocity stays at zero.

The static scene contains the cause: `Environment/Floor` is on layer **Teleportable** (layer index 6), but `PlayerController/CharacterController.LayerMask` was **23**. Decimal 23 includes layers 0, 1, 2 and 4; it excludes bit 6 (`Teleportable`). The Meta v207 `CharacterController` uses this mask for its collision casts and ground checks. `FirstPersonLocomotor` only grants slide speed when its `CharacterController` is grounded; at startup it disables velocity locomotion if it cannot find ground within its configured 10 m. With the floor excluded from its mask, the rig cannot ground on the scene floor, so valid slide events produce no movement.

This also explains why Teleport was not the cause: the stick values and all three event counters were nonzero while slide was active. Passthrough/occlusion following physical controller movement is tracking/rendering feedback and is unrelated to locomotion ground collision.

The current saved `Assets/Scenes/SampleScene.unity` configuration is statically connected:

- `OVRCameraRig/OVRComprehensiveInteractionRig/Locomotor/LocomotionSettings/Moving` has `MovingSetting.ControllerMovement.Value = Slide` (`0`).
- `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft/Interactors/Controller/LocomotionControllerInteractorGroup/ControllerSlideInteractor` is active and its `ControllerAxis2D.Axis` is `Primary2DAxis`.
- The left `LocomotionControllerInteractorGroup` connects `ControllerSlideInteractor` to `LocomotionOutput`, which sends locomotion events to `Locomotor` and its `PlayerController` / `FirstPersonLocomotor`.
- `PlayerController` has a `CharacterController` and `FirstPersonLocomotor`; its references to `OVRCameraRig` and `CenterEyeAnchor` are assigned. The floor is `Teleportable` (layer 6), so that layer must be included in `CharacterController.LayerMask`.
- The separate `LeftStickLocomotion` GameObject exists under `Locomotor`, but its broadcaster is not part of the inspected left controller group's configured broadcaster list. The comprehensive rig's own left `ControllerSlideInteractor` is the active configured path.
- The controller Teleport interactor is a separate broadcaster in the same locomotion event system. In the inspected saved scene, the movement style is Slide and the left slide path is active. There is no static evidence that Teleport is consuming the slide axis. Do not remove or disable Teleport as a speculative fix.

The Quest logs provided on 2026-11-04 confirm the runtime stages:

| Evidence | Observed value | Conclusion |
|---|---|---|
| `OVR_LTouch` while stick moved | `(0.25, 0.97)`, `(0.31, -0.95)`, `(-0.87, -0.50)` | OVR receives the left stick. |
| `ISDK_LeftAxis` | Matches the OVR values | `ControllerAxis2D` receives the controller input. |
| `events(slide/group/handled)` | `6/6/6`, `63/63/63`, `51/51/51`, `59/59/59` | Broadcaster, group connection and player handler all receive events. |
| Player velocity during input | `(0,0,0)`; position nearly unchanged | Locomotor is not applying movement. |
| Ground-layer mask comparison | Floor layer 6 excluded by mask 23 | Root cause identified in ground/collision filtering. |

## Fix applied and diagnostic retained temporarily

Changed only `PlayerController/CharacterController.LayerMask` from **23** to **87** (`23 | (1 << 6)`). This preserves the existing collision layers and adds the scene floor's `Teleportable` layer. The serialized component now reads `LayerMask.value = 87`. No Teleport bindings, locomotion input routes, floor layer, or Lesson 1–3 interaction objects were changed.

During diagnosis, the temporary `Assets/Scripts/Lesson4/L4_LocomotionRuntimeDiagnostics.cs` component was attached to the existing `L4_HandTrackingStatus` GameObject. After the instructor confirmed locomotion worked on Quest (2026-11-04), the component was removed, the scene was saved, and the temporary script was moved to Unity's trash. No diagnostic logger remains in the teaching scene.

The diagnostic had logged once per second:

- raw `OVRInput` left Touch primary thumbstick vector;
- the actual ISDK `ControllerAxis2D.Value()` used by slide locomotion;
- slide mode and broadcaster active state;
- counts of slide events, group-received events, and events handled by `FirstPersonLocomotor` during that interval;
- `FirstPersonLocomotor.IsGrounded` and `IgnoringVelocity`;
- PlayerController position and locomotor velocity.

`SampleScene` was saved after verifying the references and corrected mask value. Unity reported no C# compile errors. The instructor's post-correction Quest confirmation closes the locomotion retest.

## Reading the next log

The post-correction Quest test was confirmed successful by the instructor: the player moves with the controller thumbstick. The test was performed after the mask correction; the instructor did not provide a new diagnostic log, so the success status is based on the direct headset observation.

Before the cause was known, the diagnostic interpretation was:

1. `OVR_LTouch` stays zero while pushing the stick: raw controller axis is not reaching OVR input (device/input mode/runtime issue).
2. `OVR_LTouch` changes but `ISDK_LeftAxis` stays zero: controller data-source/reference path is the break.
3. `ISDK_LeftAxis` changes but slide-event count remains zero: broadcaster activation or lifecycle is the break.
4. Slide events increase but group count stays zero: group connection is not receiving events at runtime.
5. Group count increases but handled count stays zero: forwarding from the group/output connection to the player is the break.
6. Handled count increases but position/velocity remain unchanged: inspect `FirstPersonLocomotor` movement constraints, collision/ground state, and player-origin synchronization; the input chain is reaching the locomotor.

Keep the diagnostics in this technical report; they are not lesson or slide content. Remove the temporary component and script after the Quest retest confirms the correction.

## Runtime status

- Quest input/event chain: **RUNTIME_VERIFIED** by the instructor's supplied log values.
- Root cause: **STATIC_VERIFIED** — `CharacterController.LayerMask` excluded the floor's Teleportable layer.
- Fix: **APPLIED** — mask changed from 23 to 87, adding layer 6 while retaining previous bits.
- Unity compilation and scene save: **PASSED**; no C# compile errors.
- Corrected Quest locomotion: **PASS_REPORTED** by instructor on 2026-11-04.
- Teleport conflict: **RULED OUT FOR THIS FAILURE** by slide-mode runtime events reaching the player handler.
