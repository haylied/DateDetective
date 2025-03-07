using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Threading.Tasks;
using DDetective.Models;
using System.Security.Policy;


public class Repo
{
    private readonly string _connectionString;

    public Repo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    // New NpgsqlConnection instance need each time it is used???
    public IDbConnection Connection => new NpgsqlConnection(_connectionString);

    /// Create Helper Method for all connections, similar to this??... should I use void?
    //public async Task<IDbConnection> OpenAsyncConnection()
    //{
    //    var db = Connection;
    //    await db.OpenAsync();
    //    return db;
    //}


    // ----- EVENT METHODS ----- //


    public async Task<IEnumerable<AddEventModel>> GetAllEventsAsync()
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = "SELECT * FROM Event";
            return await db.QueryAsync<AddEventModel>(sql).ToList();
        }
    }

    public async Task<AddEventModel> GetAllEventsByIdAsync(int eventId)
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = "SELECT * FROM Event WHERE EventId = @eventId";
            return await db.QueryAsync<AddEventModel>(sql, new { eventId = eventId };
        }
    }

    // public async Task<AddEventModel> CreateEvent(AddEventModel newEvent)
    public async Task<int> CreateEvent(AddEventModel newEvent)
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = "INSERT INTO Event (EventId, EventName, EventDescription, AllDayEvent, StartDate, StartTime, EndDate, EndTime, EventOriginatorId)" +
                "VALUES (@eventId, @eventName, @eventDescription, @allDayEvent, @startDate, @startTime, @endDate, @endTime, @eventOriginiatorId)";
            //return await db.Execute(sql, new { eventId = @eventId, eventName = @eventName, eventDescription = @eventDiscription, allDayEvent = @allDayEvent, startDate = @startDate, startTime = @startTime, endDate = @endDate, endTime = @endTime, eventOriginatorId = @eventOriginatorId})
            return await db.ExecuteAsync(sql, new { newEvent.EventId, newEvent.EventName, newEvent.EventDiscription, newEvent.AllDayEvent, newEvent.StartDate, newEvent.StartTime, newEvent.EndDate, newEvent.EndTime, newEvent.EventOriginatorId });
        }
    }
    // what should this be? Task<int>??
   public async Task<bool> UpdateEvent(AddEventModel eventToUpdate)
   {
        using (var db = Connection)
        {
            await db.Open();
            string sql = "UPDATE Event " +
                "SET EventId = @EventID, EventName = @EventName, EventDescription = @EventDescription, AllDayEvent = @AllDayEvent, StartDate = @StartDate, StartTime = @StartTime, EndDate = @EndDate, EndTime = @EndTime, EventOriginatorId = @EventOriginatorId " +
                "WHERE EventId = @EventId";
            // sets sql execute to int value representing rows affected
            int result = await db.ExecuteAsync(sql, new { eventToUpdate.EventId, eventToUpdate.EventName, eventToUpdate.EventDiscription, eventToUpdate.AllDayEvent, eventToUpdate.StartDate, eventToUpdate.StartTime, eventToUpdate.EndDate, eventToUpdate.EndTime, eventToUpdate.EventOriginatorId });
            return result > 0;
        }
   }

    public async Task<bool> DeleteEvent(int eventId)
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = " DELETE FROM Event WHERE EventId = @EventId";
            int result = await db.ExecuteAsync(sql, new { EventId = eventId });
            return result > 0;
        }
    }


    // ----- SESSION METHODS ----- //

    public async Task<int> CreateSession(SessionModel newSession)
    {
        using (var db = Connection)
        {
            await db.Open();
            // need to double check on sql syntax
            string sql = "INSERT INTO Session (SessionId, SessionName, SessionToken, ExpirationDate) VALUES (@sessionId, @sessionName, @sessionToken, @exirpationDate) RETURNING SessionId"
            return await db.ExecuteAsync(sql, new {newSession.SessionId, newSession.SessionName, newSession.SessionToken, newSession.ExpirationDate})
        }
    }

    public async Task<bool> UpdateSession(SessionModel sessionToUpdate)
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = "UPDATE Session SET SessionId = @SessionId, SessionName = @SessionName, SessionToken = @SessionToken, ExpirationDate = @ExpirationDate WHERE SessionId = @SessionId";
            int result = await db.ExecuteAsync(sql, new { sessionToUpdate.SessionId, sessionToUpdate.SessionName, sessionToUpdate.SessionToken, sessionToUpdate.ExpirationDate})
            return result > 0;
        }
    }

    public async Task<bool> DeleteSession(int sessionId)
    {
        using (var db = Connection)
        {
            await db.Open();
            string sql = " DELETE FROM Session WHERE SessionId = @SessionId";
            int result = await db.ExecuteAsync(sql, new { SessionId = sessionId });
            return result > 0;
        }
    }