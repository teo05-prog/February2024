using WebApi.Entities;

namespace WebApi.Services;

public interface IStorageService
{
    StorageRoom CreateStorageRoom(StorageRoom storageRoom);
    void AddBoxToStorageRoom(int storageRoomId, Box box);
    List<Box> GetBoxesFromStorageRoom(int storageRoomId);
    void RemoveBoxFromStorageRoom(int storageRoomId, int boxId);
    List<StorageRoom> GetStorageRooms(double? minVolume = null, int? maxBoxCount = null);
}