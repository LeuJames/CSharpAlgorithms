using System;
using System.Collections.Generic;

namespace algorithms.Models
{
    public class TrieNode
    {
        public string Value {get;set;}
        public bool isWord {get;set;}
        public Dictionary<char, TrieNode> children {get;set;}
        public TrieNode(string val)
        {
            Value = val;
            isWord = false;
            children = new Dictionary<char, TrieNode>();
        }
    }
}