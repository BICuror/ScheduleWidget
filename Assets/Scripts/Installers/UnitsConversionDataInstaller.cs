using Zenject;
using UnityEngine;

[CreateAssetMenu(menuName = "Installers/UnitsConversionData")]


public sealed class UnitsConversionDataInstaller : ScriptableObjectInstaller<UnitsConversionDataInstaller> 
{
    [SerializeField] private UnitsConversionData _unitsConversionData;

    public override void InstallBindings()
    {
        Container.Bind<UnitsConversionData>().FromInstance(_unitsConversionData).AsSingle().NonLazy();
    }
}
