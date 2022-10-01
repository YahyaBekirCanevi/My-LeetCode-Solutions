/* StockSpanner obj = new StockSpanner();
List<int> list = new List<int>() { 100, 80, 60, 70, 60, 75, 85 };
string result = "";
foreach (int price in list)
{
    result += obj.Next(price).ToString() + " ";
}
Console.WriteLine(result); */

public class StockSpanner
{
    List<int> list;
    public StockSpanner()
    {
        list = new List<int>();
    }
    public int Next(int price)
    {
        int index = list.FindIndex((e) => price < e);
        list.Insert(0, price);
        return index == -1 ? list.Count : index + 1;
    }
}

/* Console.WriteLine($"\n-----\\{price}/{count}-----\n");
foreach (int value in list)
{
    Console.Write($"{value} ");
}
Console.WriteLine("\n------/-------\n"); */

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */

//Version 1
/* public class StockSpanner
{
    Stack<int> stack;
    public StockSpanner()
    {
        stack = new Stack<int>();
    }
    public int Next(int price, bool canPush = false)
    {
        int count = 1;
        if (stack.Count == 0)
        {
            stack.Push(price);
            return count;
        }
        Stack<int> temp = new Stack<int>();
        while (stack.Count > 0)
        {
            int value = stack.Pop();
            temp.Push(value);
            if (value > price) break;
            count++;
        }
        while (temp.Count > 0)
        {
            int val = temp.Pop();
            stack.Push(val);
        }
        stack.Push(price);
        return count;
    }
} */
//Version 2
/* public class StockSpanner
{
    Stack<int> stack;
    public StockSpanner()
    {
        stack = new Stack<int>();
    }
    public int Next(int price, int count = 1, bool canPush = true)
    {
        if (stack.Count > 0)
        {
            int value = stack.Pop();
            if (value <= price)
            {
                count = Next(price, count + 1, false);
            }
            stack.Push(value);
        }
        if (canPush)
            stack.Push(price);
        return count;
    }
} */

//Version 3
/* public class StockSpanner
{
    List<int> list;
    public StockSpanner()
    {
        list = new List<int>();
    }
    public int Next(int price)
    {
        int count = 1;
        int index = 1;
        if (list.Count > 0)
        {
            int value = 0;
            index = list.Count;
            while (value <= price)
            {
                count++;
                index--;
                if (index < 0)
                {
                    count = list.Count + 2;
                    break;
                }
                value = list[index];
            }
            count--;
        }
        list.Add(price);

        return count;
    }
} */