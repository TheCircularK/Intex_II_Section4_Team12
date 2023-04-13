using Intex_II_Section4_Team12.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Intex_II_Section4_Team12.NavigationModels;

namespace Intex_II_Section4_Team12.Pages
{
    public class BurialSummaryModel : PageModel
    {
        private IMummyRepository? _repo;
        public FilteredRecordsWithPages Records { get; set; }
        private FilteredRecordRequest _request = new FilteredRecordRequest(1);

        public BurialSummaryModel(IMummyRepository temp)
        {
            _repo = temp;
        }

        public void OnGet()
        {
            Records = _repo.GetFiltered(_request);
        }

        public IActionResult OnPost()
        {
            _request.Sex = Request.Form["Sex"];
            
            string MinBur = Request.Form["MinBurialDepth"];
            
            if (MinBur != null && MinBur != "")
            {
                _request.MinBurialDepth = float.Parse(MinBur);
            }
            else
            {
                _request.MinBurialDepth = null;
            }

            string MaxBur = Request.Form["MaxBurialDepth"];

            if (MaxBur != null && MaxBur != "")
            {
                _request.MaxBurialDepth = float.Parse(MaxBur);
            }
            else
            {
                _request.MaxBurialDepth = null;
            }

            _request.EstimateStature = Request.Form["EstimateStature"];
            _request.AgeAtDeath = Request.Form["AgeAtDeath"].ToList();
            _request.HeadDirection = Request.Form["HeadDirection"];
            _request.BurialId = Request.Form["BurialId"];
            _request.HairColors = Request.Form["HairColors"].ToList();

            string faceBox = Request.Form["FaceBundles"];
            if (faceBox == "Checked")
            {
                _request.FaceBundles = "Y";
            }
            else
            {
                _request.FaceBundles = "N";
            }

            _request.TextileStructure = Request.Form["TextileStructure"];
            _request.TextileColor = Request.Form["TextileColor"];
            _request.TextileFunction = Request.Form["TextileFunction"];
            //Make sure this is a boolean select
            string ribbonBox = Request.Form["ContainsRibbons"];

            if (ribbonBox == "Checked")
            {
                _request.ContainsRibbons = true;
            }
            else
            {
                _request.ContainsRibbons = null;
            }
            

            Records = _repo.GetFiltered(_request);

            return Page();
        }
    }
}
