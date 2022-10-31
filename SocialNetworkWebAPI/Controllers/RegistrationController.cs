using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MySqlConnector;

using SocialNetworkWebAPI.Models;

namespace SocialNetworkWebAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
        {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
            {
            _configuration = configuration;
            }

        [HttpPost]
        [Route("Registration")]
        public Response Registration(Registration registration)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Registration(registration,connection);
            return response;
            }

        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.Login(registration,connection);
            return response;
            }
        [HttpPost]
        [Route("UserApproval")]
        public Response UserApproval(Registration registration)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.UserApproval(registration,connection);
            return response;
            }

        [HttpPost]
        [Route("StaffRegistration")]
        public Response StaffRegistration(Staff staff)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.StaffRegistration(staff,connection);
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

        }
    }
