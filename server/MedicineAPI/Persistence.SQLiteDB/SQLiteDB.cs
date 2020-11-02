using MedicineAPI.Persistence;
using MedicineModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.SQLiteDB
{
    public class SQLiteDB : IPersistence
    {
        private List<Medicine> _medicines;
        private readonly SqliteConnectionStringBuilder _sqliteConnectionStringBuilder;
        public SQLiteDB()
        {
            _medicines = new List<Medicine>();
            //_sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder();
            //_sqliteConnectionStringBuilder.DataSource = "./SqliteDB.db";
            //_sqliteConnectionStringBuilder.Cache = SqliteCacheMode.Shared;
            //for in-memory
            //_sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder();
            //_sqliteConnectionStringBuilder.DataSource = "Sharable";
            //_sqliteConnectionStringBuilder.Mode = SqliteOpenMode.Memory;
            //_sqliteConnectionStringBuilder.Cache = SqliteCacheMode.Shared;
        }

        public void Add(MedicineModel.Medicine medicine)
        {
            _medicines.Add(medicine);
            //using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            //{
            //    conn.Open();

            //    //create MEDICINES table
            //    var createTableCmd = conn.CreateCommand();
            //    createTableCmd.CommandText =
            //        "Create Table IF NOT EXISTS MEDICINES(Id TEXT PRIMARY KEY , " +
            //        "Name TEXT NOT NULL, " +
            //        "Price REAL NOT NULL, " +
            //        "Quantity INTEGER NOT NULL, " +
            //        "Expiry TEXT NOT NULL, " +
            //        "Notes TEXT NOT NULL)";
            //    createTableCmd.ExecuteNonQuery();

            //    //insert into MEDICINES table
            //    var insertCmd = conn.CreateCommand();
            //    insertCmd.CommandText = $"INSERT INTO MEDICINES(Id, Name, Price, Quantity, Expiry, Notes) " +
            //        $"VALUES('{medicine.Id}', '{medicine.Name}', '{medicine.Price}', '{medicine.Quantity}', '{medicine.Expiry}', '{medicine.Notes}')";
            //    insertCmd.ExecuteNonQuery();
            //}
        }

        public MedicineModel.Medicine Get(Guid id)
        {
            return _medicines.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MedicineModel.Medicine> GetAll()
        {
            return _medicines;
        }

        public IEnumerable<MedicineModel.Medicine> Search(string name)
        {
            return _medicines.FindAll(x => x.Name.Contains(name));
        }

        public void Update(MedicineModel.Medicine medicine)
        {
            var med = _medicines.FirstOrDefault(x => x.Id == medicine.Id);
            med = medicine;
        }
    }
}
