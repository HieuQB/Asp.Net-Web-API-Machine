using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class BietDuoc : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("id")]
        public int id { get; set; }
        [BsonElement("media_type")]
        public int media_type { get; set; }
        [BsonElement("url")]
        public string url { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        [BsonElement("description")]
        public object description { get; set; }
        [BsonElement("params")]
        public object @params { get; set; }
        [BsonElement("source")]
        public object source { get; set; }
        [BsonElement("owner")]
        public int owner { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }

        public IEnumerable<BietDuoc> GetBietDuocs()
        {
            return _db.GetCollection<BietDuoc>("bietduocs").FindAll();
        }

        public BietDuoc GetBietDuoc(ObjectId id)
        {
            var res = Query<BietDuoc>.EQ(p => p.Id, id);
            return _db.GetCollection<BietDuoc>("bietduocs").FindOne(res);
        }

        public BietDuoc Create(BietDuoc p)
        {
            _db.GetCollection<BietDuoc>("bietduocs").Save(p);
            return p;
        }

        public void Update(ObjectId id, BietDuoc p)
        {
            p.Id = id;
            var res = Query<BietDuoc>.EQ(pd => pd.Id, id);
            var operation = Update<BietDuoc>.Replace(p);
            _db.GetCollection<BietDuoc>("bietduocs").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<BietDuoc>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<BietDuoc>("bietduocs").Remove(res);
        }
    }
}