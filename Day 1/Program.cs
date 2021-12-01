using System;
using System.IO;
using System.Linq;

class Program
{
    static int getCountHigher(String[] lines) 
    {
        int count = 0;
        int? last = null;
        int current;

        foreach(var line in lines)
        {
            current = Convert.ToInt32(line);
            if (last != null && current > last) { count++; }
            last = current;
        }
        return count;
    }

    static int getRollingHigher(String[] lines)
    {
        int count = 0;
        int? lastTotal = null;
        int current, total;
        int?[] values = {null, null, null};

        foreach (var line in lines)
        {
            current = Convert.ToInt32(line); 
            total = 0; //reset so that we don't keep increasing the total
            values[values.Length - 1] = current;

            if (!values.Contains(null)) //make sure we have an array full of proper values
            {
                for (int i = 0; i < values.Length; i++)
                {
                    total += (int)(values[i]);
                }
                if (total > lastTotal) { count++; }
                lastTotal = total;
            }

            for (int i = 0; i < values.Length - 1; i++)
            {
                values[i] = values[i + 1];
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        String input = Directory.GetCurrentDirectory() + "\\input.txt"; //input files location
        var lines = File.ReadAllLines(input); //turns input into an array
        Console.WriteLine("Amount of increases: " + getCountHigher(lines));
        Console.WriteLine("Amount of rolling increases: " + getRollingHigher(lines));
    }
}
