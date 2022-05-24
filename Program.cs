using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {

        string n = Console.ReadLine();
        string inParams = Console.ReadLine();

        int[] conditions = n.Split(" ").Select(int.Parse).ToArray();
        string[] basicTestCase = inParams.Split(" ").ToArray();

        var distinctNumsCount = new Dictionary<int, int>();

        foreach (string i in basicTestCase)
        {
            int num = int.Parse(i);
            if (distinctNumsCount.ContainsKey(num))
                distinctNumsCount[num]++;
            else
                distinctNumsCount.Add(num, 1);
        }

        if (conditions[1] == 0)
        {
            Console.WriteLine(distinctNumsCount.Values.Max());
        }
        else
        {

            for (int i = 0; i < conditions[1]; i++)
            {
                KeyValuePair<int, int> pair = new KeyValuePair<int, int>(0, 0);
                foreach (var kvp in distinctNumsCount)
                {
                    if (kvp.Value > pair.Value)
                        pair = kvp;
                }

                distinctNumsCount[pair.Key] -= 1;
            }
            Console.WriteLine(distinctNumsCount.Values.Max());
        }
    }
}