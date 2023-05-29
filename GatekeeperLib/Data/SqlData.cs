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
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        // Mělo by být limitováno jen na počet, který dokážeme zobrazit na obrazovce
        public List<PersonModel> LoadPersons()
        {
            List<PersonModel> persons = new List<PersonModel>();
            return persons;
        }

        public List<PersonEntriesFullModel> LoadPersonEntries()
        {
            List<PersonEntriesFullModel> personEntries = new List<PersonEntriesFullModel>();
            return personEntries;
        }

        public List<VehicleEntries> LoadVehicleEntries()
        {
            List<VehicleEntries> vehicleEntries = new List<VehicleEntries>();
            return vehicleEntries;
        }

        public void CreatePerson(string firstName, string lastName)
        {
            _db.SaveData("spPersons_Create", new {firstName, lastName},connectionStringName,true);
        }

        public List<PersonModel> FindPersons(string lastName)
        {
            List<PersonModel> rows = _db.LoadData<PersonModel, dynamic>("spPersons_FindByLastName", new { lastName }, connectionStringName, true);
            return rows;
        }

        public void CreatePersonEntry(int personId, DateTime entryTime)
        {
            _db.SaveData("spPersonEntries_Create", new { personId, entryTime }, connectionStringName, true);
        }

        public void UpdatePersonExit(int entryId, DateTime exitTime)
        {
            _db.SaveData("spPersonEntries_UpdateExitTime", new { entryId, exitTime }, connectionStringName, true);
        }

        public void CreateVehicle()
        {

        }

        public void CreateVehicleEntry()
        {

        }

        public void UpdateVehicleExit()
        {

        }

    }
}
