using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;


class BullshitBingo
{
    private static List<string> defaultWords = new List<string>(){
    "cow",
    "camel",
    "elephant"
    };

    private static Dictionary<string, int> counter = new Dictionary<string, int>();

    public static List<string> getBullshitBingo(List<string> words, string txt, int bullshitCount)
    {
        List<string> result = new List<string>();
        string lowTxt = txt.ToLower();

        foreach (string word in words)
        {
            int start = 0;

            int found = -1;

            found = lowTxt.IndexOf(word, start);

            while (found >= 0)
            {
                if (counter.ContainsKey(word) == true)
                {
                    counter[word]++;
                }
                else
                {
                    counter.Add(word, 1);
                }

                if (counter[word] >= bullshitCount)
                {
                    result.Add("bullshit");

                    counter[word] = 0;
                }

                start = found + 1;

                found = lowTxt.IndexOf(word, start);
            }
        }

        Console.WriteLine(result.Count);

        return result;
    }

    public static List<string> getBullshitBingo(List<string> words, string txt)
    {
        return getBullshitBingo(words, txt, 5);
    }

    public static List<string> getBullshitBingo(string txt)
    {
        return getBullshitBingo(defaultWords, txt, 5);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> result = BullshitBingo.getBullshitBingo("cow cow cow");

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }

        result = BullshitBingo.getBullshitBingo("cow cow cow cow cow cowcow cow cowcow cow cowcow cow cowcow cow cow elephant");

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }

        result = BullshitBingo.getBullshitBingo("cow cow cow elephant elephant elephant elephant elephant");

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }

        result = BullshitBingo.getBullshitBingo("cow cow cow");

        foreach (string word in result)
        {
            Console.WriteLine(word);
        }
    }
}