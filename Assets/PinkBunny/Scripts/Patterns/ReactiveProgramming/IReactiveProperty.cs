namespace Laphed.Rx
{
    public interface IReactiveProperty<T>: INotifyPropertyChanged
    {
        T Value { get; }
    }
}