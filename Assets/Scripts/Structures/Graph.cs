using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Structures
{
    public class Graph<T>
    {
        private List<GraphNode<T>> _nodes = new List<GraphNode<T>>();
        private GraphNode<T> _root;

        public Graph()
        {
        }

        public int count => _nodes.Count;
        public GraphNode<T> root => _root;
        public IList<GraphNode<T>> nodes => _nodes.AsReadOnly();

        public void Clear()
        {
            foreach (GraphNode<T> node in _nodes)
            {
                node.RemoveAllNeighbors();
            }

            _nodes.Clear();
        }

        public bool AddNode(T value)
        {
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                _nodes.Add(new GraphNode<T>(value));
                return true;
            }
        }

        public bool AddRootNode(T value)
        {
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                _root = new GraphNode<T>(value);
                _nodes.Add(_root);
                return true;
            }
        }

        public bool AddEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);
            if (node1 == null || node2 == null)
            {
                return false;
            }

            if (node1.neighbors.Contains(node2))
            {
                return false;
            }

            node1.AddNeighbor(node2);
            node2.AddNeighbor(node1);
            return true;
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return false;
            }

            _nodes.Remove(removeNode);
            foreach (var node in _nodes)
            {
                node.RemoveNeighbor(removeNode);
            }
            return true;
        }

        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);

            if (node1 == null || node2 == null) return false;
            if (!node1.neighbors.Contains(node2)) return false;

            node1.RemoveNeighbor(node2);
            node2.RemoveNeighbor(node1);
            return true;
        }

        public GraphNode<T> Find(T value)
        {
            foreach (var node in _nodes)
            {
                if (node.value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                builder.Append(_nodes[i].ToString());
                if (i < count - 1)
                {
                    builder.Append(',');
                }
            }
            return builder.ToString();
        }
    }
}
