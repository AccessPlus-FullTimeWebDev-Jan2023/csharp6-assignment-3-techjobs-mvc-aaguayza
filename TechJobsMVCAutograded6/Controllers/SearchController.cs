using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{
    List<Job> jobs;
    // GET: /<controller>/
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        

        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
    [HttpPost]
    [Route("/search/results")]
    public IActionResult Results(string searchType, string searchTerm)
    {
        if(searchTerm == "" || searchTerm == "all")
        {
            jobs = JobData.FindAll();
            ViewBag.jobs = jobs;

        }
        else{
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobs; 
        }
        return View();
    }
    
}

