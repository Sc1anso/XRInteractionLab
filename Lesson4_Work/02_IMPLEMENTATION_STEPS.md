# Lesson 4 Pilot — Implementation Steps

## Added hierarchy

```text
Lesson4_AdvancedInteractions
└── DistanceHandGrab_Exercise
    └── L4_DistanceGrabCapsule
        └── ISDK_DistanceHandGrabInteraction
```

The capsule’s world/local position is **(2.3, 1.05, 2.8)**, rotation **(0, 0, 0)**, scale **(1, 1, 1)**. The existing floor top is approximately y=0.05, so the default capsule collider rests at floor height. Its horizontal distance from the rig origin is approximately 3.62 m, beyond arm’s reach while remaining in the open teaching area. The capsule uses Unity’s built-in mesh/material; no project material asset or package was added.

## Quick Action used

Installed v207 menu: **GameObject > Interaction SDK > Add Distance Grab Interaction**.

Settings applied to the selected `L4_DistanceGrabCapsule`:

- **Add Required Interactor(s): Hands.** The v207 source checks for an existing `DistanceHandGrabInteractor` with an `IHand` on the same GameObject before adding one. The live rig had such interactors on both sides, so no new rig/interactor objects were created.
- **Distance Grab Type: Pull Interactable To Hand** (`InteractableToHand` in the local source).
- **Supported Grab Types: All**. In the installed enum, `All` is Pinch + Palm (`3`); pinch is supported.
- **Auto Generate Collider: Generate Collider**. A CapsuleCollider was already present, so the wizard did not add another collider.
- No Time Out Snap Zone was added. The wizard’s default mesh reticle references the Capsule’s MeshFilter.

The v207 wizard was used to add the required target components, then its `Create` routine was invoked once. It produced exactly one `ISDK_DistanceHandGrabInteraction` child.

## Components and references

On `L4_DistanceGrabCapsule`:

- `CapsuleCollider`: radius 0.5, height 2, Y axis, `isTrigger=false`.
- `Rigidbody`: mass 1, `useGravity=false`, `isKinematic=true` (wizard defaults for distance grab).
- `Oculus.Interaction.Grabbable`: Rigidbody reference points to this Capsule’s Rigidbody; target Transform points to this Capsule; kinematic while selected is enabled.

On `ISDK_DistanceHandGrabInteraction`:

- `Oculus.Interaction.HandGrab.DistanceHandGrabInteractable`: Rigidbody and PointableElement references point to the Capsule’s Rigidbody and Grabbable; supported grab flags are `3` (Pinch + Palm); movement provider points to the local `MoveTowardsTargetProvider`.
- `Oculus.Interaction.DistanceGrabInteractable`: Rigidbody and PointableElement reference the same Capsule components. This is part of the v207 template; no controller-only interactor was added.
- `Oculus.Interaction.MoveTowardsTargetProvider`.
- `Oculus.Interaction.DistanceReticles.ReticleDataMesh` referencing the Capsule’s MeshFilter and Transform.
- `Oculus.Interaction.DistanceReticles.ReticleDataIcon` using the package’s reticle-dot texture.

## Reproduction for students

1. Select the new Capsule and choose **GameObject > Interaction SDK > Add Distance Grab Interaction**.
2. Set **Add Required Interactor(s)** to **Hands** only when hand Distance Grab interactors are not already present. In this project they are already present; verify before selecting a device option, because v207 can add missing interactors.
3. Set **Distance Grab Type** to **Pull Interactable To Hand** and **Supported Grab Types** to **All** (or Pinch if an exercise specifically restricts the gesture).
4. Keep **Generate Collider** enabled. If the target already has a collider under its Rigidbody, the wizard reuses it.
5. Fix only the missing Rigidbody and Grabbable dependencies, then press **Create** once.
6. Inspect the Capsule’s Rigidbody, Grabbable, and generated `ISDK_DistanceHandGrabInteraction` references before saving.

The scene’s existing near grab, UI, locomotion, teleport and snap objects are not part of this wizard setup.
