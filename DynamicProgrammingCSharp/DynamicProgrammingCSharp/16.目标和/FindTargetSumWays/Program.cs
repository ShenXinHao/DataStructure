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

 
 
 


*/

int FindTargetSumWays(int[] nums, int target)
{
    var sum = 0;
       
    for (int i = 0; i < nums.Length; i++)
    { 
        sum += nums[i];
    }

    if (Math.Abs(target) > sum) return 0;
    var dp = new int[sum + 1];
    var count = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        // if (nums[i] == 0)
        // {
        //     count = count == 0 ? 2 : count * 2 ;
        //     continue;
        // }

        if (sum == nums[i])
        {
            count++;
            continue;
        }
        for (int j = sum - nums[i]; j >= 0; j--)
        {
            if(j >= sum + Math.Abs(target)) continue;
            if (j < nums[i]) break;
            dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
            if (j == target + sum)
                count++;
            if(j == -target + sum )
                count++;
            if(j == target)
                count++;
            if(j == -target)
                count++;
        }
    
    }

    Console.WriteLine(count);
    return count;
}
 // FindTargetSumWays(new []{1,1,1,1,1}, 3);
// FindTargetSumWays(new []{1}, 1);
//FindTargetSumWays(new []{1}, 2);
// FindTargetSumWays(new []{1000}, -1000);
// FindTargetSumWays(new []{1,0}, 1);
FindTargetSumWays(new []{0,0,0,0,0,0,0,0,1}, 1);