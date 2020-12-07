using System;
using System.Collections.Generic;

namespace Ozow.Assessment.QuestionTwo.Core
{
    public class Board
    {
        public Cell[,] GameBoard { get; private set; }
        public int Columns { get; }
        public int Rows { get; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            RandomizeState();
        }

        private void RandomizeState()
        {
            GameBoard = new Cell[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    GameBoard[row, column] = new Cell
                    {
                        IsAlive = new Random().Next(1, 100) < 10
                    };
                }
            }
        }

        public Board Evolve()
        {
            var evolution = new Board(Rows, Columns);

            for (int row = 1; row < Rows - 1; row++)
            {
                for (int column = 1; column < Columns - 1; column++)
                {
                    var aliveNeighbours = GetAlive(row, column);                    
                    var currentCell = GameBoard[row, column];
                    aliveNeighbours.Remove(currentCell); //Exclude current cell due to inclusion when getting neighbours

                    currentCell.AliveNeighbours = aliveNeighbours;
                    currentCell.SetState();

                    if (currentCell.CanLive)
                    {
                        evolution.GameBoard[row, column] = currentCell;
                    }
                }
            }
            return evolution;
        }

        private List<Cell> GetAlive(int row, int column)
        {
            var aliveCells = new List<Cell>();
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (GameBoard[row + i, column + j].IsAlive)
                    {
                        aliveCells.Add(GameBoard[row + i, column + j]);
                    }
                }
            }
            return aliveCells;
        }
    }
}
