# Distance Hand Grab Pilot — Proposal Only

**NOT EXECUTED.** This is for a new disposable scene or a copy of the teaching scene. Current `SampleScene` is dirty and must not be saved/modified for this pilot.

## Goal / input mode

Demonstrate a far target selected and pulled by bare tracked hands on Quest. Baseline mode: `Pull Interactable To Hand`, pinch. This means the Meta ISDK hand path, not the controller `DistanceGrabInteractor` path.

## Preconditions and existing rig

Per Unity MCP, the active rig already includes bare-hand interactors:

- Left: `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft/Interactors/Hand and No Controller/DistanceHandGrabInteractor`
- Right: corresponding `ComprehensiveInteractorsRight/.../DistanceHandGrabInteractor`

They reference their Hand/HMD, wrist/grab origin, pinch/palm points and frustums; `HandGrabApi` assigned. Inspected `Movement` field was null. The separate controller path is `.../Controller and No Hand/ControllerDistanceGrabInteractor` (`DistanceGrabInteractor`). Do not add another hand interactor unless a future copied-scene inspection proves one missing.

## Proposed disposable-scene procedure (future authorized implementation)

1. Preserve the dirty `SampleScene`. Create a scene copy/new scene, e.g. `Assets/Scenes/Lesson4_DistanceHandGrab_Pilot.unity`, in a separately authorized implementation phase. Confirm exactly one OVR rig, one Locomotor and one EventSystem; verify copied references point inside the copy.
2. Add one new Capsule as a disposable target. Do not use `ControlCanvas`, `PowerCell`, `BatteryDock` or the existing task objects.
3. Inspect Capsule `Rigidbody`, `CapsuleCollider` and `Grabbable`/pointable refs. Local Unity menu entry is `GameObject/Interaction SDK/Add Distance Grab Interaction`; wizard source: `Library/PackageCache/com.meta.xr.sdk.interaction@b0ce09a959ae/Editor/QuickActions/Scripts/DistanceGrabWizard.cs`.
4. Select **Hands** for `Add Required Interactor(s)` (DeviceTypes). Existing bare-hand rig is present; do not choose controller-only for this lesson and do not duplicate a rig.
5. Assign/confirm `Rigidbody` and `Grabbable` (`IPointableElement`). Optional wizard fields: `Time Out Snap Zone`; `Hologram Mesh` conditional for Pull. Choose `Distance Grab Type = Pull Interactable To Hand`; choose Pinch in `Supported Grab Types` if that option is present in the actual v207 wizard UI. Review `Auto Generate Collider` and the generated collider before Create.
6. Before Create, screenshot the actual wizard. After Create, inspect Capsule for `DistanceHandGrabInteractable`, `Grabbable`, Rigidbody/collider and all object/hand/movement references. Verify the wizard did not add a duplicate interactor. Do not assume generated Movement configuration; inspect it.
7. Only after distance-only baseline, optionally add near `HandGrabInteractable` to a duplicate target and check priority/conflicts separately.

Fields confirmed in local wizard source: `Add Required Interactor(s)` (`DeviceTypes`), `Rigidbody`, `Grabbable` (`IPointableElement`), optional `Time Out Snap Zone`, optional `Hologram Mesh`, `Distance Grab Type` (`Grab Relative To Hand`, `Pull Interactable To Hand`, `Manipulate In Place`), `Supported Grab Types`, `Auto Generate Collider`. Conditional visibility may differ. Audit did not execute the Quick Action.

## Future acceptance checks (not performed)

### Editor/runtime

- [ ] Pilot is separate; exactly one rig/Locomotor/EventSystem; no missing refs.
- [ ] Bare-hand interactors remain the input source; no generated duplicates.
- [ ] Capsule has reviewed Rigidbody, collider, Grabbable, DistanceHandGrabInteractable and movement/provider refs.
- [ ] In a later authorized Play Mode, both hands pinch-select the far object, pull, move, release; feedback and collider are stable.
- [ ] Console has no errors relevant to this interaction.

### Quest

- [ ] In a later authorized build/deploy, confirm app starts and tracked bare hands are active.
- [ ] Test left and right pinch, pull/hold/reposition/release. Record what was observed, headset and build version.
- [ ] Separately compare controller route only if lesson requires; don’t infer from Editor config.

### Regressions on copy

- [ ] Baseline near hand grab.
- [ ] ControlCanvas Poke and Ray clicks (panel unchanged by pilot).
- [ ] Floor and ControlStation hotspot teleport.
- [ ] Left-stick smooth locomotion.
- [ ] PowerCell snaps into BatteryDock and task state responds.
- [ ] No duplicate rig, EventSystem, Locomotor, hands or interactors.

No check above was run. `EDITOR_PLAY_MODE_NOT_TESTED`; `QUEST_NOT_TESTED`.
