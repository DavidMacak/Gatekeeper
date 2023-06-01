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

        /// <summary>
        /// Loads x number of persons from DB.
        /// </summary>
        /// <param name="personsCount">How much records we want to load from DB.</param>
        /// <returns></returns>
        public List<PersonModel> LoadPersons(int personsCount = 50)
        {
            List<PersonModel> persons = _db.LoadData<PersonModel, dynamic>("dbo.spPersons_LimitedLoad", new { personsCount }, connectionStringName, true);
            return persons;
        }
        /// <summary>
        /// Loads x number of person entries from DB.
        /// </summary>
        /// <param name="entriesCount">How much records we want to load from DB.</param>
        /// <returns></returns>
        public List<PersonEntriesFullModel> LoadPersonEntries(int entriesCount = 50)
        {
            List<PersonEntriesFullModel> personEntries = _db.LoadData<PersonEntriesFullModel, dynamic>("dbo.spPersonEntries_LimitedLoad",
                                                                                                       new { entriesCount },
                                                                                                       connectionStringName,
                                                                                                       true);
            return personEntries;
        }
        /// <summary>
        /// Creates new person if it does't exist in DB.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void CreatePerson(string firstName, string lastName)
        {
            _db.SaveData("dbo.spPersons_Create", new { firstName, lastName }, connectionStringName, true);
        }
        public void EditPerson(int id, string firstName, string lastName)
        {
            _db.SaveData("dbo.spPersons_Edit", new {id, firstName, lastName }, connectionStringName, true);
        }
        /// <summary>
        /// Finds all persons with same last name.
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public List<PersonModel> FindPersons(string lastName)
        {
            List<PersonModel> rows = _db.LoadData<PersonModel, dynamic>("dbo.spPersons_FindByLastName", new { lastName }, connectionStringName, true);
            return rows;
        }
        /// <summary>
        /// Creates new person entry.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="entryTime"></param>
        public void CreatePersonEntry(int personId, DateTime entryTime)
        {
            _db.SaveData("dbo.spPersonEntries_Create", new { personId, entryTime }, connectionStringName, true);
        }
        /// <summary>
        /// Adds exit time to specified person entry.
        /// </summary>
        /// <param name="entryId"></param>
        /// <param name="exitTime"></param>
        public void UpdatePersonExit(int entryId, DateTime exitTime)
        {
            _db.SaveData("dbo.spPersonEntries_UpdateExitTime", new { entryId, exitTime }, connectionStringName, true);
        }

        public List<VehicleEntriesFullModel> LoadVehicleEntries()
        {
            List<VehicleEntriesFullModel> vehicleEntries = new List<VehicleEntriesFullModel>();
            return vehicleEntries;
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
