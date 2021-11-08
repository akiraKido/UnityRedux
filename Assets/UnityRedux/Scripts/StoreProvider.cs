namespace UnityRedux
{
    public class StoreProvider<TState>
    {
        public static StoreProvider<TState> Current { get; private set; }

        public readonly Store<TState> Store;
        
        private StoreProvider(Store<TState> store)
        {
            Store = store;
        }
        
        public static void Initialize(Store<TState> store)
        {
            Current = new StoreProvider<TState>(store);
        }
    }
}