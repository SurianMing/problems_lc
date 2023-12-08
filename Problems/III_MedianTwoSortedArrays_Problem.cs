namespace LeetCode.SolutionRunner.Problems;

internal class IV_MedianTwoSortedArrays_Problem : IProblem
{
    public void Run()
    {
        Tuple<int[], int[], double>[] testCases =
        [
            new([1, 3], [2], 2.0000),
            new([1, 2], [3, 4], 2.50000)
        ];

        foreach(var testCase in testCases)
        {
            var result = MedianTwoSortedArrays(testCase.Item1, testCase.Item2);
            var expectedResult = testCase.Item3;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static double MedianTwoSortedArrays(int[] nums1, int[] nums2)
    {
        var noVals = nums1.Length + nums2.Length;
        var nums1Pos = 0;
        var nums2Pos = 0;
        var numbersToSkip = noVals % 2 == 0
            ? noVals / 2 - 1
            : noVals / 2;

        for (int i = 0; i < numbersToSkip; i++)
        {
            if (TakeFromNums1(nums1, nums1Pos, nums2, nums2Pos))
            {
                nums1Pos++;
            }
            else
            {
                nums2Pos++;
            }
        }

        if (noVals % 2 == 0)
        {
            int subTotal;
            if (TakeFromNums1(nums1, nums1Pos, nums2, nums2Pos))
            {
                subTotal = nums1[nums1Pos];
                nums1Pos++;
            }
            else
            {
                subTotal = nums2[nums2Pos];
                nums2Pos++;
            }
            subTotal += TakeFromNums1(nums1, nums1Pos, nums2, nums2Pos)
                ? nums1[nums1Pos]
                : nums2[nums2Pos];

            return (double)subTotal / (double)2;
        }
        else
        {
            return TakeFromNums1(nums1, nums1Pos, nums2, nums2Pos)
                ? nums1[nums1Pos]
                : nums2[nums2Pos];
        }
    }

    private static bool TakeFromNums1(int[] nums1, int nums1Pos, int[] nums2, int nums2Pos)
        => nums1Pos != nums1.Length
            && (nums2Pos == nums2.Length || nums1[nums1Pos] < nums2[nums2Pos]);
}