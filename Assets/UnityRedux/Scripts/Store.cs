using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace UnityRedux
{
    public delegate TState Reducer<TState>(TState state, object action);

    public interface IReducer<TState>
    {
        TState Invoke(TState state, object action);
    }

    public delegate object Middleware<TState>(Store<TState> store, object action, NextDispatcher next);

    public interface IMiddleware<TState>
    {
        object Invoke(Store<TState> store, object action, NextDispatcher next);
    }

    public delegate object NextDispatcher(object action);

    public class Store<TState>
    {
        public TState              State    { get; private set; }
        public IObservable<TState> OnChange => _changeSubject;

        private readonly Reducer<TState>             _reducer;
        private readonly Subject<TState>             _changeSubject = new Subject<TState>();
        private readonly IReadOnlyList<NextDispatcher> _dispatchers;

        public Store(
            Reducer<TState>                 reducer,
            TState                          initialState,
            IEnumerable<Middleware<TState>> middleware = null,
            bool                            distinct   = false)
        {
            middleware ??= Array.Empty<Middleware<TState>>();

            _reducer     = reducer;
            State       = initialState;
            _dispatchers = CreateDispatchers(middleware, CreateReduceAndNotify(distinct));
        }

        private NextDispatcher CreateReduceAndNotify(bool distinct) =>
            action =>
            {
                var state = _reducer(State, action);

                if (distinct && state.Equals(State))
                {
                    return null;
                }

                State = state;
                _changeSubject.OnNext(state);
                return null;
            };

        private IReadOnlyList<NextDispatcher> CreateDispatchers(
            IEnumerable<Middleware<TState>> middleware,
            NextDispatcher                  reduceAndNotify)
        {
            var dispatchers = new List<NextDispatcher> {reduceAndNotify};

            foreach (var nextMiddleware in middleware.Reverse())
            {
                var next = dispatchers.Last();

                dispatchers.Add(action => nextMiddleware(this, action, next));
            }

            dispatchers.Reverse();
            return dispatchers;
        }

        public void Dispatch(object action)
        {
            _dispatchers[0](action);
        }
    }
}