
using System;
using System.Collections.Generic;
using System.Text;
namespace Assets.Scripts.Structures
{
    public static class GraphExtension
    {
        public static string Search<T>(this Graph<T> graph, T start, T finish)
        {
            LinkedList<GraphNode<T>> searchList = new LinkedList<GraphNode<T>>();
            if (start.Equals(finish))
            {
                return start.ToString();
            }

            if (graph.Find(start) == null || graph.Find(finish) == null)
            {
                return null;
            }

            var startNode = graph.Find(start);
            Dictionary<GraphNode<T>, PathNodeInfo<T>> pathNodes = new Dictionary<GraphNode<T>, PathNodeInfo<T>>();
            pathNodes.Add(startNode, new PathNodeInfo<T>(null));
            searchList.AddFirst(startNode);

            while (searchList.Count > 0)
            {
                GraphNode<T> currentNode = searchList.First.Value;
                searchList.RemoveFirst();

                foreach (GraphNode<T> neighbor in currentNode.Neighbors)
                {
                    if (neighbor.Value.Equals(finish))
                    {
                        pathNodes.Add(neighbor, new PathNodeInfo<T>(currentNode));
                        return ConvertPathToString(neighbor, pathNodes);

                    }

                    if (pathNodes.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    pathNodes.Add(neighbor, new PathNodeInfo<T>(currentNode));

                    searchList.AddLast(neighbor);

                }

            }
            return string.Empty;
        }

        public static bool HasPath<T>(this Graph<T> graph, T start, T finish, Func<T, bool> condition)
        {
            LinkedList<GraphNode<T>> searchList = new LinkedList<GraphNode<T>>();
            if (start.Equals(finish))
            {
                return true;
            }

            if (graph.Find(start) == null || graph.Find(finish) == null)
            {
                return false;
            }

            var startNode = graph.Find(start);
            Dictionary<GraphNode<T>, PathNodeInfo<T>> pathNodes = new Dictionary<GraphNode<T>, PathNodeInfo<T>>();
            pathNodes.Add(startNode, new PathNodeInfo<T>(null));
            searchList.AddFirst(startNode);

            while (searchList.Count > 0)
            {
                GraphNode<T> currentNode = searchList.First.Value;
                searchList.RemoveFirst();

                foreach (GraphNode<T> neighbor in currentNode.Neighbors)
                {
                    if (neighbor.Value.Equals(finish))
                    {
                        pathNodes.Add(neighbor, new PathNodeInfo<T>(currentNode));
                        return true;

                    }

                    if (pathNodes.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    if (!condition(neighbor.Value))
                    {
                        continue;
                    }

                    pathNodes.Add(neighbor, new PathNodeInfo<T>(currentNode));

                    searchList.AddLast(neighbor);

                }

            }
            return false;
        }

        public static bool hasLeaf<T>(this Graph<T> graph, T target, T root, Func<T, bool> filterCondition, Func<T, bool> condition)
        {
            LinkedList<GraphNode<T>> searchList = new LinkedList<GraphNode<T>>();
            var startNode = graph.Find(target);
            var rootNode = graph.Find(root);
            foreach (var n in startNode.Neighbors)
            {
                if (!filterCondition(n.Value))
                {
                    continue;
                }

                bool hasPath = graph.HasPath(n.Value, root, condition);
                if (!hasPath)
                {
                    return true;
                }
            }

            return false;
        }

        private static string ConvertPathToString<T>(GraphNode<T> endNode, Dictionary<GraphNode<T>, PathNodeInfo<T>> pathNodes)
        {
            LinkedList<GraphNode<T>> path = new LinkedList<GraphNode<T>>();
            path.AddFirst(endNode);
            GraphNode<T> previous = pathNodes[endNode].Previous;
            while (previous != null)
            {
                path.AddFirst(previous);
                previous = pathNodes[previous].Previous;
            }

            StringBuilder pathStr = new StringBuilder();
            LinkedListNode<GraphNode<T>> currentNode = path.First;
            int nodeCount = 0;
            while (currentNode != null)
            {
                nodeCount++;
                pathStr.Append(currentNode.Value.Value);
                if (nodeCount < path.Count)
                {
                    pathStr.Append(" ");
                }
                currentNode = currentNode.Next;
            }
            return pathStr.ToString();
        }
    }
}