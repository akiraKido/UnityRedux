using System;
using UnityRedux.TodoApp.Actions;
using UnityRedux.TodoApp.Models;
using UnityRedux.TodoApp.Presentation;
using UnityRedux.TodoApp.Utils;

namespace UnityRedux.TodoApp.Containers
{
    public class FilterSelectionContainer : Container<FilterView, FilterSelectionViewModel>
    {
        protected override void Initialize(FilterSelectionViewModel viewModel)
        {
            View.Initialize(viewModel.OnSelectFilter);
            OnUpdate(viewModel);
        }

        protected override void OnUpdate(FilterSelectionViewModel viewModel)
        {
            View.UpdateFilter(viewModel.ActiveFilter);
        }
    }

    public class FilterSelectionViewModel : ViewModelBase
    {
        public Action<VisibilityFilter> OnSelectFilter { get; private set; }
        public VisibilityFilter         ActiveFilter   { get; private set; }
        
        public override void Initialize(Store<AppState> store)
        {
            OnSelectFilter = filter => store.Dispatch(new UpdateFilterAction(filter));
            UpdateData(store);
        }

        public override void UpdateData(Store<AppState> store)
        {
            ActiveFilter = store.State.ActiveFilter;
        }
    }
}