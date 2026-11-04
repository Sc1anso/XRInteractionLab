# Screenshot capture log

Date: 2026-11-03. Required method: Windows Snipping Tool, auto-save to the default Screenshots folder, then inspect and copy the original to Lesson4_Work/Screenshots.

## Pre-capture checks
- Snipping Tool Settings showed “Automatically save original screenshots” enabled.
- Save location shown by the app: C:/Users/Scianso/Pictures/Screenshots.
- Unity identified as XRInteractionLab - SampleScene - Android - Unity 6.3 LTS (6000.3.9f1).
- Unity stayed visible and maximized during verified UI checks. Its title bar showed the Restore control, indicating maximized state. Windows IsIconic/IsZoomed API verification was unavailable in the connected UI automation.
- Live scene query: SampleScene, Assets/Scenes/SampleScene.unity, isDirty=false, isLoaded=true, rootCount=12.
- Snipping Tool initially showed capture mode Window. A UI targeting attempt opened the common Open dialog instead of the intended control. The instructor closed it. No screenshot capture was active.

## Pilot results
| Pilot | Required view | Result | File check |
|---|---|---|---|
| A | Unity Hierarchy + Inspector with selected exercise GameObject | NOT CAPTURED | No new PNG |
| B | Actual open menu or wizard with choices visible | NOT CAPTURED | No new PNG |

Pilot B did not pass, so mass capture did not proceed.

## Folder and window-state verification
- Default folder search found no Screenshot 2026-11-03* file.
- Lesson4_Work/Screenshots contained zero files recursively. No original, crop or rejected image was added.
- Unity remained visible and maximized after the instructor closed the Open dialog. Assistant did not issue minimize, restore or resize. No CAPTURE_BLOCKED_WINDOW_STATE incident established.
- Failure classification: CAPTURE_BLOCKED_UI_TARGETING. Further Snipping Tool clicks stopped to avoid another unintended dialog.
- All required screenshot steps are SCREENSHOT_MISSING; accepted 0, rejected 0, QA-unverified image files 0.

## Provenance and resume
No image was captured, copied, renamed or cropped during this pass. Assets/Screenshots/screenshot-20261102-113456.png is an older Game View and does not demonstrate Lesson 4 steps. Previous references to absent Lesson4_Work PNGs remain stale.
For a later pass: keep Unity maximized; capture pilot A, verify file exists and content; capture pilot B and verify; only after both pass capture the manifest items. Preserve full originals and make crops only as additional copies.
## Retest addendum — 2026-11-03 (user-requested retry)
- A fresh CUA session reattached to Unity and Snipping Tool. Unity was observed in a restored/windowed state at the start of this retry (Unity title bar exposed “Ingrandisci”). It was maximized again using Unity’s title-bar maximize control; the resulting Unity view filled the selected display and showed the Restore control visually.
- Snipping Tool was raised and its Window capture mode was visible. A click attempt against its New capture control returned `window is not a usable app window`; no capture overlay was started in this retry. Earlier retries in the preceding turn had started the overlay, but CUA input was not delivered to that overlay and returned errors or returned focus to Unity.
- No Snipping Tool image was saved. The newest file in `C:\Users\Scianso\Pictures\Screenshots` remains `Screenshot 2026-11-02 144809.png` (180116 bytes, 2026-11-02 14:48:09). `Lesson4_Work\Screenshots` still contains zero files.
- Window incident: during the preceding capture attempts Unity was observed restored/windowed after a misrouted interaction; its exact trigger is uncertain. It has now been maximized again. No minimize command was issued. This is recorded as `WINDOW_STATE_INCIDENT_RESTORED`, not as a successful capture.
- Capture remains blocked by the target-window/overlay limitation. Pilot A and B remain NOT CAPTURED. Accepted 0; rejected 0; missing required records 22; no new image to visually QA.
- Additional recovery note: after Snipping Tool disappeared from the targetable-window list, a global capture toolbar was visible over Unity but could not be targeted. Cancelling it with Escape returned Unity to a restored/windowed state; Unity was immediately maximized again and verified by the title-bar “Ripristino” control. This confirms the window-state incident during this retry as well; no capture file resulted.
