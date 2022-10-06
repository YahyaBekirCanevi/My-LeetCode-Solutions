/// https://www.youtube.com/watch?v=wjYnzkAhcNk
public class FindDuplicateNumber
{
    public int FindDuplicate(int[] nums)
    {
        /// floyd
        int slow = 0;
        int fast = 0;
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);
        /// first intersection of slow and fast pointers
        int slow2 = 0;
        do
        {
            slow = nums[slow];
            slow2 = nums[slow2];
        } while (slow != slow2);
        /// last intersection
        return slow;
    }
}