# Gaps and discrepancies

Audit date: 2026-11-03. Read-only audit; no configuration fix was applied.

## Source-of-truth differences
1. Current saved SampleScene is the authority. Previous notes report historical operations, but original wizard/dialog states were not captured then.
2. Previous notes say Distance Grab Quick Action used Hands and Pull Interactable To Hand. Local v207 source confirms these choices exist and the current object is configured, but cannot prove historical selections. The target also contains generic DistanceGrabInteractable beside DistanceHandGrabInteractable; do not describe it as hands-only.
3. Older manifests list Lesson4_Work screenshots, but recursive listing found no screenshot files there. Those entries are stale. The described older Unity-only crop is not in the current target folder.
4. Assets/Screenshots/screenshot-20261102-113456.png is an older Game View with small content, not a menu/Inspector proof for these modules. Excluded.
5. Live Unity query confirms SampleScene is loaded and isDirty=false.

## Missing proof
- No accepted current screenshots show the Interaction SDK menu, Distance Grab wizard options, capsule Inspector, hand-interactor branches, data-source refs, pose recorder UI, recognizer fields/events, or two-hand transformer fields.
- Pilot A (Hierarchy + Inspector) and pilot B (real menu/wizard) were not captured; mass capture did not begin.
- Exact Distance Grab wizard choices remain unverified historically. Reopening the wizard safely could show current choices as RECONSTRUCTED_WIZARD_VIEW, but no valid view was obtained.
- New Hand Grab Pose recording is pending a live tracked-hand session. Torch sample poses are not course-authored.
- Thumbs-up serialized UnityEvents were confirmed from prefab overrides, but readable Inspector photographs are missing.
- Two-hand transformer refs/scale limits are static only; no runtime motion/scaling evidence.
- No Play Mode, Quest test, build or deployment was run.

## Screenshot acquisition incident
Snipping Tool auto-save was verified enabled at C:/Users/Scianso/Pictures/Screenshots. A UI targeting attempt opened the common Open dialog; the instructor closed it before any capture started. Unity remained visible and maximized on the next check. The issue was UI targeting/accessibility routing, not evidence Unity was minimized. No Nov 3 PNG was found and no file was moved to Lesson4_Work/Screenshots. Classification: CAPTURE_BLOCKED_UI_TARGETING / SCREENSHOT_MISSING, not CAPTURE_BLOCKED_WINDOW_STATE.

## Console
Latest console query returned MCP WebSocket/TransformHandle warnings, unsupported component-alias lookups, and OVR GetHmdColorDesc warning. Two lookup errors came from this audit's searches using aliases not recognized by MCP. Searches were read-only. No runtime console session was collected.

## Next screenshot-only pass
1. Establish Snipping Tool targeting without minimizing Unity; verify both pilots.
2. Capture current Hierarchy/Inspector for all modules.
3. Reopen v207 wizard/recorder only for documentation; label reconstructed wizard, do not click Create/Record.
4. Reconcile slide instructions with accepted captures.
5. Run separate Quest tests only after the instructor schedules that phase.