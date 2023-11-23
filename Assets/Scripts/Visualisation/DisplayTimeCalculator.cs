using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayTimeCalculator : MonoBehaviour
{
    public delegate void PeriodChanged(int start, int end);
    public event PeriodChanged CurrentTimeUpdated; 

    public delegate void PeriodChangedWay(int start, int end);
    public event PeriodChangedWay FutureTimeUpdated; 
    public event PeriodChangedWay PastTimeUpdated; 

    [SerializeField] private int _additionalBorders = 5;

    [SerializeField] private Scrollbar _scrollbar;

    private int _previousHigherBorder, _previousLowerBorder;

    private float _size;

    private int _maxTime;

    public void Setup(LayerContainer layerContainer)
    {   
        CurrentTimeUpdated = null;

        SetSize();

        SetMaxTime(layerContainer);
    }

    private void SetSize() => _size = 1f - _scrollbar.size;

    private void SetMaxTime(LayerContainer layerContainer)
    {
        _maxTime = int.MinValue;

        for (int i = 0; i < layerContainer.Layers.Length; i++)
        {
            _maxTime = Mathf.Max(_maxTime, layerContainer.Layers[i].MaxTime);
        }
    }

    public void StartTime() => ValueUpdated(0f);

    public void ValueUpdated(float value)
    {
        float currentValue = _scrollbar.value;

        float screenAdditive = Mathf.Lerp(0f, _size, currentValue);

        int lowerBorder = (int)((currentValue - screenAdditive) * _maxTime) - _additionalBorders;
        int higherBorder = (int)((currentValue + _size - screenAdditive) * _maxTime) + _additionalBorders;

        if (higherBorder > _previousHigherBorder) FutureTimeUpdated?.Invoke(Mathf.Max(_previousHigherBorder, lowerBorder), higherBorder);
        else if (lowerBorder < _previousLowerBorder) PastTimeUpdated?.Invoke(lowerBorder, Mathf.Min(_previousLowerBorder, higherBorder));

        _previousLowerBorder = lowerBorder;
        _previousHigherBorder = higherBorder;

        CurrentTimeUpdated.Invoke(lowerBorder, higherBorder);
    }
}
