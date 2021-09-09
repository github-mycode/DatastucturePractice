using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class ListNode
    {
        private int weight;
        private ListNode next;
        public ListNode()
        {
            this.weight = 1;
            this.next = null;
        }
        public ListNode(int weight)
        {
            this.weight = weight;
            this.next = null;
        }
        public ListNode(int weight, ListNode node)
        {
            this.weight = weight;
            this.next = node;
        }

    }
}
