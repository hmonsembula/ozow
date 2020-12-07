using Ozow.Assessment.QuestionOne.Models;
using Ozow.Assessment.QuestionOne.SortOptions.Interface;

namespace Ozow.Assessment.QuestionOne.Service
{
    public class StringSortService : IStringSortService
    {
        private readonly ISortOption _sortOption;
        public StringSortService(ISortOption sortOption)
        {
            _sortOption = sortOption;
        }

        public string TrySort(string text)
        {
            ValidationResult validationResult = text.IsValidText();

            if (!validationResult.IsValid)
            {
                return validationResult.ResultText;
            }

            string stringToSort = text.RemovePunctuation();

            validationResult = stringToSort.IsValidText();
            if (!validationResult.IsValid)
            {
                return validationResult.ResultText;
            }

            return _sortOption.Sort(validationResult.ResultText.ToLowerInvariant().ToCharArray());
        }
    }
}
