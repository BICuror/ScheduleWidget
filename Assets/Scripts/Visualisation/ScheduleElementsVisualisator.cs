using UnityEngine;
using System.Collections.Generic;
using Zenject;

public sealed class ScheduleElementsVisualisator : MonoBehaviour
{   
    [Header("Links")]
    [SerializeField] private RectTransform _layerObject;

    [Header("Prefabs")]
    [SerializeField] private ScheduleVisualisationObject _scheduleElementVisualisationPrefab;
    [SerializeField] private Transform _layerObjectContainer;

    [Inject] private UnitsConversionData _unitsConversionData;

    private RectTransform[] _layerObjects;

    private ObjectPool<ScheduleVisualisationObject> _objectPool;

    private LayerContainer _layerContainer;

    private int _minTime;

    public void SetTimeCalculator(DisplayTimeCalculator displayTimeCalculator)
    {
        displayTimeCalculator.FutureTimeUpdated += EnableElementsInFutureTimePeriod;
        displayTimeCalculator.PastTimeUpdated += EnableElementsInPastTimePeriod;

        displayTimeCalculator.CurrentTimeUpdated += DisableAllElementsOffScreen;
    }

    public void VisualiseLayers(LayerContainer layerContainer)
    {
        _layerContainer = layerContainer;

        ClearObjectPool();

        CreateObjectPool();

        DeleteAllLayers();
        
        CreateLayerObjects();

        CalculateMinTime();
    }

    private void ClearObjectPool()
    {
        if (_objectPool != null)
        {
            _objectPool.DestroyAllObjects();
        }
    }

    private void CreateObjectPool()
    {
        _objectPool = new ObjectPool<ScheduleVisualisationObject>(_scheduleElementVisualisationPrefab, 100);
    }

    private void CalculateMinTime()
    {
        _minTime = int.MaxValue;

        for (int i = 0; i < _layerContainer.Layers.Length; i++)
        {
            _minTime = Mathf.Min(_minTime, _layerContainer.Layers[i].MinTime);
        }
    }

    public void CreateLayerObjects()
    {
        _layerObjects = new RectTransform[_layerContainer.Layers.Length];

        for (int i = 0; i < _layerObjects.Length; i++)
        {
            _layerObjects[i] = Instantiate(_layerObject, Vector3.zero, Quaternion.identity, _layerObjectContainer);
        }
    }

    public void DeleteAllLayers()
    {
        if (_layerObjects == null) return;

        for (int i = 0; i < _layerObjects.Length; i++)
        {
            Destroy(_layerObjects[i].gameObject);
        }
    }

    private void EnableElementsInFutureTimePeriod(int startTime, int endTime)
    {
        for (int i = 0; i < _layerContainer.Layers.Length; i++)
        {
            for (int time = startTime - 1; time <= endTime + 1; time++)
            {
                ScheduleElement currentElement;

                if (_layerContainer.Layers[i].ElementsStartTime.Search(time, out currentElement))
                {
                    ActivateElement(currentElement, i);
                }
            }
        }
    }

    private void EnableElementsInPastTimePeriod(int startTime, int endTime)
    {
        for (int i = 0; i < _layerContainer.Layers.Length; i++)
        {
            for (int time = startTime - 1; time <= endTime + 1; time++)
            {
                ScheduleElement currentElement;
                
                if (_layerContainer.Layers[i].ElementsEndTime.Search(time, out currentElement))
                {
                    ActivateElement(currentElement, i);
                }
            }
        }
    }

    private void ActivateElement(ScheduleElement element, int layerIndex)
    {
        ScheduleVisualisationObject currentElement = _objectPool.GetNextPooledObject();
        
        currentElement.transform.SetParent(_layerObjects[layerIndex].transform);
        
        currentElement.SetScheduleElement(element);

        currentElement.SetPositionAndScale(_unitsConversionData, _minTime);
    }

    private void DisableAllElementsOffScreen(int startTime, int endTime)
    {
        IReadOnlyList<ScheduleVisualisationObject> list = _objectPool.GetList();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].gameObject.activeSelf == true)
            {
                if (list[i].Element.StartTime > endTime) list[i].gameObject.SetActive(false);
                else if (list[i].Element.EndTime < startTime) list[i].gameObject.SetActive(false);
            }
        }
    }
}
