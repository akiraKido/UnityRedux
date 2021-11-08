namespace UnityRedux
{
    public class Redux
    {
        public static Reducer<TState> CombineReducers<TState>(params IReducer<TState>[] reducers) =>
            (state, action) =>
            {
                foreach (var reducer in reducers)
                {
                    state = reducer.Invoke(state, action);
                }

                return state;
            };
    }
}