using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> Users = new List<User>
        {
            new User("Miri","Uziel 35","Miri@gmail.com","1234" ),
            new User("Tzivi","Uziel 35","Tzivi@gmail.com","5678" ),
            new User("Lali","Uziel 35","Lali@gmail.com","9012" ),
            new User("Ayala","Uziel 35","Ayala@gmail.com","3456" )
      };

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return Users.Find(x => x.id == id);
        }

        // POST api/<UsersController>
        //[HttpPost]
        //public void Post([FromBody] User user)
        //{ User i = new User(user.name, user.address, user.email, user.password);
        //    Users.Add(i);
        //}
        [HttpPost]
        public void Post([FromBody] User value)
        {
            Users.Add(new User(value.name, value.address, value.email, value.password));
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User NewUser)
        {
            var user = Users.Find(x => x.id == id);
            if (user != null)
            {
                user.address = NewUser.address;
                user.password = NewUser.password;
                user.name = NewUser.name;
                user.email = NewUser.email;
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = Users.Find(x => x.id == id);
            if (user != null) { Users.Remove(user); }
        }
    }
}
