using APBD.Models;
using APBD.Services;

namespace APBD.Endpoints;

public static class VisitEndpoints
{
    public static void MapVisitEndpoints(this WebApplication app)
    {
        VisitService visitService = new VisitService();
        
        app.MapGet("/visits/{animalId}", (int animalId) =>
        {
            var visits = visitService.GetVisitsByAnimalId(animalId);
            return Results.Ok(visits);
        });

        app.MapPost("/visits", (Visit visit) =>
        {
            var addedVisit = visitService.AddVisit(visit);
            return Results.Created($"/visits/{addedVisit.Id}", addedVisit);
        });
    }
}