// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
/*
 https://leetcode.cn/problems/ones-and-zeroes/
给你一个二进制字符串数组 strs 和两个整数 m 和 n 。

请你找出并返回 strs 的最大子集的大小，该子集中 最多 有 m 个 0 和 n 个 1 。

如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。

示例 1：

输入：strs = ["10", "0001", "111001", "1", "0"], m = 5, n = 3

输出：4

解释：最多有 5 个 0 和 3 个 1 的最大子集是 {"10","0001","1","0"} ，因此答案是 4 。 其他满足题意但较小的子集包括 {"0001","1"} 和 {"10","1","0"} 。{"111001"} 不满足题意，因为它含 4 个 1 ，大于 n 的值 3 。

示例 2：

输入：strs = ["10", "0", "1"], m = 1, n = 1
输出：2
解释：最大的子集是 {"0", "1"} ，所以答案是 2 。
提示：

1 <= strs.length <= 600
1 <= strs[i].length <= 100
strs[i] 仅由 '0' 和 '1' 组成
1 <= m, n <= 100


用官方的题解思路思考，或者我自己的习惯来说
我习惯以物品i作为纵向，以背包容量作为剩下的一维或者二维去做处理
对于这道题来说，就是普通的二维数组似乎无法存储得下
那么就定义成三维dp[i][j][k]
那也就是说dp的含义是，当用0-i物品去填满背包的时候，最多有m个0和n个1的最大子集数量为dp[i][j][k]
当我用前i个物品的时候，当这个i物品本身的1的数量或者0的数量大于j或者k的时候，那么当前dp[i][j][k] = dp[i-1][j][k]
当不大于时，这个i物品的有两种选择，放或者不放（01背包的核心问题所在）放的时候刚好等于自己，不放的时候等于前i-1个，j - 当前的1的数量，和i-当前0的数量的那个背包的容量
也就是说当 
      k < zeronum, 或者j < onenum
      dp[i][j][k] = dp[i-1][j][k]
      不然
      dp[i][j][k] = Max(dp[i - 1][j - a[i]sum0][k - a[i]sum1] + 1, dp[i-1][j][k])
      
      
      
      for(i = 0, i < strs.length; i ++)
        sum_0
        sum_1
        for(j = 0, j < m; j ++)
            for(k = 0;k < n; k++)
                if(sum_0 > m || sum_1 > n) dp[i][j][k] = dp[i - 1][j][k]
                else
                {
                    dp[i][j][k] = Max(dp[i - 1][j - a[i]sum0][k -a[i]sum1] + 1, dp[i - 1][j][k])
                }
*/

int[] GetZerosOnes(string str) {
    int[] zerosOnes = new int[2];
    int length = str.Length;
    for (int i = 0; i < length; i++) {
        zerosOnes[str[i] - '0']++;  //ASCII编码中'0'的编码为48，‘1’的编码为49
    }
    return zerosOnes;
}


int FindMaxForm(string[] strs, int m, int n) {
    
    var dp = new int[strs.Length + 1, m + 1, n + 1];
    dp[0, 0, 0] = 0;
    for (int i = 1; i <= strs.Length; i++)
    {
        var str_count = GetZerosOnes(strs[i - 1]);
        var zeroNum = str_count[0];
        var oneNum = str_count[1];
        for (int j = 0; j <= m; j++)
        {
            for (int k = 0; k <= n; k++)
            {
                if (j < zeroNum || k < oneNum)
                {
                    dp[i,j,k] = dp[i - 1, j, k];
                }
                else
                {
                    dp[i, j, k] = Math.Max(dp[i - 1, j, k], dp[i - 1, j - zeroNum, k - oneNum] + 1 );
                }
            }
        }
    }

    Console.WriteLine( dp[strs.Length, m, n]);
    return dp[strs.Length - 1, m, n];
}


FindMaxForm(new[]{"10", "0001", "111001", "1", "0"}, 5, 3);
FindMaxForm(new[]{"10", "0", "1"}, 1, 1);

/* 仔细想想是否还可以在优化？
   在做斐波那契数列的时候，提到了一个概念叫做滚动数组，其实核心原理就是如果某个数字是由前一个数字推导而来，那么
   对于求后续的数字来说，可以在空间复杂度上进行优化，
   那我也说条件，也就是当前只由前一个数字推导而来，对于这道题中，物品i这个维度好像永远都是可以由上一个状态推导而来
   它永远都是-1的关系

*/
int FindMaxFormVector2(string[] strs, int m, int n)
{
    var dp = new int[m + 1, n + 1];//这里就是二维数组了
    for (int i = 0; i < strs.Length; i++)
    {
        var str_count = GetZerosOnes(strs[i]);
        var zeroNum = str_count[0];
        var oneNum = str_count[1];
        for (int j = m; j >= zeroNum; j--)
        {
            for (int k = n; k >= oneNum; k--)
            {
                if (j < zeroNum || k < oneNum)
                {
                    dp[j, k] = dp[j, k];
                }
                else
                {
                    dp[j, k] = Math.Max(dp[j, k], dp[j - zeroNum, k - oneNum] + 1 );
                }
            }
        }
    }
    Console.WriteLine(dp[m, n]);
    return dp[m, n];
}

FindMaxFormVector2(new[]{"10", "0001", "111001", "1", "0"},5, 3);
FindMaxFormVector2(new[]{"10", "0", "1"}, 1, 1);