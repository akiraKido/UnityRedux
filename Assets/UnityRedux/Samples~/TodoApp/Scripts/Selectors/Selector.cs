using System.Collections.Generic;
using System.Linq;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Selectors
{
    public static class Selector
    {
        public static IReadOnlyList<Todo>
            SelectFilteredTodos(IReadOnlyList<Todo> todos, VisibilityFilter activeFilter) =>
            todos.Where(t => activeFilter switch
            {
                VisibilityFilter.Active    => t.IsComplete == false,
                VisibilityFilter.Completed => t.IsComplete,
                _                          => true
            }).ToArray();
    }
}