using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class CongTyDanNhan : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        [BsonElement("title_en")]
        public object title_en { get; set; }
        [BsonElement("dia_chi")]
        public string dia_chi { get; set; }     

        public IEnumerable<CongTyDanNhan> Get()
        {
            return _db.GetCollection<CongTyDanNhan>("cty_dannhans").FindAll();
        }

        public CongTyDanNhan Get(ObjectId id)
        {
            var res = Query<CongTyDanNhan>.EQ(p => p.Id, id);
            return _db.GetCollection<CongTyDanNhan>("cty_dannhans").FindOne(res);
        }

        public IEnumerable<CongTyDanNhan> GetCongTyDanNhanTheoTen(String name)
        {
            var res = Query<CongTyDanNhan>.Where(p => p.title.Contains(name));
            return _db.GetCollection<CongTyDanNhan>("cty_dannhans").Find(res);
        }

        public CongTyDanNhan Create(CongTyDanNhan p)
        {
            _db.GetCollection<CongTyDanNhan>("cty_dannhans").Save(p);
            return p;
        }

        public void Update(ObjectId id, CongTyDanNhan p)
        {
            p.Id = id;
            var res = Query<CongTyDanNhan>.EQ(pd => pd.Id, id);
            var operation = Update<CongTyDanNhan>.Replace(p);
            _db.GetCollection<CongTyDanNhan>("cty_dannhans").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<CongTyDanNhan>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<CongTyDanNhan>("cty_dannhans").Remove(res);
        }
    }
}