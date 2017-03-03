using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PairingTest.Web.Models;
using QuestionServiceWebApi;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IGetApiClient _getApiClient;

        public QuestionnaireService(IGetApiClient getApiClient)
        {
            _getApiClient = getApiClient;
        }

        public async Task<QuestionnaireViewModel> GetAsync()
        {
            return await _getApiClient.Get<QuestionnaireViewModel>("/api/Questions");
        }

        public async Task<Questionnaire> GetQuestionnaire()
        {
            return await _getApiClient.Get<Questionnaire>("/api/Questions");
        }
    }
}