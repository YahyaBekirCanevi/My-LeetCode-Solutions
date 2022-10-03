public class MinTimeRopeColor
{
    private int Min(int a, int b) => a < b ? a : b;
    private int Max(int a, int b) => a > b ? a : b;
    public int MinCost(string colors, int[] neededTime)
    {
        int n = neededTime.Length;
        int sum = 0;
        int i = 0;
        while (i < n - 1)
        {
            if (colors[i] == colors[i + 1])
            {
                int secondIndex = i + 1;
                if (secondIndex < n - 1 && colors[secondIndex] == colors[secondIndex + 1])
                {
                    sum += neededTime[i];
                    int max = neededTime[i];
                    int t = 0;
                    while (secondIndex < n - 1 && colors[secondIndex] == colors[secondIndex + 1])
                    {
                        t = neededTime[secondIndex++];
                        max = Max(max, t);
                        sum += t;
                    }
                    t = neededTime[secondIndex++];
                    max = Max(max, t);
                    sum += t - max;
                    i = secondIndex;
                }
                else
                {
                    sum += Min(neededTime[i], neededTime[secondIndex]);
                    i++;
                }
            }
            else i++;

        }
        return sum;
    }
}