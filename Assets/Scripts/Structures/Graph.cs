using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Structures
{
    public class Graph<T>
    {
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        public int Count => nodes.Count;
        public GraphNode<T> _root;

        public IList<GraphNode<T>> Nodes => nodes.AsReadOnly();

        public Graph()
        {

        }

        public Graph(GraphNode<T> root)
        {
            _root = root;
        }

        public void Clear()
        {
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveAllNeighbors();
            }

            nodes.Clear();
        }

        public bool AddNode(T value)
        {
            if (Find(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<T>(value));
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

            if (node1.Neighbors.Contains(node2))
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

            nodes.Remove(removeNode);
            foreach (var node in nodes)
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
            if (!node1.Neighbors.Contains(node2)) return false;

            node1.RemoveNeighbor(node2);
            node2.RemoveNeighbor(node1);
            return true;
        }

        public GraphNode<T> Find(T value)
        {
            foreach (var node in nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(nodes[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(',');
                }
            }
            return builder.ToString();
        }
    }
}
