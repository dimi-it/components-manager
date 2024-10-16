namespace DBManager.Util;

public class MutualExclusiveTuple<T, U>
{
    private readonly T? _first;
    private readonly U? _second; 
    private readonly bool _isFirstNull = false;
    
    public MutualExclusiveTuple(T? first, U? second)
    {
        if (first is null && second is null)
        {
            throw new InvalidOperationException("Only one of the value can be null");
        }

        _first = first;
        _second = second;
        _isFirstNull = first is null ? true : false;
    }

    public bool IsFirst() => _isFirstNull;
    public bool IsSecond() => _isFirstNull;

    public T GetFirst() => _first ?? throw new NullReferenceException("First is null");
    public U GetSecond() => _second ?? throw new NullReferenceException("Second is null");
}