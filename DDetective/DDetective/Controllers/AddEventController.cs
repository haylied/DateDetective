using DDetective.Models;
using Microsoft.AspNetCore.Mvc;
using DDetective.ViewModels;
using DDetective.Data;

namespace DDetective.Controllers
 {
  /*  [ApiController]
    [Route("[controller]")]
    public class AddEventController : Controller
    {

        //EVENT DATABASE
        private EventDbContext eventContext;


        public AddEventController(EventDbContext dbContext)
        {
            eventContext = dbContext;
        }

        [HttpGet]
        [Route("/Index")]
        public ActionResult Index()
        {
            List<AddEventModel> events = eventContext.AddEventModel?.ToList();
            return View(events);
        }


        // GET FORM FIELDS TO CREATE AN EVENT

        [HttpGet]
        [Route("/CreateEvent")]
        public IActionResult CreateEvent()
        {
            // Use ViewModel Fields & Validation for Form to Create an Event
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }


        // SUBMIT FORM FIELDS TO CREATE AN EVENT

        [HttpPost]
        [Route("/CreateEvent")]
        public async Task<IActionResult> CreateEvent(AddEventViewModel addEventViewModel)
        {
            // If the Submission has VALID Data, Add to Database, Redirect to Form to Create Another Event
            if (ModelState.IsValid)
            {
                AddEventModel addEventModel = new AddEventModel
                {
                    EventId = addEventViewModel.EventId,
                    EventName = addEventViewModel.EventName,
                    EventDescription = addEventViewModel.EventDescription,
                    DateStart = addEventViewModel.DateStart,
                    DateEnd = addEventViewModel.DateEnd,
                    TimeStart = addEventViewModel.TimeStart,
                    TimeEnd = addEventViewModel.TimeEnd
                };

                await eventContext.AddEventModel.AddAsync(addEventModel);
                await eventContext.SaveChangesAsyn();

                return Redirect("CreateEvent");
            }

            return View();
        }


        // VIEW EVENTS

        [HttpGet]
        [Route("/Read")]
        public async Task<IActionResult> Read()
        {
            // Grab a List of Events from the Database
            var events = await eventContext.AddEventModel.ToListAsync();

            // Return a Json executable to be Read by React.js
            return Json(events);
        }


        // EDIT EXISTING EVENTS

        [HttpPut]
        [Route("/AddEventModel/Edit/{id}")]
        public async Task<IActionResult> EditEvent(int id, AddEventViewModel addEventViewModel)
        {
            // Grabbing New Event Data to Implement into Existing Event
            var editedEventData = new AddEventModel
            {
                EventId = id,
                EventName = addEventViewModel.EventName,
                EventDescription = addEventViewModel.EventDescription,
                DateStart = addEventViewModel.DateStart,
                DateEnd = addEventViewModel.DateEnd,
                TimeStart = addEventViewModel.TimeStart,
                TimeEnd = addEventViewModel.TimeEnd
            };

            // Existing Event Data
            var existingEvent = await eventContext.AddEventModel.FirstOrDefaultAsync(x => x.EventId == id);

            // If Existing Event is in the Database, Replace Old Event Data with New Event Data
            if (existingEvent != null)
            {
                existingEvent.EventId = editedEventData.EventId;
                existingEvent.EventName = editedEventData.EventName;
                existingEvent.EventDescription = editedEventData.EventDescription;
                existingEvent.DateStart = editedEventData.DateStart;
                existingEvent.TimeStart = editedEventData.TimeStart;
                existingEvent.EndTime = editedEventData.TimeEnd;
            }

            // Save Changes
            await eventContext.SaveChangesAsync();

            // On Successful Edit, Execute 'No Content' Response
            return NoContent();
        }


        // DELETE EXISTING EVENT

        [HttpDelete]
        [Route("/Delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            // Grab the first or Default Event by its unique ID
            var anEvent = await eventContext.AddEventModel.FirstOrDefaultAsync(x => x.EventId == id);

            // If Event Present, Delete Event and Save Changes, Return No Content 
            if (anEvent != null)
            {
                eventContext.Remove(anEvent);
                await eventContext.SaveChangesAsync();
                return NoContent();
            }

            // If Event Not Present, Return Not Found 404
            return NotFound();
        }
    }*/
}