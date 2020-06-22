using System;
using System.Collections.Generic;
using algorithms.Models;

namespace algorithms
{
    class Program
    {

      // Given a sorted array and a value, return whether the array contains that value. Do not sequentially iterate the array. Instead, ‘divide and conquer’, taking advantage of the fact that the array is sorted. As always, only use built-in functions that you are prepared to recreate (write yourself) on demand!
      public static bool BinarySearch(int[] arr, int num)
        {
          int midPoint = (int) arr.Length / 2;
          if (num <= arr[midPoint])
          {
            for(int i = midPoint; i >= 0; i--)
            {
              if(num == arr[i])
              {
                return true;
              }
            }
          }
          else 
          {
            for(int j = midPoint+1; j < arr.Length; j++)
            {
              if(num == arr[j])
              {
                return true;
              }
            }
          }
          return false;
        }

      public static bool Exists(int[] arr, int val, int min, int max)
      {
        Console.WriteLine($"min={min}, max={max}, arr len = {max-min}");

        if(max-min==1 && arr[min]!=val && arr[max]!=val){
            return false;
        }

        int cnt = min+(max-min)/2;

        if(arr[cnt]>val){
            max = cnt;
        } else if(arr[cnt]<val){
            min = cnt;
        } else {
            return true;
        }

        return Exists(arr,val,min,max);
      }

    // Array: Remove Duplicates
    // Remove array duplicates. Do not alter original. Return new array with results ‘stable’ (original order). For [1,2,1,3,4,2] return [1,2,3,4].

      public static int[] RemoveDuplicates(int[] arr)
      {
        List<int> ret = new List<int>();
        for(int i = 0; i < arr.Length; i++)
        {
          bool isPresent = false;
          for(int j = 0; j < ret.Count; j++)
          {
            if(arr[i] == ret[j])
            {
              isPresent = true;
              break;
            }
          }
          if( !isPresent)
          {
            ret.Add(arr[i]);
          }
        }
        Console.WriteLine(String.Join(", ", ret));
        return ret.ToArray();
      }

      // Taco Truck
      // Joe drives a taco truck in the booming town of Squaresburg. He uses an array of [x,y] coordinates corresponding to locations of his customers. They walk to his truck, but he is fair-minded so he wants to minimize total distance from truck to customers. City blocks are perfect squares, and every street is two-way, at perfect right angles. 
      // He only parks by street corners (coordinates like [37,-16]). Customers only travel on streets: coordinate [2,-2] is distance 4 from [0,0]. Joe checks the array before deciding where to park. Given a customer coordinate array, return an optimal taco truck location. Example: given [ [10,0], [-1,-10], [2,4] ], return [2,0], as total distance is 25 (8+13+4).

      public static int GetDistance (int[,] customers, int[] coord)
      {
        int sum = 0;
        for(int i =0; i< customers.GetLength(0); i++)
        {
          sum += Math.Abs(coord[0] - customers[i,0]) + Math.Abs(coord[1] - customers[i,1]);
        }
        Console.WriteLine(sum);
        return sum;
      }

      public static int[] OptimalXY (int[,] customers)
      {
        int minX = customers[0,0];
        int maxX = customers[0,0];
        int minY = customers[0,1];
        int maxY = customers[0,1];

        for(int i = 1; i< customers.GetLength(0); i++)
        {
          if(customers[i,0] < minX)
          {
            minX = customers[i,0];
          }
          if(customers[i,0] > maxX)
          {
            maxX = customers[i,0];
          }
          if(customers[i,1] < minY)
          {
            minY = customers[i,1];
          }
          if(customers[i,1] > maxY)
          {
            maxY = customers[i,1];
          }
        }

        int minDistance = Int32.MaxValue;
        int[] minCoord = new int[]{minX, minY};

        for(int x = minX; x < maxX; x++)
        {
          for (int y = minY; y < maxY; y++)
          {
            int distance = GetDistance(customers, new int[]{x,y});
            if (distance < minDistance)
            {
              minDistance = distance;
              minCoord[0] = x;
              minCoord[1] = y;
            }
          }
        }

        Console.WriteLine($"x:{minCoord[0]}, y: {minCoord[1]}");
        Console.WriteLine(minDistance);
        return minCoord;
      }

        static void Main(string[] args)
        {
          // Binary Search:
            // int[] arr = new int[]{3,8,15,21,33,89};
            // int num = 33;
            // Console.WriteLine(BinarySearch(arr, num));

          // Exists:
            // Console.WriteLine($"{Exists(arr,num,0,arr.Length)}");
          
          // Remove Duplicates:
            // int[] arr1 = new int[]{1,2,1,3,4,2};
            // RemoveDuplicates(arr1);

          // Taco Truck (Optimize location):
            // int[,] customers = new int[,]{{10,0},{-1,-10},{2,4}};
            // int[] test = new int[]{2,0};
            // GetDistance(customers, test);
            // OptimalXY(customers);

          // Singly Linked Lists:
            // Console.WriteLine("Singly Linked Lists!");
            // SLL List1 = new SLL();
            // Console.Write("List1 Creation: ");
            // List1.Append(5).Append(3).Append(9).Append(6).Display();

          // Reverse SLL:
            // List.Reverse().Display();

          // Flatten Children:
            // Console.Write("List2 Creation: ");
            // SLL List2 = new SLL();
            // List2.Append(4).Append(7).Append(2).Display();

            // List1.Head.Next.Child = List2;

            // Console.Write("List1 Flatten Children: ");
            // List1.FlattenChildren().Display();
            
            // Console.Write("List2: ");
            // List2.Display();

          // Unflatten Children:
            // Console.Write("List1 Unflatten Children: ");
            // List1.UnflattenChildren().Display();
            // Console.Write("List 2: ");
            // List2.Display();

          // Looped Lists:
            // Console.Write("LoopList Creation... ");
            // // List1.MakeLoop(3).HasLoop();
            // List1.MakeLoop(3).BreakLoop().Display();
            
          // Doubly Linked Lists:
            // DLL DList1 = new DLL();
            // Console.WriteLine("List Creation: ");
            // DList1.AddToBack(5).AddToFront(7).AddToFront(4).AddToBack(6).Display();

            // DList1.Size();

            // Console.Write("Searching... ");
            // DList1.Contains(4);

            // Console.Write("Searching... ");
            // DList1.Contains(9);

            // Console.Write("Remove From Front: ");
            // Console.WriteLine(DList1.RemoveFromFront());
            // Console.Write("List is now: ");
            // DList1.Display();

            // Console.Write("Remove From Back: ");
            // DList1.RemoveFromBack();
            // Console.Write("List is now: ");
            // DList1.Display();

            // DList1.Reverse().Display();

          // Binary Search Tree
            // BST Tree1 = new BST();
            // Tree1.Add(10).Add(5).Add(8).Add(15).Add(23).Add(8).Add(9).Display();
            // Console.WriteLine("");
            // Console.Write("Min is: ");
            // Tree1.Min();
            // Console.Write("Size is: ");
            // Console.WriteLine(Tree1.Size());
            // Tree1.Contains(23);
            // Tree1.Contains(7);
            // Console.Write("Tree 1 height: ");
            // Console.WriteLine(Tree1.Height());
            // Console.Write("Is Tree 1 Balanced? ");
            // Console.WriteLine(Tree1.IsBalanced());

            // BST Tree2 = new BST();
            // Tree2.Add(10).Add(5).Add(15).Add(17);
            // Console.Write("Tree 2 height: ");
            // Console.WriteLine(Tree2.Height());
            // Console.Write("Is Tree 2 Balanced? ");
            // Console.WriteLine(Tree2.IsBalanced());

          // Tries
            Trie trie1 = new Trie();
            trie1.Insert("car");
            trie1.Insert("cat");
            trie1.Insert("cart");
            trie1.Insert("dog");
            trie1.Display();
            Console.WriteLine();
            trie1.DisplayWords();
        }
    }
}
