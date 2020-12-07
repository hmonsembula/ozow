namespace Ozow.Assessment.QuestionOne.Models
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string resultText)
        {
            IsValid = isValid;
            ResultText = resultText;
        }
        public bool IsValid { get;}
        public string ResultText { get;}
    }
}
