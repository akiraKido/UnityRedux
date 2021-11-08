using UnityRedux.TodoApp.Utils;

namespace UnityRedux.TodoApp.Models
{
    public readonly struct Todo
    {
        public readonly string Id;
        public readonly string Task;
        public readonly bool   IsComplete;

        public Todo(string id, string task, bool isComplete)
        {
            Id         = id;
            Task       = task;
            IsComplete = isComplete;
        }

        public override string ToString() => $"Todo{{IsComplete: {IsComplete}, Task: {Task}, Id: {Id}}}";

        public Todo CopyWith(
            Optional<string> id         = default,
            Optional<string> task       = default,
            Optional<bool>   isComplete = default
        ) =>
            new Todo(
                id: id ? id.Value : Id,
                task: task ? task.Value : Task,
                isComplete: isComplete ? isComplete.Value : IsComplete
            );
    }
}