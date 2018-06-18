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
    [Route("api/congtysohuus")]
    public class CongTySoHuuController : ApiController
    {
        CongTySoHuu congTySoHuus = new CongTySoHuu();

        [HttpGet]
        public IEnumerable<CongTySoHuu> Get()
        {
            return congTySoHuus.Get();
        }

        [HttpGet]
        [Route("api/congtysohuus/{id}")]
        public IHttpActionResult Get(string id)
        {
            var CongTySoHuu = congTySoHuus.Get(new ObjectId(id));
            if (CongTySoHuu == null)
            {
                return NotFound();
            }
            return Ok(CongTySoHuu);
        }

        [HttpGet]
        [Route("api/congtysohuus/ten/{name}")]
        public IEnumerable<CongTySoHuu> GetWithName(string name)
        {
            return congTySoHuus.GetCongTySoHuuTheoTen(name);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]CongTySoHuu p)
        {
            congTySoHuus.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/congtysohuus/{id}")]
        public IHttpActionResult Put(string id, [FromBody]CongTySoHuu p)
        {
            var recId = new ObjectId(id);
            var CongTySoHuu = congTySoHuus.Get(recId);
            if (CongTySoHuu == null)
            {
                return NotFound();
            }

            congTySoHuus.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/congtysohuus/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = congTySoHuus.Get(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            congTySoHuus.Remove(product.Id);
            return Ok();
        }
    }
}
