using Dapper;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Threading.Tasks;
using DDetective.Models;
using System.Security.Policy;
using DDetective.Services;

public class Domain
{
    private readonly Repo _repo;

    public Domain(Repo repo)
    {
        _repo = repo;
    }

    // --------- Events Logic ---------
    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await _repo.GetAllEvents();
    }

    public async Task<Event> GetEventById(int eventId)
    {
        return await _repo.GetEventById(eventId);
    }

    public async Task<int> CreateEvent(Event newEvent)
    {
        return await _repo.CreateEvent(newEvent);
    }

    // View Model for validation???
    public async Task<bool> UpdateEvent(Event eventToUpdate)
    {
        if (eventToUpdate.AllDayEvent)
        {
            // Set start time to midnight of the start date.
            eventToUpdate.StartTime = eventToUpdate.StartDate.Date;
            // Set end time to 23:59:59 of the end date.
            eventToUpdate.EndTime = eventToUpdate.EndDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        return await _repo.UpdateEvent(eventToUpdate);
    }

    public async Task<bool> DeleteEvent(int eventId)
    {
        var existingEvent = await _repo.GetEventByIdAsync(eventId);

        if (existingEvent == null)
        {
            Console.WriteLine($"Event {eventId} not found.");
            return false;
        }

        Console.WriteLine($"Event {eventId} deleted.");
        return await _repo.DeleteEventAsync(eventId);
    }

    // --------- Sessions Logic ---------
    public async Task<IEnumerable<Session>> GetAllSessionsAsync()
    {
        return await _repo.GetAllSessionsAsync();
    }

    public async Task<Session> GetSessionByIdAsync(int sessionId)
    {
        return await _repo.GetSessionIdAsync(sessionId);
    }

    public async Task<int> CreateSessionAsync(Session newSession)
    {
        return await _repo.CreateSession(newSession);
    }

    public async Task<bool> UpdateSessionAsync(Session sessionToUpdate)
    {
        return await _repo.UpdateSession(sessionToUpdate);
    }

    public async Task<bool> DeleteSessionAsync(int sessionId)
    {
        var existingSession = await _repo.GetSessionByIdAsync(sessionId);

        if (existingSession == null)
        {
            Console.WriteLine($"Session {sessionId} not found.");
            return false;
        }

        Console.WriteLine($"Session {sessionId} deleted.");
        return await _repo.DeleteSession(sessionId);
    }

    // --------- Profiles Logic ---------
    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
        return await _repo.GetAllProfilesAsync();
    }

    public async Task<Profile> GetProfileByIdAsync(int profileId)
    {
        return await _repo.GetProfileByIdAsync(profileId);
    }

    public async Task<int> CreateProfileAsync(Profile newProfile)
    {
        return await _repo.CreateProfile(newProfile);
    }

    public async Task<bool> UpdateProfileAsync(Profile profileToUpdate)
    {
        return await _repo.UpdateProfile(profileToUpdate);
    }

    public async Task<bool> DeleteProfileAsync(int profileId)
    {
        var existingProfile = await _repo.GetProfileByIdAsync(profileId);

        if (existingProfile == null)
        {
            Console.WriteLine($"Profile {profileId} not found.");
            return false;

        }

        Console.WriteLine($"Profile {profileId} deleted.");
        return await _repo.DeleteProfile(profileId);
    }
}