using System;

namespace Laphed.MVP
{
    public interface IView<T>
    {
        void UpdateView(T value);
        event Action OnDispose;
    }
}