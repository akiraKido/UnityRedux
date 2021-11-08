using System;
using UnityEngine;
using UnityEngine.UI;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Presentation
{
    public class TodoEntry : MonoBehaviour
    {
        [SerializeField] private Text   _isComplete;
        [SerializeField] private Text   _text;
        [SerializeField] private Button _completeButton;
        [SerializeField] private Button _deleteButton;

        public void Initialize(Todo todo, Action onToggleComplete, Action onDelete)
        {
            _isComplete.text = todo.IsComplete ? "✔" : string.Empty;
            _text.text       = todo.Task;

            _completeButton.onClick.AddListener(() => onToggleComplete());
            _deleteButton.onClick.AddListener(() => onDelete());
        }
    }
}