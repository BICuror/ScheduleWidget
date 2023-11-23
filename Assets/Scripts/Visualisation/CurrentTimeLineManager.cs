using UnityEngine;
using Zenject;
using DG.Tweening;

public sealed class CurrentTimeLineManager : MonoBehaviour
{
    [Inject] private UnitsConversionData _unitsConversionData;    

    [SerializeField] private RectTransform _rectTransform;
    
    public void SetScheduleElementStateChecker(ScheduleElementStateChecker scheduleElementStateChecker)
    {   
        _rectTransform.anchoredPosition = Vector2.zero;

        scheduleElementStateChecker.CheckedSecond += OnCheckSecond;
    }

    private void OnCheckSecond(int second)
    {
        DOTween.Kill(transform);

        DOVirtual.Float(second * _unitsConversionData.UnitsPerSecond, (second + 1) * _unitsConversionData.UnitsPerSecond, Time.timeScale, SetPosition).SetEase(Ease.Linear);
    }
    
    private void SetPosition(float value)
    {
        _rectTransform.anchoredPosition = new Vector2(value, 0f);
    }
}
