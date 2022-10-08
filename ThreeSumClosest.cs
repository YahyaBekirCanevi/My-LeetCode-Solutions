public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int? closest = null;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            int j = i + 1;
            int k = nums.Length - 1;
            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum > target) k--;
                else if (sum < target) j++;
                else return sum;

                closest = closest == null ? sum :
                    (Math.Abs(target - sum) < Math.Abs(target - (int)closest!) ? sum : closest);
            }
        }
        return (int)closest!;
    }
}