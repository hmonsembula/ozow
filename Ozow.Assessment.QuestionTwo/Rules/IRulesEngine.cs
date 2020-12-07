namespace Ozow.Assessment.QuestionTwo.Rules
{
    public interface IRulesEngine
    {
        bool ShouldLive(bool isAlive, int neigbourCount);
    }
}
