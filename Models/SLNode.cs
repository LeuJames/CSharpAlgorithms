using System;

namespace algorithms.Models
{
  class SLNode
  {
    public int Value;
    public SLNode Next;

    public SLL Child;

    public bool End;

    public SLNode(int val)
    {
      Value = val;
      Next = null;
      Child = null;
      End = false;
    }

  }
}