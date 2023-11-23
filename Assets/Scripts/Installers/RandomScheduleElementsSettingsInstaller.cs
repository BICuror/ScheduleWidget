using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/RandomScheduleElementsSettings")]

public sealed class RandomScheduleElementsSettingsInstaller : ScriptableObjectInstaller<RandomScheduleElementsSettingsInstaller> 
{
    [SerializeField] private RandomScheduleElementsSettings _randomScheduleElementsSettings;

    public override void InstallBindings()
    {
        Container.Bind<RandomScheduleElementsSettings>().FromInstance(_randomScheduleElementsSettings).AsSingle().NonLazy();
    }
}
