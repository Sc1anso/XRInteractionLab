# Two-handed manipulation setup

## Reused sample asset

`L4_TwoHandedObject` is an instance of the local package sample `StonePolyhedron.prefab` at:
`Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/StonePolyhedra/StonePolyhedron.prefab`.
It was not modeled from scratch. The package sample provides its mesh, collider, Rigidbody, Grabbable/interaction setup and `GrabFreeTransformer`. Leave the source prefab read-only.

```text
Lesson4_AdvancedInteractions
└── L4_TwoHanded_Exercise   position (2.8, 0, 4.6)
    └── L4_TwoHandedObject  local position (0, 0.45, 0), scale (0.6,0.6,0.6)
```

## Reuse steps for students

1. In Project window navigate to **Packages > Meta XR Interaction SDK > Runtime > Sample > Objects > Props > StonePolyhedra** and drag `StonePolyhedron.prefab` into the scene.
2. Create a parent empty named `L4_TwoHanded_Exercise`; position it `(2.8,0,4.6)`. Parent the instance, rename it `L4_TwoHandedObject`, and set its local position `(0,0.45,0)` and scale `(0.6,0.6,0.6)`.
3. In the root `Grabbable` confirm **Max Grab Points = 2**; **Transfer On Second Selection** unchecked; **Add New Points To Front** unchecked. Rigidbody points to the object’s Rigidbody; **Kinematic While Selected** and **Throw When Unselected** checked; **Force Kinematic Disabled** unchecked.
4. Verify **One Grab Transformer** and **Two Grab Transformer** each reference the local `GrabFreeTransformer` on the same object. Both fields were assigned to the same local component in the saved scene.
5. `GrabFreeTransformer` position/rotation axes are unconstrained. Scale axes are constrained, relative, with limits `1` to `3` (local sample configuration). Scaling behavior has not been tested at runtime.
6. Keep this exercise separate from `ControlCanvas`; do not use its two-hand scale configuration on the movable UI.

## Validation and limits

The Grabbable/transformer references and Max Grab Points value were statically inspected. **EDITOR_CONFIGURED; QUEST_NOT_TESTED.** Actual simultaneous two-hand translation, rotation, one-hand behavior, selection transfer and constrained scale need Quest verification. Screenshot `Screenshots/05_TwoHandedObject_SceneView.png` shows the object in Scene View. `Screenshots/06_EditorWindow_Lesson4Hierarchy.png` shows the Unity window hierarchy but the Inspector is focused on the thumbs-up exercise, not the two-hand object. A genuine two-hand Inspector screenshot is **SCREENSHOT_MISSING**.
