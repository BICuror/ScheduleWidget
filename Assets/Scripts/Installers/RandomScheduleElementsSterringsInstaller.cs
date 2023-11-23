using Zenject;
using UnityEngine;

[CreateAssetMenu(menuName = "Installers/RandomScheduleElementsSettings")]

public sealed class RandomScheduleElementsSterringsInstaller : ScriptableObjectInstaller<RandomScheduleElementsSterringsInstaller> 
{
    [SerializeField] private RandomScheduleElementsSettings _randomScheduleElementsSettings;

    public override void InstallBindings()
    {
        Container.Bind<RandomScheduleElementsSettings>().FromInstance(_randomScheduleElementsSettings).AsSingle().NonLazy();
    }
}
