using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        //// GET api/<AutuController>/5
        //[HttpGet("{id}")]
        //public ActionResult<User> Get(int id)
        //{
        //    User? user = Program.context.Users.Where((user) => user.UserId == id).FirstOrDefault();

        //    return user == null ? NotFound("Пользователь не найден") : Ok(user);


        //}

        [HttpGet("authenticate/{login},{password}")]
        public ActionResult<User?> Authenticate(string login, string password)
        {
            User? user = Program.context.Users.FirstOrDefault(user => user.Login == login && user.Password == password);
            return user == null ? NotFound("Пользователь не найден") : Ok(user);
        }

        [HttpGet("register/{surname},{name},{patronymic},{login},{password}")]
        public ActionResult<User?> Register(string surname, string name, string patronymic, string login, string password)
        {
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(patronymic) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Все поля должны быть заполнены!");
            }

            User user = new User
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Login = login,
                Password = password,
                Role = 1
            };

            TradeContext context = Program.context;
            context.Users.Add(user);
            context.SaveChanges();

            return Ok(user);
        }

    }


}
