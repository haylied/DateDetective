using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Threading.Tasks;
using DDetective.Models;


public class Repo
{
    private readonly string _connectionString;

    public Repo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    // New NpgsqlConnection instance need each time it is used
    public IDbConnection Connection => new NpgsqlConnection(_connectionString);

    public async Task<IEnumerable<AddEventModel>> GetAllEventsAsync()
    {
        using (var db = Connection)
        {
            await db.OpenAsync();
            string sql = "SELECT * FROM Event";
            return await db.QueryAsync<AddEventModel>(sql).ToList();
        }
    }





/*
 * SQL Logic:
 * 
 * GetAllEvents-
 * SELECT * FROM Event
 * 
 * GetEventByID-
 * SELECT * FROM Event WHERE EventId = @EventId
 * 
 * CreateEvent-
 * INSERT INTO Event (EventId, EventName, EventDescription, AllDayEvent, StartDate, StartTime, EndDate, EndTime, EventOriginatorId) 
 * VALUES (@EventId, @EventName, @EventDescription, @AllDayEvent, @StartDate, @StartTime, @EndDate, @EndTime, @EventOriginiatorId)
 * 
 * UpdateEvent-
 * UPDATE Event
 * SET EventId = @EventId, EventName = @EventName, EventDescription = @EventDescription, AllDayEvent = @AllDayEvent, StartDate = @StartDate, 
 * StartTime = @StartTime, EndDate = @EndDate, EndTime = @EndTime, EventOriginatorId = @EventOriginatorId
 * WHERE EventId = @EvendId
 * 
 * DeleteEvent-
 * DELETE FROM Event
 * WHERE EventId = @EventId
 * 
 * 
 */
