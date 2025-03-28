using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var anonUsername = Context.GetHttpContext()?.Request.Query["anonUsername"];
            var isAdmin = Context.GetHttpContext()?.Request.Query["admin"].ToString();
            //admin ise admins diye gruba eklenip bağlantı kuruluyor
            if (isAdmin == "true")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Admins");
                Console.WriteLine($"Admin bağlandı: {Context.ConnectionId}");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Users");
                Console.WriteLine($"Kullanıcı bağlandı: {anonUsername} - {Context.ConnectionId}");
            }

            await Clients.Caller.SendAsync("Connected", Context.ConnectionId, anonUsername ?? "Anonim");
            await base.OnConnectedAsync();
        }
        //admine mesaj gönderme ReceiveMessage adlı kanal üzerinden
        public async Task SendMessageToAdmin(string message)
        {
            var username = Context.GetHttpContext()?.Request.Query["anonUsername"];
            await Clients.Group("Admins").SendAsync("ReceiveMessage", username ?? "Anonim", message);
        }
        //kullanıcıya mesaj gönderme
        public async Task SendMessageFromAdmin(string message)
        {
            await Clients.Group("Users").SendAsync("ReceiveMessage", "Admin", message);
            await Clients.Caller.SendAsync("ReceiveMessage", "Admin", message);
        }
    }
}
