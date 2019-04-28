using System;
using System.Collections.Generic;

namespace Problems {

    // This class is to store the city road information 
    public class CityRoadMap {

        // Store the index of the cities, the index is used below to mao the roads and road cost
        public string[] Cities { get ; private set ; }
        // Represents the roads between the cities
        public bool[,] RoadMap { get ; private set ; }
        public int[,] RoadCostMap { get ; private set ; }

        public int NumberOfCities => Cities.Length;      

        // the key is city pair, like AB, AC, value is whether they can indirectly or directly access each otehr
        private Dictionary<string, bool> AccessInfo;

        public CityRoadMap(string[] cities, bool[,] cityRoadMap, int[,] roadCostMap) {
            Cities = cities;
            RoadMap = cityRoadMap;
            RoadCostMap = roadCostMap;
            GetAccessInfo();            
        }
       
       private void GetAccessInfo() {
            AccessInfo = new Dictionary<string, bool>();
            foreach(var city in Cities) {
                foreach(var otherCity in Cities) {
                    if (city == otherCity) {
                        continue;
                    }
                    var canAccess = CanAccess(city, otherCity);
                    CacheAccessInfo(city, otherCity, canAccess);                   
                }
            }
       }
       
        private void CacheAccessInfo(string cityA, string cityB, bool canAccess) {
           string key = GetKey(cityA, cityB);
           // store access information somewhere to use for the future
    
           if (AccessInfo.ContainsKey(key)) {
               AccessInfo[key] = canAccess;
           } else {
               AccessInfo.Add(key, canAccess);
           }
        }

       // Find out all the cities that are not directly or indirectly connected
        public List<Tuple<int, int>> GetCitiesNotConnected() {      
            // for through each city, then check if the city can connect to others 
            foreach(var city in Cities) {
                foreach(var otherCity in Cities) {
                    if (city == otherCity) {
                        continue;
                    }
                    if (CanAccess(city, otherCity)) {

                    }
                }

            }
            return null;
        }


        // todo using the given road map to check if all the cities can now 
        // access each other directly or indirectly 
        public bool CanAcessAll(bool[,] roadMap) {

            // 
            return true;
        }

        public bool CanAccess(string cityA, string cityB) {
            bool? canAcess = CanAccessFromCache(cityA, cityB);
            if (canAcess.HasValue) {
                return canAcess.Value;
            }
            int indexCityA = Cities.IndexOf(cityA);
            int indexCityB = Cities.IndexOf(cityB);
            var canAccess = CanAccessBreadthFirstSearch(indexCityA, indexCityB);      
            return canAccess;         
       }

       private bool? CanAccessFromCache(string cityA, string cityB) {
           string key = GetKey(cityA, cityB);
           if (AccessInfo.ContainsKey(key)) {
               return AccessInfo[key];
           }
           return null;
       }

        private string GetKey(string cityA, string cityB) {
            string key;
            if (char.Parse(cityA) <= char.Parse(cityB)) {
               key = cityA + cityB;
            } else {
               key = cityB + cityA;
            }
           return key;
        }

        // Given city A and city B, find out if A can directly or indirectly acess B
      public bool CanAccessBreadthFirstSearch(int cityA, int cityB) {
          var toVisit = new Queue<int>();
          var visited = new List<int>();
          toVisit.Enqueue(cityA);
          while (toVisit.Count > 0) {
            // visit one city in the toVisit list
            var current = toVisit.Dequeue();

            if (current == cityB) {
              return true;
            }
            // do not visit twice
            if (visited.Contains(current)) {
                continue;
            }
            visited.Add(current);
            // get all the cities is directly connected to
            var connected = GetDirectlyConnected(current);
            foreach (var city in connected) {
              if (!visited.Contains(city)) {
                toVisit.Enqueue(city);
              }
            }
          }
          return false;
      }

      // using Depth first search to check if city A can access city B. ALways visit the last one added firsy
      // looks like the depth first search is longer to write 
      public bool CanAccessDepthFirstSearch(int cityA, int cintyB) {
          var toVisit = new Stack<int>();
          var visited = new List<int>();
          toVisit.Push(cityA);
          while (toVisit.Count > 0) {
            // get the last added item
            var current = toVisit.Peek();
            var connected = GetDirectlyConnected(cityA);

            bool findNext = false;
            // add the next city to the stack to traverse deeper 
            foreach (var city in connected) {
               if (visited.Contains(city)) {
                 continue;
               }
               findNext = true;
               toVisit.Push(city);
               break;               
            }             

            if (!findNext) {
              // if next node is not found for given city, then this is the deepest node, start processing
              current = toVisit.Pop();

              if (current == cintyB) {
                return true;
              } else {
                visited.Add(current);
              }          
            }
          }
          return false;
      }

       private List<int> GetDirectlyConnected(int city) {
          var connected = new List<int>();
          int index = city;
          for (int i = 0; i < NumberOfCities; i++) {
             if (RoadMap[index, i]) {
               connected.Add(i);
             }              
          }
          return connected;          
      }

    }
}