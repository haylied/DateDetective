using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Security.Policy;
using Microsoft.Extensions.Configuration;
using DDetective.Models;


namespace DDetective.Services
{
    public class Repo
    {
        private readonly string _connectionString;

        public Repo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }

        public NpgsqlConnection Connection => new NpgsqlConnection(_connectionString);

        // New NpgsqlConnection instance need each time it is used???
        // public IDbConnection Connection => new NpgsqlConnection(_connectionString);

        /// Create Helper Method for all connections, similar to this??... 
        //public async Task<IDbConnection> OpenAsyncConnection()
        //{
        //    var db = Connection;
        //    await db.OpenAsync();
        //    return db;
        //}


        // ----- EVENT METHODS ----- //


        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "SELECT * FROM Event";
                return await db.QueryAsync<Event>(sql);

                // Make to List

                //var events = await db.QueryAsync<Event>(sql);
                //return events.ToList();

                // close database at end ?
            }
        }

        public async Task<Event> GetEventById(int eventId)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "SELECT * FROM Event " +
                    "WHERE EventId = @eventId";
                // this returns an IEnumerable<Event> instead of <Event> ... assuming multiple events will be recalled
                //return await db.QueryAsync<Event>(sql, new { eventId = eventId });

                return await db.QueryFirstOrDefaultAsync<Event>(sql, new { eventId });
            }
        }

        // Original w. 
        public async Task<int> CreateEvent(Event newEvent)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "INSERT INTO Event " +
                    "(EventId, " +
                    "EventName, " +
                    // "EventDescription, " +
                    "AllDayEvent, " +
                    "StartDate, " +
                    "StartTime, " +
                    "EndDate, " +
                    "EndTime) " +
                    // "EventOriginatorId)" +
                    "VALUES " +
                    "(@eventId, " +
                    "@eventName, " +
                    // "@eventDescription, " +
                    "@allDayEvent, " +
                    "@startDate, " +
                    "@startTime, " +
                    "@endDate, " +
                    "@endTime) ";
                   // "@eventOriginiatorId)";
                   //"RETURN EventId = eventId");

                return await db.ExecuteAsync(sql, new {
                    newEvent.EventId,
                    newEvent.EventName,
                    // newEvent.EventDiscription, 
                    newEvent.AllDayEvent,
                    newEvent.StartDate,
                    newEvent.StartTime,
                    newEvent.EndDate,
                    newEvent.EndTime,
                    // newEvent.EventOriginatorId
                });
            }
        }

        // what should this be? Task<int>??
        public async Task<bool> UpdateEvent(Event eventToUpdate)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "UPDATE Event " +
                    "SET EventId = @EventId, " +
                    "EventName = @EventName, " +
                    // "EventDescription = @EventDescription, " +
                    "AllDayEvent = @AllDayEvent, " +
                    "StartDate = @StartDate, " +
                    "StartTime = @StartTime, " +
                    "EndDate = @EndDate, " +
                    "EndTime = @EndTime, " +
                    // "EventOriginatorId = @EventOriginatorId " +
                    "WHERE EventId = @EventId";
                // sets sql execute to int value representing rows affected
                int result = await db.ExecuteAsync(sql, new { eventToUpdate.EventId,
                    eventToUpdate.EventName,
                    // eventToUpdate.EventDiscription, 
                    eventToUpdate.AllDayEvent,
                    eventToUpdate.StartDate,
                    eventToUpdate.StartTime,
                    eventToUpdate.EndDate,
                    eventToUpdate.EndTime,
                    // eventToUpdate.EventOriginatorId 
                });
                return result > 0;
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = " DELETE FROM Event " +
                    "WHERE EventId = @EventId";
                int result = await db.ExecuteAsync(sql, new { EventId = eventId });
                return result > 0;
            }
        }


        // ----- SESSION METHODS ----- //

        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "SELECT * FROM Session";
                return await db.QueryAsync<Session>(sql);

                // may need to do same thing as the Event Method
            }
        }

        public async Task<Session> GetSessionById(int sessionId)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "SELECT * FROM Session WHERE SessionId = @sessionId";
               // return await db.QueryAsync<Session>(sql, new { SessionId = sessionId });

                return await db.QueryFirstOrDefaultAsync<Session>(sql, new { sessionId });
            }
        }

        public async Task<int> CreateSession(Session newSession)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                // need to double check on sql syntax
                //string sql = "INSERT INTO Session " +
                //    "(" +
                //    //"SessionId, " +
                //    //"SessionName, " +
                //    "SessionToken " +
                //    //"ExpirationTime" +
                //    ") " +
                //    "VALUES " +
                //    "(" +
                //    //"@sessionId, " +
                //   // "@sessionName, " +
                //    "@sessionToken " +
                //    //"@ExpirationTime" +
                //    ") " +
                //    "RETURNING SessionId";

                string sql = "INSERT INTO Session (SessionId, SessionToken) " +
             "VALUES (@sessionId, @sessionToken) " +
             "RETURNING SessionId";


                // may need to use QuerySingleAsync<int>() to return single Id
                return await db.QuerySingleAsync<int>(sql, new { newSession.SessionToken });

                //return await db.ExecuteAsync(sql, new
                //{
                //   // newSession.SessionId,
                //    //newSession.SessionName,
                //    newSession.SessionToken
                //   // newSession.ExpirationTime

                //    // SessionToken = newSession.SessionToken
                //});
            }
        }

        public async Task<bool> UpdateSession(Session sessionToUpdate)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "UPDATE Session " +
                    "SET SessionId = @SessionId, " +
                   // "SessionName = @SessionName, " +
                    "SessionToken = @SessionToken, " +
                    //"ExpirationTime = @ExpirationTime " +
                    "WHERE SessionId = @SessionId";
                int result = await db.ExecuteAsync(sql, new
                {
                    sessionToUpdate.SessionId,
                   // sessionToUpdate.SessionName,
                    sessionToUpdate.SessionToken,
                   // sessionToUpdate.ExpirationTime                                                                                                                                                                            
                });
                return result > 0;
            }
        }

        public async Task<bool> DeleteSession(int sessionId)
        {
            using (var db = Connection)
            {
                await db.OpenAsync();
                string sql = "DELETE FROM Session " +
                    "WHERE SessionId = @SessionId";
                int result = await db.ExecuteAsync(sql, new { SessionId = sessionId });
                return result > 0;
            }
        }


        // ----- PROFILE METHODS ----- //

        //public async Task<IEnumerable<Profile>> GetAllProfiles()
        //{
        //    using (var db = Connection)
        //    {
        //        await db.OpenAsync();
        //        string sql = "SELECT * FROM Profile";
        //        return await db.QueryAsync<Profile>(sql);

        //        // may need to do same thing as the Event Method
        //    }
        //}

        //public async Task<Profile> GetProfileById(int profileId)
        //{
        //    using (var db = Connection)
        //    {
        //        await db.OpenAsync();
        //        string sql = "SELECT * FROM Profile " +
        //            "WHERE ProfileId = @profileId";
        //        return await db.QueryAsync<Profile>(sql, new { ProfileId = profileId });
        //    }
        //}

        //public async Task<int> CreateProfile(Profile newProfile)
        //{
        //    using (var db = Connection)
        //    {
        //        await db.OpenAsync();
        //        string sql = "INSERT INTO Profile " +
        //                "(ProfileId, " +
        //                "ProfileName, " +
        //                "SessionId) " +
        //                "VALUES " +
        //                "(@profileId, " +
        //                "@profileName, " +
        //                "@sessionId) " +
        //                "RETURNING ProfileId";
        //        return await db.ExecuteAsync(sql, new
        //        {
        //            newProfile.ProfileId,
        //            newProfile.ProfileName,
        //            newProfile.SessionId
        //        });
        //    }
        //}

        //public async Task<bool> UpdateProfile(Profile profileToUpdate)
        //{
        //    using (var db = Connection)
        //    {
        //        await db.OpenAsync();
        //        string sql = "UPDATE Profile " +
        //                "SET ProfileId = @ProfileId, " +
        //                "ProfileName = @ProfileName, " +
        //                "SessionId = @SessionId " +
        //                "WHERE ProfileId = @ProfileId";
        //        int result = await db.ExecuteAsync(sql, new
        //        {
        //            profileToUpdate.ProfileId,
        //            profileToUpdate.ProfileName,
        //            profileToUpdate.SessionId
        //        });
        //        return result > 0;
        //    }
        //}

        //public async Task<bool> DeleteProfile(int profileId)
        //{
        //    using (var db = Connection)
        //    {
        //        await db.OpenAsync();
        //        string sql = " DELETE FROM Profile " +
        //                "WHERE ProfileId = @ProfileId";
        //        int result = await db.ExecuteAsync(sql, new { ProfileId = profileId });
        //        return result > 0;
        //    }
        //}

    }
}