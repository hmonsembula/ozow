using Ozow.Assessment.QuestionOne.SortOptions.Interface;
using System.Linq;

namespace Ozow.Assessment.QuestionOne.SortOptions
{
    public class LinqSortOption : ISortOption
    {
        public string Sort(char[] characterArray)
        {
            return characterArray.OrderBy(x => x).ToString();
        }
    }
}
