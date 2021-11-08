using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Reducers
{
    public static class AppStateReducer
    {
        public static AppState Reducer(AppState state, object action)
        {
            return new AppState(
                todos: TodosReducer.Reducer(state.Todos, action),
                activeFilter: VisibilityReducer.Reducer(state.ActiveFilter, action)
            );
        }
    }
}