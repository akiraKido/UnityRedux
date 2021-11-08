namespace UnityRedux.TodoApp.Utils
{
    public readonly struct Optional<T>
    {
        public readonly bool HasValue;
        public readonly T    Value;

        private Optional(bool hasValue, T value)
        {
            HasValue = hasValue;
            Value    = value;
        }

        public static Optional<T> Some(T value) => new Optional<T>(true, value);

        public static Optional<T> None() => new Optional<T>();

        public static implicit operator bool(Optional<T> o) => o.HasValue;

        public static implicit operator Optional<T>(T value) => Some(value);
    }
}