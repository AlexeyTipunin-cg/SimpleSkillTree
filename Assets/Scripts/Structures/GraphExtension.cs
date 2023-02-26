using System;
using System.Collections.Generic;

namespace Assets.Scripts.Structures
{
    public static class GraphExtension
    {
        public static bool AreNodesConnected<T>(this Graph<T> graph, T start, T finish, Func<T, bool> condition = null)
        {
            Queue<GraphNode<T>> searchList = new Queue<GraphNode<T>>();
            if (start.Equals(finish))
            {
                return true;
            }

            if (graph.Find(start) == null || graph.Find(finish) == null)
            {
                return false;
            }

            var startNode = graph.Find(start);
            HashSet<GraphNode<T>> visitedNodes = new HashSet<GraphNode<T>>();
            searchList.Enqueue(startNode);

            while (searchList.Count > 0)
            {
                GraphNode<T> currentNode = searchList.Dequeue();

                foreach (GraphNode<T> neighbor in currentNode.neighbors)
                {
                    if (neighbor.value.Equals(finish))
                    {
                        return true;

                    }

                    if (visitedNodes.Contains(neighbor))
                    {
                        continue;
                    }

                    if (condition != null)
                    {
                        if (!condition(neighbor.value))
                        {
                            continue;
                        }
                    }

                    visitedNodes.Add(neighbor);
                    searchList.Enqueue(neighbor);
                }

            }
            return false;
        }

        public static List<GraphNode<T>> FilterNeighbors<T>(this Graph<T> graph, T target, Func<T, bool> condition)
        {
            List<GraphNode<T>> searchList = new List<GraphNode<T>>();
            var startNode = graph.Find(target);
            foreach (var n in startNode.neighbors)
            {
                if (condition(n.value))
                {
                    searchList.Add(n);
                }
            }
            return searchList;
        }

        public static bool AreNodesConnected<T>(this Graph<T> graph, List<GraphNode<T>> nodes, T target, Func<T, bool> condition)
        {
            var endNode = graph.Find(target);
            foreach (var n in nodes)
            {
                bool hasPath = graph.AreNodesConnected(n.value, target, condition);
                if (!hasPath)
                {
                    return false;
                }
            }

            return true;
        }
    }
}