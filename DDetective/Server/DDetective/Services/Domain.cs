using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using Npgsql; 
using System.Threading.Tasks;
using DDetective.Services;
using DDetective.Model;

/*
 * Methods:
 * - GetAllEvents
 * - GetEventByID
 * - CreateEvent
 * - UpdateEvent
 * - DeleteEvent
 * - CreateSession
 * - UpdateSession
 * - CreateProfile
 * - UpdateProfile
 * - DeleteProfile
 */

public class Domain
{
    private readonly Repo _repo;

    public Domain(Repo repo)
    {
        _repo = repo;
    }

    public async Task<> EventCreate(AddEventModel newEvent)
    {
        if (ModelState.IsValid)
        {
            return await _repo.CreateEventAsync(newEvent);
        }
        // if false, state false
        return BadRequest(); //????
    }

    public async Task<> EventDeleteById(int eventId)
    {

    }

    public async Task<IEnumerable<Event>> EventGetAll()
    {
        return await _repo.GetAllEventsAsync();
    }

    public async Task<AddEventModel> EventGetAllById(int eventId)
    {
        if (AddEventModel.EventId == eventId)
        {
            return await _repo.GetEventByIdAsync(eventId);
        }

        return NotFound();

    }

    public async Task<> EventUpdateById(int EventId)
    {

    }


    public async Task<> ProfileCreate()
    {

    }

    public async Task<> ProfileDelete()
    {

    }

    public async Task<> ProfileUpdate()
    {

    }

    public async Task<> SessionCreate()
    {

    }

    public async Task<> SessionDelete()
    {

    }

    public async Task<> SessionUpdate()
    {

    }


}
