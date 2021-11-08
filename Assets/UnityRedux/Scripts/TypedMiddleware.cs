using System;

namespace UnityRedux
{
    public class TypedMiddleware<TState, TAction> : IMiddleware<TState>
    {
        private readonly Func<Store<TState>, TAction, NextDispatcher, object> _middleware;

        public TypedMiddleware(Func<Store<TState>, TAction, NextDispatcher, object> middleware)
        {
            _middleware = middleware;
        }

        public object Invoke(Store<TState> store, object action, NextDispatcher next)
        {
            if (action is TAction theAction)
            {
                return _middleware(store, theAction, next);
            }
            else
            {
                return next(action);
            }
        }
    }
}