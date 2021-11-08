using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Actions
{
    public readonly struct DeleteTodoAction
    {
        public readonly string Id;

        public DeleteTodoAction(string id) => Id = id;

        public override string ToString() => $"DeleteTodoAction{{id: {Id}}}";
    }
    
    public readonly struct AddTodoAction
    {
        public readonly Todo Todo;

        public AddTodoAction(Todo todo) => Todo = todo;

        public override string ToString() => $"AddTodoAction{{todo: {Todo}}}";
    }

    public readonly struct UpdateTodoAction
    {
        public readonly string Id;
        public readonly Todo   UpdatedTodo;

        public UpdateTodoAction(string id, Todo updatedTodo)
        {
            Id          = id;
            UpdatedTodo = updatedTodo;
        }

        public override string ToString() => $"UpdateTodoAction{{Id: {Id}, UpdatedTodo: {UpdatedTodo}}}";
    }

    public readonly struct UpdateFilterAction
    {
        public readonly VisibilityFilter NewFilter;

        public UpdateFilterAction(VisibilityFilter newFilter)
        {
            NewFilter = newFilter;
        }
    }
}