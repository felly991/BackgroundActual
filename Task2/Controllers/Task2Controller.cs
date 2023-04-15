using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Task2.Data;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Task2Controller : ControllerBase
    {
        private static List<User> user = new List<User>
        {
            new User()
            {
                Id = 1,
                Name = "1",
                Surname = "1",
                Age = 1,
                Sex = "1",
                Place = "1",
                DateRegistration = new DateTime(2020, 7, 20)
            },
            new User()
            {
                Id = 2,
                Name = "2",
                Surname = "2",
                Age = 2,
                Sex = "2",
                Place = "2",
                DateRegistration = new DateTime(2021, 8, 19)
            },
            new User()
            {
                Id = 3, Name = "3", Surname = "3", Age = 3, Sex = "3", Place = "3",
                DateRegistration = new DateTime(2023, 1, 20)
            },
            new User()
            {
                Id = 4, Name = "$", Surname = "$", Age = 4, Sex = "$", Place = "$",
                DateRegistration = new DateTime(2011, 7, 20)
            },
            new User()
            {
                Id = 5, Name = "$", Surname = "$", Age = 4, Sex = "$", Place = "$",
                DateRegistration = new DateTime(2022, 7, 20)
            },
        };

        [HttpGet("userCount")]
        public ActionResult<int> Count()
        {
            Task<int> cnt = new Task<int>(() => user.Count());
            cnt.Start();
            var result = cnt.Result;
            return result;
        }
    }
}

