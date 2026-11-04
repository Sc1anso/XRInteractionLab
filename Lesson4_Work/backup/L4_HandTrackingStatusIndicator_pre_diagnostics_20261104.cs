using Oculus.Interaction.Input;
using UnityEngine;

[ExecuteAlways]
public sealed class L4_HandTrackingStatusIndicator : MonoBehaviour
{
    [Header("Existing Meta Interaction SDK hand data")]
    [SerializeField] private Hand _leftHand;
    [SerializeField] private Hand _rightHand;

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

    private void Update()
    {
        ApplyStatus(_leftHand, _leftIndicator);
        ApplyStatus(_rightHand, _rightIndicator);
    }

    private void ApplyStatus(Hand hand, Renderer indicator)
    {
        if (indicator == null) return;

        Color status = _notTracked;
        if (hand != null && hand.IsTrackedDataValid)
            status = hand.IsHighConfidence ? _highConfidence : _lowConfidence;

        _block ??= new MaterialPropertyBlock();
        indicator.GetPropertyBlock(_block);
        _block.SetColor(BaseColorId, status);
        _block.SetColor(ColorId, status);
        indicator.SetPropertyBlock(_block);
    }
}