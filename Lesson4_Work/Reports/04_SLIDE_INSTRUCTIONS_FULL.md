# Lesson 4 â€” complete slide-ready procedures (English)

These steps describe how to reconstruct the current static setup from the end-of-Lesson-3 project. They are not a historical click log. Where actual operations are known, they are identified as editor actions; student steps are a reproducible procedure based on the installed local SDK 207.0.1 examples. Runtime results are tracked separately in `QUEST_TEST_CHECKLIST_FINAL.md`; static configuration alone does not count as a runtime test.

## Cross-lesson setup correction — smooth controller locomotion

Include this correction if the slides recap or ask students to configure the existing smooth locomotion:

1. Keep `Environment/Floor` on the `Teleportable` layer so the locomotion surface remains available to the Teleport interaction.
2. In the Hierarchy, select `OVRCameraRig > OVRComprehensiveInteractionRig > Locomotor > PlayerController`.
3. In the Meta `CharacterController` component, expand **Layer Mask** and include `Teleportable` (layer 6), preserving the existing selected layers. In the verified project the resulting mask value is **87**; the previous value **23** excluded layer 6 and prevented the controller from grounding on the floor, so slide locomotion did not move the player.
4. Keep the controller movement style set to **Slide** when testing thumbstick locomotion. Teleport bindings do not need to be removed to make this correction.

The instructor confirmed that locomotion works on Quest after the layer-mask correction (2026-11-04). Do not include temporary runtime diagnostic code or logs in the lesson slides.

## 1. Distance Hand Grab â€” evidence IDs A01â€“A05

1. In the Hierarchy, expand `Lesson4_AdvancedInteractions > DistanceHandGrab_Exercise` and select `L4_DistanceGrabCapsule`. Frame it in Scene view. Evidence: A01, A02.
2. Inspect the root `CapsuleCollider`, `Rigidbody` and `Grabbable`. Current values: capsule radius 0.5, height 2, Y direction; Rigidbody mass 1, gravity off, kinematic on; Grabbable target and Rigidbody reference the capsule root; Max Grab Points is -1. Evidence: A02.
3. Expand the capsule child `ISDK_DistanceHandGrabInteraction`. Inspect `DistanceHandGrabInteractable`: Supported Grab Types value 3 (Pinch + Palm), Relative To/root, Pointable Element/root and Rigidbody/root. Its Movement Provider child is `MoveTowardsTargetProvider`. A generic `DistanceGrabInteractable` is also present. Evidence: A03.
4. To learn the menu workflow, use an unconfigured disposable object in a throwaway project copy and open `GameObject > Interaction SDK > Add Distance Grab Interaction`. Do not click Create on the configured teaching capsule. Historical Hands/Pull wizard selections are not photo-verified. Evidence: A04 is missing/reconstructed only.
5. Expand the existing OVRComprehensiveInteractionRig left and right `Interactors > Hand and No Controller` branches. Confirm `DistanceHandGrabInteractor` on each side. Do not substitute the separate `ControllerDistanceGrabInteractor`. Evidence: A05.

## 2. Hand tracking foundations â€” evidence IDs B01â€“B04

1. Expand `OVRCameraRig > OVRComprehensiveInteractionRig > OVRHands`; inspect `Hand`, `HandSkeletonOVR`, left/right `OVRHandDataSource`, and the serialized references that connect each data source to its matching hand and skeleton providers. Evidence: B01.
2. Expand `OVRHandVisualLeft` and `OVRHandVisualRight`, select their visual components and inspect the `HandVisual` references. Evidence: B02.
3. Select `Lesson4_AdvancedInteractions/L4_HandTrackingStatus`. Assign each side's existing raw `OVRHand` component from `OVRHandDataSourceLeft/Right` to the matching status slot and assign the matching sphere Renderer. Keep the existing left/right ISDK `Hand` references intact for the interaction data chain. State colors use raw OVR flags: untracked/invalid `(0.22,0.25,0.30,1)`, tracked but low-confidence `(1,0.58,0.08,1)`, tracked and high-confidence `(0.16,0.82,0.36,1)`. Evidence: B03 and B04.
4. Explain that the indicators show raw hand tracking and confidence. They do not report pinch or whether the user selected hand/controller interaction mode. Keep the rig's `LastKnownGoodHand` enabled for interactions; it can preserve a usable pose after raw tracking weakens.

## 3. Custom hand-grab pose â€” evidence IDs C01â€“C03

1. Select `Lesson4_AdvancedInteractions/L4_GrabPose_Exercise/L4_GrabPoseTool`. This is a scene instance of the installed Meta Torch sample prefab (`Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Objects/Props/Torch/Torch.prefab`). Inspect its root Rigidbody/Grabbable and normal/mirrored `HandGrabInteractable` branches. Evidence: C01.
2. Inspect the six preauthored sample `HandGrabPose` points. They are sample poses, not a course recording. Evidence: C03.
3. The instructor confirmed the Torch sample pose works on Quest (2026-11-04); this is a test of preauthored sample data only. For a new project-specific pose, open `Window > Meta > Interaction SDK > Hand Grab Pose Recorder`. The recorder captures and saves how tracked fingers conform to an object. In the local v207 window, select the tracked `Hand`, `Item` (Rigidbody), optional `Ghost Provider`, and `Poses Collection` (`HandGrabInteractableDataCollection`). Evidence: C02.
4. A new recording requires Play Mode with real tracked hands. In the later Quest session, create a project-owned collection, record, save, reload and verify the pose. Do not claim this recording was completed in the present Editor-only phase.

## 4. Thumbs-up pose detection â€” evidence IDs D01â€“D05

1. Inspect the local sample prefab `Packages/com.meta.xr.sdk.interaction/Runtime/Sample/Prefabs/HandPose/ThumbsUpPose.prefab`, then the scene instances `L4_ThumbsUpRecognizer_Left` and `L4_ThumbsUpRecognizer_Right`. Evidence: D01â€“D03.
2. Confirm each recognizer's `HandRef` and feature-provider references all use the matching side. The recognizer combines the local shape and transform active-state components and their sample assets; do not describe it as a temporal swipe detector.
3. Inspect each `SelectorUnityEventWrapper`: `WhenSelected` calls the same-side `L4_ThumbsUpFeedback.OnPoseRecognized()` and `WhenUnselected` calls `OnPoseLost()`. Inspect the indicator renderer and gray/green colors `(0.28,0.31,0.36,1)` and `(0.12,0.88,0.38,1)`. Evidence: D04â€“D05.
4. Verify activation and release using tracked hands on Quest; static references do not prove recognition.

## 5. Two-handed manipulation â€” evidence IDs E01â€“E04

1. Select `Lesson4_AdvancedInteractions/L4_TwoHanded_Exercise/L4_TwoHandedObject`, a scene instance of the v207 StonePolyhedron sample. Keep it separate from `ControlCanvas`. Evidence: E01.
2. Inspect its root Rigidbody: mass 0.2, gravity on, kinematic off. On `Grabbable`, inspect Max Grab Points=2, Transfer On Second Selection=false, Add New Points To Front=false, and Rigidbody=self. Evidence: E02.
3. Inspect the One Grab Transformer and Two Grab Transformer fields; both refer to the object's local `GrabFreeTransformer`. Its relative scale axes X/Y/Z are constrained with min 1 and max 3; position and rotation constraints are those shown by the current Inspector. Evidence: E03.
4. Inspect child `GrabInteractable` (controller route) and `HandGrabInteractable` (hand route, Supported Grab Types=1/Pinch). Evidence: E04.
5. On Quest, verify second-hand selection, translation, rotation, scale range and release behavior. The configured object is not runtime-verified.

## 6. Hand Grab Use â€” evidence IDs F01â€“F04

1. The project contains a copied scene object from the local `HandGrabUseExamples` scene at `Lesson4_AdvancedInteractions/L4_HandGrabUse_Exercise/L4_HandGrabUse_SprayBottle`. It is a sample-derived scene object, not a newly authored bottle model. Evidence: F01.
2. Expand the bottle's `HandGrabInteractable`, mirrored variant, `UseInteractable`, mirrored variant, pose points and filters. Each use interactable delegates to the root `WaterSpray`, has Strength Deadzone 0.2, three relaxed and three tight poses, and its SecondaryInteractorFilter pairs the primary grab with its use interactable; Select Required=true. Evidence: F02.
3. On root `WaterSpray`, inspect release threshold 0.3, fire threshold 0.7, spread 40Â°/20Â°, strength 5, six hits and max distance 2. Inspect `WhenSpray` and `WhenStream`: each invokes the corresponding particle `Play` and audio `PlayAudio` methods. Evidence: F03.
4. In the rig, inspect the existing left/right `HandGrabUseInteractor`; these were reused, not duplicated. Evidence: F04.
5. Teach the distinction: grab selects and holds the bottle; the use interaction drives its function while held. Test only with real tracked hands on Quest.

## 7. Grab Surface â€” evidence IDs F05â€“F08

1. Select `Lesson4_AdvancedInteractions/L4_GrabSurface_Exercise/L4_GrabSurface_Torch`. Provenance: copied scene object from the local `HandGrabExamples` scene's `Interactables/SimpleGrab2PalmGrab`. Evidence: F05.
2. Inspect root Rigidbody/Grabbable and normal/mirrored `HandGrabInteractable`; current Supported Grab Types=2 (Palm). Evidence: F06.
3. Expand a `HandGrab Point`: its `HandGrabPose` snap surface points to the sibling `CylinderGrabSurface`; both Relative To references point to the new target root. The mirrored set has its own corresponding references. Evidence: F07â€“F08.
4. Explain that both this sample and the earlier Torch use a palm-style grab, so the physical hand gesture can look the same. The difference is the valid contact region: each HandGrabPose references a CylinderGrabSurface, allowing pose matching across that surface instead of only at a fixed point. The instructor tested several points and hand orientations on Quest and observed behavior that looked the same as the earlier Torch pose sample. Teach the surface as a configuration concept; do not promise a visibly different gesture in this scene. A collider alone does not define a hand-grab surface.

## 8. Throw â€” evidence IDs F09â€“F13

1. Select `Lesson4_AdvancedInteractions/L4_Throw_Exercise/L4_ThrowStone`, an instance of the local v207 StonePolyhedron package prefab. Evidence: F09.
2. Inspect `Grabbable`: Max Grab Points=1; Transfer On Second Selection=false; One Grab Transformer=local `GrabFreeTransformer`; Two Grab Transformer=None; Target Transform=None/self; Rigidbody=self; Kinematic While Selected=true; Throw When Unselected=true; Force Kinematic Disabled=false. Evidence: F10.
3. Inspect Rigidbody: mass 0.2, gravity on, kinematic off, linear damping 0.1, angular damping 0.05, Collision Detection=Continuous. `RespawnOnDrop` Y Threshold For Respawn=-1.0. Evidence: F11.
4. Inspect the controller GrabInteractable and separate hand HandGrabInteractable (Supported Grab Types=1/Pinch). The haptics listener targets only the controller GrabInteractable. Evidence: F12 and F13.
5. Throw with controller and hand separately, confirm recovery, and verify controller haptics only on a real Quest. Static release settings are not proof of a physical throw or haptic output.

## 9. Microgestures and gesture sequence â€” evidence IDs F14â€“F17

1. Inspect the existing `OVRMicrogestureEventSource` and wrappers under each rig `Hand and No Controller/MicroGesturesLocomotionHandInteractorGroup`. Current bindings include locomotion gate, teleport selection, snap turn, step, jump/crouch. Do not add duplicate bindings. Evidence: F14â€“F15.
2. The local `GestureExamples` sample contains sequence-based swipe examples, but no new sequence was connected in SampleScene because its provider chain has not been verified for this rig. It is an optional sample-only topic. Evidence: F17.
3. The Haptics SDK is installed and the advanced clip exercise is now configured; see section 11. Controller vibration still requires Touch hardware and is not produced by bare hands.

## 10. Beyond the lab

Use the locally imported `TouchGrabExamples`, `GazeExamples`, and `GestureExamples` for an overview only. A gaze interactable in a sample does not prove an active gaze interactor or eye tracking is configured in this project. Custom hand models and eye tracking were not configured here.

## 11. Advanced controller haptics - Meta XR Haptics SDK

### Concept for the instructor

Haptic feedback adds a tactile cue to an interaction. A HapticClip is an authored pattern imported from a .haptic file. HapticSource plays that pattern and exposes clip, controller, amplitude, frequency shift, loop and priority controls. Amplitude scales intensity from 0 to 1; frequencyShift adjusts the clip's normalized frequency characteristics from -1 to 1 and is not a value in hertz. Meta Haptics Studio can author and export custom .haptic files; Studio is optional background, not a required lab task.

The basic example uses a short OVRInput.SetControllerVibration pulse. The advanced mode plays the sample switch_on.haptic clip. The scene's mode selector chooses one branch at a time. Both examples target Touch controllers; tracked hands alone do not produce controller vibration.

### Reproducible Unity setup (current project configuration)

1. Confirm com.meta.xr.sdk.haptics 207.0.1 is installed. The project already has this package; do not add another version.
2. In the Project window, locate Assets/Samples/Meta XR Haptics SDK/207.0.1/HapticPacks/Haptics/Objects/switch_on.haptic. This is copied from the installed SDK sample pack and imported by the Haptics SDK as a HapticClip.
3. In the Hierarchy, expand Lesson4_AdvancedInteractions > L4_Throw_Exercise and select L4_ThrowStone.
4. On the root, retain the existing L4_ControllerGrabHaptics component and its Controller Grab Interactable reference to L4_ThrowStone/GrabInteractable.
5. Set its Feedback Mode (_feedbackMode) to MetaHapticsSdk. This is the saved default. The component's other Inspector option is BasicOvrInput.
6. On the same root, add/select Oculus.Haptics.HapticSource. Assign switch_on.haptic to Clip; set Amplitude=0.6, Frequency Shift=0, Loop=false, and Priority=128 (the SDK default). Its serialized Controller field remains the SDK default Both, but the script calls Play(Controller.Left) or Play(Controller.Right) for every grab, so runtime playback is side-specific.
7. In L4_ControllerGrabHaptics, assign the same-root HapticSource component to Haptic Source. Keep the Controller Grab Interactable reference on the controller-only child.
8. The event chain is L4_ThrowStone/GrabInteractable to WhenSelectingInteractorViewAdded to L4_ControllerGrabHaptics.OnControllerGrabStarted(IInteractorView) to IInteractorView.Data concrete GrabInteractor to same-object ControllerRef.Handedness to HapticSource.Play(Left|Right) to switch_on.haptic on the corresponding Touch controller. The local left/right controller interactors each contain their own ControllerRef.
9. To compare the basic method, change Feedback Mode to BasicOvrInput. It uses the same grab event and side mapping, with Frequency=0.5, Amplitude=0.2, and a 0.12 s pulse. Change back to MetaHapticsSdk for the default lesson mode. The code branches are exclusive, so the two feedback systems are not started by one grab.
10. On Quest, grab L4_ThrowStone with the left and right Touch controllers separately. The instructor reports sound plus light vibration on both sides, with no new feedback on release. Amplitude changes at 0.2 and 1.0 and frequency shifts at -0.5 and +0.5 produced perceptible differences; restore Amplitude=0.6 and Frequency Shift=0. The instructor also compared BasicOvrInput, restored MetaHapticsSdk, and reports the throw regression works. This completes the controller haptics exercise. Hand interactions are demonstrated and tested separately; controller vibration is not expected from tracked hands.

### Suggested diagrams

- Haptic feedback pipeline: controller grab to selection event to handedness from ControllerRef to HapticSource to HapticClip to matching Touch controller. Show that the hand route does not enter this controller-only chain.
- Basic vs advanced feedback: OVRInput pulse (frequency, amplitude, duration) alongside HapticClip playback (authored pattern, amplitude, frequency shift, priority).
- Clip modulation: the same switch_on.haptic pattern at amplitude 0.3/0.6/1.0 and frequency shift -0.3/0/+0.3, labelled as relative modulation, not Hz.

### Instructor-reported Quest test result — 2026-11-04

Both left and right Touch grabs produced sound and light vibration on the corresponding controller. Release did not produce another feedback event. The instructor perceived amplitude differences at 0.2 and 1.0 and frequency-shift differences at -0.5 and +0.5, then restored the documented values 0.6 and 0. The BasicOvrInput comparison was completed, MetaHapticsSdk was restored, and the requested throw regression was reported successful. This is user-reported hardware evidence; Codex did not run the Quest test. The instructor considers the haptics exercise complete; separate event-count instrumentation is not required. Hand interactions were tested separately in their dedicated exercises, and this controller-haptics path does not claim to vibrate tracked hands.

## Appendix — complete source of Lesson 4 custom C# scripts

The three project-owned Lesson 4 scripts are included below in full. For the presentation, place their complete listings in a code appendix, split across multiple slides where needed without omitting lines. `L4_HandTrackingStatusIndicator` also contains diagnostic logging; that logger is implementation support, not a concept or exercise objective to teach.


## Evidence rule

All referenced PNGs are currently missing and must be manually captured using `SCREENSHOT_CAPTURE_GUIDE_MANUAL.md`. The IDs above identify requested evidence; they do not imply that image files exist.




### L4_HandTrackingStatusIndicator.cs - complete source

Path: `Assets/Scripts/Lesson4/L4_HandTrackingStatusIndicator.cs`.

```csharp
using System.Text;
using Oculus.Interaction.Input;
using UnityEngine;

[ExecuteAlways]
public sealed class L4_HandTrackingStatusIndicator : MonoBehaviour
{
    [Header("Existing Meta Interaction SDK hand data")]
    [SerializeField] private Hand _leftHand;
    [SerializeField] private Hand _rightHand;

    [Header("Raw OVR hand data for Quest diagnostics")]
    [SerializeField] private OVRHand _leftOVRHand;
    [SerializeField] private OVRHand _rightOVRHand;
    [SerializeField] private bool _logRuntimeState = true;
    [SerializeField, Min(0.25f)] private float _logIntervalSeconds = 1f;

    [Header("Lesson 4 indicator renderers")]
    [SerializeField] private Renderer _leftIndicator;
    [SerializeField] private Renderer _rightIndicator;

    [Header("Status colors")]
    [SerializeField] private Color _notTracked = new Color(0.22f, 0.25f, 0.30f, 1f);
    [SerializeField] private Color _lowConfidence = new Color(1f, 0.58f, 0.08f, 1f);
    [SerializeField] private Color _highConfidence = new Color(0.16f, 0.82f, 0.36f, 1f);

    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
    private static readonly int ColorId = Shader.PropertyToID("_Color");
    private MaterialPropertyBlock _block;
    private float _nextLogTime;

    private void Update()
    {
        ApplyStatus(_leftOVRHand, _leftIndicator);
        ApplyStatus(_rightOVRHand, _rightIndicator);

        if (!Application.isPlaying || !_logRuntimeState || Time.unscaledTime < _nextLogTime)
        {
            return;
        }

        _nextLogTime = Time.unscaledTime + Mathf.Max(0.25f, _logIntervalSeconds);
        var message = new StringBuilder(256);
        message.Append("[L4HandStatus] t=").Append(Time.unscaledTime.ToString("F2"));
        message.Append(" | LEFT ");
        AppendHandState(message, _leftOVRHand, _leftHand);
        message.Append(" | RIGHT ");
        AppendHandState(message, _rightOVRHand, _rightHand);
        Debug.Log(message.ToString(), this);
    }

    private static void AppendHandState(StringBuilder output, OVRHand ovrHand, Hand hand)
    {
        output.Append("OVR(");
        if (ovrHand == null)
        {
            output.Append("null");
        }
        else
        {
            output.Append("tracked=").Append(ovrHand.IsTracked)
                .Append(",dataValid=").Append(ovrHand.IsDataValid)
                .Append(",highConfidence=").Append(ovrHand.IsDataHighConfidence)
                .Append(",confidence=").Append(ovrHand.HandConfidence);
        }

        output.Append(") ISDK(");
        if (hand == null)
        {
            output.Append("null");
        }
        else
        {
            output.Append("connected=").Append(hand.IsConnected)
                .Append(",trackedDataValid=").Append(hand.IsTrackedDataValid)
                .Append(",highConfidence=").Append(hand.IsHighConfidence);
        }

        output.Append(')');
    }

    private void ApplyStatus(OVRHand hand, Renderer indicator)
    {
        if (indicator == null) return;

        Color status = _notTracked;
        if (hand != null && hand.IsDataValid)
        {
            if (!hand.IsTracked)
            {
                status = _notTracked;
            }
            else
            {
                status = hand.IsDataHighConfidence ? _highConfidence : _lowConfidence;
            }
        }

        _block ??= new MaterialPropertyBlock();
        indicator.GetPropertyBlock(_block);
        _block.SetColor(BaseColorId, status);
        _block.SetColor(ColorId, status);
        indicator.SetPropertyBlock(_block);
    }
}
```

### L4_ThumbsUpFeedback.cs - complete source

Path: `Assets/Scripts/Lesson4/L4_ThumbsUpFeedback.cs`.

```csharp
using UnityEngine;

[ExecuteAlways]
public sealed class L4_ThumbsUpFeedback : MonoBehaviour
{
    [SerializeField] private Renderer _indicatorRenderer;
    [SerializeField] private Color _notRecognized = new Color(0.28f, 0.31f, 0.36f, 1f);
    [SerializeField] private Color _recognized = new Color(0.12f, 0.88f, 0.38f, 1f);

    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");
    private static readonly int ColorId = Shader.PropertyToID("_Color");
    private MaterialPropertyBlock _block;

    private void OnEnable()
    {
        OnPoseLost();
    }

    public void OnPoseRecognized()
    {
        Apply(_recognized);
    }

    public void OnPoseLost()
    {
        Apply(_notRecognized);
    }

    private void Apply(Color color)
    {
        if (_indicatorRenderer == null) return;
        _block ??= new MaterialPropertyBlock();
        _indicatorRenderer.GetPropertyBlock(_block);
        _block.SetColor(BaseColorId, color);
        _block.SetColor(ColorId, color);
        _indicatorRenderer.SetPropertyBlock(_block);
    }
}
```

### L4_ControllerGrabHaptics.cs - complete source

Path: `Assets/Scripts/Lesson4/L4_ControllerGrabHaptics.cs`.

```csharp
using System.Collections;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Haptics;
using UnityEngine;

using HapticsController = Oculus.Haptics.Controller;
using ISDKHandedness = Oculus.Interaction.Input.Handedness;

/// <summary>
/// Plays one selectable haptic style when the controller-only GrabInteractable
/// is selected. The controller side is taken from the selecting ISDK interactor.
/// Tracked-hand grabs use a separate HandGrabInteractable and do not trigger this.
/// </summary>
public sealed class L4_ControllerGrabHaptics : MonoBehaviour
{
    private enum FeedbackMode
    {
        MetaHapticsSdk = 0,
        BasicOvrInput = 1
    }

    [SerializeField] private GrabInteractable _controllerGrabInteractable;
    [SerializeField] private FeedbackMode _feedbackMode = FeedbackMode.MetaHapticsSdk;
    [SerializeField] private HapticSource _hapticSource;
    [SerializeField, Range(0f, 1f)] private float _ovrFrequency = 0.5f;
    [SerializeField, Range(0f, 1f)] private float _ovrAmplitude = 0.2f;
    [SerializeField, Min(0.01f)] private float _ovrPulseSeconds = 0.12f;

    private OVRInput.Controller _activeOvrController = OVRInput.Controller.None;

    private void OnEnable()
    {
        if (_controllerGrabInteractable != null)
        {
            _controllerGrabInteractable.WhenSelectingInteractorViewAdded += OnControllerGrabStarted;
        }
    }

    private void OnDisable()
    {
        if (_controllerGrabInteractable != null)
        {
            _controllerGrabInteractable.WhenSelectingInteractorViewAdded -= OnControllerGrabStarted;
        }

        StopOvrPulse();
        if (_hapticSource != null)
        {
            _hapticSource.Stop();
        }
    }

    private void OnControllerGrabStarted(IInteractorView interactorView)
    {
        if (!TryGetControllerHandedness(interactorView, out ISDKHandedness handedness))
        {
            // Do not guess which controller acted. A tracked-hand interaction or
            // an unexpected interactor therefore produces no controller feedback.
            return;
        }

        if (_feedbackMode == FeedbackMode.MetaHapticsSdk)
        {
            StopOvrPulse();
            if (_hapticSource == null)
            {
                Debug.LogWarning("[L4 Haptics] Meta Haptics mode is selected, but HapticSource is not assigned.", this);
                return;
            }

            _hapticSource.Play(ToHapticsController(handedness));
            return;
        }

        if (_hapticSource != null)
        {
            _hapticSource.Stop();
        }

        OVRInput.Controller controller = ToOvrController(handedness);
        StopOvrPulse();
        _activeOvrController = controller;
        OVRInput.SetControllerVibration(_ovrFrequency, _ovrAmplitude, controller);
        StartCoroutine(StopPulse(controller));
    }

    private static bool TryGetControllerHandedness(IInteractorView interactorView, out ISDKHandedness handedness)
    {
        handedness = default;
        if (interactorView?.Data is not Component interactorComponent)
        {
            return false;
        }

        // In this scene, each v207 ControllerGrabInteractor has a ControllerRef
        // component on the same GameObject. That ref delegates handedness to the
        // matching ComprehensiveInteractorsLeft/Right controller data source.
        ControllerRef controllerRef = interactorComponent.GetComponent<ControllerRef>();
        if (controllerRef == null)
        {
            return false;
        }

        handedness = controllerRef.Handedness;
        return handedness == ISDKHandedness.Left || handedness == ISDKHandedness.Right;
    }

    private static HapticsController ToHapticsController(ISDKHandedness handedness)
    {
        return handedness == ISDKHandedness.Left
            ? HapticsController.Left
            : HapticsController.Right;
    }

    private static OVRInput.Controller ToOvrController(ISDKHandedness handedness)
    {
        return handedness == ISDKHandedness.Left
            ? OVRInput.Controller.LTouch
            : OVRInput.Controller.RTouch;
    }

    private IEnumerator StopPulse(OVRInput.Controller controller)
    {
        yield return new WaitForSecondsRealtime(_ovrPulseSeconds);
        OVRInput.SetControllerVibration(0f, 0f, controller);
        if (_activeOvrController == controller)
        {
            _activeOvrController = OVRInput.Controller.None;
        }
    }

    private void StopOvrPulse()
    {
        StopAllCoroutines();
        if (_activeOvrController == OVRInput.Controller.None)
        {
            return;
        }

        OVRInput.SetControllerVibration(0f, 0f, _activeOvrController);
        _activeOvrController = OVRInput.Controller.None;
    }
}
```
