using System;
using System.Collections.Generic;

namespace algorithms.Models
{
    public class Trie
    {
        public TrieNode Root {get;set;} = new TrieNode("");

        public void Insert(string Word)
        {
            var runner = Root;
            var currentValue = "";
            foreach(char letter in Word)
            {
              currentValue += letter;
              if(!runner.children.ContainsKey(letter))
              {
                runner.children[letter] = new TrieNode(currentValue);
                
              }
              runner = runner.children[letter];
            }
            runner.isWord = true;
        }

      public void Display()
      {
        Display(Root);
      }

      public void Display(TrieNode node)
      {
        Console.Write($"{node.Value} ");
        foreach( KeyValuePair<char, TrieNode> kvp in node.children )
        {
          Display(kvp.Value);
        }
      }

      public void DisplayWords()
      {
        DisplayWords(Root);
      }

      public void DisplayWords(TrieNode node)
      {
        if(node.isWord)
        {
          Console.Write($"{node.Value} ");
        }
        foreach( KeyValuePair<char, TrieNode> kvp in node.children )
        {
          DisplayWords(kvp.Value);
        }
      }


    }

}