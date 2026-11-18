# AGENTS.md — XRInteractionLab / LabXR Class Project

> Project-wide instructions for Codex. Apply to every task run from this Unity repository.
> Last prepared: 2026-11-13, using `CODEX_PROJECT_RETROSPECTIVE.md` as a **dated, read-only** evidence source.
> Recheck the live project before acting; descriptions below are not a substitute for the current Unity Editor state.

## 1. Mission and operating priorities

This repository supports an incremental university XR laboratory. Deliver features that are technically correct, easy to inspect in Unity, reproducible by students, and safe for exercises from earlier lessons.

Prioritize, in order:

1. Preserve the instructor's files, unsaved work, scene references, package versions, and working Lessons 1–4.
2. Verify the actual installed SDK and current Editor state; do not fabricate details.
3. Prefer the smallest testable change, using built-in Meta XR facilities when suitable.
4. Document exactly how the instructor and students can reproduce and verify the result.
5. Keep unrelated fixes, refactors, upgrades, and speculative enhancements out of scope.

Use English for student-facing Unity instructions and slide-ready technical content. Italian may be used for instructor-facing discussion and summaries unless the user requests otherwise.

## 2. Project facts — verify before relying on them

These were observed in a **static inspection on 2026-11-13**, not a fresh live Editor audit:

| Item | Observed baseline |
| --- | --- |
| Repository root on instructor's computer | `C:\Users\Scianso\Documents\GitHub\XRInteractionLab` |
| Unity version | `6000.3.9f1` (Unity 6.3) |
| Main teaching/build scene | `Assets/Scenes/SampleScene.unity` |
| Meta Core SDK | `com.meta.xr.sdk.core` `207.0.1` |
| Meta Interaction OVR integration | `com.meta.xr.sdk.interaction.ovr` `207.0.1` |
| Meta Haptics SDK | `com.meta.xr.sdk.haptics` `207.0.1` |
| OpenXR / XR Management | `1.18.0` / `4.5.3` |
| XR Hands / Input System | `1.7.3` / `1.18.0` |
| URP | `17.3.0` (active Android quality/renderer not live-verified) |
| Platform | Android/Meta Quest; active Editor build target not live-verified |
| MRUK | **Not listed as a direct package** in inspected manifest/lock; actual availability unverified |
| Unity MCP | Package present, but handshake at `127.0.0.1:8080/mcp` failed in the retrospective; retry safely when appropriate |
| Automated tests | Unity Test Framework installed; no project-authored test suite identified in inspected tree |

Authoritative files include `ProjectSettings/ProjectVersion.txt`, `Packages/manifest.json`, `Packages/packages-lock.json`, `ProjectSettings/EditorBuildSettings.asset`, `Assets/Oculus/OculusProjectConfig.asset`, `Assets/XR/`, and `Assets/Plugins/Android/AndroidManifest.xml`.

**Critical existing work:** at the date of the retrospective, `main` was at `c1cdc31` and `Assets/Scenes/SampleScene.unity` already had an uncommitted change apparently affecting `ISDKExampleMenu` layout/active states. Treat this as user work, NOT as a defect to revert. Re-run `git status --short` and examine the current diff before every editing phase. Never assume this dated status is still current.

## 3. Protect the existing XR architecture

- The teaching baseline uses `OVRCameraRig` with `OVRComprehensiveInteractionRig` and Meta Interaction SDK / OVR integration. Do **not** silently replace it with Unity XR Interaction Toolkit or add a second competing rig.
- Before scene changes, inspect current counts/relationships for `OVRCameraRig`, `OVRComprehensiveInteractionRig`, `Locomotor`, `EventSystem`, input sources, hand/controller interactors, and the active menu. If the Editor is unavailable, mark these as **not live-verified**.
- Preserve `ControlStation/ControlCanvas`, its world-space UI Poke/Ray interaction, `ISDKExampleMenu`, `PowerCell`, `BatteryDock`, Grab/Snap, floor/hotspot teleportation and its layer filters, smooth locomotion, turning, and all Lesson 4 feature roots.
- Lesson 4 is grouped under `Lesson4_AdvancedInteractions` with isolated exercise targets. Do not put high-risk two-hand scaling on `ControlCanvas` or casually attach new interaction paths to established objects.
- Keep tracked-hand and controller interaction routes distinct; an object can support both. For controller haptics, use the controller associated with the actual selecting interactor; do not imply bare-hand vibrations.
- **Do not run Quick Actions again on already configured objects** merely to inspect a wizard. Read the resulting hierarchy/references; test on a disposable object only with authorization.
- Preserve existing prefab overrides. Do not apply/revert source-prefab overrides without checking their intended effects.
- Never modify Unity package cache or original imported Meta sample assets. Use a project-owned scene instance, copy, or prefab variant and record exact sample origin/version.
- In `Assets/Samples/`, some imported path names contain invisible Unicode characters; discover real paths rather than manually guessing them.

## 4. Work phases and authorization

The user's current teaching priority is **Lesson 5: Mixed Reality & Spatial Understanding**. Lessons 6 and 7 are parked. Do not implement later-lesson features unless explicitly asked.

Default to **read-only discovery** until the instructor authorizes a specific implementation phase. The user authorizing one phase does not authorize all later phases.

For every task:

1. **Understand and scope**: restate objective, expected student-visible result, affected files/objects, required permissions, and acceptance criteria.
2. **Record baseline**: `git status --short`, relevant `git diff`, installed package versions, current scene/Editor dirty state, and selected hierarchies/Inspector references. If any are inaccessible, explicitly distinguish unknowns from inspected facts.
3. **Plan a minimal change**: prefer SDK v207 components and existing project patterns. Identify risks to earlier exercises; request authorization for high-impact steps.
4. **Preserve before changing**: for approved structural scene/prefab edits, save a timestamped backup **outside `Assets/`**, with path and hash, after checking for unsaved Editor changes. A disk backup does not preserve unsaved in-memory edits; obtain an explicit safe handling decision when dirty-state is uncertain.
5. **Implement only the approved slice**: keep scripts and objects feature-scoped; avoid unrelated formatting, refactors, dependency changes, and broad scene serialization churn.
6. **Validate in layers**: static/config checks, Editor compilation, Play Mode/simulator, Android build/install, physical Quest. Report only levels actually exercised.
7. **Review changes**: inspect `git diff` and the resulting scene/Inspector references; confirm pre-existing unrelated edits remain intact.
8. **Document and stop**: produce/update a canonical implementation report and a brief handoff. Do not automatically proceed to the next phase.

Ask for explicit approval before: installing/upgrading/removing packages; modifying XR/Android/URP project-wide settings; changing rigs or input architecture; creating or switching the principal teaching scene; applying/reverting prefab overrides; deleting/moving existing assets; running destructive commands; or building/deploying to a headset if not already authorized by the task.

Never run `git reset`, `git clean`, `git checkout -- <file>`, `git restore`, force operations, branch switches, commits, or pushes without explicit authorization. Do not overwrite an existing `AGENTS.md` or untracked files.

## 5. Unity, C#, and SDK conventions

- Check **installed Meta XR 207.0.1 package code and live Inspector labels** before using API calls, setup wizard names or settings. Online examples may target a different version. Never invent menu items, Inspector fields, object references, or numeric values.
- Favor an existing Meta component, Building Block, Quick Action, prefab, or documented SDK sample when it solves the learning task. Add custom MonoBehaviours only for specific missing behavior.
- Keep a script focused on one purpose. Use descriptive PascalCase file/class names, with `L5_` prefixes for Lesson 5-owned scripts and objects when appropriate (as Lesson 4 uses `L4_`). For approved new scripts, prefer `Assets/Scripts/Lesson5/`.
- Prefer private `[SerializeField]` references assigned and checked in the Inspector over hidden global searches. Expose public methods for explicit UnityEvent callbacks.
- Pair event registrations in `OnEnable` with corresponding unregistrations in `OnDisable`. Prefer events over per-frame polling for discrete input or passthrough switches.
- Keep MR scene state, interaction state, and feedback state conceptually separate. Null-check optional scene/MRUK references and handle unavailable data/permissions gracefully.
- Where object-specific status-color changes are needed, prefer `MaterialPropertyBlock` over editing shared imported materials.
- Do not introduce broad refactors to older scripts simply to standardize style; fix issues only when within approved scope.
- Keep Unity `.meta` GUIDs stable when moving or copying assets. Avoid hand-editing serialized scene/prefab YAML if a supported safe Editor operation is available; explain and seek approval if direct serialized edits are essential.

## 6. Lesson 5 — scope and critical decisions

Learning path: **Passthrough -> MRUK / Scene Understanding -> room visualization -> spatial surface placement -> interactive MR PowerCell Station -> Quest validation**.

### What is already known

- A prior instructor-reported Quest test indicates the existing `ISDKExampleMenu` VR/MR switch operated after fixing a menu `HmdRef` / `CenterEyeAnchor` reference. **This is historical, not a fresh test.** Inspect/retest the existing capability before creating an additional passthrough layer or new toggle.
- Serialized Oculus project config says passthrough support is `Supported`, and the Android manifest has an optional passthrough feature declaration. This does **not** prove runtime passthrough rendering.
- The direct package manifest did **not** list MRUK at the retrospective date. Check Package Manager, lockfile, `Assets/`, current samples, required Scene API permissions, and target Quest model before proposing installation or MRUK-specific hierarchy instructions.
- An `OVRPassthroughLayer` property's availability, compositing/underlay behavior, Camera clear behavior, and menu wiring must be checked against the **local SDK version**. Do not teach an "Underlay" dropdown or other setting unless it actually exists.
- Scene data may be missing, not scanned, not authorized, not loaded, or different across rooms. Plan a reproducible sample/simulated-data option if supported by the installed MRUK version, and a graceful no-data path.

### Preserve prior lessons while changing scene structure

- **Historical baseline:** Lessons 1–4 all evolved within `Assets/Scenes/SampleScene.unity`.
- **Intended Lesson 5 design (not yet implemented):** protect the working VR teaching scene and preferably use a dedicated `Lesson5_MixedReality` scene or otherwise fully isolated L5 exercise root. These are alternative architectures. **Before making scene changes, show a small comparison and obtain the instructor's explicit choice.** Do not assume the new scene already exists.
- If a new scene is approved, make its dependency on the verified shared rig/prefabs explicit, avoid duplicate rigs/EventSystems **within that scene**, and document which scene is enabled in the Android build profile. Never silently replace or change the saved `SampleScene`.
- If continuing the current scene is approved, use an isolated `Lesson5_MixedReality` root and independent L5 targets; preserve the current VR/MR menu and allow returning to the existing VR exercises without broken references.
- Reuse the **PowerCell/BatteryDock behavior**, not necessarily their live scene objects. A project-owned duplicated/variant L5 target is preferable to mutating the validated Lesson 3 task.

### Suggested gates (none automatically authorized)

- **L5.0 — Live baseline:** verify open scene, dirty state, rigs, menu, VR/MR switch, pass-through settings, package status, and preservation plan.
- **L5.1 — Passthrough:** validate or minimally adapt the *existing* toggle; demonstrate VR off -> MR on -> VR off, including relaunch, with clear fallback.
- **L5.2 — MRUK:** check and, **only with approval**, install/configure a compatible MRUK version and its scene permissions/sample data.
- **L5.3 — Scene Understanding:** load scene/room data, show surfaces/labels, handle missing permissions and no room data.
- **L5.4 — Placement:** place one simple independent virtual object on an available physical/simulated surface and verify its transform/alignment.
- **L5.5 — MR PowerCell:** reuse existing Grab/Snap logic in an isolated MR station on a recognized surface.
- **L5.6 — Regression and handoff:** test old VR interactions, capture reliable evidence, prepare the teaching procedure and report.

Never treat an optional/future feature (persistent/shared anchors, Depth API occlusion, real-world physics, passthrough styling, navigation) as required for Lesson 5 unless the instructor expands its scope.

## 7. Validation and evidence rules

Use these exact, separately attributed statuses when applicable:

- `STATIC_CONFIG_VERIFIED` — file/serialized/source facts only.
- `EDITOR_COMPILE_VERIFIED` — actual compile/Console checked.
- `EDITOR_PLAYMODE_TESTED` — actually exercised in Editor Play Mode.
- `SIMULATOR_TESTED` — actually exercised with simulator.
- `ANDROID_BUILD_INSTALLED` — APK deployed; not proof of interaction correctness.
- `QUEST_TESTED_BY_INSTRUCTOR` — instructor supplied device outcome; cite date/build/observation where available.
- `NOT_TESTED` — no test performed.
- `BLOCKED` — specific blocker and next verification step.

Do not call a feature "working" solely from serialized config or compilation. Do not claim Codex physically tested a Quest from an instructor report. Capture expected vs observed results, date, operator, device, build ID when available, and known limitations.

For any change that could affect shared XR configuration, explicitly regression-check or mark untested:

1. VR mode, Passthrough/MR mode, bidirectional toggle and relaunch.
2. Teleport (Floor layer filtering and Hotspot), smooth locomotion and turning.
3. `ControlCanvas` world-space Poke/Ray and movable-panel Grab.
4. PowerCell/BatteryDock Grab/Snap and its state/feedback.
5. Hand and controller input routes used by current Lesson 4 examples.

If Unity MCP fails, do not fabricate Inspector screenshots or values. Continue static investigation when possible, explain the failed connection, and request an instructor-provided Inspector capture when a live view is essential. Never use a screenshot as evidence without checking that the actual image exists and displays the intended object/field. Avoid full-desktop/multiple-monitor/minimized-window captures that obscure Unity.

## 8. Reports, slides, and handoff

The project has historical reports under `Lesson4_Work/Reports/`, `Lesson4_Audit/`, `Documentation/`, and root Markdown files. **Later dated implementation matrices may supersede earlier audits.** Keep both history and current truth explicit; do not silently merge conflicting status claims.

For Lesson 5, propose a single canonical report in `Lesson5_Work/Reports/` (create the folder only when authorized), with a dated change log and evidence links. At minimum document:

1. Feature objective, prerequisite, and student-visible expected result.
2. Environment snapshot (Unity/Meta versions, scene, Git status, Editor dirty state, date).
3. Exact created/modified assets, original sample provenance, before/after hierarchy, backup/rollback plan.
4. For each edited component: full GameObject path, component type, actual Inspector field/value, explicit object/asset reference, and whether a value was changed or observed unchanged.
5. Event wiring as **source -> event -> target -> method**, including hand/controller input path where relevant.
6. Scripts, responsibilities and full student-required code; avoid development-only diagnostics in slide material.
7. A click-by-click student reproduction guide in English, including menu path, selected object, field and expected result. Clearly label any sequence not independently reproduced.
8. Test matrix by status, with expected/observed behavior, operator, device, build/date; regression results and blockers.
9. Screenshot manifest with filename/path, selected object, visible fields, source, hash if available, and verified/missing status.
10. Open questions, version-sensitive assumptions, and the next **authorized** step.

Do not produce fake screenshot placeholders, invented Quest results, or slide-ready values guessed from documentation. Student-facing slides should be generated **after** the relevant implementation has real configuration evidence and reproducible steps; use English slide content and Italian instructor notes unless directed otherwise.

## 9. End-of-task response format

End every phase with a compact handoff containing:

- **Phase / scope and completion status.**
- **Verified facts vs assumptions / blocked checks.**
- **Changed files and scene objects** (or explicitly `none` for read-only work).
- **Tests actually run** with status labels; pending Quest tests for the instructor.
- **Relevant report / screenshot paths and preserved pre-existing Git changes.**
- **One proposed next phase**, which requires authorization rather than automatic execution.

When unclear, prefer a bounded, reversible, verifiable change over an ambitious reconstruction.
