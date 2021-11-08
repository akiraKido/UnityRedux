using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityRedux.TodoApp.Presentation
{
    public class TodoAddView : MonoBehaviour
    {
        [SerializeField] private InputField input;
        [SerializeField] private Button     addButton;

        public void Initialize(Action<string> onAdd)
        {
            addButton.onClick.AddListener(() => onAdd(input.text));
        }
    }
}