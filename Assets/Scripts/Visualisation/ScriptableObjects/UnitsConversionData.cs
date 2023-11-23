using UnityEngine;

[CreateAssetMenu(fileName = "UnitsConversionData", menuName = "ScriptableObjects/UnitsConversionData")]

public sealed class UnitsConversionData : ScriptableObject 
{
    [SerializeField] private float _unitsPerLayer;
    public float UnitsPerLayer => _unitsPerLayer;

    [SerializeField] private float _unitsPerSecond;
    public float UnitsPerSecond => _unitsPerSecond;
}
