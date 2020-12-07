using System.Text;

namespace Ozow.Assessment.QuestionOne.Models
{
    public static class Extensions
    {
        public static string RemovePunctuation(this string text)
        {
            var tempString = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    tempString.Append(c);
                }
            }

            return tempString.ToString();
        }

        public static ValidationResult ValidateLength(this string text)
        {
            if (text.Length > 1000)
            {
                return new ValidationResult(false, "Text is too large to process");
            }

            if (text.Length <= 1)
            {
                return new ValidationResult(false, "Cannot sort one character");
            }

            return new ValidationResult(true, text);
        }

        public static ValidationResult IsValidText(this string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {

                return new ValidationResult(false, "Cannot process blank text");
            }

            return text.ValidateLength();
        }
    }
}
