public class DecodeWays
{
    class Model
    {
        public string key;
        public int value;

        public Model(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
    List<Model> list;
    public DecodeWays()
    {
        list = new List<Model>();
    }
    public int NumDecodings(string s)
    {
        int sum = 0;
        int index = list.FindIndex((e) => e.key == s);
        if (index == -1)
        {
            int s1 = ValidByDigit(s, 1);
            int s2 = ValidByDigit(s, 2);
            sum = s1 + s2;
            list.Add(new Model(s, sum));
        }
        else
            sum = list[index].value;
        return sum;
    }
    private int ValidByDigit(string s, int digit)
    {
        if (s.Length < digit) return 0;
        int number = Convert.ToInt32(s.Substring(0, digit));
        if (digit == 1 ? number == 0 : (number < 10 || number > 26))
            return 0;
        else if (s.Length >= digit * 2)
            return NumDecodings(s.Substring(digit, s.Length - digit));
        else if (s.Length == 3 && digit == 2 && s[s.Length - 1] == '0')
            return 0;
        else
            return 1;
    }
}