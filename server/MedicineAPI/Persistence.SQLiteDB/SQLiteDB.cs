using MedicineAPI.Persistence;
using MedicineModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Persistence.SQLiteDB
{
    public class SQLiteDB : IPersistence
    {
        private readonly SqliteConnectionStringBuilder _sqliteConnectionStringBuilder;
        public SQLiteDB()
        {
            _sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder();
            _sqliteConnectionStringBuilder.DataSource = "./SqliteDB.db";
            _sqliteConnectionStringBuilder.Cache = SqliteCacheMode.Shared;            
        }

        public void Add(MedicineModel.Medicine medicine)
        {
            using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            {
                conn.Open();

                //create MEDICINES table
                var createTableCmd = conn.CreateCommand();
                createTableCmd.CommandText =
                    "Create Table IF NOT EXISTS MEDICINES(" +
                    "Id TEXT PRIMARY KEY , " +
                    "Name TEXT NOT NULL, " +
                    "Brand TEXT NOT NULL, " +
                    "Price REAL NOT NULL, " +
                    "Quantity INTEGER NOT NULL, " +
                    "Expiry TEXT NOT NULL, " +
                    "Notes TEXT NOT NULL)";
                createTableCmd.ExecuteNonQuery();

                //insert into MEDICINES table
                var insertCmd = conn.CreateCommand();
                insertCmd.CommandText = $"INSERT INTO MEDICINES(Id, Name, Brand, Price, Quantity, Expiry, Notes) " +
                    $"VALUES('{medicine.Id}', '{medicine.Name}', '{medicine.Brand}', '{medicine.Price}', '{medicine.Quantity}', '{medicine.Expiry}', '{medicine.Notes}')";
                insertCmd.ExecuteNonQuery();
            }
        }

        public MedicineModel.Medicine Get(Guid id)
        {
            Medicine medicine = null;
            using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            {
                conn.Open();

                var fetchDataCmd = conn.CreateCommand();
                fetchDataCmd.CommandText = $"SELECT Id, Name, Brand, Price, Quantity, Expiry, Notes FROM MEDICINES " +
                    $"WHERE Id = '{id}'";

                using (var reader = fetchDataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicine = new Medicine
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            Brand = reader.GetString(2),
                            Price = float.Parse(reader.GetString(3)),
                            Quantity = int.Parse(reader.GetString(4)),
                            Expiry = DateTime.Parse(reader.GetString(5)),
                            Notes = reader.GetString(6)
                        };
                    }
                }
            }
            return medicine;
        }

        public IEnumerable<MedicineModel.Medicine> GetAll()
        {
            List<Medicine> medicines = new List<Medicine>();
            using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                var fetchDataCmd = conn.CreateCommand();
                fetchDataCmd.CommandText = $"SELECT Id, Name, Brand, Price, Quantity, Expiry, Notes FROM MEDICINES ";

                using (var reader = fetchDataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medicine = new Medicine
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            Brand = reader.GetString(2),
                            Price = float.Parse(reader.GetString(3)),
                            Quantity = int.Parse(reader.GetString(4)),
                            Expiry = DateTime.Parse(reader.GetString(5)),
                            Notes = reader.GetString(6)
                        };
                        medicines.Add(medicine);
                    }
                }
            }
            return medicines;
        }

        public IEnumerable<MedicineModel.Medicine> Search(string name)
        {
            List<Medicine> medicines = new List<Medicine>();
            using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            {
                conn.Open();
                var fetchDataCmd = conn.CreateCommand();
                fetchDataCmd.CommandText = $"SELECT Id, Name, Brand, Price, Quantity, Expiry, Notes FROM MEDICINES " +
                    $"WHERE Name LIKE '%{name}%'";

                using (var reader = fetchDataCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medicine = new Medicine
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            Brand = reader.GetString(2),
                            Price = float.Parse(reader.GetString(3)),
                            Quantity = int.Parse(reader.GetString(4)),
                            Expiry = DateTime.Parse(reader.GetString(5)),
                            Notes = reader.GetString(6)
                        };
                        medicines.Add(medicine);
                    }
                }
            }
            return medicines;
        }

        public void Update(MedicineModel.Medicine medicine)
        {
            using (var conn = new SqliteConnection(_sqliteConnectionStringBuilder.ConnectionString))
            {
                conn.Open();

                //update into MEDICINES table
                var updateCmd = conn.CreateCommand();
                updateCmd.CommandText = $"UPDATE MEDICINES SET Id='{medicine.Id}', " +
                    $"Name ='{medicine.Name}' , " +
                    $"Brand ='{medicine.Brand}' , " +
                    $"Price = '{medicine.Price}', " +
                    $"Quantity= '{medicine.Quantity}', " +
                    $"Expiry= , '{medicine.Expiry}'" +
                    $"Notes= '{medicine.Notes}'" +
                    $" WHERE Id = '{medicine.Id}'";
                updateCmd.ExecuteNonQuery();
            }
        }
    }
}
