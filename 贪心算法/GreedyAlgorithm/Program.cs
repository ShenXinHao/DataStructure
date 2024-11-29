// See https://aka.ms/new-console-template for more information

using System.Collections;

int LongestPalindrome(string s)
{
    int count = 0;
    bool longestPalindrome = false;
    Dictionary<int, int> results = new Dictionary<int, int>();
    for (int i = 0; i < s.Length; i++)
    {
        if (!results.TryAdd(s[i] - 26, 1))
        {
            results[s[i] - 26]++;
        }
    }

    foreach (var result in results)
    {
        var tempCount = result.Value / 2;
        var y = result.Value % 2;
        if (!longestPalindrome && y == 1)
        {
            count++;
            longestPalindrome = true;
        }

        count += 2 * tempCount;
    }
    return count;
}