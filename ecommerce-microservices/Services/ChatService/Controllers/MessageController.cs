using ChatService.dtos;
using ChatService.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatService.Controllers
{   //api ile iletişim kurulmak istenirse çalışacak controller
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send-to-all")]
        public async Task<IActionResult> SendToAll([FromBody] MessageDto message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.User, message.Content);
            return Ok();
        }

        [HttpPost("send-to-admin")]
        public async Task<IActionResult> SendToAdmin([FromBody] MessageDto message)
        {
            await _hubContext.Clients.Group("Admins").SendAsync("ReceiveMessage", message.User, message.Content);
            return Ok();
        }
    }
}
