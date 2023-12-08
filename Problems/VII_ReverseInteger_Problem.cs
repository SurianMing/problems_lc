namespace LeetCode.SolutionRunner.Problems;

internal class VII_ReverseInteger_Problem : IProblem
{
    public void Run()
    {
        KeyValuePair<int, int>[] testCases =
        [
            new(123, 321),
            new(-123, -321),
            new(120, 21)
        ];

        foreach(var testCase in testCases)
        {
            var result = Reverse(testCase.Key);
            var expectedResult = testCase.Value;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static int Reverse(int x) {
        var xAsCharArray = x.ToString().ToCharArray();
        var negative = false;

        if (xAsCharArray.First() == '-')
        {
            negative = true;
            xAsCharArray = xAsCharArray[1..];
        }

        var xAsCharArrayReversed = xAsCharArray.Reverse().ToArray();
        char[] reverseAsCharArray;

        if (negative)
        {
            reverseAsCharArray = new char[xAsCharArray.Length + 1];
            reverseAsCharArray[0] = '-';
            xAsCharArrayReversed.CopyTo(reverseAsCharArray, 1);
        }
        else
        {
            reverseAsCharArray = xAsCharArrayReversed;
        }

        return int.TryParse(reverseAsCharArray, out var result)
            ? result
            : 0;
    }
}