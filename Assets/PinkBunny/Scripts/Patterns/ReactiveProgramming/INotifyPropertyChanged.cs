using System;

namespace Laphed.Rx
{
    public interface INotifyPropertyChanged
    {
        event Action OnChanged;
    }
}