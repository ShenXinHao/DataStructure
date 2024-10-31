// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

/*
leetcode 连接 https://leetcode.cn/problems/unique-paths-ii/description/
给定一个 m x n 的整数数组 grid。一个机器人初始位于 左上角（即 grid[0][0]）。机器人尝试移动到 右下角（即 grid[m - 1][n - 1]）。机器人每次只能向下或者向右移动一步。

网格中的障碍物和空位置分别用 1 和 0 来表示。机器人的移动路径中不能包含 任何 有障碍物的方格。

返回机器人能够到达右下角的不同路径数量。

测试用例保证答案小于等于 2 * 109。

输入：obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
输出：2
解释：3x3 网格的正中间有一个障碍物。
从左上角到右下角一共有 2 条不同的路径：
1. 向右 -> 向右 -> 向下 -> 向下
2. 向下 -> 向下 -> 向右 -> 向右

输入：obstacleGrid = [[0,1],[0,0]]
输出：1


提示
    m == obstacleGrid.length
    n == obstacleGrid[i].length
    1 <= m, n <= 100
    obstacleGrid[i][j] 为 0 或 1


思路步骤
    first step：确定dp[i,j]含义
                dp[i,j]为[i,j]格子绕开障碍物的路径
    second step:确定递推公式
                dp[i,j] = a[i - 1, j] 是否可以走 ？ dp[i-1, j] + a[i, j-1] 是否可以走？dp[i, j - 1]
    third step: 确认初始化
                第一次初始化的时候，没有考虑到当i 或者 j = 0，如果中间有障碍物，后面都为 0
                dp[i,0] = 1
                dp[0,j] = 1
    fourth step: 确认遍历先后顺序
                从前往后
    fifth step：举例
    dp[1,1] = obstacleGrid[0,1] = 1? + obstacleGrid[1,0] = 1?

*/

var nums1 = new int[,] { {0,0,0}, {0,1,0}, {0,0,0}};
var nums2 = new int[,] { {0,1}, {0,0}};
var nums3 = new int[,] { {0,0}, {1,1}, {0,0}};

void Dp(int[,] nums)
{
    var rows = nums.GetLength(0);
    var cols = nums.GetLength(1);
    var dp = new int[rows, cols];
    dp[0, 0] = 1;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (nums[i, j] == 1)
            {
                dp[i, j] = 0;
                continue;
            }
            if (i == 0)
            {
                if(j >= 1 && dp[i, j - 1] != 0)
                    dp[i, j] = 1;
            }
            else if (j == 0)
            {
                if(i >= 1 && dp[i - 1, j] != 0)
                    dp[i, j] = 1;
            }
            else
            {
                dp[i, j] = (dp[i - 1, j] == 0 ? 0 : dp[i - 1, j]) + (dp[i, j - 1] == 0 ? 0 : dp[i, j - 1]);
            }
        }
    }
    Console.WriteLine(dp[rows - 1, cols - 1]);
}

Dp(nums1);
Dp(nums2);
Dp(nums3);