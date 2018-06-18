using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class CongTySoHuu : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }
        [BsonElement(elementName: "id")]
        public string id { get; set; }
        [BsonElement(elementName: "title")]
        public string title { get; set; }
        [BsonElement(elementName: "title_en")]
        public object title_en { get; set; }
        [BsonElement(elementName: "dia_chi")]
        public string dia_chi { get; set; }

        public IEnumerable<CongTySoHuu> Get()
        {
            return _db.GetCollection<CongTySoHuu>("ctysxes").FindAll();
        }

        public CongTySoHuu Get(ObjectId id)
        {
            var res = Query<CongTySoHuu>.EQ(p => p.Id, id);
            return _db.GetCollection<CongTySoHuu>("ctysxes").FindOne(res);
        }

        public IEnumerable<CongTySoHuu> GetCongTySoHuuTheoTen(String name)
        {
            var res = Query<CongTySoHuu>.Where(p => p.title.Contains(name));
            return _db.GetCollection<CongTySoHuu>("ctysxes").Find(res);
        }

        public CongTySoHuu Create(CongTySoHuu p)
        {
            _db.GetCollection<CongTySoHuu>("ctysxes").Save(p);
            return p;
        }

        public void Update(ObjectId id, CongTySoHuu p)
        {
            p.Id = id;
            var res = Query<CongTySoHuu>.EQ(pd => pd.Id, id);
            var operation = Update<CongTySoHuu>.Replace(p);
            _db.GetCollection<CongTySoHuu>("ctysxes").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<CongTySoHuu>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<CongTySoHuu>("ctysxes").Remove(res);
        }
    }
}