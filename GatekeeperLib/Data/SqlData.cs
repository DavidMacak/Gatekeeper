using GatekeeperLib.Databases;
using GatekeeperLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatekeeperLib.Data
{
    /// <summary>
    /// Aplikace volá tyto metody. Ty obsahují vyplněné parametry a
    /// dále volají metody z SqlDataAccess
    /// </summary>
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }


        public List<PersonModel> LoadPersons(int personsCount = 50)
        {
            List<PersonModel> persons = _db.LoadData<PersonModel, dynamic>("dbo.spPersons_LimitedLoad", new { personsCount }, connectionStringName, true);
            return persons;
        }
        public List<PersonEntriesFullModel> LoadPersonEntries(int entriesCount = 50)
        {
            List<PersonEntriesFullModel> personEntries = _db.LoadData<PersonEntriesFullModel, dynamic>("dbo.spPersonEntries_LimitedLoad",
                                                                                                       new { entriesCount },
                                                                                                       connectionStringName,
                                                                                                       true);
            return personEntries;
        }
        public void CreatePerson(string firstName, string lastName)
        {
            _db.SaveData("dbo.spPersons_Create", new { firstName, lastName }, connectionStringName, true);
        }
        public void EditPerson(int id, string firstName, string lastName)
        {
            _db.SaveData("dbo.spPersons_Edit", new { id, firstName, lastName }, connectionStringName, true);
        }
        public List<PersonModel> FindPersons(string lastName)
        {
            List<PersonModel> rows = _db.LoadData<PersonModel, dynamic>("dbo.spPersons_FindByLastName", new { lastName }, connectionStringName, true);
            return rows;
        }
        public void CreatePersonEntry(int personId, DateTime entryTime)
        {
            _db.SaveData("dbo.spPersonEntries_Create", new { personId, entryTime }, connectionStringName, true);
        }
        public void UpdatePersonExitTime(int entryId, DateTime exitTime)
        {
            _db.SaveData("dbo.spPersonEntries_UpdateExitTime", new { entryId, exitTime }, connectionStringName, true);
        }


        public List<VehicleModel> LoadVehicles(int vehicleCount = 50)
        {
            List<VehicleModel> vehicles = _db.LoadData<VehicleModel, dynamic>("dbo.spVehicles_LimitedLoad", new { vehicleCount }, connectionStringName, true);
            return vehicles;
        }
        public List<VehicleEntriesFullModel> LoadVehicleEntries(int vehicleCount = 50)
        {
            List<VehicleEntriesFullModel> vehicleEntries = _db.LoadData<VehicleEntriesFullModel, dynamic>("dbo.spVehicleEntries_LimitedLoad", new { vehicleCount }, connectionStringName, true);
            return vehicleEntries;
        }
        public void CreateVehicle(string licensePlate)
        {
            _db.SaveData("dbo.spVehicles_Create", new { licensePlate }, connectionStringName, true);
        }
        public void EditVehicle(int vehicleId, string licensePlate)
        {
            _db.SaveData("dbo.spVehicles_Edit", new { vehicleId, licensePlate }, connectionStringName, true);
        }
        public List<VehicleModel> FindVehicle(string licensePlate)
        {
            List<VehicleModel> vehicles = _db.LoadData<VehicleModel, dynamic>("dbo.spVehicles_FindByLicensePlate", new {licensePlate}, connectionStringName, true);
            return vehicles;
        }
        public void CreateVehicleEntry(int vehicleId, int personId, DateTime entryTime)
        {
            _db.SaveData("dbo.spVehicleEntries_Create", new { vehicleId, personId, entryTime }, connectionStringName, true);
        }
        public void UpdateVehicleExit(int entryId, DateTime exitTime)
        {
            _db.SaveData("dbo.spVehicleEntries_UpdateExitTime", new { entryId, exitTime }, connectionStringName, true);
        }
        public void EditVehicleEntry(int entryId, int personId, int vehicleId, DateTime entryTime, DateTime exitTime)
        {
            _db.SaveData("dbo.spVehicleEntries_EditEntry", new {entryId, personId, vehicleId, entryTime, exitTime}, connectionStringName, true);
        }

    }
}
