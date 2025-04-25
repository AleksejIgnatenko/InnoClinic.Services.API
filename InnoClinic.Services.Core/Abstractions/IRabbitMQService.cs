namespace InnoClinic.Services.Core.Abstractions;

/// <summary>
/// Interface for interacting with RabbitMQ messaging service.
/// </summary>
public interface IRabbitMQService
{
    /// <summary>
    /// Publishes a message asynchronously to a specified queue.
    /// </summary>
    /// <param name="obj">The object to be published as a message.</param>
    /// <param name="queueName">The name of the queue to publish the message to.</param>
    Task PublishMessageAsync(object obj, string queueName);

    /// <summary>
    /// Creates required queues asynchronously.
    /// </summary>
    Task CreateQueuesAsync();
}