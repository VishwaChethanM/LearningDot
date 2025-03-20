using LearningDot.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using LearningDot.AdoDataLayer;
using LearningDot.DtoClass;
namespace LearningDot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillageDetailsController : ControllerBase
    {
        [HttpGet("GetAllVillage")]
        public IActionResult GetAllVillage()
        {
            List <VillageMaster> villageMasters = new List<VillageMaster> ();
            SqlDataReader sqlDataReader = AdoDateLayerConnction.GetDataReaderFromStoredProcedure("GetAllVillageDetails");
            while (sqlDataReader.Read())
            {
                villageMasters.Add(new VillageMaster
               {
                   villageId = sqlDataReader.GetInt32(0),
                   villageName = sqlDataReader.GetString(1),
                   TalukName = sqlDataReader.GetString(2)
               });
            }
            return Ok(villageMasters);
        }
        [HttpGet("getOnlyByName")]
        public IActionResult getOnlyName()
        {
            List <GetOnlyByVillageName> villageMasters=new List<GetOnlyByVillageName> ();
            SqlDataReader sqlDataReader = AdoDateLayerConnction.GetDataReaderFromStoredProcedure("GetOnlyName");
            while (sqlDataReader.Read())
            {
                villageMasters.Add(new GetOnlyByVillageName
                {
                    VillageName = sqlDataReader.GetString(0)
                });

            }
            return Ok(villageMasters);
        }



        [HttpGet("getOnlyById/{id}")]  
        public IActionResult GetById(int id)
        {
            List<GetOnlyByVillageName> villageNames = new List<GetOnlyByVillageName>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                  new SqlParameter("@VillageId", id)
            };

            SqlDataReader sqlDataReader = AdoDateLayerConnction.GetDataReaderFromStoredProcedure("GetVillageById", parameters);
            while (sqlDataReader.Read())
            {
                villageNames.Add(new GetOnlyByVillageName
                {
                    VillageName = sqlDataReader.GetString(0)
                });
            }
            return Ok(villageNames);
        }

    }
}
