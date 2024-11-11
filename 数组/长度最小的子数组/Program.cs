// See https://aka.ms/new-console-template for more information
//
/*
https://leetcode.cn/problems/minimum-size-subarray-sum/

给定一个含有 n 个正整数的数组和一个正整数 target 。

找出该数组中满足其总和大于等于 target 的长度最小的 
子数组
 [numsl, numsl+1, ..., numsr-1, numsr] ，并返回其长度。如果不存在符合条件的子数组，返回 0 。

 

示例 1：

输入：target = 7, nums = [2,3,1,2,4,3]
输出：2
解释：子数组 [4,3] 是该条件下的长度最小的子数组。
示例 2：

输入：target = 4, nums = [1,4,4]
输出：1
示例 3：

输入：target = 11, nums = [1,1,1,1,1,1,1,1]
输出：0
 

提示：

1 <= target <= 109
1 <= nums.length <= 105
1 <= nums[i] <= 104
 

进阶：

如果你已经实现 O(n) 时间复杂度的解法, 请尝试设计一个 O(n log(n)) 时间复杂度的解法。


*/

int MinSubArrayLen(int target, int[] nums)
{
    var sum = 0;
    var max = 0;
    var index = 0;
    bool isleftHeight = false;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        if (max < nums[i])
        {
            max = nums[i];
            index = i;
        }
        
    }

    if (sum < target) return 0;
    if (sum == target) return nums.Length;
    var left = index - 1 < 0 ? 0 : index - 1 ;
    var right = index + 1 > nums.Length ? nums.Length - 1 : index + 1;
    var tempSum = nums[index];
    while (true)
    {
        if (tempSum >= target)
        {
            return right - left + 1;
        }
        if (tempSum < target && left >= 0)
        {
            tempSum += nums[left];
            left--;
        }
      
        if (tempSum < target && right < nums.Length)
        {
            tempSum += nums[right];
            right++;
        }
        if (tempSum >= target)
        {
            if (left < 0) left = 0;
            if(right > nums.Length - 1) right = nums.Length - 1;
            var count = right - left + 1;
           
             if (tempSum - nums[left] - nums[right] >= target)
            {
                count = right - left;
            }
            else if(tempSum - nums[right] >= target)
                count = right - left + 1;
            else if (tempSum - nums[left] >= target)
                count = right - left - 1;
            return count;
        }
        
    }

    return 0;
}
Console.WriteLine(MinSubArrayLen(7, new []{2,3,1,2,4,3}));
Console.WriteLine(MinSubArrayLen(4, new []{1,4,4}));
Console.WriteLine(MinSubArrayLen(15, new []{1,2,3,4,5}));
Console.WriteLine(MinSubArrayLen(11, new []{1,2,3,4,5}));
//Console.WriteLine(MinSubArrayLen(11, new []{1,1,1,1,1,1,1,1}));
Console.WriteLine(MinSubArrayLen(213, new []{12,28,83,4,25,26,25,2,25,25,25,12}));