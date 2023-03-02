using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rs_Api.Models;

namespace RsApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        public AllergyController()
        {
        }

        //[HttpGet("Select")]
        //public IActionResult Select(int AllergyId)
        //{
        //    using (RsdbContext rsdbContext = new RsdbContext())
        //    {
        //        Allergy? allergyContextModel = rsdbContext
        //            .Allergies
        //            .Where(allergy => allergy.AllergyId.Equals(AllergyId))
        //            .FirstOrDefault<AllergyContextModel>();
        //        if (allergyContextModel is not null)
        //        {
        //            AllergyResponseModel? allergyResponseModel = AllergyResponseModel.GetAllergyResponseModel(allergyContextModel);
        //            return Ok(allergyResponseModel);
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }
        //    }
        //}
        //Allergy/SelectAll
        [HttpGet("Env")]
        public IActionResult Env(string value)
        {
            string? env = Environment.GetEnvironmentVariable(value);
            if (env is not null)
            {
                return Ok(env);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("SelectAll")]
        public IActionResult SelectAll()
        {
            using (RsdbContext rsdbContext = new RsdbContext())
            {
                IEnumerable<Allergy> allergyContextModelEnumerable = rsdbContext
                    .Allergies.ToList<Allergy>();
            if (allergyContextModelEnumerable is not null)
            {
                return Ok(allergyContextModelEnumerable);
            }
            else
            {
                return NoContent();
            }
        }
        }
        //[HttpPut("Insert")]
        //public IActionResult Insert(AllergyResponseModel.Insert insert)
        //{
        //    using (RsdbContext rsdbContext = new RsdbContext())
        //    {
        //        rsdbContext.Add(AllergyResponseModel.Insert.GetAllergyContextModel(insert));
        //        if (rsdbContext.SaveChanges() == 1)
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            return NoContent();
        //        }
        //    }
        //}
    }
}