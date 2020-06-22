// Chapter 11 – Trees
// This chapter we explore trees, and in particular binary search tree (BST), an important data structure. The BST is optimized for quickly finding/retrieving
// elements. A BST is similar to a linked list, in that it stores data elements within node objects.

// The binary search tree adds a requirement that for every node, all nodes in its left subtree must have smaller values. Similarly, its right subtree must contain only values that are greater than or equal to its value. This constraint holds for every node in the subtree, not just the direct children. These rules determine exactly where new children are placed in a BST. If “Grandparent” node<50> has a right child with the value 75, then children of node<75> are appropriately constrained not only by their parent, but by that grandparent as well. Specifically, the entire left subtree of node<75> must have values between 50 and 75.

// BST nodes without children are considered leaf nodes. Depending on its values, no node is required to have two children. Even in a tree containing many values, the root node might have a left or right pointer that is null (e.g. if the root contains the smallest or largest value in the tree, respectively).

using System;

namespace algorithms.Models
{
    public class BTNode
    {
        public int Value;
        public BTNode Right;
        public BTNode Left;
        public BTNode(int val)
        {
            Value = val;
            Right = null;
            Left = null;
        }
    }

    public class BST
    {
        public BTNode Root;
        public BST()
        {
            Root = null;
        }

      public BST Add(int val)
      {
        BTNode NewNode = new BTNode(val);
        if(Root == null)
        {
          Root = NewNode;
          return this;
        }
        BTNode runner = Root;
        while(runner != null)
        {
          if(val < runner.Value)
          {
            if(runner.Left != null)
            {
              runner = runner.Left;
            }
            else
            {
              runner.Left = NewNode;
              return this;
            }
          }
          else
          {
            if(runner.Right != null)
              {
                runner = runner.Right;
              }
              else
              {
                runner.Right = NewNode;
                return this;
              }
          }
        }
        return this;
      }

      public void Display()
      {
        Display(Root);
      }

      public void Display(BTNode node)
      {
        if(node != null)
        {
          Console.Write($"{node.Value} ");
          Display(node.Left);
          Display(node.Right);
        }
        else
        {
          Console.Write("Null ");
        }
      }

      // BST: Min
      // Create a min() method on the BST class that returns the smallest value found in the BST. 

      public int? Min()
      {
        if(Root == null)
        {
          Console.WriteLine("BST is empty");
          return null;
        }
        BTNode runner = Root;
        while(runner.Left != null)
        {
          runner = runner.Left;
        }
        Console.WriteLine(runner.Value);
        return runner.Value;
      }

      // BST: Size
      // Write a size() method that returns the number of nodes (values) contained in the tree.

      public int Size()
      {
        return Size(Root);
      }

      public int Size(BTNode node)
      {
        if(node == null)
        {
          return 0;
        }
        return Size(node.Left) + Size(node.Right) + 1;
      }

      // BST: Contains
      // Create a contains(val) method on BST that returns whether the tree contains a given value.


      public bool Contains(int val)
      {
        if(Root == null)
        {
          Console.WriteLine($"Tree does not contain {val}");
          return false;
        }
        BTNode runner = Root;
        while(runner != null)
        {
          if(val == runner.Value)
          {
            Console.WriteLine($"Tree does contain {val}");
            return true;
          }
          else if(val < runner.Value)
          {
            runner = runner.Left;
          }
          else if (val > runner.Value)
          {
            runner = runner.Right;
          }
        }
        Console.WriteLine($"Tree does not contain {val}");
        return false;
      }
            
      // BST: Height
      // Build a height() method on the BST object that returns the total height of the tree – the longest sequence of nodes from root node to leaf node.

      public int Height()
      {
        return Height(Root);
      }

      private int Height(BTNode node)
      {
        if(node == null)
        {
          return 0;
        }
        return Math.Max(Height(node.Left), Height(node.Right)) + 1;
      }

      // BST: Is Balanced
      // Write isbalanced()method to indicate whether a BST is balanced. For this challenge, consider a tree balanced when all nodes are balanced. A BTNode is balanced if heights of its left subtree and right subtree differ by at most one.
      public bool IsBalanced()
      {
        if (Root == null)
        {
          return true;
        }
        return Math.Abs(Height(Root.Left) - Height(Root.Right)) <= 1;
      }

    // BST: Remove
    // Remove a given val. Return false if not found.

    // 3 cases => 
    //  1) remove leaf, 
            // just remove
    //  2) remove w/ 1 child, 
            //  swap
    //  3) 2 children
      // if 2 children, need to find next order successor
        // go right 1 step, then find smallest left (go down tree all the way to left)
        
    private int Min(BTNode monkey)
    {

          while(monkey.Left != null)
          {
              monkey = monkey.Left;
          }
          return monkey.Value;
    }

    public void SearchAndDestroy(int val)
    {
          Root = RemoveNode(Root,val);
    }

    public BTNode RemoveNode(BTNode node, int val)
    {
        if(node == null)
        {
            return node;
        }
        if(val < node.Value)
        {
            node.Left = RemoveNode(node.Left,val);
        }
        else if(val > node.Value)
        {
            node.Right = RemoveNode(node.Right,val);
        }
        else
        {
              Console.WriteLine("Found the Node!!!");
              if(node.Left == null)
              {
                  return node.Right;
              }
              else if(node.Right == null)
              {
                  return node.Left;
              }
              node.Value = Min(node.Right);
              node.Right = RemoveNode(node.Right,node.Value);

        }
        return node;
    }




    }

}