using UnityEngine;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Utils
{
    public abstract class ViewModelBase
    {
        public virtual void Initialize(Store<AppState> store)
        {
        }

        public virtual void UpdateData(Store<AppState> store)
        {
        }
    }

    public abstract class Container<TView, TViewModel> : StoreConnector<AppState, TViewModel>
        where TViewModel : ViewModelBase, new()
        where TView : Component
    {
        protected TView View;

        private TViewModel _viewModel;

        protected override StoreConverter<AppState, TViewModel> StoreConverter =>
            store =>
            {
                if (View == null)
                {
                    View = GetComponent<TView>();
                }
                
                if (_viewModel == null)
                {
                    _viewModel = new TViewModel();
                    _viewModel.Initialize(store);
                }
                else
                {
                    _viewModel.UpdateData(store);
                }

                return _viewModel;
            };
    }
}