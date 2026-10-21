using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR;

/// <summary>
/// Temporary diagnostics for Quest controller/hand tracking. Logs device roles,
/// OVR hand tracking state, and the rig objects that are most relevant to visuals.
/// This component observes state only; it never enables or disables rig objects.
/// </summary>
public sealed class XRTrackingDiagnostics : MonoBehaviour
{
    [SerializeField] private float logIntervalSeconds = 2f;

    private readonly List<InputDevice> _devices = new List<InputDevice>();
    private float _nextLogTime;
    private string _lastSignature;

    private void Start()
    {
        Debug.Log("[XRDiag] Started. State is logged every " + logIntervalSeconds + " seconds and on device changes.", this);
        LogSnapshot("startup");
        InputDevices.deviceConnected += OnDeviceChanged;
        InputDevices.deviceDisconnected += OnDeviceChanged;
    }

    private void OnDestroy()
    {
        InputDevices.deviceConnected -= OnDeviceChanged;
        InputDevices.deviceDisconnected -= OnDeviceChanged;
    }

    private void Update()
    {
        if (Time.unscaledTime < _nextLogTime)
            return;

        _nextLogTime = Time.unscaledTime + Mathf.Max(0.25f, logIntervalSeconds);
        LogSnapshot("periodic");
    }

    private void OnDeviceChanged(InputDevice device)
    {
        LogSnapshot("device-change " + device.name);
    }

    private void LogSnapshot(string reason)
    {
        var output = new StringBuilder(512);
        output.Append("[XRDiag] ").Append(reason).Append(" | ");

        AddDevices(output, InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, "controller-left");
        AddDevices(output, InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, "controller-right");
        AddDevices(output, InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.Left, "hand-left");
        AddDevices(output, InputDeviceCharacteristics.HandTracking | InputDeviceCharacteristics.Right, "hand-right");

        AddOVRHand(output, "OVRHand_L", OVRInput.Hand.HandLeft);
        AddOVRHand(output, "OVRHand_R", OVRInput.Hand.HandRight);

        AddTransform(output, "ControllerVisualsLeft");
        AddTransform(output, "ControllerVisualsRight");
        AddTransform(output, "UnityXRHandVisualLeft");
        AddTransform(output, "UnityXRHandVisualRight");

        var signature = output.ToString();
        if (reason != "periodic" || signature != _lastSignature)
            Debug.Log(signature, this);
        _lastSignature = signature;
    }

    private void AddDevices(StringBuilder output, InputDeviceCharacteristics characteristics, string label)
    {
        _devices.Clear();
        InputDevices.GetDevicesWithCharacteristics(characteristics, _devices);
        output.Append(label).Append('=');
        if (_devices.Count == 0)
        {
            output.Append("none; ");
            return;
        }

        foreach (var device in _devices)
        {
            bool isTracked;
            bool hasTrackingState;
            device.TryGetFeatureValue(CommonUsages.isTracked, out isTracked);
            device.TryGetFeatureValue(CommonUsages.trackingState, out InputTrackingState trackingState);
            hasTrackingState = trackingState != InputTrackingState.None;
            output.Append('[').Append(device.name)
                .Append(" valid=").Append(device.isValid)
                .Append(" tracked=").Append(isTracked)
                .Append(" trackingState=").Append(hasTrackingState ? trackingState.ToString() : "None")
                .Append("]; ");
        }
    }

    private void AddOVRHand(StringBuilder output, string objectName, OVRInput.Hand hand)
    {
        var handObject = GameObject.Find(objectName);
        if (handObject == null)
        {
            output.Append(objectName).Append("=not-found; ");
            return;
        }

        var ovrHand = handObject.GetComponentInChildren<OVRHand>(true);
        output.Append(objectName).Append(" active=").Append(handObject.activeInHierarchy);
        if (ovrHand == null)
        {
            output.Append(" OVRHand=missing; ");
            return;
        }

        output.Append(" tracked=").Append(ovrHand.IsTracked)
            .Append(" dataValid=").Append(ovrHand.IsDataValid)
            .Append(" confidence=").Append(ovrHand.HandConfidence)
            .Append(" controllerConnected=").Append(OVRInput.IsControllerConnected(hand == OVRInput.Hand.HandLeft ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch))
            .Append("; ");
    }

    private void AddTransform(StringBuilder output, string objectName)
    {
        var target = GameObject.Find(objectName);
        if (target == null)
        {
            output.Append(objectName).Append("=not-found; ");
            return;
        }

        output.Append(objectName).Append(" active=").Append(target.activeInHierarchy)
            .Append(" pos=").Append(target.transform.position.ToString("F2"))
            .Append("; ");
    }
}
