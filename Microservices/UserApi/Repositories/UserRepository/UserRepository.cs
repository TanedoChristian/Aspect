using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Text;
using UserApi.Data;
using UserApi.Entities;

namespace UserApi.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Create(User entity)
{
    var factory = new ConnectionFactory() { HostName = "localhost" };

    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        string queueName = "emailQueue";

        channel.QueueDeclare(queue: queueName,
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        string messageBody = $"{{\"to\":\"{entity.Email}\",\"subject\":\"Hello from .NET\",\"text\":\"This is a test email from .NET!\"}}";
        var body = Encoding.UTF8.GetBytes(messageBody);

        channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);

        Console.WriteLine($" [x] Sent email message: {messageBody}");
    }

    await _context.Users.AddAsync(entity);
    await _context.SaveChangesAsync();
}

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email) {


            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }



        public async Task<IEnumerable<User>> GetAll()
        {


         

          


            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
