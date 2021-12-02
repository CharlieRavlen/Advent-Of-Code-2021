using System;
using System.IO;

class Program
{
    static int getFinalPos(String[] lines)
    {
        int x = 0;
        int y = 0;
        String[] data;

        foreach (var line in lines)
        {
            data = line.Split(' ');
            switch (data[0])
            {
                case "forward":
                    x += Convert.ToInt32(data[1]);
                    break;
                case "up":
                    y -= Convert.ToInt32(data[1]);
                    break;
                default:
                    y += Convert.ToInt32(data[1]);
                    break;
            }
        }
        return x * y;
    }
    static int getFinalAimPos(String[] lines)
    {
        int x = 0;
        int y = 0;
        int aim = 0;
        String[] data;
        int value;

        foreach (var line in lines)
        {
            data = line.Split(' ');
            value = Convert.ToInt32(data[1]);
            switch (data[0])
            {
                case "forward":
                    x += value;
                    y += aim * value;
                    break;
                case "up":
                    aim -= value;
                    break;
                default:
                    aim += value;
                    break;
            }
        }
        return x * y;
    }

    static void Main(string[] args)
    {
        String input = Directory.GetCurrentDirectory() + "\\input.txt"; //input files location
        var lines = File.ReadAllLines(input); //turns input into an array
        Console.WriteLine("Final Pos: " + getFinalPos(lines));
        Console.WriteLine("Final Accurate Pos: " + getFinalAimPos(lines));
    }
}
