using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApiMedicine.Models
{
    public class DataAccess
    {
        protected MongoClient _client;
        protected MongoServer _server;
        protected MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://HoangKimTuan:12345678@ds215380.mlab.com:15380/medicine");
            //_client = new MongoClient("mongodb://localhost:27017/medicine");
            _server = _client.GetServer();
            _db = _server.GetDatabase("medicine");
        }
    }
}