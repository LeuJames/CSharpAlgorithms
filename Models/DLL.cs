using System;
using System.Collections.Generic;

namespace algorithms.Models
{
  public class DLL
  {
        public DLNode Head {get; set;}
        public DLNode Tail {get; set;}


        public DLL()
        {
          Head = null;
          Tail = null;
        }

    // DLL Class
    // Given the above reference implementations for doubly linked node and doubly linked list, can you construct the rest of a basic DList class? This would include DList methods push(), pop(), front(), back(), contains(), and size().

        public DLL AddToBack(int val)
        {
          DLNode newNode = new DLNode(val);
          if (Head == null)
          {
            Head = newNode;
            Tail = newNode;
            return this;
          }
          Tail.Next = newNode;
          newNode.Previous = Tail;
          Tail = newNode;
          return this;
        }

        public DLL AddToFront(int val)
        {
          DLNode newNode = new DLNode(val);
          if (Head == null)
          {
            Head = newNode;
            Tail = newNode;
            return this;
          }
          Head.Previous = newNode;
          newNode.Next = Head;
          Head = newNode;
          return this;
        }

        public DLL Display()
        {
          var runner = Head;
          while(runner != null )
          {
            Console.Write(runner.Value + " => ");
            runner = runner.Next;
          }
          Console.WriteLine("");
          return this;
        }

        public int? RemoveFromFront()
        {
          if (Head == null)
          {
            Console.WriteLine("List is empty");
            return null;
          }
          int val = Head.Value;
          Head = Head.Next;
          Head.Previous = null;
          return val;
        }

      public int? RemoveFromBack()
        {
          if (Tail == null)
          {
            Console.WriteLine("List is empty");
            return null;
          }
          int val = Tail.Value;
          Tail = Tail.Previous;
          Tail.Next = null;
          Console.WriteLine(val);
          return val;
        }

        public bool Contains(int val)
        {
          var runner = Head;
          while(runner != null )
          {
            if(runner.Value == val)
            {
              Console.WriteLine($"Found {val}");
              return true;
            }
            runner = runner.Next;
          }
          Console.WriteLine($"{val} Doesn't exist in the list");
          return false;
        }

        public bool Contains2(int num)
        {
          var FrontRunner= Head;
          var BackRunner = Tail;
          while (FrontRunner != BackRunner && FrontRunner.Previous != BackRunner)
          {
            if(FrontRunner.Value == num || BackRunner.Value == num)
            {
              Console.WriteLine($"Found {num}");
              return true;
            }
            FrontRunner = FrontRunner.Next;
            BackRunner = BackRunner.Previous;
          }
          Console.WriteLine($"{num} Doesn't exist in the list");
          return false;
        }
        public int Size()
        {
          int count = 0;
          var runner = Head;
          while(runner != null )
          {
            count++;
            runner = runner.Next;
          }
          Console.WriteLine($"List contains {count} nodes.");
          return count;
        }

    // DList: Reverse
    // Create function to reverse nodes in a DList.

        public DLL Reverse()
        {
          DLNode Runner = Head;
          while (Runner != null )
          {
            DLNode Temp = Runner.Next;
            Runner.Next = Runner.Previous;
            Runner.Previous = Temp;
            Runner = Temp;
          }
          DLNode Temp2 = Head;
          Head = Tail;
          Tail = Temp2;
          return this;
        }

      public DLL Reverse2()
      {
        List<int> Values = new List<int>();
        DLNode Runner = Head;
        while(Runner != null)
        {
          Values.Add(Runner.Value);
          Runner = Runner.Next;
        }
        Runner = Tail;
        foreach (int Value in Values)
        {
          Runner.Value = Value;
          Runner = Runner.Previous;
        }
        return this;
      }

    }
  
}