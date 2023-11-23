using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public sealed class ScheduleVisualisationObject : MonoBehaviour
{
    [SerializeField] private ColorScheduleElementVisualisationData _colorScheduleElementVisualisationData;

    private Image _image;
    private RectTransform _rectTransform;

    private ScheduleElement _scheduleElement;
    public ScheduleElement Element => _scheduleElement;

    private void Awake() 
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetScheduleElement(ScheduleElement element)
    {
        UnsubscribeFromCurrentElement();

        element.StateChanged += ChangeState;
        _scheduleElement = element;

        ChangeState(element.CurrentState);
    }

    private void UnsubscribeFromCurrentElement()
    {
        if (_scheduleElement != null)
        {
            _scheduleElement.StateChanged -= ChangeState;
        }
    }

    public void SetPositionAndScale(UnitsConversionData unitsConversionData, int timeOffset)
    {
        float startPosition = (_scheduleElement.StartTime - timeOffset) * unitsConversionData.UnitsPerSecond;

        float width = _scheduleElement.Duration * unitsConversionData.UnitsPerSecond;                
        
        _rectTransform.sizeDelta = new Vector2(width, 0f);
        transform.localScale = Vector3.one;

        _rectTransform.anchoredPosition = new Vector2(startPosition, 0f);
    }

    public void ChangeState(ScheduleElement.State state)
    {
        switch(state)
        {
            case ScheduleElement.State.Jeopardy: _image.color = _colorScheduleElementVisualisationData.JeopardyColor; break;
            case ScheduleElement.State.Pending: _image.color = _colorScheduleElementVisualisationData.PendingColor; break;
            case ScheduleElement.State.Completed: _image.color = _colorScheduleElementVisualisationData.CompleteColor; break;
        }
    } 
}
