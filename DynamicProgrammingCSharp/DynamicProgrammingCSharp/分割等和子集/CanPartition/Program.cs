﻿// See https://aka.ms/new-console-template for more information

/*https://leetcode.cn/problems/partition-equal-subset-sum/
给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。



示例 1：

输入：nums = [1,5,11,5]
输出：true
解释：数组可以分割成 [1, 5, 5] 和 [11] 。
示例 2：

输入：nums = [1,2,3,5]
输出：false
解释：数组不能分割成两个元素和相等的子集。


其实这个题目就是背包问题的变体，但是要会把背包问题套进去
两个元素和相等的子集，也就是数组中所有元素之和的1/2的情况下，将数组中随机放入几个数字
背包问题是n个物体，背包容量为m，i个物体重量w[i],价值v[i]
那对于这个题来说，n个数字，背包容量为 sum/2, i个数字的重量为a[i], 价值也为a[i]

1.确定dp[i]
dp[j]是容量为j的背包价值最大为多少 ??????这里的
2.确定状态转移方程
dp[j] = Max(dp[j - 1], dp[j - a[i]] + a[i])
3.确定初值
因为存在覆盖关系所有都初始化为0就行
4.确定遍历先后顺序

如果是从前往后dp[1] = Max(dp[0], dp[0 - w[i]] + a[0])
如果是从前往后dp[2] = Max(dp[1], dp[1 - w[i]] + a[0])
这样的话，a[0]被放进了dp[1],同时也被放进了dp[2]


*/

bool CanPartition(int[] nums)
{

        var sum = 0;
       
        for (int i = 0; i < nums.Length; i++)
        { 
                sum += nums[i];
        }

        if (sum % 2 != 0) return false; 
        var dp = new int[sum];
        for (int i = 0; i < nums.Length; i++)
        {
                for (int j = sum/2; j > 0; j--)
                {
                        if(j < nums[i])continue;
                        dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
                        if (dp[j] == sum / 2)
                        {
                                return true;
                        }
                }
        }
        return false;
}

//Console.WriteLine(CanPartition(new []{1,5,11,5}));
Console.WriteLine(CanPartition(new []{1,2,3,5}));  