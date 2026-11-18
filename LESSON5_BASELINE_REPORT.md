# Lesson 5 — Unity Project Baseline

**Data:** 2026-11-13  
**Scope:** read-only preliminary audit for Mixed Reality / Passthrough / MR Utility Kit / Scene Understanding. No project assets, settings, packages, scenes, or builds were changed.  
**Project:** `C:\Users\Scianso\Documents\GitHub\XRInteractionLab`

## Evidence labels

- **VERIFIED_STATIC** — read from the current project files, serialized scene, or installed package source.
- **HISTORICAL_EDITOR** — recorded by an earlier live Unity audit; not freshly confirmed in this session.
- **INSTRUCTOR_REPORTED_QUEST** — result reported by the instructor; Codex did not repeat the headset test.
- **UNKNOWN** — cannot be established from the files, local package source, or successful live MCP inspection available for this audit.

## Executive summary

The project already contains a static passthrough setup: `SampleScene.unity` serializes an `OVRPassthroughLayer` attached to the `OVRCameraRig`, the active `ISDKExampleMenu` prefab instance has references to that layer and the rig camera, and its `_hmd` reference points into the rig. The scene's OVRManager prefab instance also overrides `isInsightPassthroughEnabled` to `true`. Earlier project reports and the instructor's Quest test say the menu's VR/MR switch worked after correcting the menu's HMD reference.

Scene Understanding is **not ready in the current project configuration**. The direct package list and local PackageCache do not contain MRUK; `OVRProjectConfig.asset` has `sceneSupport: 0` and `anchorSupport: 0`; the Android manifest has no Scene permission declaration. Meta's v207 editor code requires Anchor Support for Scene Support. The installed Meta XR Core SDK's current docs for MRUK say to configure Scene Support and the Scene startup permission, configure Passthrough as required for the passthrough path, then update the Android manifest. None of those settings were changed here.

The initial Unity MCP handshake failed, but the server became available during the audit. A subsequent read-only MCP inspection succeeded and is the source for the live Editor facts below. The Editor reported `SampleScene.unity` active and clean (`isDirty=false`), not in Play Mode, and Android as the active build platform. No build or project mutation was performed.

## 1. Unity and Git status

| Check | Result | Evidence / limitation |
|---|---|---|
| Unity version | **VERIFIED_STATIC:** Unity `6000.3.9f1`, revision `7a9955a4f2fa` | `ProjectSettings/ProjectVersion.txt` |
| Scene currently open in Unity | **VERIFIED_EDITOR:** `Assets/Scenes/SampleScene.unity`, active and loaded | Unity MCP editor/scene state. |
| Unsaved Editor changes (`isDirty`) | **VERIFIED_EDITOR:** `false` | Unity MCP `manage_scene(action=get_active)`. |
| Git branch / HEAD | **VERIFIED_STATIC:** `main`, `538965a` (`added AGENTS.md`) | Read-only Git commands. |
| Git worktree | **VERIFIED_STATIC:** clean at audit start (`git status --short` returned no entries) | No Git state was changed. |
| Active build target | **VERIFIED_EDITOR:** Android | Unity MCP project/editor info. This does not establish successful device runtime. |
| Build scene list | **VERIFIED_STATIC:** only enabled scene is `Assets/Scenes/SampleScene.unity` | `ProjectSettings/EditorBuildSettings.asset` |

## 2. XR and render configuration

| Area | Current serialized configuration | Status |
|---|---|---|
| XR packages | `com.unity.xr.openxr` `1.18.0`; XR Management `4.5.3`; XR Hands `1.7.3` resolved in lock file; Input System `1.18.0` | **VERIFIED_STATIC** from `Packages/manifest.json` and `Packages/packages-lock.json` |
| Meta packages | Core `207.0.1`; Interaction OVR integration `207.0.1`; Haptics `207.0.1` | **VERIFIED_STATIC** from manifest/lock |
| Rig architecture | Exactly one `OVRCameraRig`, one `OVRComprehensiveInteractionRig`, one `Locomotor`, and one root `EventSystem` | **VERIFIED_EDITOR** by live Unity MCP hierarchy/component searches. |
| OpenXR loader/settings | OpenXR loader assets and OpenXR settings are present under `Assets/XR/`; OpenXR settings are referenced by Build Settings. | **VERIFIED_STATIC**. Effective runtime provider and feature initialization require Editor/device verification. |
| Render pipeline | URP `17.3.0`; mobile/PC pipeline assets exist under `Assets/Settings/` | **VERIFIED_STATIC**. Active Android quality/renderer selection was not live-queried. |
| Android target information | Android manifest targets Horizon OS SDK 207 and declares Quest device types. Unity Player Settings serialize Android min SDK 32 and target SDK 34. | **VERIFIED_STATIC**; build target selection unknown. |

The scene and project use Meta OVR/Interaction SDK; there is no evidence that Lesson 5 should switch to Unity XR Interaction Toolkit. Preserve this architecture.

## 3. Rig, passthrough and VR/MR menu

### Live Unity Editor inspection

Unity MCP identified the project instance `XRInteractionLab@2c63e50729ba7056`, Unity `6000.3.9f1`, active scene `Assets/Scenes/SampleScene.unity`, 12 root objects, Android build platform, Edit Mode (not Play Mode), `isDirty=false`, and no compilation in progress. The Editor was unfocused at inspection time; that has no bearing on the serialized scene state. No live Console error audit or runtime test was performed.

The 12 scene roots are `Directional Light`, `Global Volume`, `Environment`, `ControlStation`, `EventSystem`, `LightController`, `OVRCameraRig`, `FloorTeleportSurface`, `ISDKExampleMenu`, `Lesson4_AdvancedInteractions`, `HandLeft PointerPose`, and `HandRight PointerPose`.

The single rig has `OVRCameraRig`, `OVRManager`, `OVRHeadsetEmulator`, and `OVRPassthroughLayer` on its root. The one `OVRComprehensiveInteractionRig` is at `OVRCameraRig/OVRComprehensiveInteractionRig`; its children include `OVRHmd`, `OVRHands`, `OVRControllers`, `ComprehensiveInteractorsLeft`, `ComprehensiveInteractorsRight`, hand/controller visuals, and `Locomotor`. Unity MCP component searches returned exactly one each for rig, comprehensive rig, locomotor, root EventSystem, and passthrough layer. This is a current static Editor inventory, not evidence of runtime behavior.

### `OVRCameraRig` and `OVRManager`

The serialized scene contains one root `OVRCameraRig` prefab instance. Live Unity MCP inspection additionally confirmed the root components and these current OVRManager values:

- `isInsightPassthroughEnabled = true`.
- `requestScenePermissionOnStartup = false`.
- `requestPassthroughCameraAccessPermissionOnStartup = false` (this is the camera-access permission field, not the general passthrough feature permission).
- `trackingOriginType = 1`.
- `enableMixedReality = false` (do not conflate this legacy mixed-reality capture setting with the passthrough layer or MRUK Scene API).

The serialized scene overrides include:

- `isInsightPassthroughEnabled = 1` on the OVRManager component.
- Tracking origin override `_trackingOriginType = 1`.
- Center-eye camera clear mode override `m_ClearFlags = 2` and background RGBA set to `(0, 0, 0, 0)`.
- An `OVRPassthroughLayer` component on the rig root, serialized enabled, with `hidden = 0`.

The layer is live and enabled on the rig root with `hidden=false`, `textureOpacity=1`, and `edgeRenderingEnabled=false`. These are Editor configuration facts, not a runtime pass/fail result.

### `OVRPassthroughLayer` and menu references

The active root `ISDKExampleMenu` has the components `MRPassthrough`, `HmdRef`, `OVRButtonActiveState`, `ActiveStateSelector`, `SelectorUnityEventWrapper`, and `SceneLoader`, among others. Live Unity MCP confirmed these serialized references:

- `_layer` → the `OVRPassthroughLayer` on the rig.
- `_camera` → the rig camera reference (Center Eye camera in the rig prefab).
- `_hmd` → `OVRHmd` on the rig.
- The menu instance is serialized active.

`MRPassthrough._passThroughToggle` references `ToggleButton_Switch`; `_layer` references the rig's `OVRPassthroughLayer`; `_camera` references `CenterEyeAnchor`. The Toggle is active and interactable and currently has `isOn=false` in Edit Mode. The live `HmdRef._hmd` field references `OVRHmd`.

Earlier project documentation says the HMD reference was corrected to `OVRHmd`; the instructor then reported that both the menu and VR/MR switch worked on Quest. This remains **INSTRUCTOR_REPORTED_QUEST**, not a fresh runtime test. Unity MCP exposed empty `WhenSelected` / `WhenUnselected` event lists on `SelectorUnityEventWrapper`; the current passthrough component references are verified, but do not infer an additional callback chain from those empty lists. The user-facing toggle behavior should be retested on device after any future changes.

### Project-level passthrough setting discrepancy

`Assets/Oculus/OculusProjectConfig.asset` serializes:

- `_insightPassthroughSupport: 1`, interpreted by the installed v207 source as **Supported**.
- `insightPassthroughEnabled: 0`.

The second field is marked obsolete in local SDK source `Library/PackageCache/com.meta.xr.sdk.core@d4cd875f54ee/Editor/OVRProjectConfig.cs`; it has no effect as a current support setting. The effective support enum is `insightPassthroughSupport` / `_insightPassthroughSupport`. Thus the project is set to **Supported**, not **Required**. Meta's current MRUK getting-started instructions specify Passthrough Support `Required` for that documented MRUK setup. Do not change it during this baseline; compare the requirement against the intended deployment and confirm in the current Project Setup Tool.

The Android manifest contains `<uses-feature android:name="com.oculus.feature.PASSTHROUGH" android:required="false" />`. This is consistent with optional feature declaration, but does not alone establish runtime passthrough availability.

## 4. MRUK and Scene Understanding

### Installed / available versions

- **Installed:** Unity MCP Package Manager listed 51 installed packages and did not include `com.meta.xr.mrutilitykit`; no MRUK directory was found under the inspected `Assets/` or `Library/PackageCache/` paths. MRUK is **not installed in the current project**.
- **Available but not installed:** Unity MCP Package Manager search returned `com.meta.xr.mrutilitykit` version `209.0.0`; the official Meta package page also lists the `207.0` line. The project uses Core `207.0.1`; compatibility between that installed SDK and registry version `209.0.0` was not established. The package identifier is `com.meta.xr.mrutilitykit`. No package was installed.
- **Sample availability:** MRUK sample scenes from v76 onward live in the separate `oculus-samples/Unity-MRUtilityKitSample` repository, rather than in the MRUK package. No such sample project or `Assets/MRUKSamples` folder was found in this repository. Do not assume examples are already imported.
- **Unity compatibility:** Meta's sample guide states Unity `6000.0.66f2` or newer; this project is `6000.3.9f1`, so it meets that stated Unity-version floor. This does not by itself establish complete package/project compatibility.

### Current Scene API prerequisites

| Requirement | Current evidence | Result |
|---|---|---|
| Scene Support | `Assets/Oculus/OculusProjectConfig.asset`: `sceneSupport: 0` (`FeatureSupport.None`) | **Missing / blocker for Scene Understanding.** |
| Anchor Support | Same file: `anchorSupport: 0` (`Disabled`) | **Missing.** Local Meta v207 editor code says Anchor Support is required for Scene Support and enables anchors when Scene Support is selected. |
| Scene permission request | Live `OVRManager.requestScenePermissionOnStartup=false`; the Android manifest has no Scene-related permission entry. With `sceneSupport=None`, the v207 Inspector disables the Scene startup-permission setting. | **Not configured / verify after enabling Scene Support; not changed.** |
| Scene API data and permission on Quest | No MRUK loader/sample is installed; no headset test performed. | **Not tested.** Device room data, permission grant and scan state remain future checks. |
| Passthrough support | Configured as Supported at project level; scene layer/menu refs exist. | Passthrough path is **partially configured and historically reported working**. For MRUK's documented setup, Meta currently specifies Required support plus startup permission/configuration and manifest update. |
| Android manifest | Existing manifest has optional passthrough feature but no scene permission entry. | **Needs regeneration/review after any authorized Scene Support change.** Do not hand-edit generated output as a substitute for project configuration. |

The local SDK source supports these conclusions: `OVRProjectConfig.cs` declares `sceneSupport` default `None` and `anchorSupport` default `Disabled`; `OVRProjectConfigEditor.cs` marks Anchor Support as required for Scene Support and auto-enables it when Scene Support is selected; `OVRManagerEditor.cs` only enables the Scene startup-permission field when Scene Support is not `None`.

## 5. Compatibility risks for Lessons 1–4

1. **Do not duplicate the rig or EventSystem.** This audit confirmed one of each principal rig component live; recheck before any L5 mutation because project state can change.
2. **Keep existing VR/MR menu wiring.** `ISDKExampleMenu` references the rig's passthrough layer, camera and HMD; replacing those references or adding a second layer can break the previously working toggle or cause a black/incorrect camera background.
3. **Do not assume project support equals visible passthrough.** Layer, transparent camera clear, menu control, project support, manifest and runtime permission are separate parts of the pipeline.
4. **Keep Lesson 3 interactions intact.** Protect floor/hotspot teleport and teleportable layer masks, left-stick locomotion/turning, movable `ControlCanvas` Poke/Ray, and `PowerCell`/`BatteryDock` snap/task references.
5. **Keep Lesson 4 targets isolated.** Preserve the hand/controller routes, pose examples, two-hand object, spray/use, throw and controller haptics. Do not attach MR placement experiments to `ControlCanvas` or `PowerCell` without a separately approved regression plan.
6. **MRUK is version-sensitive and absent.** Do not write student steps around uninstalled MRUK components, sample paths or Inspector fields. First approve/install a compatible version and inspect its local v207 package/sample implementation.
7. **Scene Understanding is not enabled in the project config.** The missing Anchor/Scene support and lack of Scene permission/manifest setup are concrete blockers, distinct from the existing passthrough feature.

The live structural counts are verified through Unity MCP. Functional regression behavior is not certified by this read-only audit because Play Mode, builds, and Quest tests were not run.

## 6. Findings and remaining checks

### Verified configuration

- Unity project is 6000.3.9f1; direct Meta SDK dependencies are 207.0.1.
- `SampleScene.unity` is the only enabled build scene in serialized Build Settings.
- Live hierarchy has one root OVRCameraRig instance and one each OVRComprehensiveInteractionRig, Locomotor, and EventSystem. The rig has OVRManager and OVRPassthroughLayer; menu layer/camera/HMD refs were read through Unity MCP.
- `OculusProjectConfig` passthrough support value maps to Supported. Its old `insightPassthroughEnabled` bool is obsolete in the installed Core SDK source.
- MRUK is not listed in direct dependencies/lockfile or found in inspected local package/assets directories.
- Scene Support and Anchor Support are unset/disabled; no Scene permission declaration is present in the tracked Android manifest.
- Git worktree was clean at the start; the only untracked change at audit end is this report. No existing tracked file was modified.

### Problems or setup gaps

- MRUK is not installed locally.
- Scene Support and Anchor Support are not enabled in project config.
- Scene permission startup setting is false; the tracked Android manifest has no Scene-related permission declaration.
- Passthrough project support is Supported, while current Meta MRUK guidance describes Required for the referenced setup. The existing menu toggle has historical successful headset evidence, so this is a project-target/configuration decision to verify—not a claim that the present toggle is broken.

### Still unknown / not tested

- Whether the passthrough and menu behave correctly in a new Quest runtime session; historical instructor report is not a fresh test.
- Whether the current build's effective OpenXR/OVR runtime initializes correctly on a headset.
- Console error/warning list was not retrieved during this baseline.
- Whether the Scene permission has previously been requested/granted on the instructor's headset.
- Actual scene capture, room model availability and MRUK runtime behavior on Quest.
- Runtime behavior of the `ToggleButton_Switch` beyond its serialized reference and Edit Mode state (`isOn=false`). Unity MCP showed empty `WhenSelected` / `WhenUnselected` lists on `SelectorUnityEventWrapper`; do not infer a callback from these lists.

## 7. What is available now and what is needed to start Lesson 5

### Available now

- **Passthrough foundation:** OVR passthrough support is declared as Supported, an `OVRPassthroughLayer` is serialized on the OVR rig, the scene has a transparent camera clear/background override, and the menu instance is wired to the layer/camera/HMD references.
- **VR/MR toggle:** present in the existing menu prefab instance; the instructor previously reported it working on Quest after setting the HMD reference. Re-test only when a new runtime build is prepared.
- **Meta XR/OpenXR base:** Core, Interaction OVR integration, Haptics, OpenXR and XR Hands are installed at the versions listed above.

### Required before Scene Understanding / MRUK exercise

1. Before development, recheck `SampleScene`, dirty state, Console and references in Unity; the current baseline found one rig stack and clean scene, but project state can change.
2. Resolve any unsaved scene state without overwriting it; preserve current Git work and take the required backup before implementation.
3. Obtain explicit approval for adding MRUK (AGENTS.md requires approval before installing packages). The official Meta MRUK UPM package page lists 207.0; confirm compatibility with the installed Core 207.0.1 before adding it.
4. Configure and verify Anchor Support, Scene Support, Scene permission request and Passthrough support/permission per the installed SDK and intended Quest deployment. The project's current Scene Support is `None`; the local SDK requires Anchor Support for it.
5. Regenerate/review `AndroidManifest.xml` through the installed Meta tooling after authorized project-config changes, then verify the resulting manifest and build settings. No such changes were made in this audit.
6. Import/use version-matched MRUK samples only after inspecting their version and provenance; sample scenes are separate from the current single-scene build configuration.
7. Add one isolated Scene Understanding demo, then validate static references, compile, Quest Scene permission/data loading and passthrough-on/off behavior, followed by Lesson 1–4 regression tests.

Per `AGENTS.md`, before any structural Lesson 5 scene changes, present the alternatives (new dedicated `Lesson5_MixedReality` scene versus isolated `Lesson5_MixedReality` root in the existing scene) and obtain the instructor's choice. This baseline does not implement either option.

## References

### Project files and source

- `AGENTS.md` — project-specific safety, authorization, Lesson 5 and reporting rules.
- `ProjectSettings/ProjectVersion.txt`
- `Packages/manifest.json`, `Packages/packages-lock.json`
- `ProjectSettings/EditorBuildSettings.asset`, `ProjectSettings/XRSettings.asset`
- `Assets/Scenes/SampleScene.unity`
- `Assets/Oculus/OculusProjectConfig.asset`
- `Assets/Plugins/Android/AndroidManifest.xml`
- `Assets/XR/Loaders/`, `Assets/XR/Settings/`
- Installed Core SDK source: `Library/PackageCache/com.meta.xr.sdk.core@d4cd875f54ee/Editor/OVRProjectConfig.cs`, `Scripts/Editor/OVRProjectConfigEditor.cs`, `Scripts/Editor/OVRManagerEditor.cs`, `Editor/OVRManifestPreprocessor.cs`.
- Prior historical reports: `CODEX_PROJECT_RETROSPECTIVE.md`, `Lesson4_Audit/01_SCENE_AND_RIG_INVENTORY.md`, `Lesson4_Work/Reports/02_CONFIGURATION_MATRIX_FINAL.md`, `03_GAPS_BLOCKERS_AND_DECISIONS.md`, and `QUEST_TEST_CHECKLIST_FINAL.md`.

### Official Meta references checked 2026-11-13

- [MRUK Getting Started](https://developers.meta.com/vr/documentation/unity/unity-mr-utility-kit-gs/) — package installation, Scene Support/Scene permission, Passthrough setup and manifest update guidance.
- [Meta XR MR Utility Kit UPM 207.0](https://developers.meta.com/vr/downloads/package/meta-xr-mr-utility-kit-upm/207.0/?view=full_width) — official package page and v207.0 release notes.
- [MRUK Samples](https://developers.meta.com/vr/documentation/unity/unity-mr-utility-kit-samples/) — sample location from v76 onward and Unity version baseline.

