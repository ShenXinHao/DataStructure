// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

/*
https://leetcode.cn/problems/integer-break/
给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
示例 1:

输入: 2
输出: 1
解释: 2 = 1 + 1, 1 × 1 = 1。
示例 2:

输入: 10
输出: 36
解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
说明: 你可以假设 n 不小于 2 且不大于 58。


first step : 确定dp[i]含义
    dp[i]当i = n时的正整数拆分之后最大乘积
second step ：递推公式
    dp[i] = Max[j * dp[i - j]] 其中j >= 2 and j <= 58
third step : 确定初值
    dp[2] = 1
    dp[3] = 2
fourth step : 确定遍历顺序
    从前往后
fifth step ： 举例
dp[4] = dp[2]* 2 = 4   dp[4] = dp[3] * 1
 */



int IntegerBreak(int n)
{
    var dp = new int[n + 1];
    dp[2] = 1;
    for (int i = 3; i <= n; i++)
    {
        dp[i - 1] = int.Max(dp[i - 1], i - 1);
        var max = 0;
        for (int j = 1; j <= i; j++)
        {
            var x = dp[i - j] * j;
            max = Math.Max(max, x);
        }

        dp[i] = max;
    }
    Console.WriteLine(dp[n]);
    return dp[n];
}

IntegerBreak(2);
IntegerBreak(6);
IntegerBreak(8);
IntegerBreak(10);