using UnityEngine;

[CreateAssetMenu(fileName = "RandomGenerationSettings", menuName = "ScriptableObjects/RandomGenerationSettings")]

public sealed class RandomGenerationSettings : ScriptableObject 
{
    [SerializeField] private int _scheduleElementsPerLayer = 100;
    public int ScheduleElementsPerLayer => _scheduleElementsPerLayer;

    [SerializeField] private int _layersAmount = 20;
    public int LayersAmount => _layersAmount;

    public void SetLayersAmount(int value) => _layersAmount = value;
    public void SetScheduleElementsPerLayer(int value) => _scheduleElementsPerLayer = value;
}
