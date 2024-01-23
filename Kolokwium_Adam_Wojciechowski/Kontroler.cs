using System;
using System.Collections;
using System.Collections.Generic;

public delegate void ItemAddedEventHandler<T>(object sender, ItemAddedEventArgs<T> e);

public class ItemAddedEventArgs<T> : EventArgs
{
    public T Item { get; set; }
}

public class Kontroler<T> : IEnumerable<T>
{
    private List<T> items;

    public Kontroler()
    {
        items = new List<T>();
    }

    public event EventHandler<ItemAddedEventArgs<T>> ItemAdded;

    public void Add(T newItem)
    {
        items.Add(newItem);
        OnItemAdded(newItem);
    }

    public void Delete(T item)
    {
        items.Remove(item);
    }

    protected virtual void OnItemAdded(T newItem)
    {
        ItemAdded?.Invoke(this, new ItemAddedEventArgs<T> { Item = newItem });
    }

    public void Sort(Comparison<T> comparison)
    {
        items.Sort(comparison);
    }

    public void Filter(Func<T, bool> predicate)
    {
        items.RemoveAll(item => !predicate(item));
    }

    public List<T> GetItems()
    {
        return new List<T>(items);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


}
