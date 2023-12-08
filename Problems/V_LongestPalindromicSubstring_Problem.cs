namespace LeetCode.SolutionRunner.Problems;

internal class V_LongestPalindromicSubstring_Problem : IProblem
{
    public void Run()
    {
        KeyValuePair<string, string>[] testCases =
        [
            new("babad", "bab"),
            new("cbbd", "bb")
        ];

        foreach(var testCase in testCases)
        {
            var result = LongestPalindrome(testCase.Key);
            var expectedResult = testCase.Value;

            if (result != expectedResult)
                throw new Exception();
        }
    }

    public string LongestPalindrome(string s) {
        var longestPalindrome = string.Empty;
        var sArray = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            var minIndex = i;
            var maxIndex = i;
            while (maxIndex < sArray.Length - 1 && sArray[maxIndex + 1] == sArray[minIndex])
            {
                i++;
                maxIndex++;
            }
            while (minIndex > 0
                && maxIndex < sArray.Length - 1
                && sArray[minIndex - 1] == sArray[maxIndex + 1])
            {
                minIndex--;
                maxIndex++;
            }

            var palindromeLength = maxIndex - minIndex + 1;
            if (palindromeLength > longestPalindrome.Length)
            {
                longestPalindrome = s.Substring(minIndex, maxIndex - minIndex + 1);
            }
        }

        return longestPalindrome;
    }
}