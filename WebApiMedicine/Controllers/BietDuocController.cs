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
    [Route("api/bietduocs")]
    public class BietDuocController : ApiController
    {
        BietDuoc bietDuocs = new BietDuoc();

        [HttpGet]
        public IEnumerable<BietDuoc> Get()
        {
            return bietDuocs.GetBietDuocs();
        }

        [HttpGet]
        [Route("api/bietduocs/{id}")]
        public IHttpActionResult Get(string id)
        {
            var bietDuoc = bietDuocs.GetBietDuoc(new ObjectId(id));
            if (bietDuoc == null)
            {
                return NotFound();
            }
            return Ok(bietDuoc);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]BietDuoc p)
        {
            bietDuocs.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/bietduocs/{id}")]
        public IHttpActionResult Put(string id, [FromBody]BietDuoc p)
        {
            var recId = new ObjectId(id);
            var bietduoc = bietDuocs.GetBietDuoc(recId);
            if (bietduoc == null)
            {
                return NotFound();
            }

            bietDuocs.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/bietduocs/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = bietDuocs.GetBietDuoc(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            bietDuocs.Remove(product.Id);
            return Ok();
        }
    }
}
