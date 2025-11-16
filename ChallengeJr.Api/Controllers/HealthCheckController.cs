using Microsoft.AspNetCore.Mvc;

namespace ChallengeJr.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new 
        { 
            Status = "Healthy", 
            Message = "API is running successfully!",
            Timestamp = DateTime.UtcNow
        });
    }
}
