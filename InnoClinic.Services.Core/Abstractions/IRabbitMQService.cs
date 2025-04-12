﻿
namespace InnoClinic.Services.Application.Services
{
    public interface IRabbitMQService
    {
        Task PublishMessageAsync(object obj, string queueName);
        Task CreateQueuesAsync();
    }
}