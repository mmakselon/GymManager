using GymManager.Application.Contacts.Commands.SendContactEmail;
using GymManager.Application.Tickets.Command.AddTicket;
using GymManager.Application.Tickets.Queries.GetTicketById;
using GymManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GymManager.UI.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            await Mediator.Send(new AddTicketCommand { Name = "Test" });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View(new SendContactEmailCommand());
        }

    }
}