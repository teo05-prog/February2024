using Blazor.Entity;

namespace Blazor.Services;

public interface IKennelService
{
    Task<Dog> AddDogAsync(Dog dog);
    Task<Dog?> GetDogByIdAsync(int id);
    Task<IEnumerable<Dog>> GetAllDogsAsync();
    Task UpdateDogAsync(int id, Dog dog);
    Task DeleteDogAsync(int id);
}