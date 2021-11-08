using System;
using System.Collections.Generic;
using UnityEngine;
using UnityRedux.TodoApp.Actions;
using UnityRedux.TodoApp.Models;
using UnityRedux.TodoApp.Presentation;
using UnityRedux.TodoApp.Selectors;
using UnityRedux.TodoApp.Utils;

namespace UnityRedux.TodoApp.Containers
{
    [RequireComponent(typeof(TodoList))]
    public class FilteredTodosContainer : Container<TodoList, TodoListViewModel>
    {
        protected override void Initialize(TodoListViewModel viewModel)
        {
            View.Initialize(viewModel.OnToggleComplete, viewModel.OnDelete);
            OnUpdate(viewModel);
        }

        protected override void OnUpdate(TodoListViewModel viewModel)
        {
            View.UpdateList(viewModel.Todos);
        }
    }

    public class TodoListViewModel : ViewModelBase
    {
        public Action<Todo>        OnToggleComplete { get; private set; }
        public Action<Todo>        OnDelete         { get; private set; }
        public IReadOnlyList<Todo> Todos            { get; private set; }

        public override void Initialize(Store<AppState> store)
        {
            OnToggleComplete = todo => ToggleComplete(store, todo);
            OnDelete         = todo => Delete(store, todo);
            UpdateData(store);
        }

        public override void UpdateData(Store<AppState> store)
        {
            Todos = Selector.SelectFilteredTodos(store.State.Todos, store.State.ActiveFilter);
        }

        private static void ToggleComplete(Store<AppState> store, Todo todo)
        {
            var newTodo = todo.CopyWith(isComplete: !todo.IsComplete);

            store.Dispatch(new UpdateTodoAction(todo.Id, newTodo));
        }

        private static void Delete(Store<AppState> store, Todo todo)
        {
            store.Dispatch(new DeleteTodoAction(todo.Id));
        }
    }
}