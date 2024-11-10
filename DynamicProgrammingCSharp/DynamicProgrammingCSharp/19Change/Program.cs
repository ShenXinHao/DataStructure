﻿// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


/*给你一个整数数组 coins 表示不同面额的硬币，另给一个整数 amount 表示总金额。

请你计算并返回可以凑成总金额的硬币组合数。如果任何硬币组合都无法凑出总金额，返回 0 。

假设每一种面额的硬币有无限个。 

题目数据保证结果符合 32 位带符号整数。

 

示例 1：

输入：amount = 5, coins = [1, 2, 5]
输出：4
解释：有四种方式可以凑成总金额：
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
示例 2：

输入：amount = 3, coins = [2]
输出：0
解释：只用面额 2 的硬币不能凑成总金额 3 。
示例 3：

输入：amount = 10, coins = [10] 
输出：1
 

提示：

1 <= coins.length <= 300
1 <= coins[i] <= 5000
coins 中的所有值 互不相同
0 <= amount <= 5000




先看要求什么？求组合硬币的数量
每个硬币各自有自己的金额，硬币之间是否有联系呢？有的，他们共同影响了金额，各自数量和是否要选都是不确定的
条件貌似符和动归的背包问题
目前有几个变量可以影响到最终的结果呢？物品i以及背包容量，各自的价值，数量
如果作表，那么纵向我依旧喜欢用物品i表示
对每次放入的数量不缺的情况下，我们用dp[i,j]表示用前i个硬币背包容量为j的时候的最大值

对于前i个的时候，第i个硬币一样有两种选择，不放自己和放n个自己，也就是dp[i,j] = Max(dp[i - 1, j - n*a[i] ] + n*a[i], dp[i-1, j]
对于当n * a[i} > j的时候，dp[i, j] = dp[i - 1, j]
 但是对于这个题来说，求得并不是最大值，而是放满的总组合数，
 也就是dp此时表示的是前i个硬币在j背包大小时，任意用硬币数量k的i总价值 k*ai + 前[i-1, j- k *ai]价值的总数
 *
 * 
 */
int Change(int amount, int[] coins)
{
    var dp = new int[coins.Length + 1, amount + 1];
    
    dp[0, 0] = 1;
        
    for (int i = 1; i <= coins.Length; i++)
    {
        for (int j = 0; j <= amount; j++)
        {
            var count = 0;
            for (int k = 0; k <= amount; k++)
            {
             
                if (j >= k * coins[i - 1])
                {
                    count +=   dp[i - 1, j - k * coins[i - 1] ];
                }
                
            }
            dp[i, j] = count;
        
        }
    }
  
Console.WriteLine(dp[coins.Length, amount]);
    return dp[coins.Length, amount];
    
}

Change(5, new []{1,2,5});
// Change(10, new []{10});
// Change(0, new []{1,2});
// Change(500, new []{1,2,5});

//想办法用滚动数组优化一下
int ChangeNew(int amount, int[] coins)
{
    var dp = new int[amount + 1];

    dp[0] = 1;

    for (int i = 1; i <= coins.Length; i++)
    {
        var coinsSum = coins[i - 1];
        for (int j = 0; j <= amount; j++)
        {
            //这里的递推公式为什么是这样呢？
            //这里需要简化一下概念，dp首先含义是总的组合数，对于这个总的组合数来说，他的下标是背包的容量，也就是用硬币刚好凑出j的总的方法
            //对于每次取多少种硬币来说，每个事件是不能同时发生的，所以要求和也应该是加法。
            //关于这里j - 每种硬币的价格，这里有个很大很大的容易产生的误区，就是我当前为coins[i]的硬币的数量到底是多少？或者我在coins[i]开始使用时与前一种有没有确定的关系
            //我在绘制图表的过程中，其实我在根据硬币种类和金额进行填入总组合数的时候，其实这个过程就是在思考和总结的过程，
            //其中，在金额相等的时候，第i种之前硬币凑金额的时候，就等于当前这个i的硬币金额是否大于j，如果不大于就是可以进行放入，对于硬币i相等的时候，dp中的每一行相当于以i种硬币为结尾可以凑出j的组合数
            //那问题就变成 j-coins  + coins 两堆对于当前的遍历的coins来说，dp[coins] = 1,因为只有一种可能，那就是一枚当前的硬币，所以dp[j] = dp[j - coins] * dp[coins] = dp[j - coins]
            //循环为每一轮，就是循环最外层的coins种类，这里对于滚动数组来说，+ 原有的dp[j]就是在累加前面的数量
            /*------------------------------------------------------------------------------------------
             *     |   0    |   1    |   2    |   3    |   4    |   5    |
             *-------------------------------------------------------------------------------------------
             *  1  |   1    |   1    |   1    |   1    |   1    |   1    |
             *-------------------------------------------------------------------------------------------
             *  2  |   1    |   1    |   2    |   2    |   3    |   3    |
             *-------------------------------------------------------------------------------------------
             *  5  |   1    |   1    |   2    |   2    |   3    |   4    |
             * 
             */
            if (j >=  coinsSum)
            {
                dp[j] +=  dp[j -  coinsSum ];
            }
        }
    }
    
      
    Console.WriteLine(dp[amount]);
    return dp[amount];
}

ChangeNew(5, new []{1,2,5});
