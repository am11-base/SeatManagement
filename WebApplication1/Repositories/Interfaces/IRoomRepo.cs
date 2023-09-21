namespace WebApplication1.Repositories.Interfaces
{
    public interface IRoomRepo
    {
        string? getLastAllocatedRoom(int facility);
        int getRoomId(string name, int facilityId);
    }
}
