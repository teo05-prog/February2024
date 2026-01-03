using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageRoomsController : ControllerBase
{
    private readonly IStorageService storageService;

    public StorageRoomsController(IStorageService storageService)
    {
        this.storageService = storageService;
    }

    [HttpPost]
    public ActionResult<StorageRoom> CreateStorageRoom([FromBody] StorageRoom storageRoom)
    {
        try
        {
            var createdStorageRoom = storageService.CreateStorageRoom(storageRoom);
            return CreatedAtAction(nameof(GetStorageRoom), new { id = createdStorageRoom.Id }, createdStorageRoom);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<StorageRoom> GetStorageRoom(int id)
    {
        var storageRooms = storageService.GetStorageRooms();
        var storageRoom = storageRooms.FirstOrDefault(sr => sr.Id == id);

        if (storageRoom == null)
        {
            return NotFound(new { error = $"Storage room with id {id} not found." });
        }
        return Ok(storageRoom);
    }

    [HttpGet]
    public ActionResult<List<StorageRoom>> GetStorageRooms([FromQuery] double? minVolume = null, [FromQuery] int? maxBoxCount = null)
    {
        try
        {
            var storageRooms = storageService.GetStorageRooms(minVolume, maxBoxCount);
            return Ok(storageRooms);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{storageRoomId}/boxes")]
    public ActionResult<List<Box>> GetBoxesFromStorageRoom(int storageRoomId)
    {
        try
        {
            var boxes = storageService.GetBoxesFromStorageRoom(storageRoomId);
            return Ok(boxes);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpPost("{storageRoomId}/boxes")]
    public IActionResult AddBoxToStorageRoom(int storageRoomId, [FromBody] Box box)
    {
        try
        {
            storageService.AddBoxToStorageRoom(storageRoomId, box);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpDelete("{storageRoomId}/boxes/{boxId}")]
    public IActionResult RemoveBoxFromStorageRoom(int storageRoomId, int boxId)
    {
        try
        {
            storageService.RemoveBoxFromStorageRoom(storageRoomId, boxId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}
