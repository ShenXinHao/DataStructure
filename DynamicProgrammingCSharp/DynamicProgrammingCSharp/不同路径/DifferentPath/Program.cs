// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。

机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。

问总共有多少条不同的路径？



示例 1：


输入：m = 3, n = 7
输出：28
示例 2：

输入：m = 3, n = 2
输出：3
解释：
从左上角开始，总共有 3 条路径可以到达右下角。
1. 向右 -> 向下 -> 向下
2. 向下 -> 向下 -> 向右
3. 向下 -> 向右 -> 向下
示例 3：

输入：m = 7, n = 3
输出：28
示例 4：

输入：m = 3, n = 3
输出：6


first step: 确认dp数组以及下标的含义
dp[i][j]为走到(i,j)格子总共有多少条路径

second step：确定递推公式
dp[i][j] = dp[i-1, j] + dp[i, j-1]  i >= 1, j >= 1

third step: dp数组如何初始化
dp[1,1] = 0
dp[2,1] = 1
dp[1,2] = 1
dp[i,1] = 1
dp[1,j] = 1
fourth step:确定遍历顺序
由推导公式可以知道，后面的位置是由前面的决定，那就是从前往后
fifth step：举例
dp[3,2] = dp[2,2] + dp[3,1] = dp[1,2] + dp[2,1] + dp[3,1] = 3

*/

int DP(int m, int n)
{
    var dp = new int[m + 1, n + 1];
    for (int i = 1; i <= m; i++)
    {
        for (int j = 1; j <= n ; j++)
        {
            if (i == 1)
            {
                dp[1, j] = 1;
                continue;
            }
            if (j == 1)
            {
                dp[i, 1] = 1;
                continue;
            }
            dp[i,j] = dp[i - 1, j] + dp[i, j - 1];
        }
    }
    return dp[m, n];
}

Console.WriteLine(DP(3, 2));
Console.WriteLine(DP(7, 3));