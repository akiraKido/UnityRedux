using System.Collections.Generic;
using System.Linq;
using UnityRedux.TodoApp.Actions;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Reducers
{
    public static class TodosReducer
    {
        public static readonly Reducer<IReadOnlyList<Todo>> Reducer = Redux.CombineReducers(
            new TypedReducer<IReadOnlyList<Todo>, AddTodoAction>(AddTodo),
            new TypedReducer<IReadOnlyList<Todo>, DeleteTodoAction>(DeleteTodo),
            new TypedReducer<IReadOnlyList<Todo>, UpdateTodoAction>(UpdateTodo)
        );

        private static IReadOnlyList<Todo> AddTodo(IReadOnlyList<Todo> todos, AddTodoAction action)
        {
            return todos.Append(action.Todo).ToArray();
        }

        private static IReadOnlyList<Todo> DeleteTodo(IReadOnlyList<Todo> todos, DeleteTodoAction action)
        {
            return todos.Where(t => t.Id != action.Id).ToArray();
        }

        private static IReadOnlyList<Todo> UpdateTodo(IReadOnlyList<Todo> todos, UpdateTodoAction action)
        {
            IEnumerable<Todo> Creator()
            {
                foreach (var todo in todos)
                {
                    yield return todo.Id == action.Id ? action.UpdatedTodo : todo;
                }
            }

            return Creator().ToArray();
        }
    }
}