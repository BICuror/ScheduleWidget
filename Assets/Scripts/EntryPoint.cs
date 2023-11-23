using UnityEngine;
using Zenject;

public sealed class EntryPoint : MonoBehaviour
{
    [Inject] private RandomLayersGenerator _randomLayersGenerator;
    [Inject] private ScheduleElementsVisualisator _scheduleElementsVisualisator;
    [Inject] private ContentSizePanelManager _contentSizePanelManager;
    [Inject] private DisplayTimeCalculator _displayTimeCalculator;
    [Inject] private ScheduleElementStateChecker _scheduleElementStateChecker;
    [Inject] private CurrentTimeLineManager _currentTimeLineManager;

    public void Enter()
    {
        _randomLayersGenerator.GenerateRandomSchedule();

        LayerContainer layerContainer = _randomLayersGenerator.GetLayerContainer();
        
        _contentSizePanelManager.AdaptSizeToLayers(layerContainer);
        
        _displayTimeCalculator.Setup(layerContainer);

        _scheduleElementsVisualisator.SetTimeCalculator(_displayTimeCalculator);

        _scheduleElementsVisualisator.VisualiseLayers(layerContainer);
    
        _displayTimeCalculator.StartTime();
        
        _currentTimeLineManager.SetScheduleElementStateChecker(_scheduleElementStateChecker);

        _scheduleElementStateChecker.StartChecking(layerContainer);
    }    
}
