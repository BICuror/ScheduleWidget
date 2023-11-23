using UnityEngine;
using Zenject;

public sealed class ContentSizePanelManager : MonoBehaviour
{
    [Inject] private UnitsConversionData _unitsConversionData;

    [SerializeField] private RectTransform _contentPanel;
    [SerializeField] private int _minimalLayersAmount = 14;

    public void AdaptSizeToLayers(LayerContainer layerContainer)
    {
        int maxTime = int.MinValue;

        for (int i = 0; i < layerContainer.Layers.Length; i++)
        {
            maxTime = Mathf.Max(maxTime, layerContainer.Layers[i].MaxTime);
        }

        float width = maxTime * _unitsConversionData.UnitsPerSecond - _contentPanel.rect.width;
        float height = Mathf.Max(layerContainer.Layers.Length, _minimalLayersAmount) * _unitsConversionData.UnitsPerLayer;
        _contentPanel.sizeDelta = new Vector2(width, height);
    }
}
