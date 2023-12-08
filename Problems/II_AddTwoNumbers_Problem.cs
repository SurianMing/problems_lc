namespace LeetCode.SolutionRunner.Problems;

internal class II_AddTwoNumbers_Problem : IProblem
{
    public class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public void Run()
    {
        Tuple<ListNode, ListNode, ListNode>[] testCases =
        [
            new(new(2, new(4, new(3))), new(5, new(6, new(4))), new(7, new(0, new(8)))),
            new(
                new(9),
                new(1, new(9, new(9, new(9, new(9, new(9, new(9, new(9, new(9, new(9)))))))))),
                new(0, new(0, new(0, new(0, new(0, new(0, new(0, new(0, new(0, new(0, new(1)))))))))))
            )
        ];

        foreach(var testCase in testCases)
        {
            var resultNode = AddTwoNumbers(testCase.Item1, testCase.Item2);
            var expectedNode = testCase.Item3;

            var expectedNodeValue = expectedNode.val;
            var resultNodeValue = resultNode.val;

            while(expectedNode is not null && expectedNode.val == resultNode!.val)
            {
                expectedNode = expectedNode.next;
                resultNode = resultNode.next;
            }

            if (resultNode != null)
                throw new Exception();
        }
    }

    private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = BuildResultListNode(l1, l2);
        return result!;
    }

    private static ListNode? BuildResultListNode(ListNode? l1, ListNode? l2, int carry = 0)
    {
        if (l1 is null && l2 is null)
        {
            return carry == 1
                ? new ListNode(1)
                : null;
        }

        var val = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;

        return new ListNode(val % 10, BuildResultListNode(l1?.next, l2?.next, val >= 10 ? 1 : 0));
    }
}