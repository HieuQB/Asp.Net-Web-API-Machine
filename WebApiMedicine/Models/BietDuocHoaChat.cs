using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class BietDuocHoaChat : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("id")]
        public int id { get; set; }
        [BsonElement("ham_luong")]
        public string ham_luong { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }
        [BsonElement("hoatchat")]
        public string hoatchat { get; set; }
        [BsonElement("duoclieu")]
        public string duoclieu { get; set; }
        [BsonElement("hoatchat_name")]
        public string hoatchat_name { get; set; }

        public IEnumerable<BietDuocHoaChat> GetBietDuocHoaChats()
        {
            return _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").FindAll();
        }

        public BietDuocHoaChat GetBietDuocHoaChat(ObjectId id)
        {
            var res = Query<BietDuocHoaChat>.EQ(p => p.Id, id);
            return _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").FindOne(res);
        }

        public IEnumerable<BietDuocHoaChat> GetBietDuocHoaChatTheoTen(String name)
        {
            var res = Query<BietDuocHoaChat>.Where(p => p.hoatchat_name.Contains(name));
            return _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").Find(res); 
        }

        public BietDuocHoaChat Create(BietDuocHoaChat p)
        {
            _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").Save(p);
            return p;
        }

        public void Update(ObjectId id, BietDuocHoaChat p)
        {
            p.Id = id;
            var res = Query<BietDuocHoaChat>.EQ(pd => pd.Id, id);
            var operation = Update<BietDuocHoaChat>.Replace(p);
            _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<BietDuocHoaChat>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<BietDuocHoaChat>("bietduochoatchats").Remove(res);
        }
    }
}