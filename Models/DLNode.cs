namespace algorithms.Models
{

//   Doubly Linked List
// There is certainly no reason why a linked list node must refer to only one other node. For the best flexibility when traversing a list, we might want to be connected in both directions: forward and backward. Whereas singly linked lists feature nodes that only know about their forward neighbor (unable to look backward), doubly linked lists are more like lines of preschoolers holding hands as they walk down the street together, on a field trip to the fire station. This expands our ability to easily iterate back and forth through the DList, forming a much better parallel with our idx array iterator.

  public class DLNode
  {
        public int Value {get; set;}
        public DLNode Next {get; set;}
        public DLNode Previous {get; set;}
        public DLNode(int val)
        {
                Value = val;
                Next = null;
                Previous = null;
        }




  }
}