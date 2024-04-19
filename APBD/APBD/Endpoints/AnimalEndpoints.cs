using APBD.Database;
using APBD.Models;
using APBD.Services;

namespace APBD.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        AnimalService animalService = new AnimalService();
        
        app.MapGet("/animals", () =>
        {
            var animals = animalService.GetAllAnimals();
            return Results.Ok(animals);
        });

        app.MapGet("/animals/{id}", (int id) =>
        {
            var animal = animalService.GetAnimalById(id);
            if (animal == null)
                return Results.NotFound();

            return Results.Ok(animal);
        });

        app.MapPost("/animals", (Animal animal) =>
        {
            var addedAnimal = animalService.AddAnimal(animal);
            return Results.Created($"/animals/{addedAnimal.Id}", addedAnimal);
        });

        app.MapPut("/animals/{id}", (int id, Animal animal) =>
        {
            if (id != animal.Id)
                return Results.BadRequest();

            animalService.UpdateAnimal(animal);
            return Results.NoContent();
        });

        app.MapDelete("/animals/{id}", (int id) =>
        {
            animalService.DeleteAnimal(id);
            return Results.NoContent();
        });
    }
}