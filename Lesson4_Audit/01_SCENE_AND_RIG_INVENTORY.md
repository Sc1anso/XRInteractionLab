# Scene and Rig Inventory

**Evidence:** Unity MCP inspection of the active in-memory `SampleScene`; scene reports `isDirty=true`, so live Editor state may differ from saved scene. No Play Mode.

## Root objects and duplicates

Roots: `Directional Light`, `Global Volume`, `Environment`, `ControlStation`, `EventSystem`, `LightController`, `OVRCameraRig`, `FloorTeleportSurface`, `ISDKExampleMenu`.

Observed counts: one `OVRCameraRig`, one `OVRComprehensiveInteractionRig`, one `Locomotor`, one root `EventSystem`. No XRI Camera Rig or XRI locomotion object found. This is active scene scope; it does not prove no duplicate exists in an unrelated prefab/asset.

## Rig paths / references

- `OVRCameraRig`: `OVRCameraRig`, `OVRManager`, `OVRHeadsetEmulator`, `OVRPassthroughLayer`.
- `OVRCameraRig/OVRComprehensiveInteractionRig`: child object; `OVRCameraRigRef` points to parent; `_requireOvrHands=true`; left/right source refs target corresponding OVR hand data sources.
- `.../OVRHmd`: active HMD referenced by `HmdRef` fields.
- `.../OVRHands`: active, two `Hand` components and `HandSkeletonOVR`.
- `.../OVRHands/OVRHandDataSourceLeft|Right`: `FromOVRHandDataSource`, `LastKnownGoodHand`, `OVRHand`.
- `.../OVRHandVisualLeft|Right`: active `HandVisual` visuals.
- `.../ComprehensiveInteractorsLeft|Right`: `Hand`, `Controller`, `HandRef`, `ControllerRef`; handedness 0/1; HMD references `OVRHmd`; hand modification source references `OVRHands`.

### Interactor paths (each side unless noted)

| Route | Path suffix | Component / observed refs |
|---|---|---|
| Bare hand distance | `Interactors/Hand and No Controller/DistanceHandGrabInteractor` | `Oculus.Interaction.HandGrab.DistanceHandGrabInteractor`; hand/HMD refs, wrist/grab origin, pinch/palm points and frustums, `HandGrabApi` assigned; `Movement` null |
| Controller-driven hand | `Interactors/Controller and Hand/DistanceControllerHandGrabInteractor` | `DistanceHandGrabInteractor` in controller-hand route |
| Controller distance | `Interactors/Controller and No Hand/ControllerDistanceGrabInteractor` | `Oculus.Interaction.DistanceGrab.DistanceGrabInteractor`, controller refs/decorator |
| Near hand | `Hand and No Controller/HandGrabInteractor`; `Controller and Hand/ControllerHandGrabInteractor` | separate near-grab paths |
| Ray | `HandRayInteractor`; `ControllerRayInteractor` | active hand/controller routes per side |
| Poke | `HandPokeInteractor`; `ControllerPokeInteractor` | active hand/controller routes per side |

### Locomotion and microgestures

`.../Locomotor` references `OVRHmd` and `OVRControllers`; contains `PlayerController` (`Rigidbody`, `CapsuleCollider`, `CharacterController`, `FirstPersonLocomotor`) and `BodyTeleportInteractor` (`TeleportInteractor`, `TransformsPolyline`, event connection, tag filter). Each hand branch has `MicroGesturesLocomotionHandInteractorGroup` with `HandRef`, `HmdRef`, `OVRMicrogestureEventSource`, `BestSelectInteractorGroup`, `LocomotionEventsConnection`; children include `TeleportMicrogestureInteractor` and `TurnerMicrogesture`, with event wrappers/broadcasters.

## Existing interactables / reuse risks

- `ControlStation/ControlCanvas`: Canvas, CanvasScaler, GraphicRaycaster, Rigidbody, Grabbable and GrabFreeTransformer. One Grab Transformer points to GrabFreeTransformer; Two Grab Transformer is null. Children include `ISDK_PokeCanvasInteraction` (`PokeInteractable`, `PointableCanvas`), `ISDK_RayCanvasInteraction` (`RayInteractable`, `PointableCanvas`), `ISDK_HandGrabInteraction` (`HandGrabInteractable`, `GrabInteractable`). Avoid as first two-hand target: transform changes can break Poke/Ray alignment.
- `Environment/Cube`: Rigidbody, Grabbable, collider; hand-grab and ray-grab children. No DistanceHandGrabInteractable observed.
- `Environment/SnapStation/PowerCell`: Rigidbody, Grabbable, CapsuleCollider, HandGrab child. Existing task object; preserve.
- `Environment/SnapStation`: PowerCellTaskManager, BatteryDock and snap setup; `.../SnapLocationRigidBody/SnapLocation` has SnapInteractable.
- `Environment/Floor/ISDK_TeleportInteraction` and root `FloorTeleportSurface/ISDK_TeleportInteraction`; ControlStation hotspot has TeleportInteractable and ColliderSurface.
- `ISDKExampleMenu/MainMenu/GrabBar`: GazeInteractable, HandGrabInteractable, GrabInteractable, RayInteractable. `CanvasInteractables`: PokeInteractable, RayInteractable, PointableCanvas, GazeInteractable.

## EventSystem and static OVR configuration

Single root EventSystem: `EventSystem`, `InputSystemUIInputModule`, `PointableCanvasModule`, `BaseInput`. Do not add another.

`Assets/Oculus/OculusProjectConfig.asset` configures `ControllersAndHands`; target flags cover Quest 2/Pro/3/3S/VR Glasses. OVRManager simultaneous hands/controllers flags are false. These values cannot tell which mode is active at runtime. Editor-idle `Hand.IsConnected`, `IsHighConfidence`, `IsTrackedDataValid` were false; not Quest evidence.

## Absent from active scene

No `DistanceHandGrabInteractable` target; no ThumbsUp pose-recognition chain; no SequenceActiveState; no Two Grab Transformer assigned to ControlCanvas; no active GazeInteractor; no separate Haptics SDK component. Imported samples do not change this.

**Flags:** `STATIC_AUDIT_PASSED`; `EDITOR_PLAY_MODE_NOT_TESTED`; `QUEST_NOT_TESTED`.

## Superseding follow-up - 2026-11-04

The inventory above is the earlier static audit snapshot. Haptics were subsequently added to `Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone`: controller `GrabInteractable` selection routes to `HapticSource` via `L4_ControllerGrabHaptics` and `ControllerRef.Handedness`. The instructor later saved the scene; Unity MCP confirms `isDirty=false`. No current hierarchy change to the rig is implied by this audit addendum.
