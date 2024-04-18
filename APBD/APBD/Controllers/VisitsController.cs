using APBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private static List<Visit> _visits = new List<Visit>();

    [HttpGet("{animalId}")]
    public IActionResult GetVisitsByAnimalId(int animalId)
    {
        var visits = _visits.Where(v => v.Animal.Id == animalId).ToList();
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        visit.Id = _visits.Count + 1;
        _visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimalId), new { animalId = visit.Animal.Id }, visit);
    }
}