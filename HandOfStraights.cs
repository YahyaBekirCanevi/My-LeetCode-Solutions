public class HandOfStraights
{
    /* for (int i = 0; i < hhand.Count; i++)
        Console.Write($"{hhand[i]} " + (i % 10 == 9 ? "\n" : ""));
    Console.WriteLine("\n" + hhand.Count); */
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        List<int> hhand = hand.ToList<int>();
        hhand.Sort();
        List<List<int>> match = new List<List<int>>();
        for (int i = 0; i < hhand.Count; i++)
        {
            int index = match.FindIndex(e =>
            {
                return e.Count < groupSize
                 && e.Any(r => hhand[i] - r <= 1)
                 && !e.Any(p => p == hhand[i]);
            });
            if (index != -1)
            {
                match[index].Add(hhand[i]);
            }
            else
            {
                if (match.Count > hand.Length / groupSize) return false;
                match.Add(new List<int>());
                match[match.Count - 1].Add(hhand[i]);
            }
        }
        int count = 0;
        foreach (List<int> item1 in match)
        {
            foreach (int item in item1)
            {
                count++;
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            if (count % groupSize != hhand.Count % groupSize) return false;
        }
        return true;
    }
}