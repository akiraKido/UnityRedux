using System;
using UnityRedux.TodoApp.Actions;
using UnityRedux.TodoApp.Models;
using UnityRedux.TodoApp.Presentation;
using UnityRedux.TodoApp.Utils;

namespace UnityRedux.TodoApp.Containers
{
    public class AddTodoContainer : Container<TodoAddView, AddTodoViewModel>
    {
        protected override void Initialize(AddTodoViewModel viewModel)
        {
            View.Initialize(viewModel.OnAddTodo);
        }
    }

    public class AddTodoViewModel : ViewModelBase
    {
        public Action<string> OnAddTodo { get; private set; }
        
        public override void Initialize(Store<AppState> store)
        {
            OnAddTodo = task =>
            {
                var todo = new Todo(Guid.NewGuid().ToString("N"), task, false);
                store.Dispatch(new AddTodoAction(todo));
            };
        }
    }
}