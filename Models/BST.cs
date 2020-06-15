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
    }

}