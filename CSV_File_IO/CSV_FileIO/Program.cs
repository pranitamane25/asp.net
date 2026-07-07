using System;
using System.IO;
class Program
{
    public static void Main()
    {
        string Path= @"./Data/sample.csv";

        string[] lines=File.ReadAllLines(Path);
        //skip first line
        for (int i = 1; i < lines.Length; i++)
        {
            string line=lines[i];
            string[]data=line.Split(',');
            int id=int.Parse(data[0]);
            string name=(data[1]);
            string email=(data[2]);
            int age=int.Parse(data[3]);
            string course=(data[4]);

            Console.WriteLine($"{id}|{name}|{email}|{age}|{course}");

        }
    }
}
