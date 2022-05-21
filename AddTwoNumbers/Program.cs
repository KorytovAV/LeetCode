using System;
using System.Linq;
using System.Text;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = ReadNode();
            ListNode node2 = ReadNode();

            ListNode result = AddTwoNumbers(node1, node2);

            WriteNode(result);
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            int prVal = 0;
            ListNode prNode = null;

            while (l1 != null || l2 != null)
            {
                int v1 = l1 != null ? l1.val : 0;
                int v2 = l2 != null ? l2.val : 0;
                int val = v1 + v2;
                if (prVal > 9) val++;

                ListNode newNode = new ListNode(val > 9 ? val-10 : val) ;
                if (result == null)
                    result = newNode;
                else
                    prNode.next = newNode;

                prVal = val;
                prNode = newNode;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            if (prVal>9)
                prNode.next = new ListNode(1);

            return result;
        }

        private static ListNode ReadNode()
        {
            int[] dataSet = Console.ReadLine().Split(',').Select(it => int.Parse(it)).ToArray();
            ListNode nextNode = null;
            ListNode node = null;
            for (int i = dataSet.Length - 1; i >= 0; i--)
            {
                node = new ListNode(dataSet[i], nextNode);
                nextNode = node;
            }

            return node;
        }

        private static void WriteNode(ListNode node)
        {
            StringBuilder sb = new StringBuilder();

            ListNode n = node;
            while (n != null)
            {
                sb.Append(n.val);
                n = n.next;
            }

            Console.WriteLine(sb.ToString());
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
