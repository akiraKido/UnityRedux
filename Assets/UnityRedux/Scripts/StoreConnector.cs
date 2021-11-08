using System;
using UniRx;
using UnityEngine;

namespace UnityRedux
{
    public delegate TViewModel StoreConverter<TState, out TViewModel>(Store<TState> state);

    public abstract class StoreConnector<TState, TViewModel> : MonoBehaviour
    {
        protected abstract StoreConverter<TState, TViewModel> StoreConverter { get; }

        protected virtual void Initialize(TViewModel viewModel)
        {
        }

        protected virtual void OnUpdate(TViewModel viewModel)
        {
        }

        private void Start()
        {
            if (StoreConverter == null)
            {
                throw new StoreConnectorException("StoreConverter expected");
            }

            var store = StoreProvider<TState>.Current.Store;

            Initialize(StoreConverter(store));

            store.OnChange
                .Select(state => StoreConverter(store))
                .Subscribe(OnUpdate)
                .AddTo(gameObject);
        }

        private class StoreConnectorException : Exception
        {
            public StoreConnectorException(string msg) : base(msg)
            {
            }
        }
    }
}