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
        public FilteredRecordRequest Request = new FilteredRecordRequest(1);

        public BurialSummaryModel(IMummyRepository temp)
        {
            _repo = temp;
        }

        public void OnGet(int pageNum = 1)
        {
            Request.PageNum = pageNum;
            Records = _repo.GetFiltered(Request);
        }

        public IActionResult OnPost()
        {
            Request.Sex = base.Request.Form["Sex"];
            
            string MinBur = base.Request.Form["MinBurialDepth"];
            
            if (MinBur != null && MinBur != "")
            {
                Request.MinBurialDepth = float.Parse(MinBur);
            }
            else
            {
                Request.MinBurialDepth = null;
            }

            string MaxBur = base.Request.Form["MaxBurialDepth"];

            if (MaxBur != null && MaxBur != "")
            {
                Request.MaxBurialDepth = float.Parse(MaxBur);
            }
            else
            {
                Request.MaxBurialDepth = null;
            }

            Request.EstimateStature = base.Request.Form["EstimateStature"];
            Request.AgeAtDeath = base.Request.Form["AgeAtDeath"].ToList<string>();
            Request.HeadDirection = base.Request.Form["HeadDirection"];
            Request.BurialId = base.Request.Form["BurialId"];
            Request.HairColors = base.Request.Form["HairColors"].ToList<string>();

            string faceBox = base.Request.Form["FaceBundles"];
            if (faceBox == "Checked")
            {
                Request.FaceBundles = "Y";
            }
            else
            {
                Request.FaceBundles = null;
            }

            Request.TextileStructure = base.Request.Form["TextileStructure"];
            Request.TextileColor = base.Request.Form["TextileColor"];
            Request.TextileFunction = base.Request.Form["TextileFunction"];
            //Make sure this is a boolean select
            string ribbonBox = base.Request.Form["ContainsRibbons"];

            if (ribbonBox == "Checked")
            {
                Request.ContainsRibbons = true;
            }
            else
            {
                Request.ContainsRibbons = null;
            }
            

            Records = _repo.GetFiltered(Request);

            return Page();
        }
    }
}
