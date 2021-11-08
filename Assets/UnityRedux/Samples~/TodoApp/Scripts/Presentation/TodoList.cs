using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Presentation
{
    public class TodoList : MonoBehaviour
    {
        private Action<Todo> _onToggleComplete;
        private Action<Todo> _onDelete;

        [SerializeField] private Transform _entriesParent;
        [SerializeField] private TodoEntry _entryPrefab;

        public void Initialize(Action<Todo> onToggleComplete, Action<Todo> onDelete)
        {
            _onToggleComplete = onToggleComplete;
            _onDelete         = onDelete;
        }

        public void UpdateList(IEnumerable<Todo> todos)
        {
            foreach (var child in _entriesParent.Cast<Transform>())
            {
                Destroy(child.gameObject);
            }

            foreach (var todo in todos)
            {
                var instance = Instantiate(_entryPrefab, _entriesParent);
                instance.Initialize(
                    todo,
                    onToggleComplete: () => _onToggleComplete(todo),
                    onDelete: () => _onDelete(todo));
            }
        }
    }
}