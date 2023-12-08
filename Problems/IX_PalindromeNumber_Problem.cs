namespace LeetCode.SolutionRunner.Problems;

internal class IX_PalindromeNumber_Problem : IProblem
{
    public void Run()
    {
        KeyValuePair<int, bool>[] testCases =
        [
            new(1000000001, true),
            new(12021, true),
            new(1001, true),
            new(121, true),
            new(-121, false),
            new(10, false)
        ];

        foreach(var testCase in testCases)
        {
            var result = IsPalindrome(testCase.Key);
            var expectedResult = testCase.Value;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        long maxPowerOf10 = 1;
        while ((x / maxPowerOf10) >= 1)
        {
            maxPowerOf10 *= 10;
        }

        var i = 0;
        var lowerNumberDivisor = 1;
        var upperNumberDivisor = (int)(maxPowerOf10 / 10);

        while (upperNumberDivisor >= lowerNumberDivisor)
        {
            if ((x / lowerNumberDivisor % 10) != x / upperNumberDivisor % 10)
            {
                return false;
            }
            lowerNumberDivisor *= 10;
            upperNumberDivisor /= 10;

            i++;
        }

        return true;
    }
}