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
    [Route("api/thuocs")]
    public class ThuocController : ApiController
    {
        Thuoc thuocs = new Thuoc();

        [HttpGet]
        public IEnumerable<Thuoc> Get()
        {
            return thuocs.Get();
        }

        [HttpGet]
        [Route("api/thuocs/{id}")]
        public IHttpActionResult Get(string id)
        {
            var Thuoc = thuocs.Get(new ObjectId(id));
            if (Thuoc == null)
            {
                return NotFound();
            }
            return Ok(Thuoc);
        }

        [HttpGet]
        [Route("api/thuocs/ten/{name}")]
        public IEnumerable<Thuoc> GetWithName(string name)
        {
            return thuocs.GetThuocTheoTen(name);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Thuoc p)
        {
            thuocs.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/thuocs/{id}")]
        public IHttpActionResult Put(string id, [FromBody]Thuoc p)
        {
            var recId = new ObjectId(id);
            var Thuoc = thuocs.Get(recId);
            if (Thuoc == null)
            {
                return NotFound();
            }

            thuocs.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/thuocs/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = thuocs.Get(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            thuocs.Remove(product.Id);
            return Ok();
        }
    }
}
