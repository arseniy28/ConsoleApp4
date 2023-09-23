using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string sentence1 = "Привет, как дела? Йа йогурт!";
        string sentence2 = "Йо, что нового? Йа йога!";


        Thread thread1 = new Thread(() => FindLastIndex(sentence1));
        Thread thread2 = new Thread(() => FindLastIndex(sentence2));

        
        DateTime startTime1 = DateTime.Now;
        DateTime startTime2 = DateTime.Now;

      
        thread1.Start();
        thread2.Start();


        thread1.Join();
        thread2.Join();

  
        TimeSpan elapsedTime1 = DateTime.Now - startTime1;
        TimeSpan elapsedTime2 = DateTime.Now - startTime2;

        Console.WriteLine($"Время работы потока 1: {elapsedTime1.TotalMilliseconds} мс");
        Console.WriteLine($"Время работы потока 2: {elapsedTime2.TotalMilliseconds} мс");
    }

    static void FindLastIndex(string sentence)
    {
        char targetChar = 'й';
        int lastIndex = -1;


        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == targetChar)
            {
                lastIndex = i;
            }
        }


        Console.WriteLine($"В предложении \"{sentence}\" символ \"{targetChar}\" имеет порядковый номер {lastIndex}");
    }
}