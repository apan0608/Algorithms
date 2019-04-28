using System;
using System.Collections.Generic;
//using Problems.Extensions;

namespace Problems {
    
/*
      This problem is from amazon online coding assignment.
      Given a two dimentional array representing cities and roads.
      Another 2 dimontional array representing cost of building road in between the cities.
      Number of roads to be build.
      Find if it can be achieved with the number of roads to be build so that all cities are accesible.
      If can be achieved, then what's the minimum cost?
    */
    public class BuildRoadsWithMinimumCost {


        CityRoadMap cityRoadMap;
        int roadsToBuild;
        // {"AB", "BD", "CA"}
        List<string> citeisNotAccessible;
        public BuildRoadsWithMinimumCost(CityRoadMap cityRoadMap, int roadsToBuild) {
            this.cityRoadMap = cityRoadMap;        
            this.roadsToBuild = roadsToBuild;
        }

        // Evaluate to see if all the cities can access each other after new roads are built
        // without knowing which roads specifically will be built
        public bool CanAccessAllWithNewRoads(int roadsToBuild) {
          return true;

        }
   

        // Exhause all the options to build the raods between the cities that are not accessible yet
        private string PickRoadsToBuild(int index) {
            return "";
          
        }


 public static void Test() {
            int[] numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8};
            // given a number to pick from above, need to exhaust all combinations
            int toPick = 1;
            List<string> picked = new List<string>();
            int[] counter = new int[toPick]; // all counters are initialized with 0
            // when the first counter reached the end (leaving room for other counter), stop
            while (counter[0] < numbers.Length) { 
                int level = 0;
                string str = "";
                while(level < toPick) {                    
                    // keep picking till count  using picked count as level
                    int pickIndex = counter[level];   
                    str += numbers[pickIndex];
                    if (level == toPick - 1) {
                         // if the counter has a lower level, then do not need to increase count
                        counter[level]++;
                    }

                    if(counter[level] == numbers.Length) {
                        // it has reached end, reset back to 0
                        counter[level] = 0;  
                        // increase the upper level counter by 1, if it's not the top most level
                        if (level != 0) {
                            counter[level - 1]++;
                        }
                    }          
                    // if the counter reached then end, reset counter to upper level counter, then reset upeer level counter 
                    level++;
                }
                Console.WriteLine(str);
            }              
        }



    }    
}