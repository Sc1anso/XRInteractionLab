# Lesson 4 — final static QA

Date: 2026-11-03. This is an Editor/static configuration report. No Quest or runtime test is claimed.

## Final environment and scene state

- Project: `C:\Users\Scianso\Documents\GitHub\XRInteractionLab`
- Unity: `6000.3.9f1`; active and loaded scene: `Assets/Scenes/SampleScene.unity`, build index 0.
- Final Unity MCP active-scene query: `isDirty=false`, 12 root objects.
- Final scene validation (`auto_repair=false`): 0 issues, 0 missing scripts, 0 broken prefabs; no repair action was run.
- Final Console error query: 0 errors. One warning remains: `[MCP-FOR-UNITY] [WebSocket] Unexpected receive error: WebSocket is not initialised`.
- Meta XR Core / Interaction / OVR integration: `207.0.1`; XR Hands `1.7.3`; OpenXR `1.18.0`; URP `17.3.0`.
- Separate `com.meta.xr.sdk.haptics` package is absent.
- One `OVRCameraRig`, one `OVRComprehensiveInteractionRig`, one `Locomotor`, one root `EventSystem`. No duplicate rig/interactor system was created.
- Build target is Android per project configuration. No build or deployment was run in this task.

## Module status (historical snapshot: 2026-11-03)

The package and haptics rows below describe the project before the Haptics SDK was installed by the instructor and before the 2026-11-04 implementation. They are retained as history; the dated 2026-11-04 addendum at the end of this file is authoritative for current Haptics status.

| Module | Static result | Compile/configuration evidence | Quest/runtime |
|---|---|---|---|
| Distance Hand Grab | Existing setup preserved; both generic distance-grab and hand distance-grab components are present | Scene references inspected; historical wizard selections remain unverified | `QUEST_NOT_TESTED` |
| Hand tracking indicators | Left/right Hand refs retained; raw OVRHand refs drive the sphere colors | Instructor reported a Quest tracking-loss test; corrected raw-OVR color behavior compiled but needs a new build and visual confirmation | `USER_REPORTED_PARTIAL`; retest required |
| Custom grab pose | Sample Torch with six sample poses; no course-owned recorded pose | Sample asset and hierarchy inspected | `POSE_RECORDING_PENDING_QUEST_OR_LINK` |
| Thumbs-up pose detection | Left/right sample recognizers and feedback events configured | Serialized event/hand references inspected | `QUEST_NOT_TESTED` |
| Two-handed manipulation | Separate sample-derived target, two grab points and transformer references | Inspector values inspected; scale limits 1–3 | `QUEST_NOT_TESTED` |
| Hand Grab Use | SprayBottle scene object copied from local v207 example and wired to WaterSpray | Persistent events and references inspected; no missing object refs found | `QUEST_NOT_TESTED` |
| Grab Surface | SimpleGrab2PalmGrab sample object copied with CylinderGrabSurface-to-pose links | Local v207 surface configuration inspected; no missing object refs found | `QUEST_NOT_TESTED` |
| Throw | StonePolyhedron instance with Rigidbody, Grabbable, recovery and separate hand/controller routes | Inspector values and references inspected | `QUEST_NOT_TESTED` |
| Controller vibration | `L4_ControllerGrabHaptics` attached to controller GrabInteractable; script compiled | Compile errors 0; local `OVRInput.SetControllerVibration` API verified | `QUEST_NOT_TESTED`; pulses both Touch masks, not hands |
| Microgestures | Existing locomotion bindings inventoried and left untouched | Current wrapper routes inspected; no new sequence wired | `STATIC_INVENTORIED`; runtime untested |
| Gesture Sequence | Local sample only | Sample available; not configured in SampleScene | Not tested |
| Meta Haptics SDK clips | Not installed at the time of this 2026-11-03 snapshot | No manifest or package changes made during that earlier audit | Superseded by 2026-11-04 implementation; see addendum |

## Screenshot and report QA

- `Lesson4_Work/Screenshots/`: 0 files found. No PNG was acquired, moved, renamed, cropped or claimed as evidence.
- At the earlier QA snapshot, the manifest contained 39 unique requested IDs: 22 prior IDs (`A01–A05`, `B01–B04`, `C01–C03`, `D01–D05`, `E01–E04`, `Q01`) and 17 new IDs (`F01–F17`). All remain `MISSING_MANUAL_CAPTURE`.
- An older untracked `Assets/Screenshots/screenshot-20261102-113456.png` exists in Git status; it is not in the Lesson4_Work screenshot folder and was previously classified as a Game View image unrelated to Lesson 4 evidence. It is not cited as accepted evidence and was not modified.
- Older midpoint reports claim ten PNGs, conflicting with the later audit and current screenshot folder. This conflict is preserved in the reconciled baseline and gaps report; none of those filenames are asserted as present.
- All required current reports were written under `Lesson4_Work/Reports/`. Manual screenshot instructions and Quest checklist are separately documented.

## Files changed or created in this work

- Scene: `Assets/Scenes/SampleScene.unity` (new isolated Lesson 4 exercise groups under the existing Lesson 4 parent; core lesson objects preserved).
- New script: `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs` (controller-only OVRInput pulse on the new Throw exercise).
- Reports: new/updated Lesson 4 reports under `Lesson4_Work/Reports/`.
- Backup: `Lesson4_Work/backup/SampleScene_pre_remaining_20261103_213316.unity` and matching `.meta`.
- No package installation/update, package source edit, Build Settings edit, Play Mode entry, build, Quest deployment, screenshot capture, or commit was performed.

## Git state and rollback

Initial status, recorded before implementation, included modified project configuration files and scene plus prior untracked Lesson 4 docs/scripts and one unrelated screenshot. Final status still shows these expected instructor/project changes; no destructive Git command or commit was run. The scene was saved after the new groups were checked.

Pre-edit scene backup SHA-256: `DFABBB2B7138AFBAE2CC7A9B5C1234DAD078C97479214661E666637E948FBCBD`.

For rollback review, compare the backup and current scene in version control or a Unity-aware diff. Do not replace the current scene wholesale without first preserving any later instructor edits.

## Final limitations

- Static Editor correctness does not prove runtime behavior.
- Custom pose recording is pending an actual tracked-hand session.
- Meta Haptics SDK clip playback is not configured and requires explicit approval to install/change packages.
- Gesture Sequence is sample-only and has not been wired into the current rig.
- The teacher must manually capture and visually QA screenshots, then execute `QUEST_TEST_CHECKLIST_FINAL.md` on the device.

## 2026-11-04 locomotion correction and Quest retest addendum

This addendum records work and a user-reported test completed after the 2026-11-03 static QA above.

- Root cause: `Environment/Floor` uses the `Teleportable` layer (index 6), but `PlayerController/CharacterController.LayerMask` had value 23 and omitted that layer. Quest diagnostics showed the thumbstick input and locomotion event chain were active while the player did not move.
- Correction: the `CharacterController.LayerMask` now has value 87, retaining the previous bits and adding layer 6. The Floor layer and Teleport input configuration were left unchanged.
- The instructor confirmed that thumbstick locomotion works on Quest after the correction (2026-11-04).
- The temporary locomotion diagnostics component and script were removed after confirmation. `SampleScene` is saved (`isDirty=false`); Unity Console currently reports 0 errors.
- The corrected slide setup is documented in `04_SLIDE_INSTRUCTIONS_FULL.md` and `04_SLIDE_INSTRUCTIONS_RECONCILED.md`. The remaining open Quest subchecks are tracked in `QUEST_TEST_CHECKLIST_FINAL.md`.


## Haptics implementation static QA - 2026-11-04

- Package: com.meta.xr.sdk.haptics 207.0.1 present; manifest unchanged by this work.
- Scene object: Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone. Added one HapticSource and assigned the imported switch_on.haptic HapticClip. Script mode defaults to SDK; basic OVRInput remains selectable. Both routes map the event's selected controller using the verified local ControllerRef.
- Serialized references and HapticSource values were read back through Unity MCP; SampleScene saved with isDirty=false.
- Script compilation finished and the Unity Console error query returned 0 errors. The Console had MCP/editor transport/serialization warnings during tooling calls; no new Unity compile error was observed.
- No Play Mode, automated runtime test, Quest build, deployment or headset test was performed during the static implementation phase; at that point haptics behavior was QUEST_NOT_TESTED. The later instructor-run headset results are recorded in the dated addendum below. No haptic screenshot was taken.
- Scope: SampleScene.unity, L4_ControllerGrabHaptics.cs, imported official sample .haptic, Lesson4 reports, and a backup folder. No Lesson 1-3 object logic, package version, manifest or project settings were modified by the Haptics implementation.


Current screenshot manifest after the Haptics update: 42 evidence IDs (A01-Q01 and F01-F20); all 42 remain MISSING_MANUAL_CAPTURE. No screenshot was captured as part of the Haptics work.

## Instructor-reported Haptics Quest test update - 2026-11-04

The instructor tested both controller sides and reported sound plus light vibration on grab, no new feedback on release, perceptible changes when adjusting amplitude and frequency shift, successful BasicOvrInput comparison, restored MetaHapticsSdk defaults, and successful throw regression. These are instructor-reported hardware results, not tests run by Codex. The instructor considers the haptics exercise complete; no separate event-count instrumentation is required. Hand interactions were tested separately and are not expected to produce controller vibration. Unity MCP subsequently read back amplitude 0.6, frequency shift 0, and MetaHapticsSdk mode. At that readback Unity reported SampleScene `isDirty=true`; because other unsaved Editor changes could not then be excluded, Codex did not save it. The instructor later saved it and Unity MCP confirmed `isDirty=false`. The 42 manual screenshot records remain missing.

The instructor subsequently confirmed saving the scene. A fresh Unity MCP check now reports `isDirty=false`; the default haptics settings remain present.
