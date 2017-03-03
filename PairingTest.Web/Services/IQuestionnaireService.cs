﻿using PairingTest.Web.Models;
using QuestionServiceWebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireViewModel> GetAsync();
        Task<Questionnaire> GetQuestionnaire();
    }
}
