using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program {
static int[] trucksList ={10,10,22,33,10,5,23,33,10,33,5};

  public static void Main(string[] args) {
    int[] topKTrucks = FindMostCommon(trucksList, 2);           
    foreach (var topKTruck in topKTrucks)
            {
                Console.WriteLine(@"truck: "+ topKTruck);
            }
  }
  public  static int[] FindMostCommon(int[] trucks, int k)
  {
           var orderedTrucks = trucks.OrderBy(i=>i);
           Dictionary<int, int> dictionaryTrucks = new Dictionary<int, int>();
           int firstElement = orderedTrucks.FirstOrDefault();
           int count = 0;
           foreach (var orderedTruck in orderedTrucks.Append(0))
           {
               if (firstElement == orderedTruck)
               {
                   count++;
               }
               else
               {
                   dictionaryTrucks.Add(firstElement,count);
                   count = 1;
                   firstElement = orderedTruck;
               }
           }
           var keyValuePairs = dictionaryTrucks.OrderByDescending(rec => rec.Value);
           int[] topTrucks = new int [k];
           for (int i = 0; i < k; i++)
           {
               topTrucks[i] = keyValuePairs.ElementAt(i).Key;
           }           
           return topTrucks;
  }
  
}