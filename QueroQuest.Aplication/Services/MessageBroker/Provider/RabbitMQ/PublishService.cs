namespace QueroQuest.Aplication.Services.MessageBroker.Provider.RabbitMQ;

using System.Text;
using global::RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using QueroQuest.Aplication.Interfaces;

public class PublishService : IPublishService
{
    private IConfiguration _configuration;

    public PublishService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void PublishMessage(string data)
    {
        try
        {
            string url = _configuration.GetSection("CloudAMQPConfigurations").GetSection("UrlRabbitMQ").Value;

            var factory = new ConnectionFactory
            {
                Uri = new Uri(url)
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Send_To_Emails",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message_event = data;

                    var body = Encoding.UTF8.GetBytes(message_event);

                    channel.BasicPublish(exchange: "", routingKey: "Send_To_Emails", basicProperties: null, body: body);

                }
            }
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}