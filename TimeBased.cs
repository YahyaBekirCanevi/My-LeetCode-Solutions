public class TimeMap
{
    Dictionary<string, List<TimeStamp>> dictionaryList;
    public TimeMap()
    {
        dictionaryList = new Dictionary<string, List<TimeStamp>>();
    }

    public void Set(string key, string value, int timestamp)
    {
        TimeStamp timeStamp = new TimeStamp(value, timestamp);
        if (dictionaryList.ContainsKey(key))
        {
            dictionaryList[key].Add(timeStamp);
        }
        else
        {
            List<TimeStamp> dictionary = new List<TimeStamp>();
            dictionary.Add(timeStamp);
            dictionaryList.Add(key, dictionary);
        }
        dictionaryList[key].OrderBy(e => e.Timestamp);
    }

    public string Get(string key, int timestamp)
    {
        if (!dictionaryList.ContainsKey(key)) return "";
        List<TimeStamp> list = dictionaryList[key];
        if (list.Count == 0) return "";
        int left = 0;
        int right = list.Count;
        while (left < right)
        {
            int mid = (int)Math.Floor((left + right) * .5f);
            if (list[mid].Timestamp <= timestamp)
                left = mid + 1;
            else right = mid;
        }
        if (right == 0) return "";

        return list[right - 1].Value;
    }
}

public struct TimeStamp
{
    public string Value { get; private set; }
    public int Timestamp { get; private set; }

    public TimeStamp(string value, int timestamp)
    {
        this.Value = value;
        this.Timestamp = timestamp;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */