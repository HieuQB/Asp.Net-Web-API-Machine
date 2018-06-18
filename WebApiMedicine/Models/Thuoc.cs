using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class Thuoc : DataAccess
    {
        public ObjectId Id { get; set; }
        [BsonElement("__v")]
        public int _v { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("bietduochoatchat_set")]
        public ArrayList bietduochoatchat_set { get; set; }
        [BsonElement("bietduocmedia_set")]
        public ArrayList bietduocmedia_set { get; set; }
        [BsonElement("dang_dong_goi")] 
        public ArrayList dang_dong_goi { get; set; }
        [BsonElement("ctysx")]
        public string ctysx { get; set; }
        [BsonElement("cty_dannhan")]
        public string cty_dannhan { get; set; }
        [BsonElement("cty_sohuu")]
        public string cty_sohuu { get; set; }
        [BsonElement("chi_dinh")]
        public string chi_dinh { get; set; }
        [BsonElement("chong_chi_dinh")]
        public string chong_chi_dinh { get; set; }
        [BsonElement("bao_quan")]
        public string bao_quan { get; set; }
        [BsonElement("duong_dung")]
        public string duong_dung { get; set; }
        [BsonElement("expired")]
        public bool expired { get; set; }
        [BsonElement("expired_reason")]
        public string expired_reason { get; set; }
        [BsonElement("cach_dung")]
        public string cach_dung { get; set; }
        [BsonElement("tac_dung_phu")]
        public string tac_dung_phu { get; set; }
        [BsonElement("qua_lieu")]
        public string qua_lieu { get; set; }
        [BsonElement("tu_van_benh_nhan")]
        public string tu_van_benh_nhan { get; set; }
        [BsonElement("luu_y_suy_gan")]
        public string luu_y_suy_gan { get; set; }
        [BsonElement("luu_y_suy_than")]
        public string luu_y_suy_than { get; set; }
        [BsonElement("luu_y_co_thai")]
        public string luu_y_co_thai { get; set; }
        [BsonElement("luu_y_cho_bu")]
        public string luu_y_cho_bu { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        [BsonElement("otc")]
        public bool otc { get; set; }

        public IEnumerable<Thuoc> Get()
        {
            return _db.GetCollection<Thuoc>("thuocs").FindAll();
        }

        public Thuoc Get(ObjectId id)
        {
            var res = Query<Thuoc>.EQ(p => p.Id, id);
            return _db.GetCollection<Thuoc>("thuocs").FindOne(res);
        }

        public IEnumerable<Thuoc> GetThuocTheoTen(String name)
        {
            var res = Query<Thuoc>.Where(p => p.title.Contains(name));
            return _db.GetCollection<Thuoc>("thuocs").Find(res);
        }

        public Thuoc Create(Thuoc p)
        {
            _db.GetCollection<Thuoc>("thuocs").Save(p);
            return p;
        }

        public void Update(ObjectId id, Thuoc p)
        {
            p.Id = id;
            var res = Query<Thuoc>.EQ(pd => pd.Id, id);
            var operation = Update<Thuoc>.Replace(p);
            _db.GetCollection<Thuoc>("thuocs").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<Thuoc>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Thuoc>("thuocs").Remove(res);
        }
    }
}