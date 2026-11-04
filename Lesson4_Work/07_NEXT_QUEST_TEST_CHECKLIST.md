# Consolidated Quest checkpoint — pending

No Quest build, deployment, Meta Quest Link hand-tracking test, or Play Mode test was performed in this milestone. Keep all boxes unchecked until directly observed on the headset.

## Distance Hand Grab

- [ ] Enable bare-hand tracking and confirm both hand visuals/data sources appear.
- [ ] Left hand: acquire distance reticle on `L4_DistanceGrabCapsule`, pinch, verify pull-to-hand, hold, release.
- [ ] Repeat with right hand.
- [ ] Reacquire after temporary tracking occlusion.
- [ ] Near-grab fallback: **not configured/verified**; do not expect one.

## Hand status indicator

- [ ] Verify each sphere follows raw `OVRHand` state: dark when invalid/untracked, amber when tracked with low confidence, green when tracked with high confidence. The interaction rig's `LastKnownGoodHand` remains enabled and is not the status source.
- [ ] Cover/uncover a hand and verify status updates without affecting rig input.

## Grab pose authoring

- [ ] Open Hand Grab Pose Recorder, select hand, Torch item, Ghost Provider and a writable Poses Collection.
- [ ] Record a new pose with tracked hand, save it, load it again, and verify the intended hand/object pose.
- [ ] Confirm the recorded data asset is saved and source Torch package prefab is unchanged.

## Thumbs-up recognition

- [ ] Test left and right independently; confirm only the corresponding indicator changes on the configured pose.
- [ ] Relax the pose and confirm `OnPoseLost` returns the indicator to gray.
- [ ] Verify low confidence / hand loss does not leave false positive feedback.

## Two-handed interaction

- [ ] Confirm one-hand grab remains available.
- [ ] Grab with both hands; translate and rotate with two-hand transformer.
- [ ] Verify scale constraints (configured relative bounds 1–3) and no unintended jump on second selection.
- [ ] Release one hand and verify stable one-hand continuation/release behavior.

## Lesson 1–3 regression checks

- [ ] `ControlCanvas`: Poke works.
- [ ] `ControlCanvas`: Ray works.
- [ ] Teleport to floor surface works.
- [ ] Teleport to hotspot works.
- [ ] Smooth locomotion and turning work.
- [ ] `PowerCell` can still be grabbed.
- [ ] `PowerCell` still snaps correctly to `BatteryDock`.
- [ ] `ISDKExampleMenu` and VR/MR switching remain functional.

Record headset model, build hash/date, input mode, and actual observed result beside each check. No item above is currently passed.
