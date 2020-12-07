using Ozow.Assessment.QuestionOne.SortOptions.Interface;
using System;

namespace Ozow.Assessment.QuestionOne.SortOptions
{
    public class QuickSortOption : ISortOption
    {
        public string Sort(char[] characterArray)
        {
            Array.Sort(characterArray);
            return new string(characterArray);
        }
    }
}
