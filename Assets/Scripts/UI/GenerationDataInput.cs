using UnityEngine;
using Zenject;

public sealed class GenerationDataInput : MonoBehaviour
{
    [Inject] private RandomGenerationSettings _randomGenerationSettings;

    public void SetLayersAmount(string text)
    {
        int resultValue;

        if (int.TryParse(text, out resultValue))
        {
            _randomGenerationSettings.SetLayersAmount(resultValue);
        }
    }

    public void SetScheduleElementsPerLayer(string text)
    {
        int resultValue;

        if (int.TryParse(text, out resultValue))
        {
            _randomGenerationSettings.SetScheduleElementsPerLayer(resultValue);
        }
    }
}
