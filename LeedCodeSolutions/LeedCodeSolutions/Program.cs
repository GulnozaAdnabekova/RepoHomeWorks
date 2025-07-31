namespace LeedCodeSolutions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // 1 2 
            // 1
            if (n == 0) return;
            var i = 0;
            var j = 0;
            while (nums1.Length > i && n > j)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1 = Helper(nums1, i);
                    nums1[i] = nums2[j];
                    ++j;
                    ++i;
                }
                else if (nums1[i] == 0)
                {
                    nums1[i] = nums2[j];
                    ++j;
                    ++i;
                }
                else
                {
                    ++i;
                }
            }
        }

        private int[] Helper(int[] nums, int i)
        {
            for (int j = nums.Length - 1; j > i; j--)
            {
                nums[j] = nums[j - 1];
            }

            return nums;
        }
    }




    /*public class Solution
    {
        public bool IsPolindrome(int x)
        {
            if(x<0) return false;
            var reversed = 0;
            int y = x;
            while (true)
            {
                var r1 = x % 10;
                reversed = reversed * 10 + r1;
                x /= 10;
                if (x==0) break;
            }
            return reversed == y;
        }
    }*/

    /*public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;
            while (current != null && current.nect != null)
            {
                if (current.value == current.next.value)
                {
                    current.next = current.nex.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }
    }*/
}
