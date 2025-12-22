using Microsoft.AspNetCore.Mvc;
using Backend.Interfaces;

namespace Backend.Controllers;

[ApiController]
[Route("api")]
public class CourseOfferingsController : ControllerBase
{
    private readonly ICourseOfferingRepository _offeringsRepo;

    public CourseOfferingsController(ICourseOfferingRepository offeringsRepo)
    {
        _offeringsRepo = offeringsRepo;
    }
}
