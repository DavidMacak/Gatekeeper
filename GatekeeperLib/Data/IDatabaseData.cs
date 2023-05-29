using GatekeeperLib.Models;

namespace GatekeeperLib.Data
{
    public interface IDatabaseData
    {
        void CreatePerson(string firstName, string lastName);
        void CreatePersonEntry(int personId, DateTime entryTime);
        void CreateVehicle();
        void CreateVehicleEntry();
        List<PersonModel> FindPersons(string lastName);
        List<PersonEntriesFullModel> LoadPersonEntries(int entriesCount = 50);
        List<PersonModel> LoadPersons(int personsCount = 50);
        List<VehicleEntries> LoadVehicleEntries();
        void UpdatePersonExit(int entryId, DateTime exitTime);
        void UpdateVehicleExit();
    }
}