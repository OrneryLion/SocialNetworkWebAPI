using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MySqlConnector;

using SocialNetworkWebAPI.Models;

namespace SocialNetworkWebAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
        {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
            {
            _configuration = configuration;
            }

        [HttpPost]
        [Route("User")]
        public Response User(User user)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.User(user,connection);
            return response;
            }

        [HttpPost]
        [Route("Login")]
        public Response Login(User user)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(user,connection);
            return response;
            }
        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(User user)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.UserApproval(user,connection);
            return response;
            }

        [HttpPost]
        [Route("StaffUser")]
        public Response StaffUser(Staff staff)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.StaffUser(staff,connection);
            return response;
            }
        [HttpPost]
        [Route("StaffDelete")]
        public Response DeleteStaff(Staff staff)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.DeleteStaff(staff,connection);
            return response;
            }

        [HttpPost]
        [Route("UserList")]
        public Response UserList(User user)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.UserList(user,connection);
            return response;
            }

        }
    }
