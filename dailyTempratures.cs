public class DailyTemperature
{
    public int CountToWarmerDay(int i, int[] temperatures)
    {
        int count = 0;
        for (count = 1; i + count <= temperatures.Length; count++)
        {
            if (i + count == temperatures.Length)
            {
                count = 0;
                break;
            }
            else if (temperatures[i] < temperatures[i + count])
            {
                break;
            }
        }
        return count;
    }
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            result[i] = CountToWarmerDay(i, temperatures);
        }
        return result;
    }
}