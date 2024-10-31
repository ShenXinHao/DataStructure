// See https://aka.ms/new-console-template for more information


class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val = 0, ListNode next = null) {
             this.val = val;
             this.next = next;
        }
}


internal class Program
{
    static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode temp = new ListNode();
        
        var result = temp;
        while(list1 != null && list2 != null)
        {
            
                if(list1.val <= list2.val)
                {
                    result.next = list1;
                   
                    list1 = list1.next;
                    
                }
                else
                {
                    result.next = list2;
                    list2 = list2.next;
                }
                result = result.next;
        }
        result.next = list1 == null ? list2 : list1;
        return temp.next;
    }
    
    public static void Main(string[] args)
    {
        //var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        //var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        var list1 = new ListNode(2);
        var list2 = new ListNode(1);
        MergeTwoLists(list1, list2);
    }
}