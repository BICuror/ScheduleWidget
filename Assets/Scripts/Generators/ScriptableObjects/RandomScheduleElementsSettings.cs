using UnityEngine;

[CreateAssetMenu(fileName = "RandomScheduleElementsSettings", menuName = "ScriptableObjects/RandomScheduleElementsSettings")]

public sealed class RandomScheduleElementsSettings : ScriptableObject 
{
    [SerializeField] private int _minElementDuration = 1;
    public int MinElementDuration => _minElementDuration;

    [SerializeField] private int _maxElementDuration = 5;
    public int MaxElementDuration => _maxElementDuration; 

    [SerializeField] private int _minSpacing = 0;
    public int MinSpacing => _minSpacing;

    [SerializeField] private int _maxSpacing = 10;
    public int MaxSpacing => _maxSpacing;
}
