public sealed class ScheduleElement
{
    public delegate void StateChangeHandler(State state);
    public event StateChangeHandler StateChanged;

    private int _startTime;
    public int StartTime => _startTime; 

    private int _endTime;
    public int EndTime => _endTime;

    public int Duration => _endTime - _startTime;

    private State _currentState;
    public State CurrentState => _currentState;

    public ScheduleElement(int startTime, int endTime)
    {   
        _currentState = State.Jeopardy;

        _startTime = startTime;
        _endTime = endTime;
    }

    public void StartPending() 
    {
        _currentState = State.Pending;
    
        InvokeChangeStateEvent();
    }

    public void Complete()
    {
        _currentState = State.Completed;    

        InvokeChangeStateEvent();
    }

    private void InvokeChangeStateEvent() => StateChanged?.Invoke(_currentState);

    public enum State
    {
        Jeopardy,
        Pending,
        Completed
    }
}
