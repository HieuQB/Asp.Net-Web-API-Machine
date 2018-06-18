using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class DuongDung : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        [BsonElement("title_en")]
        public string title_en { get; set; }
        [BsonElement("bietduoc_cnt")]
        public int bietduoc_cnt { get; set; }

        public IEnumerable<DuongDung> Get()
        {
            return _db.GetCollection<DuongDung>("duongdungs").FindAll();
        }

        public DuongDung Get(ObjectId id)
        {
            var res = Query<DuongDung>.EQ(p => p.Id, id);
            return _db.GetCollection<DuongDung>("duongdungs").FindOne(res);
        }

        public IEnumerable<DuongDung> GetDuongDungTheoTen(String name)
        {
            var res = Query<DuongDung>.Where(p => p.title.Contains(name));
            return _db.GetCollection<DuongDung>("duongdungs").Find(res);
        }

        public DuongDung Create(DuongDung p)
        {
            _db.GetCollection<DuongDung>("duongdungs").Save(p);
            return p;
        }

        public void Update(ObjectId id, DuongDung p)
        {
            p.Id = id;
            var res = Query<DuongDung>.EQ(pd => pd.Id, id);
            var operation = Update<DuongDung>.Replace(p);
            _db.GetCollection<DuongDung>("duongdungs").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<DuongDung>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<DuongDung>("duongdungs").Remove(res);
        }
    }
}