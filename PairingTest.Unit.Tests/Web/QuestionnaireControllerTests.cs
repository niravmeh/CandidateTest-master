using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.Web
{  

    [TestFixture]
    public class QuestionnaireControllerTests
    {

        [Test]
        public async void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            List<string> expectedQuestionsText = new List<string>
                                           {
                                               "What is the capital of Cuba?",
                                               "What is the capital of France?",
                                               "What is the capital of Poland?",
                                               "What is the capital of Germany?"
                                           };

            Mock<IQuestionnaireService> mockQuestionnaireService = new Mock<IQuestionnaireService>();
            var questionnaire = new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle,
                QuestionsText = expectedQuestionsText
            };
            mockQuestionnaireService.Setup(t => t.GetAsync()).ReturnsAsync(questionnaire);

            var questionnaireController = new QuestionnaireController(mockQuestionnaireService.Object);

            //Act
            var viewResult = await questionnaireController.Index();
            var result = (QuestionnaireViewModel)viewResult.ViewData.Model;

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(result.QuestionsText[0], Is.EqualTo(expectedQuestionsText[0]));
            Assert.That(result.QuestionsText[1], Is.EqualTo(expectedQuestionsText[1]));
            Assert.That(result.QuestionsText[2], Is.EqualTo(expectedQuestionsText[2]));
            Assert.That(result.QuestionsText[3], Is.EqualTo(expectedQuestionsText[3]));

        }



    }
}