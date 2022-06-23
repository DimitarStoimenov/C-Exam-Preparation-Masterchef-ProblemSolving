using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] freshnessLevel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ingreQueue = new Queue<int>(ingredients);
            Stack<int> freshStack = new Stack<int>(freshnessLevel);
            SortedDictionary<string, int> output = new SortedDictionary<string, int>();
            {
                output.Add("Dipping sauce", 0);
                output.Add("Green salad", 0);
                output.Add("Chocolate cake", 0);
                output.Add("Lobster", 0);
            }
            while (ingreQueue.Count != 0 && freshStack.Count != 0)
            {
                if (ingreQueue.Peek() == 0)
                {
                    ingreQueue.Dequeue();
                    continue;
                }

                if (ingreQueue.Peek() * freshStack.Peek() == 150)
                {
                    output["Dipping sauce"] += 1;
                    ingreQueue.Dequeue();
                    freshStack.Pop();

                }
                else if (ingreQueue.Peek() * freshStack.Peek() == 250)
                {
                    output["Green salad"] += 1;
                    ingreQueue.Dequeue();
                    freshStack.Pop();
                }
                else if (ingreQueue.Peek() * freshStack.Peek() == 300)
                {
                    output["Chocolate cake"] += 1;
                    ingreQueue.Dequeue();
                    freshStack.Pop();
                }
                else if (ingreQueue.Peek() * freshStack.Peek() == 400)
                {
                    output["Lobster"] += 1;
                    ingreQueue.Dequeue();
                    freshStack.Pop();
                }
                if (ingreQueue.Count > 0 && freshStack.Count > 0)
                {
                    if (ingreQueue.Peek() * freshStack.Peek() != 150 && ingreQueue.Peek() * freshStack.Peek() != 250 && ingreQueue.Peek() * freshStack.Peek() != 300 && ingreQueue.Peek() * freshStack.Peek() != 400)
                    {
                        
                        if (ingreQueue.Count > 0 && freshStack.Count > 0)
                        {
                            int currFresh = freshStack.Peek();
                            freshStack.Pop();
                            int currIngre = ingreQueue.Peek() + 5;
                            ingreQueue.Dequeue();
                            ingreQueue.Enqueue(currIngre);
                        }


                    }
                }
            }

            if (output["Dipping sauce"] >= 1 && output["Green salad"] >= 1 && output["Chocolate cake"] >= 1 && output["Lobster"] >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");

            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingreQueue.Count > 0)
            {
                Console.WriteLine($"Ingredients left: { ingreQueue.Sum()}");
            }

            foreach (var item in output)
            {
                if (item.Value >= 1)
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value}");
                }
            }
        }
    }
}
