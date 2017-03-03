﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Models;
using PairingTest.Web.Services;
using PairingTest.Web;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireServiceTests
    {
        [Test]
        public async void ShouldGetQuestionnaireTitle()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            Mock<IGetApiClient> mockGetApiClient = new Mock<IGetApiClient>();
            var questionnaire = new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle
            };

            mockGetApiClient.Setup(m => m.Get<QuestionnaireViewModel>(It.IsAny<string>()))
                .ReturnsAsync(questionnaire);

            var questionnaireService = new QuestionnaireService(mockGetApiClient.Object);

           //Act
           var result = (QuestionnaireViewModel)await questionnaireService.GetAsync();

            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}
