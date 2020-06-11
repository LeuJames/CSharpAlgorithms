using System;

namespace algorithms.Models
{
  class SLNode
  {
    public int Value;
    public SLNode Next;

    public SLL Child;

    public bool Flag;

    public SLNode(int val)
    {
      Value = val;
      Next = null;
      Child = null;
      Flag = false;
    }

  }
}