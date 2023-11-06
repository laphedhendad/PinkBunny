namespace Laphed.PinkBunny.UI
{
    public abstract class Presenter<TModelData, TViewData>
    {
        protected readonly IView<TViewData> view;

        protected Presenter(IView<TViewData> view)
        {
            this.view = view;
        }

        protected abstract void UpdateView(TModelData value);
    }
    
    public abstract class Presenter<T>
    {
        protected readonly IView<T> view;

        protected Presenter(IView<T> view)
        {
            this.view = view;
        }

        protected virtual void UpdateView(T value)
        {
            view.UpdateView(value);
        }
    }
}