namespace Assets.Scripts.Tree
{
    public class Node<T>
    {
        private T _value;
        public T value => _value;

        public Node(T value)
        {
            _value = value;
        }
    }
}