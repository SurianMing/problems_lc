namespace LeetCode.SolutionRunner.Problems;

internal class III_LongestSubstring_Problem : IProblem
{
    public void Run()
    {
        KeyValuePair<string, int>[] testCases =
        [
            new("abcabcbb", 3),
            new("bbbbb", 1),
            new("pwwkew", 3)
        ];

        foreach(var testCase in testCases)
        {
            var result = LongestSubstringWithoutRepeatingCharacters(testCase.Key);
            var expectedResult = testCase.Value;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    private static int LongestSubstringWithoutRepeatingCharacters(string input)
    {
        var inputQueue = new Queue<char>(input);
        var currentUniqueSet = new Queue<char>();

        var maxUniqueSetSize = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var nextChar = inputQueue.Dequeue();
            if (currentUniqueSet.Contains(nextChar))
            {
                while(currentUniqueSet.Dequeue() != nextChar) { }
            }
            else if (currentUniqueSet.Count == maxUniqueSetSize)
            {
                maxUniqueSetSize++;
            }

            currentUniqueSet.Enqueue(nextChar);
        }

        return maxUniqueSetSize;
    }
}