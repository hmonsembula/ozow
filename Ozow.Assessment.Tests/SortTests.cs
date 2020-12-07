using FluentAssertions;
using NUnit.Framework;
using Ozow.Assessment.QuestionOne.Service;
using Ozow.Assessment.QuestionOne.SortOptions;
using System.IO;

namespace Ozow.Assessment.Tests
{
    public class SortTests
    {
        private IStringSortService _sortLibrary;
        private string _directory;
        private const string CannotProcessBlank = "Cannot process blank text";
        private const string CannotSortOneCharacter = "Cannot sort one character";
        private const string TextTooLarge = "Text is too large to process";
        [SetUp]
        public void Setup()
        {
            _sortLibrary = new StringSortService(new QuickSortOption());
            _directory = TestContext.CurrentContext.TestDirectory + @"\Data\large_text.txt";
        }

        [TestCase(" ", CannotProcessBlank)]
        [TestCase("", CannotProcessBlank)]
        [TestCase(",,", CannotProcessBlank)]
        [TestCase(", ! ? ' : ; - [] {} ()", CannotProcessBlank)]
        public void Sort_Should_Exit_On_Empty_Or_WhiteSpace(string text, string output)
        {
            //Act
            var result = _sortLibrary.TrySort(text);

            //Assert
            result.Should().Be(output);
        }

        [TestCase(",,", CannotProcessBlank)]
        [TestCase(", ! ? ' : ; - [] {} ()", CannotProcessBlank)]
        public void Sort_Should_Treat_Punctuation_As_Blank(string text, string output)
        {
            //Act
            var result = _sortLibrary.TrySort(text);

            //Assert
            result.Should().Be(output);
        }

        [TestCase("a", CannotSortOneCharacter)]
        [TestCase("a ", CannotSortOneCharacter)]
        [TestCase("a.", CannotSortOneCharacter)]
        public void Should_Exit_If_Only_One_Character(string text, string output)
        {
            //Act
            var result = _sortLibrary.TrySort(text);

            //Assert
            result.Should().Be(output);
        }

        [Test]
        public void Should_Exit_On_Large_Text()
        {
            //Arrange           
            string largeText = File.ReadAllText(_directory);
            //Act
            string result = _sortLibrary.TrySort(largeText);

            //Assert
            result.Should().Be(TextTooLarge);
        }

        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.")]
        public void Should_Not_Return_Unsorted_Text(string text, string output)
        {
            //Act
            var result = _sortLibrary.TrySort(text);

            //Assert
            result.Should().NotBe(output);
        }

        [TestCase("Contrary to popular belief, the pink unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("CONTRARY TO POPULAR BELIEF, THE PINK UNICORN FLIES EAST", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("CONTRARY to popular belief, the pink UNICORN flies.", "aabcceeeeffhiiiiklllnnnnooooppprrrrstttuuy")]
        [TestCase("Contrary to popular belief, the pink unicorn flies east!", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief, the pink unicorn flies east...", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief, the pink unicorn flies east?", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief; the pink unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief: the pink unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief - the pink unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        [TestCase("Contrary to popular belief (yes) the pink unicorn flies east", "aaabcceeeeeeffhiiiiklllnnnnooooppprrrrsssttttuuyy")]
        [TestCase("Contrary to popular belief {yes} the pink unicorn flies east", "aaabcceeeeeeffhiiiiklllnnnnooooppprrrrsssttttuuyy")]
        [TestCase("Contrary to popular belief [yes] the pink unicorn flies east", "aaabcceeeeeeffhiiiiklllnnnnooooppprrrrsssttttuuyy")]
        [TestCase("Contrary to popular belief, the pink unicorn flies east. It's true.", "aaabcceeeeeeffhiiiiiklllnnnnooooppprrrrrsssttttttuuuy")]
        [TestCase("Contrary to popular belief, the \"pink\" unicorn flies east", "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")]
        public void Should_Return_Sorted_Text_Without_Punctuation_And_Upper_Case(string text, string output)
        {
            //Act
            var result = _sortLibrary.TrySort(text);

            //Assert
            result.Should().Be(output);
        }
    }
}