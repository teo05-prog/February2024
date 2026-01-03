using WebApi.Entities;

namespace WebApi.Services;

public class StorageService : IStorageService
{
    private List<StorageRoom> storageRooms;
    private int nextStorageRoomId = 1;
    private int nextBoxId = 4;
    
    public StorageService()
    {
        storageRooms = new List<StorageRoom>();
        SeedDummyData();
    }
    
    private void SeedDummyData()
    {
        var storageRoom1 = new StorageRoom
        {
            Id = nextStorageRoomId++,
            Location = "Warehouse A",
            Dimensions = new Dimensions { Length = 10, Width = 8, Height = 6 },
            Boxes = new List<Box>
            {
                new Box { Id = 1, Label = "Box 1", Dimensions = new Dimensions { Length = 2, Width = 2, Height = 2 } },
                new Box { Id = 2, Label = "Box 2", Dimensions = new Dimensions { Length = 3, Width = 3, Height = 3 } }
            }
        };
        
        var storageRoom2 = new StorageRoom
        {
            Id = nextStorageRoomId++,
            Location = "Warehouse B",
            Dimensions = new Dimensions { Length = 12, Width = 10, Height = 8 },
            Boxes = new List<Box>
            {
                new Box { Id = 3, Label = "Box 3", Dimensions = new Dimensions { Length = 4, Width = 4, Height = 4 } }
            }
        };
        
        var storageRoom3 = new StorageRoom
        {
            Id = nextStorageRoomId++,
            Location = "Warehouse C",
            Dimensions = new Dimensions { Length = 8, Width = 6, Height = 5 },
            Boxes = new List<Box>()
        };

        var storageRoom4 = new StorageRoom
        {
            Id = nextStorageRoomId++,
            Location = "Warehouse D",
            Dimensions = new Dimensions { Length = 15, Width = 12, Height = 10 },
            Boxes = new List<Box>()
        };

        var storageRoom5 = new StorageRoom
        {
            Id = nextStorageRoomId++,
            Location = "Warehouse E",
            Dimensions = new Dimensions { Length = 20, Width = 15, Height = 12 },
            Boxes = new List<Box>()
        };

        storageRooms.Add(storageRoom1);
        storageRooms.Add(storageRoom2);
        storageRooms.Add(storageRoom3);
        storageRooms.Add(storageRoom4);
        storageRooms.Add(storageRoom5);
    }
    
    public StorageRoom CreateStorageRoom(StorageRoom storageRoom)
    {
        if (storageRoom == null)
        {
            throw new ArgumentNullException(nameof(storageRoom));
        }
        storageRoom.Id = nextStorageRoomId++;
        storageRoom.Boxes ??= new List<Box>();
        
        storageRooms.Add(storageRoom);
        
        return storageRoom;
    }

    public void AddBoxToStorageRoom(int storageRoomId, Box box)
    {
        var room = storageRooms.FirstOrDefault(r => r.Id == storageRoomId);
        if (room == null)
        {
            throw new KeyNotFoundException($"Storage room with id {storageRoomId} not found.");
        }

        if (box == null)
        {
            throw new ArgumentNullException(nameof(box));
        }

        box.Id = nextBoxId++;
        room.Boxes.Add(box);
    }

    public List<Box> GetBoxesFromStorageRoom(int storageRoomId)
    {
        var room = storageRooms.FirstOrDefault(r => r.Id == storageRoomId);
        if (room == null)
        {
            throw new KeyNotFoundException($"Storage room with id {storageRoomId} not found.");
        }

        return room.Boxes;
    }

    public void RemoveBoxFromStorageRoom(int storageRoomId, int boxId)
    {
        var room = storageRooms.FirstOrDefault(r => r.Id == storageRoomId);
        if (room == null)
        {
            throw new KeyNotFoundException($"Storage room with id {storageRoomId} not found.");
        }

        var box = room.Boxes.FirstOrDefault(b => b.Id == boxId);
        if (box == null)
        {
            throw new KeyNotFoundException($"Box with id {boxId} not found in storage room {storageRoomId}.");
        }

        room.Boxes.Remove(box);
    }

    public List<StorageRoom> GetStorageRooms(double? minVolume = null, int? maxBoxCount = null)
    {
        var result = storageRooms.AsEnumerable();

        if (minVolume.HasValue)
        {
            result = result.Where(r => r.Dimensions.Length * r.Dimensions.Width * r.Dimensions.Height > minVolume.Value);
        }

        if (maxBoxCount.HasValue)
        {
            result = result.Where(r => r.Boxes.Count < maxBoxCount.Value);
        }

        return result.ToList();
    }
}