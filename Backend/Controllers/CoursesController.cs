using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend.Controllers;

public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public CoursesController(ApplicationDbContext db)
    {
        _db = db;
    }
}
