# Lesson 4 — implementation log reconciliation

This log records the latest authorized scene change. Earlier module setup details remain in the configuration matrix and slide instructions; this note does not reconstruct unobserved click history.

## Change: move recovery threshold below the floor (2026-11-04)

- Scene: Assets/Scenes/SampleScene.unity.
- Before: both exercise targets had RespawnOnDrop > Y Threshold For Respawn = 0.3.
- The instructor observed the two-hand target repeatedly reset at approximately Y=0.3, before reaching the floor.
- The floor is a static object with an enabled BoxCollider; a Rigidbody is not required for the floor.
- Set Y Threshold For Respawn = -1.0 on:
  - Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject
  - Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone
- Unity MCP readback confirmed -1.0 on both components. SampleScene was saved.
- No package, script, prefab source, collider or floor changes were made.
- Quest retest after this change is pending. Confirm the objects settle on the floor and reset only if they fall below Y=-1.0.


## Advanced controller haptics implementation - 2026-11-04

- Active scene: Assets/Scenes/SampleScene.unity; Unity 6000.3.9f1; com.meta.xr.sdk.haptics 207.0.1 was already present in Packages/manifest.json before these changes. No package install/upgrade or manifest edit was made.
- Baseline scene was clean (isDirty=false). Before mutation, copied SampleScene.unity, its .meta, and the previous haptics script to Lesson4_Work/backup/haptics_20261104_1702/. Baseline scene SHA-256: 19967032F83E3B00FD7903F7C05E2B0184FD27046FC850A8C8FE2297BE5915EE.
- Imported the official sample clip by copying SDK source Library/PackageCache/com.meta.xr.sdk.haptics@64b85fb39f00/Samples~/HapticPacks/Haptics/Objects/switch_on.haptic to Assets/Samples/Meta XR Haptics SDK/207.0.1/HapticPacks/Haptics/Objects/switch_on.haptic. Unity's HapticClipImporter created asset type Oculus.Haptics.HapticClip; SHA-256: D8872F717B8370261FF1AEDB9B716FBDDB3557B103F5BD5F659F9B4090A0D319. Sample envelope duration is about 0.46 s.
- Extended Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs. It subscribes once in OnEnable to the existing controller GrabInteractable.WhenSelectingInteractorViewAdded, removes the subscription in OnDisable, resolves IInteractorView.Data to the concrete v207 interactor component and reads its same-object ControllerRef.Handedness. That maps to the appropriate SDK Controller.Left/Right or OVR LTouch/RTouch; unknown/non-controller data is skipped instead of guessed.
- Added an exclusive FeedbackMode selector, default MetaHapticsSdk; alternative BasicOvrInput retains the previous OVR values (frequency 0.5, amplitude 0.2, 0.12 s) and now targets only the grabbing controller. The SDK branch calls HapticSource.Play(handedController); the basic branch pulses OVRInput. A new grab event takes only one branch.
- Added one Oculus.Haptics.HapticSource component to Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone. Serialized clip/reference verified; Amplitude=0.6, Frequency Shift=0, Loop=false, Priority=128, SDK component controller default Both (the script calls the explicit handed overload). The existing controller grab reference, hand grab, Grabbable, Rigidbody, and RespawnOnDrop were retained.
- Unity MCP readback verified _controllerGrabInteractable still points to the existing GrabInteractable, _hapticSource points to the new HapticSource on the same target, and the HapticSource _clip points to the imported clip. Scene was saved; a second save confirmed isDirty=false.
- Script compilation completed; Console query found 0 Error entries. No Play Mode, build, deploy, or Quest test was run during this implementation phase. The later instructor-run Quest results are recorded in the dated section below.
- No screenshots were acquired. Add manual evidence IDs F18-F20 to the guide/manifest; historical screenshot claims remain missing.

## Haptics Quest verification reported by instructor - 2026-11-04

- Left Touch grab: instructor reported sound and light vibration on the grabbing controller; release produced no new feedback.
- Right Touch grab: instructor reported the same behavior on the right controller.
- HapticSource amplitude was changed to 0.2 and 1.0; the instructor perceived a difference and restored the documented 0.6 value.
- Frequency Shift was changed to -0.5 and +0.5; the instructor perceived a difference and restored 0.
- BasicOvrInput mode was compared, then MetaHapticsSdk mode was restored.
- The instructor completed the requested throw regression and reported that throwing still works.
- Status is USER_REPORTED_QUEST_TESTED for those observations. The instructor considers the haptics test complete; no separate event-count instrumentation is part of the course test. Hand interactions were tested in their dedicated exercises, while this haptics path intentionally targets Touch controllers. No build identifier, video or Quest logs were supplied. Codex did not run the headset test.
- No scene/script configuration change was made during these tests; the instructor restored the documented mode and parameter defaults.
- During this documentation update, Unity MCP read back the expected defaults (MetaHapticsSdk, HapticSource amplitude 0.6, frequency shift 0, loop false, priority 128), but reported SampleScene `isDirty=true`. The serialized haptics values are restored; other unsaved editor changes cannot be ruled out. Codex did not save the scene. Review Unity's unsaved-state indicator before saving.
- Follow-up after the instructor saved: Unity MCP reports active `Assets/Scenes/SampleScene.unity`, `isDirty=false`, not in Play Mode. The current HapticSource values were read back as amplitude 0.6, frequency shift 0, loop false and priority 128, with `MetaHapticsSdk` selected. No save was issued by Codex.
