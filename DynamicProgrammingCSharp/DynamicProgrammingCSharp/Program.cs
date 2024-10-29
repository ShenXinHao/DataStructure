
Console.WriteLine("Hello, World!");
//子序列求和问题
var nums1 = new[]{3, -4, 2, -1, 2, 6, -5, 4};
var nums2 = new[]{3, 2};
var nums3 = new[]{3, -4, 2, 6, -5, 4};

//先尝试找到核心的迭代内容
//不停的叠加当前的数字以及后续的数字，然后返回这一次的连加之和的最大值
int MaxSum(int[] nums, int i)
{
    var max_sum = nums[i];
    var temp_sum = 0;
    for (int j = i + 1; j < nums.Length ; j++)
    {
        temp_sum += nums[j];
        max_sum = Math.Max(max_sum, MaxSum(nums, j));
        if (max_sum < temp_sum)
            max_sum = temp_sum;
    }
    return max_sum;
}

int GetMaxSum(int[] nums)
{
    var max = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        max = Math.Max(max, MaxSum(nums, i));
    }

    return max;
}

Console.WriteLine(GetMaxSum(nums1));
Console.WriteLine(GetMaxSum(nums2));


void DP(int[] nums)
{
    var L = new int[nums.Length];
    L[nums.Length - 1] = nums[^1];
    for (int i = nums.Length - 1; i > 0; i--)
    {
        var tmp_sum = 0;
        for (int j = i + 1; j < nums.Length; j++)
        {
            tmp_sum += nums[j];
            L[i - 1] = Math.Max(L[i - 1], tmp_sum);
        }
        L[i] = L[i - 1] + nums[i];
    }

    var max_sum = L[0];
    for (int i = 0; i < L.Length; i++)
    {
        max_sum = Math.Max(max_sum, L[i]);
    }

    Console.WriteLine(max_sum);
}

DP(nums1);
DP(nums3);