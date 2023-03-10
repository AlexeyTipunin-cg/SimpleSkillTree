using System.Collections.Generic;

namespace Assets.Scripts.Structures
{
    public class GraphNode<T>
    {
        private T _value;
        private HashSet<GraphNode<T>> _neighbors;
        private ReadOnlySet<GraphNode<T>> _roNeighbors;

        public GraphNode(T value)
        {
            _value = value;
            _neighbors = new HashSet<GraphNode<T>>();
            _roNeighbors = _neighbors.AsReadOnly();
        }

        public T value => _value;

        public ReadOnlySet<GraphNode<T>> neighbors
        {
            get { return _roNeighbors; }
        }

        public bool AddNeighbor(GraphNode<T> node)
        {
            if (_neighbors.Contains(node))
            {
                return false;
            }
            else
            {
                _neighbors.Add(node);
                return true;
            }
        }

        public bool RemoveNeighbor(GraphNode<T> node)
        {
            return _neighbors.Remove(node);
        }

        public bool RemoveAllNeighbors()
        {
            _neighbors.Clear();
            return true;
        }
    }
}
