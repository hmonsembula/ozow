namespace Ozow.Assessment.QuestionTwo.Rules
{
    public class GameOfLifeRulesEngine : IRulesEngine
    {
        /***********************
             *  Cell Rules:
             *     1 > Any live cell with fewer than two live neighbours should die
             *     2 > Any live cell with two or three live neighbours goes to next generation
             *     3 > Any live cell with more than three live neighbours should die
             *     4 > Any dead cell with three live neighbours should become alive
             */
        public bool ShouldLive(bool isAlive, int liveNeighbourCount)
        {
            if (isAlive)
            {
                if (liveNeighbourCount == 2 || liveNeighbourCount == 3)
                {
                    return true;
                }
            }
            else
            {
                if(liveNeighbourCount == 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
