using Ozow.Assessment.QuestionOne.ConsoleApplication.Simulations;
using System;

namespace Ozow.Assessment.QuestionOne.ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("::::::: Ozow Technical Assessment ::::::\n");
            Console.WriteLine("Please choose question to run...");
            Console.WriteLine("Enter [A] for question one, Enter [B] for question two");
            var text = Console.ReadLine();

            if (text.ToUpperInvariant().Equals("A"))
            {
                RunQuestionOne();
            }
            else if (text.ToUpperInvariant().Equals("B"))
            {
                RunQuestionTwo();
            }
            else
            {
                Console.WriteLine("INVALID OPTION: Running default option:\n");
                RunQuestionOne();
            }
        }

        private static void RunQuestionOne()
        {
            new SortSimulation().Run();
        }

        public static void RunQuestionTwo()
        {
            new GameOfLifSimulation().Run();
        }
    }
}
