# XRInteractionLab — Project & Workflow Retrospective

**Scope:** read-only retrospective for preparing a future project-specific `AGENTS.md`. No Unity scene, script, package, project setting, build or presentation was modified for this report. The only file created for this task is this report.

**Evidence labels**

- **Verified from current files:** read directly from repository configuration, serialized assets, source files or Git metadata on 2026-11-13.
- **Documented historical state:** stated in a dated project report, but not re-read from a live Unity Editor during this task.
- **Instructor-reported runtime result:** the instructor described a Quest test; Codex did not perform that test.
- **Inference/recommendation:** a conclusion or proposed practice, not a verified past event.

## 1. Executive Summary

The project is a Unity 6.3 Android/OpenXR XR lab built incrementally in one teaching scene, `Assets/Scenes/SampleScene.unity`. The current package manifest pins Meta XR Core, Interaction SDK OVR integration and Haptics to **207.0.1**; Unity OpenXR is **1.18.0**, XR Hands **1.7.3** in the lock file, Input System **1.18.0**, and URP **17.3.0**. The scene combines a shared OVR rig and earlier lesson interactions with isolated Lesson 4 exercise roots.

The repository includes substantive Lesson 3 and Lesson 4 implementation reports, configuration tables, slide instructions, test checklists and screenshot registers. These are useful evidence, but their chronology matters: older audits conflict with later implementation reports. The latest relevant Lesson 4 matrix supersedes earlier “not implemented” snapshots. The current Unity Editor could not be queried because the Unity MCP handshake at `127.0.0.1:8080` failed. Accordingly, this report does not claim that the current open scene, active build target, dirty state, or current runtime matches the last saved reports.

The current Git worktree has a pre-existing modification to `Assets/Scenes/SampleScene.unity`. Its diff appears to adjust the nested `ISDKExampleMenu` prefab instance layout and active UI states. Do not discard or overwrite it. The `main` branch is at `c1cdc31` (`pt4`), matching `origin/main` at the time checked.

For Lesson 5, first re-establish live Editor truth and inspect the passthrough/menu configuration. The direct manifest does not list a separate MRUK package, so do not assume MRUK is installed. Preserve the single-scene progression and earlier interactions, use installed v207 component names, separate saved configuration from runtime claims, and document exact steps and test status.

## 2. Verified Project Configuration

| Item | Current-file evidence | Finding / limit |
|---|---|---|
| Project root | Current working directory | `C:\Users\Scianso\Documents\GitHub\XRInteractionLab` |
| Unity Editor version | `ProjectSettings/ProjectVersion.txt` | `6000.3.9f1`, revision `7a9955a4f2fa` |
| Render pipeline | `Packages/manifest.json`, `ProjectSettings/GraphicsSettings.asset`, `Assets/Settings/` | URP 17.3.0 is installed and a custom render pipeline asset is configured. Mobile and PC URP assets/renderers exist. The live active quality/renderer selection was not queried. |
| XR provider/configuration | `Packages/manifest.json`, `Assets/XR/`, `ProjectSettings/XRSettings.asset` | OpenXR 1.18.0 and XR Management 4.5.3 are locked. Project has OpenXR loader assets and Android/Standalone loader settings. Current Editor build-target selection is unknown. |
| Meta packages | `Packages/manifest.json`, `Packages/packages-lock.json` | `com.meta.xr.sdk.core` 207.0.1; `com.meta.xr.sdk.interaction.ovr` 207.0.1 (which brings Interaction SDK); `com.meta.xr.sdk.haptics` 207.0.1. No automatic package operations were performed. |
| XR/Unity packages | Manifest and lock | Input System 1.18.0; XR Hands 1.7.3; OpenXR 1.18.0; XR Management 4.5.3; XR Core Utils 2.5.3; URP 17.3.0; UGUI 2.0.0; Unity Test Framework 1.6.0. |
| Other notable dependencies | Manifest/lock | AI Navigation 2.0.16, ProBuilder 6.0.9, Timeline 1.8.13, Visual Scripting 1.9.12, Unity MCP package from CoplayDev Git URL `#main`. The MCP dependency is not a fixed commit in the manifest. |
| Android target | `ProjectSettings/ProjectSettings.asset`, Android manifest and historical reports | Android is the Quest platform configured in project files and prior reports. Android minimum SDK 32 and target SDK 34 are serialized. Current Editor active target was not queried. |
| OpenXR feature evidence | `Assets/XR/Settings/OpenXR Package Settings.asset` | Hand Tracking Subsystem and Meta Quest Touch Plus profile are enabled in Android settings according to serialized configuration. Verify in Editor before relying on it. |
| Meta device/passthrough config | `Assets/Oculus/OculusProjectConfig.asset`, `Assets/Plugins/Android/AndroidManifest.xml` | Serialized config includes Quest device types and passthrough support set to Supported. Manifest contains passthrough optional feature and hand tracking declarations. Regenerate/inspect using the installed Meta tooling after future settings changes; do not infer runtime passthrough from manifest alone. |
| MRUK | Direct manifest/lock search | No separate MRUK package is listed in the inspected dependency files. Whether any MRUK code arrived transitively or through untracked/imported assets was not established; check Package Manager and `Assets/` before Lesson 5. |
| Main scene / build scene | `Assets/Scenes/`, `ProjectSettings/EditorBuildSettings.asset` | Only `Assets/Scenes/SampleScene.unity` is in the main scene folder and the only enabled build scene found. Do not mistake imported package Example Scenes for project build scenes. |
| Assemblies/tests | Repository search | No project-owned `.asmdef` or test source was found in the inspected tree. Unity Test Framework is installed; that alone does not establish an authored or executed automated test suite. |

### Git and preservation state

- Git branch: `main`; HEAD `c1cdc31 pt4`; origin branch was `origin/main` at the same commit during inspection.
- `git status --short` before report creation: ` M Assets/Scenes/SampleScene.unity`.
- The current scene diff was inspected. It consists of serialized prefab-instance overrides under `ISDKExampleMenu`, including RectTransform/layout and UI active-state changes. This is consistent with menu layout work, but the intended outcome was not independently confirmed.
- No reset, checkout, restore, clean, commit, branch change, or scene save was performed. Any future Editor session must preserve this existing change.

## 3. Project Structure

Important directories and files:

| Location | Role |
|---|---|
| `Assets/Scenes/SampleScene.unity` | Continuing teaching scene, also the sole enabled build scene. |
| `Assets/Scripts/` | Project-owned C# scripts, including lesson task, diagnostics and Lesson 4 feedback scripts. |
| `Assets/Scripts/Lesson4/` | Lesson 4 status, pose-feedback and controller-haptics scripts. |
| `Assets/InteractionSDK/` | Project-level interaction assets, including a comprehensive interactor prefab. |
| `Assets/Samples/` | Imported Unity/Meta sample content. Some directory names include an invisible Unicode character, so discover exact paths rather than typing assumed paths. |
| `Assets/Materials/`, `Assets/Settings/` | Project materials and URP assets/renderers. |
| `Assets/XR/` | OpenXR loaders and package settings. |
| `Assets/Oculus/` | Meta/Oculus project configuration. |
| `Assets/Plugins/Android/AndroidManifest.xml` | Android manifest content used by the project. |
| `Packages/manifest.json`, `Packages/packages-lock.json` | Direct dependency declarations and resolved package versions. |
| `ProjectSettings/` | Unity project, build, graphics, input and XR settings. |
| `Documentation/`, `Lesson4_Audit/`, `Lesson4_Work/` | Project reports, audit records, slide instructions, checklists and screenshot registers. |
| `Builds/`, `Logs/` | Build/log-related project folders; no current build was run for this retrospective. |

### Main scene hierarchy, last documented Editor inventory

The following is **historical**, from the November 2026 Lesson 4 audits, not freshly queried from Unity MCP:

```text
SampleScene
├─ Directional Light
├─ Global Volume
├─ Environment
│  └─ Floor / lesson environment objects
├─ ControlStation
│  └─ ControlCanvas (movable world-space UI; Poke/Ray interactions)
├─ EventSystem
├─ LightController
├─ OVRCameraRig
│  └─ TrackingSpace
│     └─ OVRComprehensiveInteractionRig
│        ├─ OVRHmd
│        ├─ OVRHands / OVRHandDataSourceLeft|Right / hand visuals
│        ├─ OVRControllers
│        ├─ ComprehensiveInteractorsLeft|Right
│        └─ Locomotor and locomotion interactors/settings
├─ FloorTeleportSurface
├─ ISDKExampleMenu
├─ Lesson4_AdvancedInteractions
│  ├─ DistanceHandGrab_Exercise
│  ├─ L4_HandTrackingStatus
│  ├─ L4_GrabPose_Exercise
│  ├─ L4_ThumbsUp_Exercise
│  ├─ L4_TwoHanded_Exercise
│  ├─ L4_HandGrabUse_Exercise
│  ├─ L4_GrabSurface_Exercise
│  └─ L4_Throw_Exercise
├─ HandLeft PointerPose
└─ HandRight PointerPose
```

Previous Editor audit counted one `OVRCameraRig`, one `OVRComprehensiveInteractionRig`, one `Locomotor`, and one root `EventSystem`. That count is not certified for the current unsaved working tree. The root-level floor teleport, environment floor teleport interaction and hotspots have appeared in previous inventories; exact current relationships should be re-read live.

### Current versus historical configurations

The scene file on disk and its Git diff are current-file evidence. Hierarchy/component details above are historical report evidence. No reliable live `isDirty` or active-scene result is available in this session; the Editor may have unsaved in-memory changes beyond the file diff.

## 4. Development History — Lessons 1–4

### Lesson 1 — First VR Experience

- **Documented/intended:** initial XR setup, Meta XR packages, Interaction Rig and grabbing.
- **Git evidence:** `df168aa OVRCameraRig Switch` documents the project’s migration direction from Unity XR camera rig to `OVRCameraRig`; earlier commits include `17df3ed first commit` and scene updates.
- **Current architecture:** OVR rig and comprehensive interaction architecture are the documented baseline.
- **Unknown:** there is no single authoritative Lesson 1 implementation report in the current report set; exact original object sequence and Inspector values cannot be reconstructed confidently from commit subjects alone.

### Lesson 2 — Poke, Ray, UI and Snap

- **Current serialized/documented features:** `ControlCanvas` has Poke/Ray UI interaction paths. `PowerCell`/`BatteryDock` and snap station objects support the snap exercise. These remain dependencies for later regression checks.
- **Git evidence:** `850969b added snap`, `725abfe lesson 3 impl` and subsequent scene commits.
- **Architecture:** UI interaction and object snap are built on Meta Interaction SDK components in the shared scene, not a separate XR Interaction Toolkit rig.
- **Unknown:** exact historical construction steps are not fully captured in a dedicated Lesson 2 report. Existing scene state and later reports are better evidence than inferred click history.

### Lesson 3 — Locomotion, Movable UI and Multi-step Tasks

- **Documented implementation:** floor/hotspot teleportation, controller smooth locomotion/turning, movable world-space `ControlCanvas`, and a multi-step PowerCell task.
- **Scene dependencies:** `OVRCameraRig` / `OVRComprehensiveInteractionRig`, `Locomotor`, teleport surfaces, `ControlCanvas`, `PowerCell`, `BatteryDock`, snap interactables and root EventSystem.
- **Scripts:** `Assets/Scripts/PowerCellTaskManager.cs`, `Assets/Scripts/PowerCellTaskFeedback.cs`, and `Assets/Scripts/LightController.cs`.
- **Task manager pattern:** serialized references to grab/hand-grab/snap interactables and UnityEvents, with event subscription/unsubscription in `OnEnable`/`OnDisable` and explicit task states. Feedback script exposes methods such as marking task progress/completion.
- **Important later fix:** a runtime locomotion report records that floor movement required the teleportable layer to be included for the appropriate locomotion/player collision path; the user later reported thumbstick movement worked after the layer-mask fix. See `Lesson4_Work/Reports/LOCOMOTION_RUNTIME_DIAGNOSTIC.md` and `04_SLIDE_INSTRUCTIONS_FULL.md`. Teach the exact local object/mask after rechecking the saved scene rather than copying a generalized “add layer” instruction.
- **Limits:** historical test documents distinguish Editor configuration from instructor Quest outcomes. No independent present-day test was run here.

### Lesson 4 — Advanced VR Interactions

The later configuration matrix is the most complete summary: `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md`, supported by `01_REMAINING_FEATURES_IMPLEMENTATION_LOG.md`, `04_SLIDE_INSTRUCTIONS_FULL.md`, `03_GAPS_BLOCKERS_AND_DECISIONS.md` and `QUEST_TEST_CHECKLIST_FINAL.md`.

| Feature | Documented implementation and source | Status/evidence nuance |
|---|---|---|
| Distance Hand Grab | `Lesson4_AdvancedInteractions/DistanceHandGrab_Exercise/L4_DistanceGrabCapsule`; root collider/Rigidbody/Grabbable; child interaction components include both `DistanceHandGrabInteractable` and generic `DistanceGrabInteractable`, movement provider and reticles. Existing bare-hand interactors are distinct from controller routes. | Instructor reported left/right pinch selection, pull, hold and release on Quest. The capsule felt visually oversized. Historical Quick Action options were not captured; do not state it is exclusively hands-only. |
| Hand tracking status | `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`; paired left/right indicators, raw `OVRHand` validity/tracked/confidence drives status colors while ISDK Hand refs remain for interaction data. | User supplied Quest observations/logs; status colors were adjusted to react to raw hand tracking. Development logs are not Lesson content. “Yellow” is only the low-confidence state; a hand hidden behind the back may be untracked/black instead. |
| Custom Hand Grab Pose | `L4_GrabPoseTool` scene instance from Meta Torch sample; preauthored normal/mirrored poses. Recorder available at `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`. | No course-authored pose collection or newly recorded custom pose confirmed. Pose recorder explanation is documented; actual recording remains pending a tracked-hand session. Grab-pose authoring is distinct from pose recognition. |
| Thumbs-up pose recognition | Left/right v207 `ThumbsUpPose` sample instances and feature/shape/orientation active states, wrappers and `L4_ThumbsUpFeedback` callbacks. | Instructor reported recognition works on Quest. It is a static pose recognizer, not a temporal gesture sequence. |
| Two-handed manipulation | `L4_TwoHandedObject`, from Meta StonePolyhedron sample; `Grabbable` supports two grab points and uses local `GrabFreeTransformer` refs for one- and two-hand manipulation, scale limits and a respawn threshold. | Instructor reported translation/rotation/scaling worked; an early respawn threshold at Y=0.3 reset the object too soon. It was changed to Y=-1.0 and the instructor later reported the behavior worked. Do not apply this setup to `ControlCanvas`. |
| Hand Grab Use | `L4_HandGrabUse_SprayBottle` copied from the v207 HandGrabUse sample; paired hand grab/use interactables, filters, `WaterSpray`, particle and audio events. | Instructor reported spray and audio work on Quest. A use action is separate from selecting/grabbing. |
| Grab Surface | `L4_GrabSurface_Torch`, based on a v207 hand-grab example with normal/mirror hand interactables and `CylinderGrabSurface` pose data. | Instructor tested and reported behavior indistinguishable from the other Torch interaction in the chosen trial; document this observation rather than promising a visible difference. |
| Throw | `L4_ThrowStone`, based on StonePolyhedron; Grabbable, controller/hand interaction routes, dynamic Rigidbody and respawn handling. | Instructor reported throw works. It initially was not selectable until the correct interaction route was identified. |
| Basic and advanced controller haptics | `L4_ThrowStone`, `Oculus.Haptics.HapticSource`, imported `switch_on.haptic`, and `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs`; mode selector retains an OVRInput comparison and routes to the actual selecting controller. | Reports record compilation and serialized references; instructor reported Quest left/right feedback, amplitude/frequency comparison, basic/advanced mode comparison, no release vibration, and throw regression. This is controller haptics, not bare-hand vibration. |

The Lesson 4 example assets are version-dependent. Historical reports identify sample sources under the Meta Interaction SDK v207 sample package; do not edit package cache/sample originals. Sample-derived objects in the scene should be treated as independent scene copies/instances and their provenance should remain documented.

### Historical and superseded information

The `Lesson4_Audit/` and early `Lesson4_Work/` reports include read-only snapshots before the full Lesson 4 implementation and older package-absent statements about Haptics. Later files explicitly supersede them after the instructor installed Haptics SDK 207.0.1. Similarly, early screenshot manifests/audits conflict with later reports recording zero accepted screenshots and missing evidence IDs. Treat the newest dated report as status authority, but preserve discrepancies instead of deleting history.

## 5. Established Development Workflow

### Evidence-backed patterns

1. **Continue the same teaching scene.** Lessons build on `SampleScene.unity`; Lesson 4 content is grouped under `Lesson4_AdvancedInteractions` with one root per feature. This keeps the lab incremental while separating demonstration targets.
2. **Prefer SDK components and samples before custom systems.** Distance interaction, pose recognition, hand-grab use, surfaces, transformers and Haptics use Meta XR SDK v207 components/sample patterns. Custom scripts are small feedback/status/task adapters where Inspector configuration alone did not cover the desired behavior.
3. **Keep lesson targets independent.** The StonePolyhedron is a separate two-hand target; reports explicitly warn that scaling it on `ControlCanvas` could break Poke/Ray. The throw target is separate from the PowerCell task. This isolation is a concrete preservation strategy.
4. **Treat Quick Actions as version-specific setup tools.** Reports record the local menu/action and resulting component graph. Historical choices that were not captured are marked inferred/unknown. Do not re-run a Quick Action on a configured object just to recover its dialog.
5. **Record exact references and values.** Lesson 4 reports include component paths, serialized refs, values, event targets, asset origins, and status tags. This was motivated by earlier student setup failures from missing/unspecified Inspector references.
6. **Separate interaction from feedback.** Examples include PowerCell task state vs light feedback, thumbs-up recognizer events vs indicator methods, and grab selection vs haptic clip playback. Haptic mode selection prevents the OVRInput and Haptics SDK paths from firing together.
7. **Debug with observable runtime data when static setup is insufficient.** User-provided Quest log excerpts were used for hand tracking and locomotion. The records distinguish raw OVR tracking fields from filtered ISDK hand validity. Diagnostic logging was explicitly excluded from lesson slides.
8. **Test changes incrementally on Quest.** The instructor reported testing each feature (distance grab, thumbs-up, two-hand, hand-use, throw and haptics) after builds. These are instructor-reported results, not tests run by this retrospective.
9. **Document screenshots by evidence purpose, not just decoration.** The history includes Inspector/Hierarchy captures and strict capture instructions. Automated attempts produced bad desktop/multi-monitor/minimized-window captures; later workflow requests direct manual capture and requires honest missing-evidence labels.

### Conventions not fully established

- A uniform Git checkpoint/commit cadence is not evident; the current scene has an uncommitted change. A before-change backup plus a clean, scoped diff is a recommended improvement, not a verified past rule.
- Not every feature has a complete click-by-click historical action log. Current component state is often better known than the original sequence of clicks.
- A single canonical status file was not consistently maintained across all intermediate audits. Recommend one “current configuration” report with dated change log and links to historical reports.

## 6. Coding and Architecture Conventions

Representative current project-owned scripts include:

- `Assets/Scripts/PowerCellTaskManager.cs`
- `Assets/Scripts/PowerCellTaskFeedback.cs`
- `Assets/Scripts/LightController.cs`
- `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`
- `Assets/Scripts/Lesson4/L4_ThumbsUpFeedback.cs`
- `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs`
- `Assets/Scripts/XRTrackingDiagnostics.cs` (diagnostic script asset; latest report says the temporary logger component was removed from the scene, but current scene attachment was not live-verified)

### Observed patterns

- MonoBehaviours use descriptive file/class names, generally PascalCase; Lesson 4 scripts use an `L4_` prefix.
- Inspector dependencies are commonly private `[SerializeField]` fields, while UnityEvent targets are public parameterless methods.
- `PowerCellTaskManager` and controller haptics use event subscription in `OnEnable` and unsubscription in `OnDisable`, preventing duplicate/stale subscriptions across enable cycles.
- Feedback callbacks are small and specific (`MarkInProgress`, `OnPoseRecognized`, etc.). `L4_HandTrackingStatusIndicator` uses `MaterialPropertyBlock` rather than changing shared material assets.
- Null checks are mixed: newer Lesson 4 feedback code is defensive; older `LightController`/task code is less uniform. Improve only when editing the relevant script; no broad refactor is justified by this review.
- Namespaces are generally omitted for project scripts. There is no project-owned `.asmdef` in the inspected tree.
- Runtime logging exists for diagnostics but should not be copied into student code unless observability is a stated learning objective.

### Useful Lesson 5 guardrails

- Put scene references in serialized fields and assign them visibly; avoid `FindObjectOfType`/global lookup for core rig or passthrough references when an explicit Inspector reference is available.
- Use an event-driven UnityEvent or SDK event for a discrete toggle/action; avoid per-frame polling for passthrough toggle behavior.
- Keep MR environment state, interaction state and feedback state understandable as separate responsibilities.
- Null-check optional MRUK/scene-data references because scene understanding may be unavailable, denied, not scanned or not yet loaded.
- Verify exact v207 APIs and Inspector labels in package source before writing scripts or instructions; do not copy examples from a newer Meta version without reconciliation.

## 7. Testing and Verification Practices

The reports demonstrate a layered validation approach, but its evidence comes from different sources:

| Level | What it establishes | Project evidence/status |
|---|---|---|
| Static file/config inspection | Package versions, serialized scene fields, source references, manifest/project settings | Performed for this retrospective. Current Editor memory was not available. |
| Unity Editor serialized/Inspector validation | Components, exact refs, duplicate counts, scene dirty/saved state | Used in prior Unity MCP audits, but not available now because MCP connection failed. Historical reports are not a substitute for current revalidation. |
| Script compilation/Console | C# and asset compile status at that point | Lesson 4 Haptics report says compilation completed with zero Console errors. This is historical, not a current compile run. |
| Editor Play Mode / simulator | Interaction behavior under simulated/editor input | No evidence of a comprehensive automated simulator suite. Several reports explicitly say no Play Mode during static phases. Current result: not performed. |
| Android build/install | Packaging and deployment success | Build logs and user reports exist historically; that alone does not prove interaction correctness. This task ran no build. |
| Physical Quest | Actual tracking/input/rendering/haptics behavior | Instructor-reported results exist for named Lesson 4 features. Codex did not perform or observe device testing in this task. |
| Logs/diagnostics | Runtime values, e.g. hand tracking fields, input axis/event counts, player velocity | Instructor supplied logcat excerpts in prior conversation, documented in `LOCOMOTION_RUNTIME_DIAGNOSTIC.md` and Lesson 4 updates. Development debugging evidence, not lesson procedure. |
| Screenshots | Visual proof of actual Inspector/menu state | Older capture efforts included invalid images; latest Lesson 4 docs report missing accepted evidence. Do not cite a screenshot without verifying the actual file. |

No authored project test suite was found in the inspected search, despite `com.unity.test-framework` being installed. Do not state that the project has zero tests conclusively if files are outside the searched scope; no test files or `.asmdef` were found in the inspected project tree.

### Status vocabulary recommended for future reports

Use separate labels: `STATIC_CONFIG_VERIFIED`, `EDITOR_COMPILE_VERIFIED`, `EDITOR_PLAYMODE_TESTED`, `SIMULATOR_TESTED`, `ANDROID_BUILD_INSTALLED`, `QUEST_TESTED_BY_INSTRUCTOR`, `NOT_TESTED`, `BLOCKED`. Include who ran the test, date, build identifier, and expected/observed result. Never treat compilation or a successful build as proof of hand tracking, passthrough, locomotion or haptic behavior.

## 8. Asset and Prefab Management

- The project imports Meta XR Interaction SDK sample scenes and prefabs under `Assets/Samples/`; exact names can contain a zero-width space in “Interaction SDK”. Use `rg --files`/Project search instead of typing a visually identical path.
- Sample assets used by Lesson 4 include Torch, StonePolyhedron, ThumbsUpPose, HandGrabUseExamples, HandGrabExamples and Haptics `switch_on.haptic`. Their package origin and SDK version are recorded in `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md`.
- The project uses both imported samples and scene-level copies/instances. Keep package sample originals read-only; if students need customization, make a project-owned copy/variant with clear provenance. Verify prefab overrides before applying changes.
- Earlier lesson objects (`ControlCanvas`, `PowerCell`, `BatteryDock`, teleport surfaces and `ISDKExampleMenu`) are working teaching dependencies and should be preserved. Reusing them in a new MR activity risks coupling/regression; prefer a separate L5 target or explicitly test and document any intended reuse.
- Lesson-specific code is organized under `Assets/Scripts/Lesson4/`; scene exercise objects are grouped under `Lesson4_AdvancedInteractions`. This is an established Lesson 4 pattern; a matching `Lesson5_...` root/folder is a recommendation, subject to instructor approval and actual scene state.
- No separate MRUK dependency is listed in the current manifest. Do not create steps that assume a MRUK prefab or component exists until Package Manager and samples are checked in Unity.

## 9. Documentation Practices

### Existing artifacts located

- Root-level/project docs: `WORK_PROGRESS.md`, `UNITY_IMPLEMENTATION_REPORT.md`, `UNITY_VERIFICATION_REPORT.md`, `HANDOFF_LEZIONE_3_4.md`, `SCREENSHOT_REGISTER.md`, `PRESENTATION_QA_REPORT.md`, `ASSET_QUALITY_REPORT.md`.
- `Lesson4_Audit/`: read-only audit snapshots, scene/rig inventory, feature feasibility, source notes and screenshots guidance.
- `Lesson4_Work/Reports/`: baseline, implementation log, configuration matrix, gaps/blockers, full slide instructions, Quest checklist, screenshot manifests and final QA summary.
- `Documentation/Backups/` and `Lesson4_Work/backup/`: historical scene backup locations.

### Observed documentation conventions

- Markdown reports record scene hierarchy paths, component names, serialized fields, exact references, asset origins and test results.
- Statuses differentiate static setup from Editor/runtime/Quest testing. Updates sometimes explicitly supersede older snapshots.
- Slide-ready instructions use English; instructor speaker notes in earlier presentation work were Italian. Screenshot manifests use IDs and expected content.
- Reports include known limitations (e.g. custom pose recording pending, gesture sequence not configured, haptics only on controllers).
- The weakness is fragmentation: multiple reports carry overlapping status and some historical claims conflict. A new canonical Lesson 5/future lesson summary should link to evidence and mark an “as of” date rather than silently rewrite history.

### Recommended standardized implementation report

For each feature, keep one record with:

1. **Objective / learning outcome / prerequisite.**
2. **Evidence and environment:** Unity, Meta packages, active scene, date, Git status, `isDirty`/saved state.
3. **Change scope:** files/assets created or modified, backup path, prefab origin.
4. **Before/after hierarchy:** exact scene path, GameObject names and Transform values.
5. **Configuration table:** GameObject, fully-qualified component, Inspector section/field, observed value/default-vs-changed, object/asset reference path.
6. **Interaction/event graph:** source event → target component → callback/action, controller/hand route.
7. **Scripts:** responsibility and public serialized refs; include full source only where slide/course requirements need students to reproduce it.
8. **Reproducible student steps:** menu/action, selected object, component, field/value, expected result.
9. **Validation:** compilation, static references, Editor/Play Mode/simulator/build/Quest—each separately attributed.
10. **Screenshots/evidence:** filename, hash, selected object, fields shown, evidence provenance and QA state.
11. **Regression checks, known issues, rollback, unresolved questions.**

## 10. Development Environment and Available Tools

- **Operating system:** Windows 11 per the supplied environment instructions; not independently queried by this report.
- **Shell:** PowerShell command execution was available and used for read-only file/Git inspection.
- **Git:** installed and usable. Repository ownership initially required a per-command `safe.directory` override; no global Git configuration was changed.
- **Unity Editor:** project version is known from `ProjectVersion.txt`; the Editor was not launched. Prior build logs show a Unity Hub installation under `C:\Program Files\Unity\Hub\Editor\6000.3.9f1\Editor`, but installation state was not checked in this task.
- **Unity MCP:** project dependency is present in `Packages/manifest.json`. The configured MCP endpoint did not complete its handshake at `http://127.0.0.1:8080/mcp` during this task; no live Unity interaction was performed. Do not infer that the Editor or MCP is generally unavailable from one failed session.
- **PowerPoint MCP:** used in the broader course workflow per conversation and existing presentation reports; not required or called in this retrospective. Current tool-session availability was not verified.
- **Snipping Tool/computer use:** earlier work attempted desktop screenshots and encountered captures including multiple monitors or minimized Unity; later workflow deliberately switched to instructor-captured screenshots. No screenshot was captured in this retrospective.
- **ADB/Quest:** logcat excerpts were supplied by the instructor in prior work. Current ADB executable/device connectivity was not checked.
- **Build/test scripts:** no dedicated project build or test script was identified in the inspected tree. `Builds/` and `Logs/` folders exist, but this task ran neither.

## 11. Existing Risks and Technical Debt

### Confirmed or directly documented

1. **Uncommitted scene edit:** `SampleScene.unity` has a current Git diff. Preserve it and resolve/document it before adding Lesson 5 changes.
2. **Live Editor truth unavailable in this session:** the Unity MCP handshake failed. Active scene, dirty state, current counts and in-memory overrides are unknown.
3. **Single-scene coupling:** all lessons share one scene and rig. Lesson roots isolate content, but project-wide inputs, layers, canvas and locomotion still couple features.
4. **Version-sensitive SDK/sample content:** instructions and imported samples are Meta XR 207.0.1. Current online Meta docs may describe newer APIs/labels.
5. **Parallel hand/controller interaction paths:** an object may have hand and controller interactables, and the rig has separate interactor routes. Be explicit about which route the lesson uses.
6. **Sample-derived scene content:** package samples are dependencies; source prefabs/scenes should not be modified. Imported sample assets may be unavailable if samples are removed.
7. **Pose recording incomplete:** custom Lesson 4 grab-pose recording is not confirmed. The imported Torch poses are sample-authored.
8. **Gesture sequence not part of the teaching scene:** sample availability is not implementation.
9. **Screenshot evidence gaps:** latest Lesson 4 reports contain missing/uncaptured evidence entries. Earlier manifests conflict; actual PNGs must be verified before citation.
10. **Runtime outcomes are instructor-reported:** no Quest test was run in this retrospective. State these as attributed observations, not current validation.

### Lesson 5-specific risks to check before implementation

- Passthrough support being set to `Supported` and an Android manifest feature declaration do not alone guarantee a visible passthrough layer. Validate camera clear/alpha, layer compositing, OVRManager configuration, menu switch, assigned camera/HMD references and Quest runtime separately.
- Prior menu launch failures were linked in the conversation to a missing/wrong `HmdRef` relationship in the menu’s `CenterEyeAnchor` path; the instructor later confirmed the menu and VR/MR switch worked after correcting it. Reinspect exact current serialized refs before teaching this as a universal fix.
- Do not instruct students to set a UI label such as “Underlay” unless that exact property exists in SDK 207.0.1. The installed component/package source is authoritative; prior guidance established that compositing details may be managed internally by the SDK version.
- `OVRProjectConfig` passthrough support, generated Android manifest and other build settings can diverge. After a configuration change, inspect the generated/current manifest and the Unity project settings; do not edit generated build output as the durable source of truth.
- MRUK/Scene API may require package installation, scene permission/data, room scan and device/runtime prerequisites. A direct dependency is not present in the manifest; installation/import must be a separately authorized and version-checked step.
- Protect Lesson 3 teleportation/layer-mask setup, locomotion, ControlCanvas and PowerCell/BatteryDock snap when adding spatial anchors or scene-aware objects.

No fix was applied in this audit.

## 12. Recommended AGENTS.md Rules

Each item is labeled by evidence class: **Existing convention**, **Recommended improvement**, or **Lesson 5 requirement**.

### 12.1 Permanent project rules

- **Existing convention:** Continue development in `Assets/Scenes/SampleScene.unity`; keep exercise content under a named lesson root and use a separate target per new interaction when practical.
- **Existing convention:** Preserve one OVR camera/comprehensive interaction architecture. Before changes, count rigs, locomotors, EventSystems and relevant interactors in the live scene.
- **Recommended improvement:** Start every change by recording `git status --short`, active scene, `isDirty`, package versions and relevant hierarchy. If live MCP is unavailable, use static files only and label live facts unknown.
- **Recommended improvement:** Back up the scene outside `Assets/` before structural changes, record backup timestamp/hash, inspect the diff after changes, and never reset/clean/restore user work.
- **Existing convention:** Keep earlier lesson interactions intact; explicitly regression-check teleport, smooth locomotion/turning, ControlCanvas Poke/Ray and PowerCell/BatteryDock snap when changes can affect them.

### 12.2 Unity and Meta XR conventions

- **Existing convention:** Use Meta XR Interaction SDK/OVR Integration components, not Unity XR Interaction Toolkit as a silent substitute.
- **Existing convention:** Match installed SDK 207.0.1 component names, fields, Quick Actions and sample implementation. Check local source and Inspector; document any mismatch with online docs.
- **Recommended improvement:** Do not re-run a Quick Action on an already configured target. Inspect its result and references; use a disposable object only if a wizard’s options genuinely need demonstration.
- **Existing convention:** Keep controller and tracked-hand interaction routes distinct. Do not infer controller ownership from availability; resolve the actual selecting interactor when routing controller-only feedback.
- **Lesson 5 requirement:** Verify current OVRManager, `OVRPassthroughLayer`, menu `HmdRef`/camera wiring, composition behavior, `OVRProjectConfig` and Android manifest together. Do not claim MR visibility from a single checkbox.
- **Lesson 5 requirement:** Verify MRUK package/version and required samples/data in Package Manager before writing a workflow. If missing, state the dependency; do not invent a prefab/component.

### 12.3 Scene and prefab management

- **Existing convention:** Do not modify imported package samples. Use scene instances, project-owned copies or variants and document source/version.
- **Existing convention:** Keep high-risk multi-hand scaling on isolated objects, not `ControlCanvas`.
- **Recommended improvement:** Add one feature at a time and inspect the scene diff for unintended serialized changes. Keep asset edits under their feature’s folder and use `L5_` names for new lesson-owned objects/scripts.
- **Lesson 5 requirement:** Place MR test objects in a separate L5 root and preserve the menu’s VR/MR toggle and all prior lesson roots.

### 12.4 Coding standards

- **Existing convention:** Use focused MonoBehaviours, private serialized references, public methods for UnityEvent callbacks, and `OnEnable`/`OnDisable` pairing for event subscriptions.
- **Recommended improvement:** Null-check optional SDK/data references; keep one script responsible for one visible behavior; avoid frame polling for discrete event behavior. Use clear `L5_` prefixes and XML/comments where a script is part of the student procedure.
- **Existing convention:** Use `MaterialPropertyBlock` for per-object status-color changes rather than changing shared sample material assets.
- **Lesson 5 requirement:** Handle unavailable MRUK/scene data, missing permissions and not-yet-loaded room data gracefully. Do not make scene understanding a hidden prerequisite for opening the base VR scene.

### 12.5 Testing and verification

- **Recommended improvement:** Report static serialized checks, compilation, Editor Play Mode, simulator, Android build/install and physical Quest tests as separate outcomes, including test operator/date.
- **Existing convention:** Quest outcomes reported by the instructor must be labeled `QUEST_TESTED_BY_INSTRUCTOR`, not as Codex-run.
- **Recommended improvement:** For MR, test passthrough-off VR and passthrough-on MR paths independently, then test toggling in both directions and relaunch behavior on a physical device.
- **Recommended improvement:** Never treat a successful build or no compile errors as evidence that camera passthrough, scene scan or hand tracking works.

### 12.6 Documentation and screenshots

- **Existing convention:** Record exact Hierarchy path, component, field, value/reference, asset origin, event chain and expected behavior.
- **Existing convention:** Separate slide content from development diagnostics; do not include temporary logs unless the lesson teaches debugging.
- **Recommended improvement:** Keep one dated canonical implementation matrix and append a change log instead of duplicating conflicting “current” reports.
- **Recommended improvement:** Screenshot records should contain actual filename/path, selected object, visible fields, caption, hash and evidence status. Never invent a screenshot or cite one not verified on disk.
- **Existing convention:** The course slide workflow uses English slide content; instructor notes have been Italian. Preserve this distinction unless the course owner changes it.

### 12.7 Change control and approvals

- **Existing convention:** Do not silently install or upgrade Meta packages, change XR architecture, remove existing exercises, or overwrite scene/prefab work.
- **Recommended improvement:** Ask before package installation, broad project-setting changes, or destructive changes. Continue independent read-only analysis where possible.
- **Recommended improvement:** If Unity MCP is unavailable, do not launch Unity or alter state unless the task specifically authorizes that. Report what static inspection can and cannot establish.

## 13. Open Questions and Missing Evidence

1. What is the current active Unity scene, `isDirty` state, current duplicate count and in-memory menu configuration? **Unknown; Unity MCP handshake failed.**
2. Is the uncommitted `ISDKExampleMenu` prefab-instance diff intentional and already saved in the Editor? Git confirms the file change, not Editor memory or intent.
3. Which quality-level URP asset/renderer is active on the current Android build target? The URP setup exists; current selection was not read from live Editor.
4. Is a separate MRUK package/sample available through Package Manager or local untracked assets? It is absent from direct manifest/lock entries; current Editor Package Manager was not queried.
5. Was a custom Lesson 4 hand-grab pose ever recorded after the reports that say pending? No evidence in the latest report set inspected.
6. Which Lesson 4 screenshot PNGs currently exist and pass visual QA? Reports identify missing evidence; this task did not inventory/inspect image files.
7. What exact tests were run on each headset build, and with what app/build identifiers? User reports describe outcomes, but no complete build/test ledger was found.
8. Are any feature branches or local-only scene changes present beyond the one Git diff? The local `main` status showed one tracked modification; untracked status had no additional entry at the time checked.

## 14. Recommended Next Steps for Lesson 5

1. In Unity, verify the open project, `SampleScene.unity`, dirty state and exact current hierarchy. Preserve the existing scene diff and make a backup before any authorized implementation.
2. Confirm `OVRCameraRig`, `OVRComprehensiveInteractionRig`, `OVRManager`, `ISDKExampleMenu`, its passthrough toggle and `HmdRef`/CenterEyeAnchor references. Verify passthrough support/permission settings and generated Android manifest using SDK 207.0.1 local tooling.
3. Inspect the installed Package Manager state for MRUK and Scene API, exact package versions, samples, permissions and required runtime setup. Do not use documentation for a newer version as if it were local truth.
4. Define a minimal Lesson 5 acceptance path: launch in VR with passthrough off; enable passthrough; verify scene understanding availability/permission; place or classify one isolated L5 object; disable passthrough and confirm VR remains usable.
5. Implement incrementally in a new lesson root, preserving all Lesson 1–4 objects. Record exact fields, event refs and package sample provenance in the canonical implementation report.
6. Validate static references and compilation first; then use the Quest for MR-specific runtime checks. Record each test separately and retain a regression pass for teleport/layer mask, locomotion, UI Poke/Ray and PowerCell snap.
7. Only after evidence and instructions are complete, write/update the project-specific `AGENTS.md`; this retrospective does not create it.

## Evidence Index

Primary current-file evidence:

- `ProjectSettings/ProjectVersion.txt`
- `Packages/manifest.json`
- `Packages/packages-lock.json`
- `ProjectSettings/EditorBuildSettings.asset`
- `ProjectSettings/XRSettings.asset`
- `ProjectSettings/GraphicsSettings.asset`
- `Assets/XR/Loaders/` and `Assets/XR/Settings/`
- `Assets/Oculus/OculusProjectConfig.asset`
- `Assets/Plugins/Android/AndroidManifest.xml`
- `Assets/Settings/`
- `Assets/Scripts/`
- `Assets/Scenes/SampleScene.unity` and its current Git diff

Primary historical project evidence:

- `UNITY_IMPLEMENTATION_REPORT.md`
- `UNITY_VERIFICATION_REPORT.md`
- `WORK_PROGRESS.md`
- `HANDOFF_LEZIONE_3_4.md`
- `Lesson4_Audit/01_SCENE_AND_RIG_INVENTORY.md`
- `Lesson4_Work/Reports/00_RECONCILED_BASELINE.md`
- `Lesson4_Work/Reports/01_REMAINING_FEATURES_IMPLEMENTATION_LOG.md`
- `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md`
- `Lesson4_Work/Reports/03_GAPS_BLOCKERS_AND_DECISIONS.md`
- `Lesson4_Work/Reports/04_SLIDE_INSTRUCTIONS_FULL.md`
- `Lesson4_Work/Reports/05_FINAL_STATIC_QA.md`
- `Lesson4_Work/Reports/QUEST_TEST_CHECKLIST_FINAL.md`
- `Lesson4_Work/Reports/LOCOMOTION_RUNTIME_DIAGNOSTIC.md`
- Git commits listed in section 2.

