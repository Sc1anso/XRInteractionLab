# Thumbs-up hand pose detection and visual feedback

## Local SDK source and added hierarchy

The recognizer template is the installed v207 sample prefab:
`Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab`.

```text
Lesson4_AdvancedInteractions
└── L4_ThumbsUp_Exercise
    ├── L4_ThumbsUpIndicator_Left  (Unity Sphere + L4_ThumbsUpFeedback)
    ├── L4_ThumbsUpIndicator_Right (Unity Sphere + L4_ThumbsUpFeedback)
    ├── L4_ThumbsUpRecognizer_Left (ThumbsUpPose prefab instance, hand left)
    └── L4_ThumbsUpRecognizer_Right (ThumbsUpPose prefab instance, hand right)
```

Each sample instance retains the v207 chain: `HandRef`, `SelectorUnityEventWrapper`, `ActiveStateSelector`, `ActiveStateGroup`, `ShapeRecognizerActiveState`, and `TransformRecognizerActiveState`; shape assets are the local `FingersAllClosed.asset` and `ThumbUp.asset`. Both recognizers have side-matched hand/data providers assigned from the existing rig’s `ComprehensiveInteractors[Left|Right]/Features` branches. Persistent selected/unselected UnityEvent listeners connect to the side’s `L4_ThumbsUpFeedback.OnPoseRecognized()` / `OnPoseLost()` methods.

Feedback is gray `(0.28,0.31,0.36,1)` until recognized, green `(0.12,0.88,0.38,1)` when recognized. Indicators are Unity spheres, scale `(0.24,0.24,0.24)`, positions left `(-1.3,1.1,3.2)` and right `(1.3,1.1,3.2)` in the exercise parent local space. Script uses `MaterialPropertyBlock`.

## Recreate the feedback objects

1. Under `L4_ThumbsUp_Exercise`, choose **GameObject > 3D Object > Sphere** twice; name the objects as above. Add `L4_ThumbsUpFeedback` to each and assign its own MeshRenderer.
2. In the Project window find the package’s `ThumbsUpPose.prefab` at the path above. Drag two instances into the exercise parent. Keep one instance for each hand; do not edit the package prefab.
3. For each instance, set `HandRef` to the existing matching hand component and assign the left or right `FingerFeatureStateProvider` and `TransformFeatureStateProvider` from that same side’s existing `Features` branch. These were null on the prefab before the scene-specific wiring; omitting them leaves a broken recognizer chain.
4. In the instance’s `SelectorUnityEventWrapper`, wire the existing selected/unselected events to the corresponding indicator’s `L4_ThumbsUpFeedback.OnPoseRecognized` and `.OnPoseLost` methods. Verify the persistent listener targets and methods in Inspector.
5. Save, check Console and missing refs. A static pose recognizer detects a configured pose; it is not a temporal swipe/sequence gesture.

## Status and evidence

Both sides’ HandRef/provider references and one selected plus one unselected persistent event listener per side were inspected. This is **STATIC_CONFIGURED**; detecting a person’s thumbs-up and changing color are **QUEST_NOT_TESTED**. Scene captures exist (`Screenshots/04_ThumbsUp_Indicators_SceneView.png`); full-resolution Unity hierarchy/Inspector screenshots for prefab fields and events are **SCREENSHOT_MISSING**.

