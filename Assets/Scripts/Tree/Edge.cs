

namespace Assets.Scripts.Tree
{
    public class Edge<T>
    {
        public T from { get; private set; }
        public T to { get; private set; }

        public Edge(T from, T to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
