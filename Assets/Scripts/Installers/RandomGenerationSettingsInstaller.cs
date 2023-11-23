using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/RandomGenerationSettings")]

public sealed class RandomGenerationSettingsInstaller : ScriptableObjectInstaller<RandomGenerationSettingsInstaller> 
{
    [SerializeField] private RandomGenerationSettings _randomGenerationSettings;

    public override void InstallBindings()
    {
        Container.Bind<RandomGenerationSettings>().FromInstance(_randomGenerationSettings).AsSingle().NonLazy();
    }
}
