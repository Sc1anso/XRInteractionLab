using UnityEngine;

public sealed class PowerCellTaskFeedback : MonoBehaviour
{
    [SerializeField] private Light statusLight;
    [SerializeField] private Color inProgressColor = new Color(1f, 0.62f, 0.08f);
    [SerializeField] private Color completedColor = new Color(0.18f, 0.9f, 0.28f);
    [SerializeField, Min(0f)] private float inProgressIntensity = 1.2f;
    [SerializeField, Min(0f)] private float completedIntensity = 1.8f;

    public void MarkInProgress()
    {
        SetFeedback(inProgressColor, inProgressIntensity);
    }

    public void MarkCompleted()
    {
        SetFeedback(completedColor, completedIntensity);
    }

    private void SetFeedback(Color color, float intensity)
    {
        if (statusLight == null) return;
        statusLight.color = color;
        statusLight.intensity = intensity;
        statusLight.enabled = true;
    }
}
