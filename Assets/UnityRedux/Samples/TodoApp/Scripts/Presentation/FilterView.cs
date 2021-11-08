using System;
using UnityEngine;
using UnityEngine.UI;
using UnityRedux.TodoApp.Models;

namespace UnityRedux.TodoApp.Presentation
{
    public class FilterView : MonoBehaviour
    {
        [SerializeField] private Button _all;
        [SerializeField] private Button _active;
        [SerializeField] private Button _complete;

        public void Initialize(Action<VisibilityFilter> onSelectFilter)
        {
            _all.onClick.AddListener(() => onSelectFilter(VisibilityFilter.All));
            _active.onClick.AddListener(() => onSelectFilter(VisibilityFilter.Active));
            _complete.onClick.AddListener(() => onSelectFilter(VisibilityFilter.Completed));
        }

        public void UpdateFilter(VisibilityFilter filter)
        {
            _all.image.color      = Color.white;
            _active.image.color   = Color.white;
            _complete.image.color = Color.white;

            var targetButton = filter switch
            {
                VisibilityFilter.All       => _all,
                VisibilityFilter.Active    => _active,
                VisibilityFilter.Completed => _complete,
                _                          => throw new ArgumentOutOfRangeException(nameof(filter), filter, null)
            };
            
            targetButton.image.color = Color.red;
        }
    }
}