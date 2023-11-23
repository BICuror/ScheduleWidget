using Bitlush;
using UnityEngine;
using Zenject;

public sealed class ScheduleElementStateChecker: MonoBehaviour
{
    public delegate void TimeChangeHandler(int secondCheched);
    public event TimeChangeHandler CheckedSecond; 

    private LayerContainer _layerContainer;

    private int _currentTime = 0; 

    private int _maxTime;

    public void StartChecking(LayerContainer layerContainer)
    {
        _maxTime = int.MinValue;

        for (int i = 0; i < layerContainer.Layers.Length; i++)
        {
           _maxTime = Mathf.Max(layerContainer.Layers[i].MaxTime, _maxTime);
        }

        _layerContainer = layerContainer;

        _currentTime = 0;
        
        CancelInvoke();

        CheckNextSecond();
    }

    private void CheckNextSecond()
    {
        for (int i = 0; i < _layerContainer.Layers.Length; i++)
        {
            CheckLayerToUpdateScheduleElements(_layerContainer.Layers[i], _currentTime);
        }

        CheckedSecond.Invoke(_currentTime);

        _currentTime++;

        if (_currentTime <= _maxTime) Invoke("CheckNextSecond", Time.timeScale);
    }

    public void CheckLayerToUpdateScheduleElements(Layer layerToCheck, int time)
    {
        CheckLayerToStartPendingScheduleElement(layerToCheck.ElementsStartTime, time);
        CheckLayerToCompleteScheduleElement(layerToCheck.ElementsEndTime, time);
    }    

    private void CheckLayerToStartPendingScheduleElement(AvlTree<int, ScheduleElement> tree, int time)
    {
        ScheduleElement currentElement;

        if (tree.Search(time, out currentElement))
        {
            currentElement.StartPending();
        }
    }

    private void CheckLayerToCompleteScheduleElement(AvlTree<int, ScheduleElement> tree, int time)
    {
        ScheduleElement currentElement;

        if (tree.Search(time, out currentElement))
        {
            currentElement.Complete();
        }
    }
}
