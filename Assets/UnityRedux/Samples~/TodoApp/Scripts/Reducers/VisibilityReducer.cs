using UnityRedux.TodoApp.Actions;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Reducers
{
    public static class VisibilityReducer
    {
        public static readonly Reducer<VisibilityFilter> Reducer = Redux.CombineReducers(
            new TypedReducer<VisibilityFilter, UpdateFilterAction>(UpdateFilter)
        );

        private static VisibilityFilter UpdateFilter(VisibilityFilter filter, UpdateFilterAction action)
        {
            return action.NewFilter;
        }
    }
}