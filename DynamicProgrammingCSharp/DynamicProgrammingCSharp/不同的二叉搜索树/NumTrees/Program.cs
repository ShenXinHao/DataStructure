// See https://aka.ms/new-console-template for more information

using System.Numerics;
using NumTrees;

/*
 
 二叉搜索树是一个有序树：

若它的左子树不空，则左子树上所有结点的值均小于它的根结点的值；
若它的右子树不空，则右子树上所有结点的值均大于它的根结点的值；
它的左、右子树也分别为二叉搜索树
这就决定了，二叉搜索树，递归遍历和迭代遍历和普通二叉树都不一样。
 
 给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？


输入：n = 3
输出：5

输入：n = 1
输出：1


1.确定dp[i]含义
    dp[i] 为n时总共有多少种二叉搜索树
2.递推公式
    首先是对于dp[3]来说，dp[1]和dp[2]可以组成dp[3],
    对于不重复的二叉搜索树来说，左子结点必定小于当前结点，右子节点必须大于当前结点
    所以对于dp[3]来说，有左0右2，有左1右1，有左1右0这三种情况
    左右互相乘积再相加就是dp[3]
    dp[i] = sum(dp[0]*dp[i] + dp[1]*dp[i-1].....)
3.确定初值
    dp[0]=1
    dp[1]=1
    dp[2]=2
4.确定从前向后顺序
    
5.举例
dp[3] = dp[0]*dp[2] + dp[1]*dp[1] + dp[2]*dp[0]= 2 + 1 + 2

*/


int NumTrees(int n)
{
    var dp = new int[n + 1];
    dp[0] = 1;
    dp[1] = 1;
    dp[2] = 2;
    var sum = 0;
    for (int i = 3; i <= n; i++)
    {
        sum = 0;
        for (int j = 0; j < i; j++)
        {
            sum += dp[j]* dp[i - j - 1];
        }

        dp[i] = sum;
    }
    Console.WriteLine(dp[n - 1]);
    return dp[n - 1];
} 

NumTrees(2);
NumTrees(3);
NumTrees(4);
NumTrees(5);
NumTrees(6);
