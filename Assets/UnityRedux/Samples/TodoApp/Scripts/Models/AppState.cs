using System;
using System.Collections.Generic;

namespace UnityRedux.TodoApp.Models
{
    public readonly struct AppState
    {
        public readonly IReadOnlyList<Todo> Todos;
        public readonly VisibilityFilter    ActiveFilter;

        public AppState(IReadOnlyList<Todo> todos, VisibilityFilter activeFilter)
        {
            Todos             = todos;
            ActiveFilter = activeFilter;
        }

        public static AppState InitialState =>
            new AppState(
                todos: Array.Empty<Todo>(),
                activeFilter: VisibilityFilter.All
            );
    }
}