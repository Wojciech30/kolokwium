using System;

public class Pair<T, S> : IComparable<Pair<T, S>> where T : IComparable<T> where S : IComparable<S>
{
    public T First { get; }
    public S Second { get; }

    public Pair(T first, S second)
    {
        First = first;
        Second = second;
    }

    public int CompareTo(Pair<T, S> other)
    {
        int compareFirst = First.CompareTo(other.First);
        return compareFirst != 0 ? compareFirst : Second.CompareTo(other.Second);
    }
}
