using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Application.Notifications.Commands;
using NotificationSystem.Application.Notifications.Handlers;
using System.Reflection.Metadata;

namespace NotificationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController(CreateNotificationHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateNotificationCommand command)
        {
            var id = await handler.Handle(command);
            return CreatedAtAction(nameof(Create), new {id}, new {id});
        }
    }
}
