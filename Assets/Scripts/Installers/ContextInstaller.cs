using UnityEngine;
using Zenject;

public sealed class ContextInstaller : MonoInstaller
{
    [SerializeField] private RandomLayersGenerator _randomLayersGenerator;
    [SerializeField] private ScheduleElementsVisualisator _scheduleElementsVisualisator;
    [SerializeField] private ContentSizePanelManager _contentSizePanelManager;
    [SerializeField] private DisplayTimeCalculator _displayTimeCalculator;
    [SerializeField] private ScheduleElementStateChecker _scheduleElementStateChecker;
    [SerializeField] private CurrentTimeLineManager _currentTimeLineManager;

    public override void InstallBindings()
    {
        Container.Bind<RandomLayersGenerator>().FromInstance(_randomLayersGenerator).AsSingle().NonLazy();
        Container.Bind<ScheduleElementsVisualisator>().FromInstance(_scheduleElementsVisualisator).AsSingle().NonLazy();
        Container.Bind<ContentSizePanelManager>().FromInstance(_contentSizePanelManager).AsSingle().NonLazy();
        Container.Bind<DisplayTimeCalculator>().FromInstance(_displayTimeCalculator).AsSingle().NonLazy();
        Container.Bind<ScheduleElementStateChecker>().FromInstance(_scheduleElementStateChecker).AsSingle().NonLazy();
        Container.Bind<CurrentTimeLineManager>().FromInstance(_currentTimeLineManager).AsSingle().NonLazy();
    }
}
