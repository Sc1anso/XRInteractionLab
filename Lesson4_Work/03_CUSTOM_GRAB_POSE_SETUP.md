# Custom hand-grab pose authoring preparation

## Object origin

`L4_GrabPoseTool` is an instance of the Meta SDK package sample Torch prefab, not a hand-modeled object created for this lesson. Local source: `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/Torch/Torch.prefab`. It contains sample Hand Grab pose data and an ISDK grab setup. Package contents are read-only; do not edit the package asset.

Hierarchy:

```text
Lesson4_AdvancedInteractions
└── L4_GrabPose_Exercise
    └── L4_GrabPoseTool   (Torch sample prefab instance)
```

## How students can reuse the object

In the Unity Project window, expand `Packages > Meta XR Interaction SDK > Runtime > Sample > Objects > Props > Torch`, then drag `Torch` into `L4_GrabPose_Exercise` in the Hierarchy. Rename the scene instance `L4_GrabPoseTool`. If the package UI label differs, locate the exact `Torch.prefab` file at the path above; do not duplicate or modify the package source. Current scene uses the package prefab directly.

## Recorder workflow (not executed as a recording)

Local menu: **Window > Meta > Interaction SDK > Hand Grab Pose Recorder**. Local recorder UI has controls labeled **Hand**, **Item**, **Ghost Provider**, **Poses Collection**, with actions **Go to Play Mode and record…**, **Record HandGrabPose**, **Save To Collection**, and **Load From Collection**. Use the locally installed window and verify current field names before teaching; menu/recorder screenshot is missing.

To author a new pose at the future live-hands checkpoint:

1. Open the recorder menu above.
2. Assign the tracked hand, `L4_GrabPoseTool`, suitable Ghost Provider and a writable Poses Collection asset.
3. Enter the recorder’s required Play Mode session with a live Quest/Link hand input.
4. Shape the hand around the tool and use **Record HandGrabPose**; review the saved pose in the collection.
5. Use **Save To Collection** and **Load From Collection** to verify asset persistence, then test mirroring only if the local collection/UI exposes it.

These steps are prepared from the local recorder controls; **no new pose has been recorded or saved**. Status: **POSE_RECORDING_PENDING_QUEST_OR_LINK**. The Torch’s bundled poses are preauthored sample data and are not evidence of a student-recorded pose. Grab pose authoring is not thumbs-up recognition.

Screenshot: `Screenshots/03_CustomGrabPose_TorchTarget.png`, `_Detail.png`, and `-1.png` show the object/result, not recorder clicks or collection fields. Recorder and pose Inspector screenshots are **SCREENSHOT_MISSING**.
