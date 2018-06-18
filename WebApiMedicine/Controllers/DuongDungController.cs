using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMedicine.Models;

namespace WebApiMedicine.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/duongdungs")]
    public class DuongDungsController : ApiController
    {
        DuongDung duongDungs = new DuongDung();

        [HttpGet]
        public IEnumerable<DuongDung> Get()
        {
            return duongDungs.Get();
        }

        [HttpGet]
        [Route("api/duongdungs/{id}")]
        public IHttpActionResult Get(string id)
        {
            var DuongDung = duongDungs.Get(new ObjectId(id));
            if (DuongDung == null)
            {
                return NotFound();
            }
            return Ok(DuongDung);
        }

        [HttpGet]
        [Route("api/duongdungs/ten/{name}")]
        public IEnumerable<DuongDung> GetWithName(string name)
        {
            return duongDungs.GetDuongDungTheoTen(name);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]DuongDung p)
        {
            duongDungs.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/duongdungs/{id}")]
        public IHttpActionResult Put(string id, [FromBody]DuongDung p)
        {
            var recId = new ObjectId(id);
            var DuongDung = duongDungs.Get(recId);
            if (DuongDung == null)
            {
                return NotFound();
            }

            duongDungs.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/duongdungs/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = duongDungs.Get(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            duongDungs.Remove(product.Id);
            return Ok();
        }
    }
}
