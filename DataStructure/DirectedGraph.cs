using System;
using System.Collections.Generic;

namespace DataStructure {
    public class DirectedGraph: IGraph {
        // key is the startng node and value is the nodes that the starting node connects to
        Dictionary<string, List<string>> _graphInfo;

        public DirectedGraph(string graphInfo) {
            string testGraphInfo = "AB, AD, BC, BD,CA, CD, DA";
            //string testGraphInfo = "AB, AD, BC, BD,CA, CD, DA";
        }

        private void TryInitalize(string graphInfo) {
            try {
                Initialize(graphInfo);
            } catch (NullReferenceException exc) {
                Console.WriteLine($"Failed to initialize Graph from given information. {exc}");
            }
        }

        public void Initialize(string graphInfo) {            
            _graphInfo = new Dictionary<string, List<string>>();         
            // get the edges by splitting the graph info using comma seperator
            string[] edges = graphInfo.Split(',');
            foreach(string edge in edges) {
                string startNode = edge[0].ToString();
                string endNode = edge[1].ToString();
                AddNode(startNode, endNode);
            }
        }

        // todo implement the graph in array only form. Or linked array form . see the amount of code. 
        // Implement data structure from array
        private void AddNode(string startNode, string endNode) {
            if (_graphInfo.ContainsKey(startNode)) {
                    _graphInfo.Add(startNode, new List<string>(){endNode});
                } else {
                    if (!_graphInfo[startNode].Contains(endNode)) {
                        _graphInfo[startNode].Add(endNode);
                    }
                }
        }

    }
}