using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using DDetective.Models;
using DDetective.Services;

namespace DDetective.Services
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            // -------------------------
            // EVENT ENDPOINTS
            // -------------------------

            // GET all events
            endpoints.MapGet("/event", async (Domain domain) =>
            {
                var events = await domain.GetAllEvents();
                // var events = (await domain.GetAllEvents()).ToList();

                return Results.Ok(events);
            });

            // GET event by id
            endpoints.MapGet("/event/{id}", async (int id, Domain domain) =>
            {
                var eventById = await domain.GetEventById(id);
                return eventById is not null ? Results.Ok(eventById) : Results.NotFound();
            });

            // POST (create) an event
            endpoints.MapPost("/event", async (Event newEvent, Domain domain) =>
            {
                // Validation Here?
                int newEventCreated = await domain.CreateEvent(newEvent);
                // Return a 201 Created response with a location header.
                return Results.Created($"/event/created", newEvent);
            });

            // PUT (update) an event ... {id} or {id:int} ??? (same for all methods below)
            endpoints.MapPut("/event/{id}", async (int id, Event updateEvent, Domain domain) =>
            {
                // Validation Here?
                bool updated = await domain.UpdateEvent(updateEvent);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE an event by ID
            endpoints.MapDelete("/event/delete", async (int id, Domain domain) =>
            {
                // Validation Here?
                bool deleted = await domain.DeleteEvent(id);
                return deleted ? Results.Ok() : Results.NotFound();
                // return to what route?
            });

            // -------------------------
            // SESSION ENDPOINTS
            // -------------------------

            // GET all sessions
            endpoints.MapGet("/session/all", async (Domain domain) =>
            {
                var sessions = await domain.GetAllSessions();
                return Results.Ok(sessions);
            });

            // GET session by id
            endpoints.MapGet("/session/{id}", async (int id, Domain domain) =>
            {
                var sessionById = await domain.GetSessionById(id);
                return sessionById is not null ? Results.Ok(sessionById) : Results.NotFound();
            });

            // POST (create) a session
            //endpoints.MapPost("/session", async (Domain domain) =>
            ////endpoints.MapPost("/session", async (Session newSession, Domain domain) =>
            //{
            //    // Validation Here?
            //    int newSessionCreated = await domain.CreateSession();
            //    //int newSessionCreated = await domain.CreateSession(newSession);
            //   // return Results.Created($"/session/created", newSession);
            //    return Results.Created($"/session/created");
            //});

            // POST (create) a session
            endpoints.MapPost("/session", async (Domain domain) =>
            {
                Session newSessionCreated = await domain.CreateSession();
                // Return a 201 Created response with the URI for the newly created session.
                return Results.Created($"/session/{newSessionCreated}", new { sessionId = newSessionCreated, sessionToken = newSessionCreated });
                //return Results.Created($"/session/{newSessionCreated}", new { sessionId = newSessionCreated });
            });

            // PUT (update) a session
            endpoints.MapPut("/session/{id}", async (int id, Session sessionToUpdate, Domain domain) =>
            {
                // Validation Here?
                bool updated = await domain.UpdateSession(sessionToUpdate);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // DELETE a session by ID
            endpoints.MapDelete("/session/delete", async (int id, Domain domain) =>
            {
                // Validation Here?
                bool deleted = await domain.DeleteSession(id);
                return deleted ? Results.Ok() : Results.NotFound();
            });

            // -------------------------
            // PROFILE ENDPOINTS
            // -------------------------

            // GET all profiles
            //endpoints.MapGet("/profile", async (Domain domain) =>
            //{
            //    var profiles = await domain.GetAllProfiles();
            //    return Results.Ok(profiles);
            //});

            //// GET profile by id
            //endpoints.MapGet("/profile/{id}", async (int id, Domain domain) =>
            //{
            //    var profile = await domain.GetProfileById(id);
            //    return profile is not null ? Results.Ok(profile) : Results.NotFound();
            //});

            //// POST (create) a profile
            //endpoints.MapPost("/profile", async (Profile newProfile, Domain domain) =>
            //{
            //    // Validation Here?
            //    int newProfileCreated = await domain.CreateProfile(newProfile);
            //    return Results.Created($"/profile/created", newProfile);
            //});

            //// PUT (update) a profile
            //endpoints.MapPut("/profile/{id}", async (int id, Profile profileToUpdate, Domain domain) =>
            //{
            //    // Validation Here?
            //    bool updated = await domain.UpdateProfile(profileToUpdate);
            //    return updated ? Results.NoContent() : Results.NotFound();
            //});

            //// DELETE a profile by ID
            //endpoints.MapDelete("/profile/delete", async (int id, Domain domain) =>
            //{
            //    // Validation Here?
            //    bool deleted = await domain.DeleteProfile(id);
            //    return deleted ? Results.Ok() : Results.NotFound();
            //});

            return endpoints;
        }
    }
}