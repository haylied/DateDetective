using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using DDetective.Models;
using DDetective.Services;


// namespace DDetective.Services.Endpoints
namespace DDetective.Services
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints (this IEndpointRouteBuilder endpoints)
        {
            // -------------------------
            // EVENT ENDPOINTS
            // -------------------------

            // GET all events
            endpoints.MapGet("/events", async (Domain domain) =>
            {
                var events = await domain.GetAllEvents();
                // var events = (await domain.GetAllEvents()).ToList();

                return Results.Ok(events);
            });

            // GET event by id
            endpoints.MapGet("/events/{id}", async (int id, Domain domain) =>
            {
                var eventsById = await domain.GetEventById(id);
                return eventsById is not null ? Results.Ok(eventsById) : Results.NotFound();
            });

            // POST (create) an event
            endpoints.MapPost("/events", async (Event newEvent, Domain domain) =>
            {
                int newId = await domain.CreateEvent(newEvent);
                // Return a 201 Created response with a location header.
                // return Results.Created($"/events/created", newEvent);
                return Results.Created($"/events/{newId}", newEvent);
            });

            // PUT (update) an event ... {id} or {id:int} ??? (same for all methods below)
            endpoints.MapPut("/events/{id}", async (int id, Event updateEvent, Domain domain) =>
            {
                // Ensure the update model has the correct EventId.
                //updateEvent.EventId = id;
                bool updated = await domain.UpdateEvent(updateEvent);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE an event
            endpoints.MapDelete("/events/{id}", async (int id, Domain domain) =>
            {
                try
                {
                    bool deleted = await domain.DeleteEvent(id);
                    return deleted ? Results.NoContent() : Results.NotFound();
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
            });

            // -------------------------
            // SESSION ENDPOINTS
            // -------------------------

            // GET all sessions
            endpoints.MapGet("/sessions", async (Domain domain) =>
            {
                var sessions = await domain.GetAllSessions();
                return Results.Ok(sessions);
            });

            // GET session by id
            endpoints.MapGet("/sessions/{id}", async (int id, Domain domain) =>
            {
                var session = await domain.GetSessionById(id);
                return session is not null ? Results.Ok(session) : Results.NotFound();
            });

            // POST (create) a session
            endpoints.MapPost("/sessions", async (Session newSession, Domain domain) =>
            {
                int newId = await domain.CreateSession(newSession);
                return Results.Created($"/sessions/{newId}", newSession);
            });

            // PUT (update) a session
            endpoints.MapPut("/sessions/{id}", async (int id, Session sessionToUpdate, Domain domain) =>
            {
                // Optionally ensure the session ID is correct.
                //sessionToUpdate.SessionId = id;
                bool updated = await domain.UpdateSession(sessionToUpdate);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE a session
            endpoints.MapDelete("/sessions/{id}", async (int id, Domain domain) =>
            {
                bool deleted = await domain.DeleteSession(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

            // -------------------------
            // PROFILE ENDPOINTS
            // -------------------------

            // GET all profiles
            endpoints.MapGet("/profiles", async (Domain domain) =>
            {
                var profiles = await domain.GetAllProfiles();
                return Results.Ok(profiles);
            });

            // GET profile by id
            endpoints.MapGet("/profiles/{id}", async (int id, Domain domain) =>
            {
                var profile = await domain.GetProfileById(id);
                return profile is not null ? Results.Ok(profile) : Results.NotFound();
            });

            // POST (create) a profile
            endpoints.MapPost("/profiles", async (Profile newProfile, Domain domain) =>
            {
                int newId = await domain.CreateProfile(newProfile);
                return Results.Created($"/profiles/{newId}", newProfile);
            });

            // PUT (update) a profile
            endpoints.MapPut("/profiles/{id}", async (int id, Profile profileToUpdate, Domain domain) =>
            {
                //profileToUpdate.ProfileId = id;
                bool updated = await domain.UpdateProfile(profileToUpdate);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE a profile
            endpoints.MapDelete("/profiles/{id}", async (int id, Domain domain) =>
            {
                bool deleted = await domain.DeleteProfile(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });

            return endpoints;
        }
    }