using System;

namespace UnityRedux
{
    public class TypedReducer<TState, TAction> : IReducer<TState>
    {
        private readonly Func<TState, TAction, TState> _reducer;

        public TypedReducer(Func<TState, TAction, TState> reducer)
        {
            _reducer = reducer;
        }

        public TState Invoke(TState state, object action)
        {
            if (action is TAction theAction)
            {
                return _reducer(state, theAction);
            }

            return state;
        }
    }
}