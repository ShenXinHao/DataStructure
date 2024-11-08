// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

/*
给定一个非负整数数组，a1, a2, ..., an, 和一个目标数，S。现在你有两个符号 + 和 -。对于数组中的任意一个整数，你都可以从 + 或 -中选择一个符号添加在前面。

返回可以使最终数组和为目标数 S 的所有添加符号的方法数。

示例：

输入：nums: [1, 1, 1, 1, 1], S: 3
输出：5
解释：

-1+1+1+1+1 = 3
+1-1+1+1+1 = 3
+1+1-1+1+1 = 3
+1+1+1-1+1 = 3
+1+1+1+1-1 = 3
一共有5种方法让最终目标和为3。

提示：

数组非空，且长度不会超过 20 。
初始的数组的和不会超过 1000 。
保证返回的最终结果能被 32 位整数存下

思路
这里需要思考的比较多的就是，到底这个问题该怎么转换为背包问题
最开始的想法就是，将一部分的数字放入左边，这些数字都是x1，那么剩下的数字都x-1，左右两堆数字相加之后就可以得到target，
同时左边 + 右边 的所有的数字之和等于原始数组的和，这样的话，我想到了背包的容量为（sum + target）/ 2
但是接下来的思考过程就比较复杂且难懂
我要求的是放满背包容量的时候，总共有多少种方法
那么第一步在确定dp数组含义来说，使用0-i的数字填满背包容量为j总共有多少种方法
1.dp[i][j]
2.确定递归公式：
当j = 0 ，也就是只有0的时候，
当a[0] = 0,有2种可以放0，也可以不把0放进去
当a[1] = 0,也有两种选择，可以放a[1]和不把a[1]放进去，但是a[0]也有2种，所以最后是2*2
当a[2] = 0,也有两种选择，可以放a[2]和不把a[2]放进去，但是a[0], a[1]各自也有2种，所以最后是2*2*2
当前面的a数值为0，那么后续一直变成2的阶乘

如果一开始a[0] != 0的话，其实只有一种不放物品

继续往下推的话，就是j！=0
那从原本判断a[0] = 0，变成判断a[i] > j,也就是背包中根本装不下a[i],那么结果就变成求dp[i - 1, p]
如果能装下，似乎也有两个可能，放物品a[i]和不放a[i],dp[i - 1, j] + dp[i - 1][j - nums[i]

3.确定初值：
当i = 0时。这一行背包容量在a[i] == j时等于1，同时a[0]j[0] = 1
当j = 0时，这一列都为1，因为都可以不放

4.从前往后


1.一维滚动数组 dp[j] 为背包容量j的时候方法之和
2.确定状态转移公式
dp[j] += dp[j-nums[i]]

如果是一
*/

int FindTargetSumWays(int[] nums, int target)
{
    var sum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
    }
    if ((target + sum) % 2 == 1) return 0;
    if (Math.Abs(target) > sum) return 0;
    var dp = new int[nums.Length + 1, (sum + target)/2 + 1];
    dp[0, 0] = 1;
    int numZero = 0;
    for (int i = 0; i <= sum; i++)
    {
        if(nums[i] == 0)numZero ++;
        dp[i, 0] = (int)(Math.Pow(2, numZero));
    }

    for (int i = 1; i < nums.Length; i++)
    {
        for (int j = 0; j <= (sum  + target)/2; j++)
        {
            //当第i个物品的重量大于当前背包容量，那么就相当于不放入第i个物品的方法总和
            if (nums[i] > j) dp[i, j] = dp[i - 1, j];
             // 当第i个物品的重量小于当前背包的容量，那么就可以有放入第i个物品的方法总和加上不放入第i个物品的方法总和
            else dp[i, j] = dp[i - 1 , j] + dp[i - 1, j - nums[i]];
        }

    }

    Console.WriteLine(dp[nums.Length - 1, (sum + target) / 2]);
    return dp[nums.Length, (sum + target) / 2];
}
 // FindTargetSumWays(new []{1,1,1,1,1}, 3);
// FindTargetSumWays(new []{1}, 1);
//FindTargetSumWays(new []{1}, 2);
// FindTargetSumWays(new []{1000}, -1000);
// FindTargetSumWays(new []{1,0}, 1);
FindTargetSumWays(new []{0,0,0,0,0,0,0,0,1}, 1);


int FindTargetSumWays1(int[] nums, int target)
{
    var sum = 0;

    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
    }
    if ((target + sum) % 2 == 1) return 0;
    if (Math.Abs(target) > sum) return 0;
    var dp = new int[(sum + target)/2 + 1];
    dp[0] = 1;
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = (sum + target) / 2; j >= nums[i]; j--)
        {
            dp[j] += dp[j - nums[i]];
        }
    }
    Console.WriteLine(dp[(sum + target) / 2]);
    return dp[(sum + target) / 2];
}
FindTargetSumWays1(new []{0,0,0,0,0,0,0,0,1}, 1);