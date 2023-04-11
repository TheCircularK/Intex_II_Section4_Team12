using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intex_S4T12_Api.Controllers
{
    public class MummyController
    {
        public MummyController(IMummyRepository mummyRepository)
        {
            _repo = mummyRepository;
        }

        private IMummyRepository _repo;

        //All records paginated
        [HttpGet("all/{pageNum}", Name = "GetAllRecords")]
        public ICollection<Burialmain> GetAllBurials(int pageNum)
        {

            return _repo.GetAllPaged(pageNum);
        }

        //Get filtered records



        //Individual record
        [HttpGet("record/{burialId}", Name = "GetBurialRecord")]
        public Burialmain GetBurialInfo(int burialId)
        {
            return null;
        }
    }
}
