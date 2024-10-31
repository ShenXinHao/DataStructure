// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
/*
    给你一个整数数组 cost ，其中 cost[i] 是从楼梯第 i 个台阶向上爬需要支付的费用。一旦你支付此费用，即可选择向上爬一个或者两个台阶。

    你可以选择从下标为 0 或下标为 1 的台阶开始爬楼梯。

    请你计算并返回达到楼梯顶部的最低花费。

    示例 1：

        输入：cost = [10,15,20]
        输出：15
        解释：你将从下标为 1 的台阶开始。
        - 支付 15 ，向上爬两个台阶，到达楼梯顶部。
        总花费为 15 。

    示例 2：
        输入：cost = [1,100,1,1,1,100,1,1,100,1]
        输出：6
        解释：你将从下标为 0 的台阶开始。
        - 支付 1 ，向上爬两个台阶，到达下标为 2 的台阶。
        - 支付 1 ，向上爬两个台阶，到达下标为 4 的台阶。
        - 支付 1 ，向上爬两个台阶，到达下标为 6 的台阶。
        - 支付 1 ，向上爬一个台阶，到达下标为 7 的台阶。
        - 支付 1 ，向上爬两个台阶，到达下标为 9 的台阶。
        - 支付 1 ，向上爬一个台阶，到达楼梯顶部。
        总花费为 6 。
*/

/*
    first step :确定DP数组以及下标的含义
    dp[i] = 登上第i阶台阶所需要的最低费用

    second step ：确定递推公式
    dp[i] = Min(dp[i - 1] + cost[i - 1] , dp[i - 2] + cost[i - 2])

    third step : dp数组如何初始化
    dp[0] = 0
    dp[1] = 0

    fourth step：确定遍历顺序
    因为这个整体的递推是由前面两项确定后面的内容因此是从前往后

    fifth step ：举例推导dp数组

*/

var nums = new int[] { 10, 15, 20};
var nums2 = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };

int DP(int[] nums)
{
    int[] dp = new int[nums.Length + 1];
    dp[0] = 0;
    dp[1] = 0;
    for (int i = 2; i <= nums.Length; i++)
    {
        dp[i] = Math.Min(dp[i - 1] + nums[i - 1], dp[i - 2] + nums[i - 2]);
    }
    return dp[nums.Length];
}

Console.WriteLine(DP(nums));
Console.WriteLine(DP(nums2));