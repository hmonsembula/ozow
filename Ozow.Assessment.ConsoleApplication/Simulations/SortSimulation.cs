using Ozow.Assessment.QuestionOne.Service;
using Ozow.Assessment.QuestionOne.SortOptions;
using Ozow.Assessment.QuestionOne.SortOptions.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ozow.Assessment.QuestionOne.ConsoleApplication
{
    public class SortSimulation
    {
        public SortSimulation()
        {
            SortOptions = new Dictionary<int, ISortOption>
            {
                { 1, new QuickSortOption() },
                { 2, new LinqSortOption() }
            };
        }

        public IDictionary<int, ISortOption> SortOptions { get; }

        private ISortOption GetSortOption(int option)
        {
            return SortOptions.FirstOrDefault(x => x.Key == option).Value;
        }

        private void ProcessString(string text, int option)
        {
            if (!SortOptions.ContainsKey(option))
            {
                Console.WriteLine($"\nOption {option} is not a valid sort option.");
            }
            else
            {
                var watch = Stopwatch.StartNew();
                string response = new StringSortService(GetSortOption(option)).TrySort(text);
                watch.Stop();
                Console.WriteLine($"\n:: Processing complete ::");
                Console.WriteLine($"\n> Elapsed time: {watch.ElapsedMilliseconds} (ms) \n> Sort result: {response}");
            }
        }

        public void Run()
        {
            Console.WriteLine("::::::: Ozow Sort Assessment ::::::\n");

            Console.WriteLine("Please enter text to sort...");
            var text = Console.ReadLine();

            Console.WriteLine("\nPlease choose a sort option:");

            foreach (var option in SortOptions)
            {
                Console.WriteLine($"> Enter {option.Key} for {option.Value.GetType().Name}");
            };

            var validOption = int.TryParse(Console.ReadLine(), out int parseResult);
            if (validOption)
            {
                ProcessString(text, parseResult);
            }
        }
    }
}
