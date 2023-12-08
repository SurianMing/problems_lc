namespace LeetCode.SolutionRunner.Problems;

internal class VIIIStringToInteger_Problem : IProblem
{
    public void Run()
    {
        KeyValuePair<string, int>[] testCases =
        [
            new("-2147483648", int.MaxValue),
            new("42", 42),
            new("   -42", -42),
            new("4193 with words", 4193)
        ];

        foreach(var testCase in testCases)
        {
            var result = MyAtoi(testCase.Key);
            var expectedResult = testCase.Value;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static int MyAtoi(string s) {
        var valueQueue = new Queue<char>();
        var started = false;
        var isPositiveInteger = true;

        int index = 0;
        for (; index < s.Length; index++)
        {
            char thisChar = s[index];

            if (started)
            {
                if (!char.IsDigit(thisChar))
                {
                    break;
                }
                if (valueQueue.Count == 10)
                {
                    // Has to be outside range - let's shortcut.
                    return isPositiveInteger
                        ? int.MaxValue
                        : int.MinValue;
                }

                valueQueue.Enqueue(thisChar);
                continue;
            }

            if (thisChar == ' ')
            {
                continue;
            }
            if (thisChar == '+')
            {
                isPositiveInteger = true;
                started = true;
                continue;
            }
            if (thisChar == '-')
            {
                isPositiveInteger = false;
                started = false;
                continue;
            }
            if (char.IsDigit(thisChar))
            {
                started = true;
                valueQueue.Enqueue(thisChar);
                continue;
            }

            // We've hit a character before any digits have been found.
            return 0;
        }

        if (valueQueue.Count == 0) return 0;

        var valueString = (isPositiveInteger ? string.Empty : "-") + new string(valueQueue.ToArray());
        return int.TryParse(valueString, out var result)
            ? result
            : isPositiveInteger
                ? int.MaxValue
                : int.MinValue;
    }
}