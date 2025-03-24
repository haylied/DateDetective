using Dapper;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DDetective.Models;
using DDetective.Services;

namespace DDetective.Services
{

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
            if (newEvent.AllDayEvent)
            {
                // Set start time to midnight of the start date.
                newEvent.StartTime = newEvent.StartDate.Date;
                // Set end time to 23:59:59 of the end date.
                newEvent.EndTime = newEvent.EndDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            } else
            {
                newEvent.StartTime = null;
                newEvent.EndTime = null;
            }

            return await _repo.CreateEvent(newEvent);
        }

        public async Task<bool> UpdateEvent(Event eventToUpdate)
        {
            // REFACTOR METHOD
            if (eventToUpdate.AllDayEvent)
            {
                // Set start time to midnight of the start date.
                eventToUpdate.StartTime = eventToUpdate.StartDate.Date;
                // Set end time to 23:59:59 of the end date.
                eventToUpdate.EndTime = eventToUpdate.EndDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            } else
            {
                eventToUpdate.StartTime = null;
                eventToUpdate.EndTime = null;
            }

            return await _repo.UpdateEvent(eventToUpdate);
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var existingEvent = await _repo.GetEventById(eventId);

            if (existingEvent == null)
            {
                Console.WriteLine($"Event {eventId} not found.");
                return false;
            }

            Console.WriteLine($"Event {eventId} deleted.");
            return await _repo.DeleteEvent(eventId);
        }

        // --------- Sessions Logic ---------
        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            return await _repo.GetAllSessions();
        }

        public async Task<Session> GetSessionById(int sessionId)
        {
            return await _repo.GetSessionById(sessionId);
        }

        public async Task<int> CreateSession(Session newSession)
        {
            return await _repo.CreateSession(newSession);
        }

        public async Task<bool> UpdateSession(Session sessionToUpdate)
        {
            return await _repo.UpdateSession(sessionToUpdate);
        }

        public async Task<bool> DeleteSession(int sessionId)
        {
            var existingSession = await _repo.GetSessionById(sessionId);

            if (existingSession == null)
            {
                Console.WriteLine($"Session {sessionId} not found.");
                return false;
            }

            Console.WriteLine($"Session {sessionId} deleted.");
            return await _repo.DeleteSession(sessionId);
        }

        // --------- Profiles Logic ---------
        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await _repo.GetAllProfiles();
        }

        public async Task<Profile> GetProfileById(int profileId)
        {
            return await _repo.GetProfileById(profileId);
        }

        public async Task<int> CreateProfile(Profile newProfile)
        {
            return await _repo.CreateProfile(newProfile);
        }

        public async Task<bool> UpdateProfile(Profile profileToUpdate)
        {
            return await _repo.UpdateProfile(profileToUpdate);
        }

        public async Task<bool> DeleteProfile(int profileId)
        {
            var existingProfile = await _repo.GetProfileById(profileId);

            if (existingProfile == null)
            {
                Console.WriteLine($"Profile {profileId} not found.");
                return false;

            }
            else
            {
                Console.WriteLine($"Profile {profileId} deleted.");
                return await _repo.DeleteProfile(profileId);
            }
        }
    }
}