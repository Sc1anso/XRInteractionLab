# Blockers, confidence, and sources

## Confidence/status

- **Verified in Editor/static:** project version 6000.3.9f1, active SampleScene saved/clean, package versions in lock file, added hierarchy, prefab provenance, scene wiring described in this folder, Inspector references queried during implementation.
- **Compiler/Console:** no C# compile errors were present on the final review; Unity MCP emitted a WebSocket “not initialised” warning. The Editor Console may retain earlier unrelated diagnostics described in legacy `03_EDITOR_VALIDATION.md`; do not represent the warning as a Quest runtime result.
- **Not tested:** Play Mode, tracked hand signal, pose recognition, distance pull, two-hand manipulation, locomotion/UI/snap regressions on headset, Quest build/deployment.
- **Blocked for visual documentation:** the saved screenshot collection mainly has Scene View results. Required click-path and Inspector/wizard screenshots are still missing. A genuine Unity-window crop was recovered from the Windows Screenshots folder, but it shows hierarchy and a root inspector only. Snipping Tool UI interaction returned `coordinate input geometry is unavailable`; a separate attempt captured both displays while Unity was in a restored window, so that image was excluded. Unity has since been restored to full screen. Do not fabricate or label any result view as wizard evidence.
- **Pose recording:** pending live hands through Quest/Link. Existing Torch poses are sample data.
- **Haptics:** separate Meta Haptics SDK not found; no installation was attempted. Do not claim bare-hand vibration.
- **Prefab portability:** Torch and StonePolyhedron remain package sample references. Students must use the same Meta XR Interaction SDK 207.0.1 sample package/path. No independent downloadable asset bundle was authored.
- **Scene backup diff:** the pre-existing PowerCell PhysicsMaterial reference reserialization is documented in the prior baseline/change log; inspect before committing if serialized reference identity matters.

## Official references

- Distance Hand Grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-distance-hand-grab-interaction/
- Ghost/reticles: https://developers.meta.com/vr/documentation/unity/unity-isdk-create-ghost-reticles/
- Hand Grab poses: https://developers.meta.com/horizon/documentation/unity/unity-isdk-creating-handgrab-poses/
- Hand pose detection: https://developers.meta.com/vr/documentation/unity/unity-isdk-hand-pose-detection/
- Two-handed grab: https://developers.meta.com/vr/documentation/unity/unity-isdk-two-handed-grab-interaction/
- Transformer examples: https://developers.meta.com/vr/documentation/unity/unity-isdk-transformer-examples-scene/

Use package v207.0.1 source and Inspector as the local authority for labels and fields. Online pages may refer to newer package versions.

## Exact local sample/script sources

- `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/Torch/Torch.prefab`
- `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/StonePolyhedra/StonePolyhedron.prefab`
- `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab`
- Unity menu: `GameObject > Interaction SDK > Add Distance Grab Interaction`
- Pose recorder: `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`
- Lesson scripts: `Assets/Scripts/Lesson4/`

