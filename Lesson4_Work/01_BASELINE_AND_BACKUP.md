# Lesson 4 Pilot — Baseline and Backup

## Editor and scene

- Unity Editor: **6000.3.9f1** (`ProjectSettings/ProjectVersion.txt`).
- Target platform shown by Unity: **Android**.
- Active scene: `Assets/Scenes/SampleScene.unity`.
- Before any exercise changes, Unity reported `isDirty=false`; the user’s saved state was confirmed.
- Scene was saved after implementation; Unity then reported `isDirty=false`, 10 root objects.
- Meta packages in `Packages/packages-lock.json`: `com.meta.xr.sdk.core` **207.0.1**, `com.meta.xr.sdk.interaction` **207.0.1**, and `com.meta.xr.sdk.interaction.ovr` **207.0.1**. `com.meta.xr.sdk.essentials` and `com.meta.xr.sdk.haptics` are not direct entries in this lock file.

## Backup

Byte-for-byte copies were made before the scene was modified:

- `Lesson4_Work/backup/SampleScene.unity` — SHA-256 `C90AF0EBA274DD228EC4B0B3A604D90AEA330C92EA99DF3CE3D7EF592A25BC1D`
- `Lesson4_Work/backup/SampleScene.unity.meta` — SHA-256 `B5815A6B12AFAF810577BC89041C4CE46516C7CD6609693F8DB616F8E5584D80`

The backup contains the saved scene state immediately before this pilot, including pre-existing local Git changes. It is not a clean checkout of HEAD.

## Existing scene and rig baseline

The scene contained one GameObject each named `OVRCameraRig`, `OVRComprehensiveInteractionRig`, `Locomotor`, and `EventSystem`. The root EventSystem included `InputSystemUIInputModule`, `PointableCanvasModule`, and `BaseInput`.

The rig already had left/right hand Distance Hand Grab interactors at:

- `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsLeft/Interactors/Hand and No Controller/DistanceHandGrabInteractor`
- `OVRCameraRig/OVRComprehensiveInteractionRig/ComprehensiveInteractorsRight/Interactors/Hand and No Controller/DistanceHandGrabInteractor`

It also had separate controller-driven-hand distance interactors under each side’s `Controller and Hand`, and controller-only `ControllerDistanceGrabInteractor` objects under each side’s `Controller and No Hand`. Those are separate input paths. The existing interactors were retained; the wizard added none.

Existing `ControlCanvas`, `PowerCell`, `BatteryDock`, teleport objects, `ISDKExampleMenu`, rig, locomotion and EventSystem were not intentionally changed.

## Git status before this task’s changes

Read-only status before implementation:

```text
 M Assets/Oculus/OculusProjectConfig.asset
 M Assets/Plugins/Android/AndroidManifest.xml
 M Assets/Scenes/SampleScene.unity
 M ProjectSettings/ProjectSettings.asset
 M ProjectSettings/TagManager.asset
?? Assets/Screenshots/screenshot-20261102-113456.png
?? Assets/Screenshots/screenshot-20261102-113456.png.meta
?? Lesson4_Audit/
```

The `SampleScene.unity` Git modification predated this task. Unity’s clean/dirty state and Git’s modified status are different checks.

## Scope note

The scene comparison against the byte-for-byte backup shows the exercise additions plus a PhysicsMaterial instance/reference reserialization on the existing `PowerCell` collider. The replacement material has the same default values visible in the scene data (friction 0.6/0.6, bounce 0). This appears to be Unity’s collider material-instance serialization during component inspection/save; no PowerCell GameObject, transform, or interaction components were edited. This incidental serialized reference change is disclosed for review.
