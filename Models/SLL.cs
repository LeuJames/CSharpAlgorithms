using System;

namespace algorithms.Models
{
  class SLL
  {
    public SLNode Head;
    public int Size;

    public SLL()
    {
      Head = null;
      Size = 0;
    }

    public SLL Append(int val)
    {
      var runner = Head;
      if (Head == null)
      {
        Head = new SLNode(val);
        Size++;
        return this;
      }
      while(runner.Next != null )
      {
        runner = runner.Next;
      }
      runner.Next = new SLNode(val);
      Size ++;
      return this;
    }

    public SLL AppendNode(SLNode node)
    {
      var runner = Head;
      if (Head == null)
      {
        Head = node;
        Size++;
        return this;
      }
      while(runner.Next != null )
      {
        runner = runner.Next;
      }
      runner.Next = node;
      Size ++;
      return this;
    }


    public void Display()
    {
      var runner = Head;
      while(runner != null )
      {
        Console.Write(runner.Value + " => ");
        runner = runner.Next;
      }
      Console.WriteLine("");
    }

    // SList: Reverse
    // Reverse the node sequence. Given an SList object, the .head property should point to the previously-last node, and the rest of the nodes should follow similarly from back to front.

    public SLL Reverse()
    {
      if (Head == null)
      {
        return this;
      }
      SLNode runner = Head;
      SLNode before = null;
      SLNode after = null;
      while (runner != null)
      {
        after = runner.Next;
        runner.Next = before;
        before = runner;
        runner = after;

      }
      Head = before;
      return this;
    }


// SList: Flatten Children
// Why limit nodes to contain only one pointer? In this challenge, each node has .next, but also .child that is either null or points to another head. In turn each child node could point to another list. Don’t alter .child; arrange .next pointers to ‘flatten’ the hierarchy into one linear list, from head through all others via .next.

    public SLL FlattenChildren()
    {
      SLNode runner = Head;
      while (runner != null)
      {
        if (runner.Child != null)
        {
          SLNode runner2 = runner.Child.Head;
          while(runner2.Next != null)
          {
            runner2 = runner2.Next;
          }
          runner2.Flag = true;
          runner2.Next = runner.Next;
          runner.Next = runner.Child.Head;
        }
        runner = runner.Next;
      }
      return this;
    }

// SList: Unflatten Children
//         Take the output from your “flatten child lists” function (a linear linked list containing nodes
// with .child pointers), and restore it to its original state. Do you need to change your flatten function to enable this?

    public SLL UnflattenChildren()
    {
      SLNode runner = Head;
      while(runner.Next != null)
      {
        if(runner.Child != null)
        {
          SLNode runner2 = runner.Child.Head;
            while(runner2.Flag != true)
            {
              runner2 = runner2.Next;
            }
            runner.Next = runner2.Next;
            runner2.Next = null;
        }
        runner = runner.Next;
      }
      return this;
    }

    public SLL ResetFlags()
    {
      SLNode runner = Head;
      while(runner != null )
      {
        runner.Flag = false;
      }
      Console.Write("Flags Reset...");
      return this;
    }



    // You can refactor this without using end flag - have to access the "Size" attribute
    // public SLL UnflattenChildren2()
    // {
    //   SLNode runner = Head;
    //   while(runner.Next != null)
    //   {
    //     if(runner.Child != null)
    //     {
    //       runner2.size =
    //       for ()
    //     }
    //     runner = runner.Next;
    //   }
    //   return this;
    // }

    public SLL MakeLoop(int val)
      {
          var runner = Head;
          SLNode temp = null;
          while(runner.Next != null)
          {
              if(runner.Value == val)
              {
                  temp = runner;
              }
              runner = runner.Next;
          }
          runner.Next = temp;
          return this;
      }


  // SList: Has Loop
  // Ben sends linked lists to Emma, but she doesn’t quite trust him. Is he trying to make her code spin infinitely? Given a linked list, determine whether it has a loop, and return a boolean accordingly.

    public bool HasLoop()
    {
      SLNode runner = Head;
      while(runner != null  )
      {
        if(runner.Flag)
        {
          Console.WriteLine("List has Loop!");
          return true;
        }
        runner.Flag = true;
        runner = runner.Next;
      }
      Console.WriteLine("List does not have Loop");
      return false;
    }

  // SList: Break Loop
  // Even better than finding where the loops start would be to just fix them. You will be given a potentially loopy list; determine whether there is a loop, and if so, break it. Retain all nodes, in original order.

    public SLL BreakLoop()
    {
      SLNode runner = Head;
      while(runner != null)
      {
        if(runner.Next.Flag)
        {
          runner.Next = null;
        }
        runner.Flag = true;
        runner = runner.Next;
      }
      Console.WriteLine("Loop is broken");
      return this;
    }
  }
}