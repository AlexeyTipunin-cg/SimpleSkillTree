using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Structures
{
    public class GraphNode<T>
    {
        T value;
        List<GraphNode<T>> neighbors;

        public GraphNode(T value)
        {
            this.value = value;
            neighbors = new List<GraphNode<T>>();
        }

        public T Value
        {
            get { return value; }
        }

        public IList<GraphNode<T>> Neighbors
        {
            get { return neighbors.AsReadOnly(); }
        }

        public bool AddNeighbor(GraphNode<T> node)
        {
            if (neighbors.Contains(node))
            {
                return false;
            }
            else
            {
                neighbors.Add(node);
                return true;
            }
        }

        public bool RemoveNeighbor(GraphNode<T> node)
        {
            return neighbors.Remove(node);
        }

        public bool RemoveAllNeighbors()
        {
            neighbors.Clear();
            return true;
        }

        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append($"[Node Value: {value} Neighbors:");
            for (int i = 0; i < neighbors.Count; i++)
            {
                nodeString.Append(neighbors[i].Value + " ");
            }
            nodeString.Append(']');
            return nodeString.ToString();
        }

    }
}
