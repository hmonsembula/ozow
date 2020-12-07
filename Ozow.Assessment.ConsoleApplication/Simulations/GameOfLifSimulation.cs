using Ozow.Assessment.QuestionTwo.Core;
using System;
using System.Text;
using System.Threading;

namespace Ozow.Assessment.QuestionOne.ConsoleApplication.Simulations
{
    public class GameOfLifSimulation
    {
        private void Render(Board simulation)
        {
            var stringBuilder = new StringBuilder();

            foreach (var cell in simulation.GameBoard)
            {
                if (cell.IsAlive)
                {
                    stringBuilder.Append("[*]");
                }
                else
                {
                    stringBuilder.Append("[ ]");
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(stringBuilder.ToString());
            Thread.Sleep(3000);
        }

        private void Simulate(int iterations, int rows, int columns)
        {
            Console.Clear();
            Board board = new Board(rows, columns);
            Render(board);
            for (int i = 1; i < iterations; i++)
            {
                board = board.Evolve();
                Render(board);
            }
            Console.WriteLine("\nSimulation complete...");
        }

        public void Run()
        {
            Console.WriteLine("::::::: Conway's Game Of Life ::::::\n");
            Console.WriteLine("Please enter number of rows...");
            var validRow = int.TryParse(Console.ReadLine(), out int rows);

            Console.WriteLine("Please enter number of columns...");
            var validColumns = int.TryParse(Console.ReadLine(), out int columns);

            if (validRow && validColumns)
            {
                Console.WriteLine("Please enter number of iterations...");
                var validIteration = int.TryParse(Console.ReadLine(), out int iterationResult);

                if (validIteration)
                {
                    Simulate(iterationResult, rows, columns);
                }
            }
            else
            {
                Console.WriteLine("Invalid values entered...");
            }
            Console.ReadLine();
        }
    }
}
