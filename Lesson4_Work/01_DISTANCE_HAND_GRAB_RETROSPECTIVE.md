# Distance Hand Grab — retrospective inspection

## Status

**STATIC_CONFIGURED; QUEST_NOT_TESTED.** The capsule was already added before the later Lesson 4 modules. This report documents the current saved configuration and prior setup record; it does not claim a live hand interaction.

## Hierarchy and configuration

```text
Lesson4_AdvancedInteractions
└── DistanceHandGrab_Exercise
    └── L4_DistanceGrabCapsule
        └── ISDK_DistanceHandGrabInteraction
```

`L4_DistanceGrabCapsule`: local/world placement recorded in the earlier setup report as position `(2.3, 1.05, 2.8)`, rotation `(0,0,0)`, scale `(1,1,1)`. It is a Unity built-in Capsule with CapsuleCollider and Rigidbody. Rigidbody: mass 1, gravity off, kinematic on. Grabbable references that Rigidbody and target Transform.

`ISDK_DistanceHandGrabInteraction` contains `Oculus.Interaction.HandGrab.DistanceHandGrabInteractable`, `Oculus.Interaction.DistanceGrabInteractable`, `Oculus.Interaction.MoveTowardsTargetProvider`, and package reticle data. The hand-grab interactable references the target Rigidbody/Grabbable pointable element and uses the local movement provider. Supported grab flags recorded in the earlier report are `3` (Pinch + Palm). Do not confuse `DistanceGrabInteractor` (controller route) with `DistanceHandGrabInteractor` (tracked-hand route).

Existing tracked-hand interactors are under:

- `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft/Interactors/Hand and No Controller/DistanceHandGrabInteractor`
- `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsRight/Interactors/Hand and No Controller/DistanceHandGrabInteractor`

The rig was not modified for this exercise. Existing controller branches remain separate.

## Operation record

The previous implementation report says the v207 Quick Action `GameObject > Interaction SDK > Add Distance Grab Interaction` was applied once with device type Hands and pull-to-hand behavior, creating the `ISDK_DistanceHandGrabInteraction` child. That is a historical report, not an independently captured wizard execution. The original wizard view is not present in the project screenshot folder, so its exact dialog state is **not visually verified** here. Do not press Create again on this already configured target.

## Recreate from scratch for students

1. In Hierarchy select the intended parent. Use **GameObject > Create Empty**, name it `Lesson4_AdvancedInteractions`, then create a child empty named `DistanceHandGrab_Exercise`.
2. Select that child and use **GameObject > 3D Object > Capsule**. Rename it `L4_DistanceGrabCapsule`; set Transform Position `(2.3, 1.05, 2.8)`, Rotation `(0,0,0)`, Scale `(1,1,1)`.
3. Inspect its CapsuleCollider. Keep one non-trigger collider. Add/retain one Rigidbody and one Grabbable only as prescribed by the local v207 wizard.
4. Before the wizard, verify the project already has left and right `DistanceHandGrabInteractor` components under the existing `Hand and No Controller` branches above.
5. With the capsule selected, click **GameObject > Interaction SDK > Add Distance Grab Interaction**. In the dialog select the **Hands** device route and **Pull Interactable To Hand**. Keep supported grab type consistent with the lab’s pinch goal. Inspect every v207 label because SDK versions may differ.
6. Create once, then inspect the new child, movement provider, collider, Rigidbody and Grabbable references. Do not request new rig/interactors when existing hand interactors are present.
7. Save the scene and check the Console. Test left and right tracked hands only at the later authorized Quest checkpoint.

## Evidence and limits

Scene-view captures: `Screenshots/01_DistanceGrab_ExistingTarget.png` and `Screenshots/01_DistanceGrab_ExistingTarget-1.png` (near-duplicate retakes; neither displays the wizard). `Screenshots/06_EditorWindow_Lesson4Hierarchy.png` shows the Unity window hierarchy but not the wizard configuration. The menu/wizard screenshot is **SCREENSHOT_MISSING**; see manifest.

No near-grab fallback was established for this object. Do not teach one unless separately configured and tested.
