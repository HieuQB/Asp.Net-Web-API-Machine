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
    [Route("api/congtydannhans")]
    public class CongTyDanNhanController : ApiController
    {
        CongTyDanNhan congTyDanNhans = new CongTyDanNhan();

        [HttpGet]
        public IEnumerable<CongTyDanNhan> Get()
        {
            return congTyDanNhans.Get();
        }

        [HttpGet]
        [Route("api/congtydannhans/{id}")]
        public IHttpActionResult Get(string id)
        {
            var CongTyDanNhan = congTyDanNhans.Get(new ObjectId(id));
            if (CongTyDanNhan == null)
            {
                return NotFound();
            }
            return Ok(CongTyDanNhan);
        }

        [HttpGet]
        [Route("api/congtydannhans/ten/{name}")]
        public IEnumerable<CongTyDanNhan> GetWithName(string name)
        {
            return congTyDanNhans.GetCongTyDanNhanTheoTen(name);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]CongTyDanNhan p)
        {
            congTyDanNhans.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/congtydannhans/{id}")]
        public IHttpActionResult Put(string id, [FromBody]CongTyDanNhan p)
        {
            var recId = new ObjectId(id);
            var CongTyDanNhan = congTyDanNhans.Get(recId);
            if (CongTyDanNhan == null)
            {
                return NotFound();
            }

            congTyDanNhans.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/congtydannhans/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = congTyDanNhans.Get(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            congTyDanNhans.Remove(product.Id);
            return Ok();
        }
    }
}
