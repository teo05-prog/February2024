using Blazor.Entity;

namespace Blazor.Services;

public class KennelService : IKennelService
{
    private List<Dog> dogs;
    
    public KennelService()
    {
        dogs = new()
        {
            new Dog
            {
                Id = 1,
                Name = "Buddy",
                Sex = 'M',
                Breed = "Golden Retriever",
                ImageUrl = "https://heronscrossing.vet/wp-content/uploads/Golden-Retriever-1024x683.jpg",
                Description = "A friendly and energetic dog.",
                ArrivalDate = new DateTime(2023, 1, 15)
            },
            new Dog
            {
                Id = 2,
                Name = "Lucy",
                Sex = 'F',
                Breed = "Labrador Retriever",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqZhJ983ynxhEqv8XjyjMV9vTJcMo66blHfQ&s",
                Description = "Loves to play fetch and swim.",
                ArrivalDate = new DateTime(2023, 2, 10)
            },
            new Dog
            {
                Id = 3,
                Name = "Max",
                Sex = 'M',
                Breed = "German Shepherd",
                ImageUrl = "https://www.bellaandduke.com/wp-content/uploads/2024/10/A-guide-to-German-Shepherds-characteristics-personality-lifespan-and-more-featured-image.webp",
                Description = "A loyal and protective companion.",
                ArrivalDate = new DateTime(2023, 3, 5)
            },
            new Dog
            {
                Id = 4,
                Name = "Daisy",
                Sex = 'F',
                Breed = "Beagle",
                ImageUrl = "https://content.lyka.com.au/f/1016262/1104x676/e36872ce32/beagle.png/m/640x427/smart/filters:format(webp)",
                Description = "Curious and friendly with a great sense of smell.",
                ArrivalDate = new DateTime(2023, 4, 20)
            },
            new Dog
            {
                Id = 5,
                Name = "Charlie",
                Sex = 'M',
                Breed = "Bulldog",
                ImageUrl = "https://breed-assets.wisdompanel.com/dog/bulldog-standard/Bulldog2.png",
                Description = "Calm and courageous with a lovable personality.",
                ArrivalDate = new DateTime(2023, 5, 18)
            }
        };
    }
    
    public async Task<Dog> AddDogAsync(Dog dog)
    {
        dog.Id = dogs.Any() ? dogs.Max(x => x.Id) + 1 : 1;
        dogs.Add(dog);
        return await Task.FromResult(dog);
    }

    public async Task<Dog?> GetDogByIdAsync(int id)
    {
        var dog = dogs.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(dog);
    }

    public async Task<IEnumerable<Dog>> GetAllDogsAsync()
    {
        return await Task.FromResult(dogs.AsEnumerable());
    }

    public async Task UpdateDogAsync(int id, Dog dog)
    {
        var existingDog = dogs.FirstOrDefault(x => x.Id == id);
        if (existingDog != null)
        {
            var index = dogs.IndexOf(existingDog);
            dogs[index] = dog;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteDogAsync(int id)
    {
        var dog = dogs.FirstOrDefault(x => x.Id == id);
        if (dog != null)
        {
            dogs.Remove(dog);
        }
        await Task.CompletedTask;
    }
}