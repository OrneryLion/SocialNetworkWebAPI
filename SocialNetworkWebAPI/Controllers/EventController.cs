using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MySqlConnector;
using SocialNetworkWebAPI.Models;

namespace SocialNetworkWebAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
        {
        private readonly IConfiguration _configuration;
        public EventController(IConfiguration configuration)
            {
            _configuration = configuration;
            }
        [HttpPost]
        [Route("AddEvent")]
        public Response AddEvent(Events event_)
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddEvent(event_,connection);
            return response;
            }

        [HttpGet]
        [Route("EventList")]
        public Response EventList()
            {
            Response response = new Response();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.EventList(connection);
            return response;
            }
        }
    }
