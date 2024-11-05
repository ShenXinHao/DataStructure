// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


/*
     有一堆石头，用整数数组 stones 表示。其中 stones[i] 表示第 i 块石头的重量。

    每一回合，从中选出任意两块石头，然后将它们一起粉碎。假设石头的重量分别为 x 和 y，且 x <= y。那么粉碎的可能结果如下：

    如果 x == y，那么两块石头都会被完全粉碎；
    如果 x != y，那么重量为 x 的石头将会完全粉碎，而重量为 y 的石头新重量为 y-x。
    最后，最多只会剩下一块 石头。返回此石头 最小的可能重量 。如果没有石头剩下，就返回 0。

     

    示例 1：

    输入：stones = [2,7,4,1,8,1]
    输出：1
    解释：
    组合 2 和 4，得到 2，所以数组转化为 [2,7,1,8,1]，
    组合 7 和 8，得到 1，所以数组转化为 [2,1,1,1]，
    组合 2 和 1，得到 1，所以数组转化为 [1,1,1]，
    组合 1 和 1，得到 0，所以数组转化为 [1]，这就是最优值。
    示例 2：

    输入：stones = [31,26,33,21,40]
    输出：5
     

    提示：

    1 <= stones.length <= 30
    1 <= stones[i] <= 100
 *
 *
 *
 * https://leetcode.cn/problems/last-stone-weight-ii/description/
 * 其实我一开始是想到了。分为两堆，但是我想的是尽可能相等，于是我没有想到用sum/2也就是背包容量接近这个sum/2时
 * 就可以得到
 *
 *
 *
 *
 * 
 */

int LastStoneWeightII(int[] stones)
{
    var sum = 0;
       
    for (int i = 0; i < stones.Length; i++)
    { 
        sum += stones[i];
    }
    var half = sum / 2;
    var dp = new int[half + 1];
    for (int i = 0; i < stones.Length; i++)
    {
        for (int j = sum/2 ; j > 0; j--)
        {
            if (j < stones[i]) break;
            dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
        }
    }

    var cha = Math.Abs(sum - 2 * dp[half]);
    return cha;
}

Console.WriteLine(LastStoneWeightII(new []{2,7,4,1,8,1}));