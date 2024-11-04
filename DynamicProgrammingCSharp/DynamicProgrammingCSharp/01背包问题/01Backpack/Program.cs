// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
/*
有n件物品和一个最多能背重量为w 的背包。第i件物品的重量是weight[i]，得到的价值是value[i] 。每件物品只能用一次，求解将哪些物品装入背包里物品价值总和最大。
背包最大重量为4。

物品为：

        重量	价值
物品0	1	15
物品1	3	20
物品2	4	30

1.确定dp数组，dp[i][j]为物品0-i随即放进背包时的背包最大重量为j的时候的最大价值
2.确定递推公式，在dp[i][j]这时候，存在可以将i放进去，也可以不把i放进去两种情况，对于放进去的时候，那就是j-1重量 放0-（i-1）时能最大价值 + 物品i本身的价值，
        这里比较绕
        dp[i][j] = Max(dp[i - 1][j], dp[i - 1][j - w[i]] + value[i]
3.确定初值
        dp[i][0] = 0
        dp[0][w] = w
4.确定遍历顺序，从前往后
5.举例
*/

//这里只给出一部分的核心代码
int DP(int m, int n)
{
        // var dp[][] = new int[m][n];
        // for (int i = 0; i < m; i++)
        // {
        //         dp[0][j] =  weight[0]
        // }
        // for (int i = 0; i < 物品数量; i++)
        // {
        //         for (int j = 0; j < 重量; j++)
        //         {
        //                 if(j < weight[i])
        //                         dp[i][j] = dp[i - 1][j]
        //                 else
        //                 {
        //                         dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - weight[i]] + value[i]);
        //                 }
        //         }
        // }
        //
        return m;
}