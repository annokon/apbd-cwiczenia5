using APBD.Database;
using APBD.Models;

namespace APBD.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () =>
        {
            // 200 - Ok
            // 400 - Bad Request
            // 401 - Unauthorized
            // 403 - Forbidden
            // 404 - Not found
            // 500 - Internal Server Error

            var animals = StaticData.animals;
            
            return Results.Ok(animals);
        });

        app.MapGet("/animals/{id}", (int id) =>
        {
            return Results.Ok(id);
        });

        app.MapPost("/animals", (Animal animal) =>
        {
            // 201 - Created
            return Results.Created("", animal);
        });
    }
}