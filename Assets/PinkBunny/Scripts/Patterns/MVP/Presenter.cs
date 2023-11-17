using System;
using Laphed.Rx;

namespace Laphed.MVP
{
    public abstract class Presenter<TModelData, TViewData>: IDisposable
    {
        protected readonly IView<TViewData> view;
        private IReactiveProperty<TModelData> model;

        protected Presenter(IView<TViewData> view)
        {
            this.view = view;
            view.OnDispose += Dispose;
        }
        
        public void SubscribeModel(IReactiveProperty<TModelData> property)
        {
            model = property;
            property.OnChanged += HandleModelUpdate;
        }
        
        private void HandleModelUpdate() => UpdateView(model.Value);
        
        protected abstract void UpdateView(TModelData value);

        public void Dispose()
        {
            view.OnDispose -= Dispose;
            UnsubscribeModel();
        }
        
        private void UnsubscribeModel()
        {
            if (model == null) return;
            model.OnChanged -= HandleModelUpdate;
        }
    }
    
    public abstract class Presenter<T>: IDisposable
    {
        protected readonly IView<T> view;
        private IReactiveProperty<T> model;

        protected Presenter(IView<T> view)
        {
            this.view = view;
            view.OnDispose += Dispose;
        }

        public void SubscribeModel(IReactiveProperty<T> property)
        {
            model = property;
            property.OnChanged += HandleModelUpdate;
        }

        protected virtual void UpdateView(T value) => view.UpdateView(value);

        private void HandleModelUpdate() => UpdateView(model.Value);

        public void Dispose()
        {
            view.OnDispose -= Dispose;
            UnsubscribeModel();
        }

        private void UnsubscribeModel()
        {
            if (model == null) return;
            model.OnChanged -= HandleModelUpdate;
        }
    }
}