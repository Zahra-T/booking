using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Booking.Extensions;
using Booking.Resources;

namespace Booking
{
    public class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);
            
            return new BadRequestObjectResult(response);
        }
    }
}