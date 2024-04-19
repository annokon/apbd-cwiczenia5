using APBD.Models;

namespace APBD.Services;

public class AnimalService
{
    private readonly List<Animal> _animals = new List<Animal>();
    private int _nextAnimalId = 1;

    public IEnumerable<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public Animal GetAnimalById(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id);
    }

    public Animal AddAnimal(Animal animal)
    {
        animal.Id = _nextAnimalId++;
        _animals.Add(animal);
        return animal;
    }

    public void UpdateAnimal(Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == animal.Id);
        if (existingAnimal != null)
        {
            existingAnimal.Name = animal.Name;
            existingAnimal.Category = animal.Category;
            existingAnimal.Weight = animal.Weight;
            existingAnimal.FurColor = animal.FurColor;
        }
    }

    public void DeleteAnimal(int id)
    {
        var animalToRemove = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToRemove != null)
        {
            _animals.Remove(animalToRemove);
        }
    }
}