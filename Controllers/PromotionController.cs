using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_example.Controllers
{
    [Authorize()]
    [Route("promotion")]
    public class PromotionController : ControllerBase
    {
        [HttpGet("new")]
        public IActionResult GetAction()
        {
            foreach (var claim in HttpContext.User.Claims)
            {
                Console.WriteLine("Claim Type: {0}:\nClaim Value:{1}\n", claim.Type, claim.Value);
            }
            var promotionCode = Guid.NewGuid();
            return new ObjectResult($"Your promotion code is {promotionCode}");
        }

    }
}