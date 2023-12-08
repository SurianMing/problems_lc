namespace LeetCode.SolutionRunner.Problems;

internal class X_RegExMatching_Problem : IProblem
{
    public void Run()
    {
        Tuple<string, string, bool>[] testCases =
        [
            new("aa", "a", false),
            new("aa", "a*", true),
            new("ab", ".*", true)
        ];

        foreach(var testCase in testCases)
        {
            var result = IsMatch(testCase.Item1, testCase.Item2);
            var expectedResult = testCase.Item3;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static bool IsMatch(string s, string p)
    {
        var sPos = 0;

        for (int pPos = 0; pPos < p.Length; pPos++)
        {
            var charToSeek = p[pPos];

            if ((pPos + 1) < p.Length && p[pPos + 1] == '*')
            {
                if (charToSeek == '.')
                {
                    if ((pPos + 2) == p.Length)
                        return true;

                    while ()
                    else if ()
                }
                if ((pPos + 2) < p.Length && p[pPos + 2] != '.')
                {
                    // We're 
                }
            }
        }
    }
}