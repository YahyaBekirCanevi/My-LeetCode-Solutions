// sweep line algorithm
public class MyCalendarThree
{
    SortedDictionary<int, int> dict;
    public MyCalendarThree()
    {
        dict = new SortedDictionary<int, int>();
    }
    private int Max(int a, int b) => a > b ? a : b;
    public int Book(int start, int end)
    {
        if (dict.ContainsKey(start)) dict[start]++;
        else dict.Add(start, 1);
        if (dict.ContainsKey(end)) dict[end]--;
        else dict.Add(end, -1);

        int result = 0, current = 0;
        foreach (int delta in dict.Values)
        {
            current += delta;
            result = Max(result, current);
        }
        return result;
    }
}