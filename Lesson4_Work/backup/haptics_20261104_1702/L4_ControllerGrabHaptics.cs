using System.Collections;
using Oculus.Interaction;
using UnityEngine;

/// <summary>
/// Demonstrates legacy OVRInput controller vibration when the controller-only
/// GrabInteractable is selected. This does not provide hand haptics or Meta
/// Haptics SDK clip playback.
/// </summary>
public sealed class L4_ControllerGrabHaptics : MonoBehaviour
{
    [SerializeField] private GrabInteractable _controllerGrabInteractable;
    [SerializeField, Range(0f, 1f)] private float _frequency = 0.5f;
    [SerializeField, Range(0f, 1f)] private float _amplitude = 0.2f;
    [SerializeField, Min(0.01f)] private float _pulseSeconds = 0.12f;

    private const OVRInput.Controller ControllerMask =
        OVRInput.Controller.LTouch | OVRInput.Controller.RTouch;

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

        StopAllCoroutines();
        OVRInput.SetControllerVibration(0f, 0f, ControllerMask);
    }

    private void OnControllerGrabStarted(IInteractorView _)
    {
        StopAllCoroutines();
        OVRInput.SetControllerVibration(_frequency, _amplitude, ControllerMask);
        StartCoroutine(StopPulse());
    }

    private IEnumerator StopPulse()
    {
        yield return new WaitForSecondsRealtime(_pulseSeconds);
        OVRInput.SetControllerVibration(0f, 0f, ControllerMask);
    }
}