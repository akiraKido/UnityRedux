using UnityEngine;
using UnityRedux.TodoApp.Models;
using UnityRedux.TodoApp.Reducers;

namespace UnityRedux.TodoApp
{
    public static class TodoAppMain
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitializeApp()
        {
            StoreProvider<AppState>.Initialize(new Store<AppState>(
                AppStateReducer.Reducer,
                AppState.InitialState
            ));
        }
    }
}