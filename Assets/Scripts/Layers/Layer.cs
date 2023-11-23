using Bitlush;

public struct Layer
{
    private AvlTree<int, ScheduleElement> _elementsStartTime;
    public AvlTree<int, ScheduleElement> ElementsStartTime => _elementsStartTime;

    private AvlTree<int, ScheduleElement> _elementsEndTime;
    public AvlTree<int, ScheduleElement> ElementsEndTime => _elementsEndTime;

    private ScheduleElement[] _elements;
    public ScheduleElement[] Elements => _elements;

    private int _minTime;
    public int MinTime => _minTime;

    private int _maxTime; 
    public int MaxTime => _maxTime;

    public Layer(ScheduleElement[] elements, int minTime, int maxTime)
    {
        _elements = elements;

        _minTime = minTime;
        _maxTime = maxTime;

        _elementsStartTime = new AvlTree<int, ScheduleElement>();
        _elementsEndTime = new AvlTree<int, ScheduleElement>();

        for (int i = 0; i < elements.Length; i++)
        {
            _elementsStartTime.Insert(_elements[i].StartTime, _elements[i]);
            _elementsEndTime.Insert(_elements[i].EndTime, _elements[i]);
        }
    }
}
