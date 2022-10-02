/// <summary>
/// You have n dice and each die has k faces numbered from 1 to k. 
/// Given three integers n, k, and target, 
/// return the number of possible ways(out of the k^n total ways) 
/// to roll the dice so the sum of the face-up numbers equals target.
/// Since the answer may be too large, return it modulo 10^9 + 7.
/// </summary> 
public class DiceRollTargetSum
{
    int MOD = 1000000007;
    int[,] dp = new int[30 + 1, 1000 + 1];
    public int NumRollsToTarget(int n, int k, int target)
    {
        //Console.WriteLine($"NumRollsToTarget({n},{k},{target})");
        int sum = 0;
        if (n == 1)
        {
            sum += target <= k && target >= 1 ? 1 : 0;
            //Console.WriteLine($"\t{n} -> {target}");
            return sum;
        }

        for (int i = 1; i <= k; i++)
        {
            int result = 0;
            if (target - i > 0 && dp[n - 1, target - i] != 0) result = dp[n - 1, target - i] % MOD;
            else
            {
                result = FindWays(n - 1, k, target - i) % MOD;
                if (result != 0) dp[n - 1, target - i] = result % MOD;
            }
            //if (result != 0) Console.WriteLine($"{n} -> {i} => {result % MOD}");
            sum += result % MOD;
            sum %= MOD;
        }
        return sum;
    }
    private int FindWays(int n, int k, int target)
    {
        if (target < 1 || n < 1 || target > n * k) return 0;
        if (dp[n, target] != 0) return dp[n, target];
        if (n == 1 && target <= k && target >= 1)
        {
            //Console.WriteLine($"\t\t{n} -> {target}");
            return 1;
        }
        int rolls = 0;
        int i = k;
        while (target >= n && i >= 1)
        {
            if (target - i >= n - 1 && target - i <= n * k)
            {
                int result = FindWays(n - 1, k, target - i) % MOD;
                //if (result != 0) Console.WriteLine($"\t{n} -> {i}");
                rolls += result;
                rolls %= MOD;
            }
            i--;
        }
        if (rolls != 0) dp[n, target] = rolls;
        return rolls;
    }
}