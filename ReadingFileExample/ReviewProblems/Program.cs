using System;
using System.IO;
using System.Linq;

namespace ReadingFileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Reid\Downloads\Pride and Prejudice by Jane Austen.txt";

            string[] allLines = File.ReadAllLines(filePath);
            //string[] entireBook = File.ReadAllText(filePath);

            ////Output 5 lines of the book at a time
            //for (int i = 0; i < allLines; i++)
            //{
            //    if (i % 5 == 0 & i != 0)
            //    {
            //        Console.ReadKey();
            //    }
            //}

            //Console.WriteLine(allLines[i]);

            ////Console.WriteLine(entireBook);
            ///
            //Output a chapter at a time
            foreach (var line in allLines)
            {
                if(line.Contains("Chapter") == true)
                {
                    Console.ReadKey();
                }
                Console.WriteLine(line);

            }
            

        }
    }
}
