using Azure.Messaging.ServiceBus;
using Challenge.Producer.Message;
using Challenge.Producer.Message.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Challenge.Producer.Message.Controllers
{
    [ApiController]
    [Route("/mensagem")]
    public class MensagemController : ControllerBase

    {

        private readonly IConfiguration configuration;
        public MensagemController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<CreateMessage>> Post(CreateMessage mensagem)
        {


            await using var client = new ServiceBusClient(connectionString: configuration.GetConnectionString("ServiceBusConnection"));
            ServiceBusSender sender = client.CreateSender("msgfase4fiap");
            string msg = JsonSerializer.Serialize(mensagem);
            ServiceBusMessage message = new ServiceBusMessage(msg);
            await sender.SendMessageAsync(message);


            return await Task.FromResult(mensagem);
        }

    }
}
