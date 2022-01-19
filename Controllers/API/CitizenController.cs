using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace village.Controllers.API
{
    public class CitizenController : ApiController
    {
        Village dataContext = new Village();
        // GET: api/Citizen
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success", Citizens = dataContext.Citizens.ToList() });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Citizen/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Citizen expectedCitizen = await dataContext.Citizens.FindAsync(id);

                if (expectedCitizen != null) return Ok(new { Massage = "Success", expectedCitizen });
                else return NotFound();
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Citizen
        public async Task<IHttpActionResult> Post([FromBody] Citizen newCitizen)
        {
            try
            {
                dataContext.Citizens.Add(newCitizen);

                await dataContext.SaveChangesAsync();

                return Ok(new { Massage = "Success, new citizen added" });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
