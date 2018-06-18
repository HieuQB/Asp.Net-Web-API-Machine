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
    [Route("api/bietduochoatchats")]
    public class BietDuocHoaChatController : ApiController
    {
        BietDuocHoaChat bietDuocHoaChats = new BietDuocHoaChat();

        [HttpGet]
        public IEnumerable<BietDuocHoaChat> Get()
        {
            return bietDuocHoaChats.GetBietDuocHoaChats();
        }

        [HttpGet]
        [Route("api/bietduochoatchats/{id}")]
        public IHttpActionResult Get(string id)
        {
            var bietDuoc = bietDuocHoaChats.GetBietDuocHoaChat(new ObjectId(id));
            if (bietDuoc == null)
            {
                return NotFound();
            }
            return Ok(bietDuoc);
        }

        [HttpGet]
        [Route("api/bietduochoatchats/ten/{name}")]
        public IEnumerable<BietDuocHoaChat> GetWithName(string name)
        {
            return bietDuocHoaChats.GetBietDuocHoaChatTheoTen(name);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]BietDuocHoaChat p)
        {
            bietDuocHoaChats.Create(p);
            return Ok(p);
        }

        [HttpPut]
        [Route("api/bietduochoatchats/{id}")]
        public IHttpActionResult Put(string id, [FromBody]BietDuocHoaChat p)
        {
            var recId = new ObjectId(id);
            var bietduoc = bietDuocHoaChats.GetBietDuocHoaChat(recId);
            if (bietduoc == null)
            {
                return NotFound();
            }

            bietDuocHoaChats.Update(recId, p);
            return Ok();
        }

        [HttpDelete]
        [Route("api/bietduochoatchats/{id}")]
        public IHttpActionResult Delete(string id)
        {
            var product = bietDuocHoaChats.GetBietDuocHoaChat(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }

            bietDuocHoaChats.Remove(product.Id);
            return Ok();
        }
    }
}
