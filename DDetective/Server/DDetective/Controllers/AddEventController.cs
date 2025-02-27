using DDetective.Models;
using Microsoft.AspNetCore.Mvc;
using DDetective.ViewModels;
using DDetective.Data;

namespace DDetective.Controllers
 {
    [ApiController]
    [Route("[controller]")]
    public class AddEventController : Controller
    {

        private EventDbContext eventContext;


        public AddEventController(EventDbContext dbContext)
        {
            eventContext = dbContext;
        }

        [HttpGet]
        [Route("/Index")]
        public IActionResult Index()
        {
            List<AddEventModel> events = eventContext.Events?.ToList();
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
                    AllDayEvent = addEventViewModel.AllDayEvent,
                    StartDate = addEventViewModel.StartDate,
                    StartTime = addEventViewModel.StartTime,
                    EndDate = addEventViewModel.EndDate,
                    EndTime = addEventViewModel.EndTime
                };
                

                // If it's an all-day event, override times to cover the full day
                if (addEventViewModel.AllDayEvent)
                {
                    addEventModel.StartTime = addEventViewModel.StartTime.Date, // Sets to 00:00:00, I hope
                    addEventModel.EndTime = addEventViewModel.EndTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59) // Sets to 23:59:59
                }


                await eventContext.Events.AddAsync(addEventModel);
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
            var events = await eventContext.Events.ToListAsync();

            // Return a Json executable to be Read by Client
            return Json(events);
        }


        // EDIT EXISTING EVENTS

        [HttpPut]
        [Route("/AddEventModel/Edit/{id}")]
        public async Task<IActionResult> EditEvent(int id, AddEventViewModel addEventViewModel)
        {
 /*
            // Existing Event Data
            var existingEvent = await eventContext.Events.FirstOrDefaultAsync(x => x.EventId == id);

            if (existingEvent == null)
            {
                return NotFound();
            }

            // Grabbing New Event Data to Implement into Existing Event
            var editedEventData = new AddEventModel
            {
                EventId = id,
                EventName = addEventViewModel.EventName,
                EventDescription = addEventViewModel.EventDescription,
                AllDayEvent = addEventViewModel.AllDayEvent,
                StartDate = addEventViewModel.StartDate,
                StartTime = addEventViewModel.StartTime,
                EndDate = addEventViewModel.EndDate,
                EndTime = addEventViewModel.EndTime
            };

            // If Existing Event is in the Database, Replace Old Event Data with New Event Data
            if (existingEvent != null)
            {
                existingEvent.EventId = editedEventData.EventId;
                existingEvent.EventName = editedEventData.EventName;
                existingEvent.EventDescription = editedEventData.EventDescription;
                existingEvent.AllDayEvent = editedEventData.AllDayEvent,
                existingEvent.StartDate = editedEventData.StartDate,
                existingEvent.StartTime = editedEventData.StartTime,
                existingEvent.EndDate = editedEventData.EndDate,
                existingEvent.EndTime = editedEventData.EndTime

                if (editedEventData.AllDayEvent)
                {
                    existingEvent.StartTime = editedEventData.StartTime.Date, // Sets to 00:00:00, I hope
                    existingEvent.EndTime = editedEventData.EndTime.Date.AddHours(23).AddMinutes(59).AddSeconds(59) // Sets to 23:59:59
                }
            } 



            // Save Changes
            await eventContext.SaveChangesAsync();

            // On Successful Edit, Execute 'No Content' Response
            return NoContent(); */

            // REFACTORED CODE : NOT SURE IF WORKS 

                var existingEvent = await eventContext.Events.FirstOrDefaultAsync(x => x.EventId == id);

                if (existingEvent == null)
                {
                    return NotFound();
                }

                existingEvent.EventName = addEventViewModel.EventName;
                existingEvent.EventDescription = addEventViewModel.EventDescription;
                existingEvent.AllDayEvent = addEventViewModel.AllDayEvent;
                existingEvent.StartDate = addEventViewModel.StartDate;
                existingEvent.EndDate = addEventViewModel.EndDate;

                if (addEventViewModel.AllDayEvent)
                {
                    existingEvent.StartTime = addEventViewModel.StartDate.Date; // Set to 00:00:00
                    existingEvent.EndTime = addEventViewModel.EndDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59); // Set to 23:59:59
                }
                else
                {
                    existingEvent.StartTime = addEventViewModel.StartTime;
                    existingEvent.EndTime = addEventViewModel.EndTime;
                }

                await eventContext.SaveChangesAsync();

                return NoContent(); */
        }


        // DELETE EXISTING EVENT

        [HttpDelete]
        [Route("/Delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            // Grab the first or Default Event by its unique ID
            var anEvent = await eventContext.Events.FirstOrDefaultAsync(x => x.EventId == id);

            // If Event Not Present, Return Not Found 404
            if (anEvent = null)
            {
                return NotFound();
            }

            // If Event Present, Delete Event and Save Changes, Return No Content 
            eventContext.Remove(anEvent);
            await eventContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
