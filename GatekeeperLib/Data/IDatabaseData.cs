using GatekeeperLib.Models;

namespace GatekeeperLib.Data
{
    public interface IDatabaseData
    {
        void CreatePerson(string firstName, string lastName);
        void CreatePersonEntry(int personId, DateTime entryTime);
        void CreateVehicle(string licensePlate);
        void CreateVehicleEntry(int vehicleId, int personId, DateTime entryTime);
        void EditPerson(int id, string firstName, string lastName);
        void EditVehicle(int vehicleId, string licensePlate);
        List<PersonModel> FindPersons(string lastName);
        List<PersonEntriesFullModel> LoadPersonEntries(int entriesCount = 50);
        List<PersonModel> LoadPersons(int personsCount = 50);
        List<VehicleEntriesFullModel> LoadVehicleEntries(int vehicleCount = 50);
        List<VehicleModel> LoadVehicles(int vehicleCount = 50);
        void UpdatePersonExitTime(int entryId, DateTime exitTime);
        void UpdateVehicleExit(int entryId, DateTime exitTime);
    }
}