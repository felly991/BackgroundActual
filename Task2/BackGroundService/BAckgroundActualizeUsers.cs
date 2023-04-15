using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Task2.Data;
using Task2.Models;

namespace Task2.BackGroundService
{
    public class BackgroundActualizeUsers : BackgroundService
    {
        private static List<User> user = new List<User>
        {
            new User()
            {
                Id = 5, Name = "$", Surname = "$", Age = 4, Sex = "$", Place = "$",
                DateRegistration = new DateTime(2022, 7, 20)
            },
            new User()
            {
                Id = 1,
                Name = "1",
                Surname = "1",
                Age = 1,
                Sex = "1",
                Place = "1",
                DateRegistration = new DateTime(2023, 4, 14)
            },
            new User()
            {
                Id = 2,
                Name = "2",
                Surname = "2",
                Age = 2,
                Sex = "2",
                Place = "2",
                DateRegistration = new DateTime(2023, 4, 13)
            },
            new User()
            {
                Id = 3, Name = "3", Surname = "3", Age = 3, Sex = "3", Place = "3",
                DateRegistration = new DateTime(2023, 1, 20)
            },
            new User()
            {
                Id = 4, Name = "$", Surname = "$", Age = 4, Sex = "$", Place = "$",
                DateRegistration = new DateTime(2022, 7, 20)
            },
            
        };
        private readonly IServiceProvider serviceProvider;
        public BackgroundActualizeUsers(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    foreach (var _user in user)
                    {
                        var model = new UserDate
                        {
                            id = _user.Id,
                            DaysAtService = (DateTime.Now - _user.DateRegistration).Days
                        };
                        var us = await context.usersDate.FindAsync(_user.Id);
                        if (us == null)
                        {
                            context.usersDate.Add(model);
                        }
                        else
                        {
                            us.DaysAtService = model.DaysAtService;
                        }
                        await context.SaveChangesAsync();
                    }
                }
                await Task.Delay(60000, stoppingToken);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //Console.WriteLine("SA {dateTime}", DateTime.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}
