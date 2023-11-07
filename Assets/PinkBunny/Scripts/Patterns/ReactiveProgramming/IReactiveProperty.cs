using System;

namespace Laphed.Rx
{
    public interface IReactiveProperty<T>
    {
        T Value { get; }
        event Action OnChanged;
    }
}