using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnivMedicalRecord.Models.Graphs;

namespace UnivMedicalRecord.Pages.GraphTest;

public class Graph : PageModel
{
    
    public IActionResult OnGet()
    {
        var graphDataSet = new BarGraphDatasets()
        {
            label = "Sample dataset 1",
            data = new List<double>{100.23,200.44,4000.68,333.76,69.69},
            backgroundColor = new List<string> {
                "rgba(255, 99, 132, 0.2)",
                "rgba(255, 159, 64, 0.2)",
                "rgba(255, 205, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(54, 162, 235, 0.2)"},
            borderColor = new List<string> {
                "rgb(255, 99, 132)",
                "rgb(255, 159, 64)",
                "rgb(255, 205, 86)",
                "rgb(75, 192, 192)",
                "rgb(54, 162, 235)"},
            borderWidth = 1
        };

        var graphDataSet2 = new BarGraphDatasets()
        {
            label = "Sample dataset 2",
            data = new List<double> { 1010.23, 2100.44, 4100.68, 3313.76, 619.69 },
            backgroundColor = new List<string> {
                "rgba(255, 199, 132, 0.5)",
                "rgba(255, 59, 64, 0.5)",
                "rgba(255, 5, 86, 0.5)",
                "rgba(75, 92, 192, 0.5)",
                "rgba(54, 62, 235, 0.5)"},
            borderColor = new List<string> {
                "rgb(255, 199, 132)",
                "rgb(255, 59, 64)",
                "rgb(255, 05, 86)",
                "rgb(75, 92, 192)",
                "rgb(54, 62, 235)"},
            borderWidth = 1
        };

        var barGraphDataModel = new BarGraphDataModel()
        {
            labels = new List<string> { "Data 1", "Data 2", "Data 3", "Data 4", "Data 5" },
            datasets = new List<BarGraphDatasets> { graphDataSet, graphDataSet2 }
        };

        // return Json(new {success = true, data = barGraphDataModel});
        return Page();
    }
}

