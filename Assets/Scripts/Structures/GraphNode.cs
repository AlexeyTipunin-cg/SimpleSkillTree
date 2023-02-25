using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Structures
{
    public class GraphNode<T>
    {
        private T _value;
        private List<GraphNode<T>> _neighbors;

        public GraphNode(T value)
        {
            this._value = value;
            _neighbors = new List<GraphNode<T>>();
        }

        public T value => _value;

        public IList<GraphNode<T>> neighbors
        {
            get { return _neighbors.AsReadOnly(); }
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

        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append($"[Node Value: {_value} Neighbors:");
            for (int i = 0; i < _neighbors.Count; i++)
            {
                nodeString.Append(_neighbors[i].value + " ");
            }
            nodeString.Append(']');
            return nodeString.ToString();
        }

    }
}
