using System.Web.Mvc;
using PairingTest.Web.Models;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.Web.Script.Serialization;
using PairingTest.Web.Services;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireService _questionnaireService;

        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;           
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */

        public async Task<ViewResult> Index()
        {
            var viewModel = await _questionnaireService.GetAsync();
            return View(viewModel);
        }

     

        //public ViewResult Index()
        //{
        //    //string ApiUrl = ConfigurationManager.AppSettings["QuestionnaireServiceUri"].ToString();
        //    //string ResponseJsonData = QuestionsController(string.Concat(ApiUrl, "GetProducts"));
        //    //return View(GetProductList(ResponseJsonData));



        //    return View(new QuestionnaireViewModel());
        //}
    }
}
