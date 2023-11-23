using UnityEngine;
using Zenject;

public sealed class RandomLayersGenerator : MonoBehaviour
{
    [Inject] private RandomGenerationSettings _randomGenerationSettings;
    [Inject] private RandomScheduleElementsSettings _randomScheduleElementsSettings;

    private LayerContainer _layerContainer;
    public LayerContainer GetLayerContainer() => _layerContainer;

    public void GenerateRandomSchedule()
    {
        ScheduleElementsGenerator elementsGenerator = new ScheduleElementsGenerator();

        Layer[] layers = new Layer[_randomGenerationSettings.LayersAmount];

        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = elementsGenerator.CreateScheduleElements(_randomGenerationSettings.ScheduleElementsPerLayer, _randomScheduleElementsSettings);
        }

        _layerContainer = new LayerContainer(layers);
    }
}
