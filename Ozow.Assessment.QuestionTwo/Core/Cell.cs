using Ozow.Assessment.QuestionTwo.Rules;
using System.Collections.Generic;
using System.Linq;

namespace Ozow.Assessment.QuestionTwo.Core
{
    public class Cell : GameOfLifeRulesEngine
    {
        public bool IsAlive { get; set; }
        public bool CanLive { get; private set; }

        public IList<Cell> AliveNeighbours = new List<Cell>();

        public void SetState()
        {
            CanLive = ShouldLive(IsAlive, AliveNeighbours.Count());
        }
    }
}
