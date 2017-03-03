using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;
using System.Collections.Generic;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        private readonly string _expectedTitle = "Geography Questions";
        private readonly FakeQuestionRepository _fakeQuestionRepository = new FakeQuestionRepository();


        [SetUp]
        public void SetUp()
        {
            _fakeQuestionRepository.ExpectedQuestions = new Questionnaire()
            {
                QuestionnaireTitle = _expectedTitle,
                QuestionsText = new List<string>
                 {
                    "What is the capital of Cuba?",
                    "What is the capital of France?",
                    "What is the capital of Poland?",
                    "What is the capital of Germany?"
                }
            };
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var questionsController = new QuestionsController(_fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(_expectedTitle));
            Assert.That(questions.QuestionsText[0], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[0]));
            Assert.That(questions.QuestionsText[1], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[1]));
            Assert.That(questions.QuestionsText[2], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[2]));
            Assert.That(questions.QuestionsText[3], Is.EqualTo(_fakeQuestionRepository.ExpectedQuestions.QuestionsText[3]));
        }
    }
}