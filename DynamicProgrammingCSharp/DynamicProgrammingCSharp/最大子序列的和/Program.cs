
Console.WriteLine("Hello, World!");
//子序列求和问题
/*
 *给你一个整数数组 nums ，请你找出一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。

子数组
是数组中的一个连续部分。


示例 1：

输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
输出：6
解释：连续子数组 [4,-1,2,1] 的和最大，为 6 。
示例 2：

输入：nums = [1]
输出：1
示例 3：

输入：nums = [5,4,-1,7,8]
输出：23


提示：

1 <= nums.length <= 105
-104 <= nums[i] <= 104
 *
 *
 *
 *
 */
var nums1 = new[]{5,4,-1,7,8};
var nums2 = new[]{1};
var nums3 = new[]{-2,1,-3,4,-1,2,1,-5,4};

/* first step ： 确定dp[i]
 * dp[i]是第i元素为开头的子序列的和的最大值
 *second step ：确定递推公式
 * dp[i] = dp[i + 1]? dp[i + 1] : 0 + a[i]
 *third step : 确认dp初始化
 *dp[n] = a[n]
 *forth step ：确定遍历顺序
 * 从后往前
 * fifth step：举例
 * [5,3,2]
 *dp[2] = 2
 * dp[1] = 5
 * dp
 */

void DP2(int[] nums)
{
    var dp = new int[nums.Length];
    dp[nums.Length - 1] = nums[^1];
    var max = nums[^1];
    for (int i = nums.Length - 1; i > 0; i--)
    {
        dp[i - 1] = Math.Max( dp[i]  + nums[i - 1], nums[i - 1]);
        max = Math.Max(max, dp[i - 1]);
    }
    Console.WriteLine(max);
}


DP2(nums1);
DP2(nums2);
DP2(nums3);