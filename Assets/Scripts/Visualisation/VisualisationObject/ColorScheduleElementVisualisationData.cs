using UnityEngine;

[CreateAssetMenu(fileName = "ColorScheduleElementVisualisationData", menuName = "ScriptableObjects/ColorScheduleElementVisualisationData")]

public sealed class ColorScheduleElementVisualisationData : ScriptableObject 
{
    [SerializeField] private Color _jeopardyColor;
    public Color JeopardyColor => _jeopardyColor;

    [SerializeField] private Color _pendingColor;
    public Color PendingColor => _pendingColor;

    [SerializeField] private Color _completeColor;
    public Color CompleteColor => _completeColor;
} 
