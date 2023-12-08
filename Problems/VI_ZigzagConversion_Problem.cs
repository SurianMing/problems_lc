namespace LeetCode.SolutionRunner.Problems;

internal class VI_ZigzagConversion_Problem : IProblem
{
    public void Run()
    {
        Tuple<string, int, string>[] testCases =
        [
            new("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR"),
            new("PAYPALISHIRING", 4, "PINALSIGYAHRPI")
        ];

        foreach(var testCase in testCases)
        {
            var result = Convert(testCase.Item1, testCase.Item2);
            var expectedResult = testCase.Item3;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static string Convert(string s, int numRows) {
        var rowQueues = Enumerable.Range(0, numRows)
            .Select(_ => new Queue<char>())
            .ToArray();
        var currentRow = 0;
        var nextMove = 1;

        foreach (var nextChar in s)
        {
            rowQueues[currentRow].Enqueue(nextChar);
            currentRow += nextMove;

            nextMove = currentRow == numRows - 1
                ? -1
                : currentRow == 0
                    ? 1
                    : nextMove;
        }

        var result = string.Join(
            string.Empty,
            rowQueues.Select(queue => new string(queue.ToArray()))
        );

        return result;
    }
}