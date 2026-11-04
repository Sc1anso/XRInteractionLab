# Hand tracking foundation and status indicators

## Existing data route

The project's existing `OVRComprehensiveInteractionRig` and hand objects are reused. `L4_HandTrackingStatusIndicator` references the existing left/right ISDK `Hand` components and raw `OVRHand` components. The spheres use raw OVR tracking and confidence state; the ISDK `Hand` components remain part of the existing interaction data chain. This does not create a second hand subsystem or infer controller mode.

## Quest observation and filtered data

The installed SDK rig includes `LastKnownGoodHand`, which can preserve the last usable pose for interactions when raw tracking quality drops. For a status indicator that should reflect actual raw tracking, assign the existing `OVRHand` components from `OVRHandDataSourceLeft` and `OVRHandDataSourceRight` to the indicator. The spheres use raw OVR status: dark when data is invalid or the hand is untracked, orange when tracked but low-confidence, and green when tracked with high confidence. Keep the existing `LastKnownGoodHand` components enabled for the interaction pipeline.

Hierarchy added:

```text
Lesson4_AdvancedInteractions
└── L4_HandTrackingStatus
    ├── L4_LeftTrackingIndicator  (Unity Sphere)
    └── L4_RightTrackingIndicator (Unity Sphere)
```

Sphere positions in scene coordinates: left `(-0.7, 1.6, 2.5)`, right `(0.7, 1.6, 2.5)`. `L4_HandTrackingStatus` is at `(0,0,0)`. Colors in `L4_HandTrackingStatusIndicator`: not tracked `(0.22,0.25,0.30,1)`, low confidence `(1,0.58,0.08,1)`, high confidence `(0.16,0.82,0.36,1)`. The script uses a `MaterialPropertyBlock`, not a new material asset.

## Recreate the primitives and wiring

1. Create/locate `Lesson4_AdvancedInteractions` in the Hierarchy; add an empty child named `L4_HandTrackingStatus`.
2. Select the status root. Choose **GameObject > 3D Object > Sphere** twice, rename the objects `L4_LeftTrackingIndicator` and `L4_RightTrackingIndicator`, and set the positions above. Keep each as a visible MeshRenderer object.
3. Add `L4_HandTrackingStatusIndicator` to the root. Assign the existing left/right `Hand` references, the corresponding raw `OVRHand` components from `OVRHandDataSourceLeft/Right`, and the two Sphere Renderers. Do not add an OVRHand component, input module, or another rig.
4. Save and check references/Console. The status colors are based on raw OVR flags: dark for invalid/untracked, orange for tracked/low-confidence, green for tracked/high-confidence.

## Static vs live verification

Static wiring is configured. The instructor confirmed the raw hand tracker reports loss when hands are behind the back. The updated sphere colors still need visual confirmation in a new Quest build. The script does not show pinch state or controller/hand switching.

Screenshot status: the older filenames `Screenshots/02_HandTrackingStatus_Overview.png` and `Screenshots/02_HandTrackingStatus_Indicators.png` are not verified as present. The current Lesson 4 manual manifest lists B01–B04; all remain **MISSING_MANUAL_CAPTURE** until found and visually checked.
