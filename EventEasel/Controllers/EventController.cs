namespace EventEasel.Controllers
{
    using System.Diagnostics;
    using EventEasel.Data.Services.Contracts;
    using EventEasel.Models;
    using Microsoft.AspNetCore.Mvc;

    public class EventController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult GetAll()
        {
            return View();
        }

        public async Task<IActionResult> GetBy(int id)
        {
            var eventById = await _eventService.GetById(id);
            // Autmapper
            return View(eventById);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string description)
        {
            int eventId = await _eventService.Create(title, description);

            return RedirectToAction(nameof(GetBy), new { id = eventId });
        }
    }
}
