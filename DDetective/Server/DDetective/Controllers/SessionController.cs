using DDetective.Models;
using Microsoft.AspNetCore.Mvc;
using DDetective.ViewModels;
using DDetective.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DDetective.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SessionController : Controller
    {
        private SessionDbContext sessionContext;

        public SessionController(SessionDbContext dbContext) 
        { 
            sessionContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateSession()
        {
            SessionViewModel sessionViewModel = new SessionViewModel();
            return View(sessionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession(SessionViewModel sessionViewModel)
        {
            if (ModelState.IsValid)
            {
                SessionModel sessionModel = new SessionModel
                {
                    SessionId = sessionViewModel.SessionId,
                    SessionName = sessionViewModel.SessionName,
                    SessionToken = sessionViewModel.SessionToken,
                    ExpirationDate = sessionViewModel.ExpirationDate
                };

                sessionModel.SessionToken = GenerateSessionToken();

                await sessionContext.Session.AddAsync(sessionModel);
                await sessionContext.SaveChangesAsync();

                return Redirect("CreateSession");
            }

            return View();
        }

        [HttpPut]
        public async Task<IActionResult> EditSession(int id, SessionViewModel sessionViewModel)
        {
            var existingSession = await sessionContext.Session.FirstOrDefaultAsync(x => x.SessionId == id);

            if (existingSession == null)
            {
                return NotFound();
            }

            existingSession.SessionName = sessionViewModel.SessionName;

            await sessionContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await sessionContext.Session.FirstOrDefaultAsync(x => x.SessionId == id);

            if (session == null)
            {
                return NotFound();
            }

            sessionContext.Remove(session);
            await sessionContext.SaveChangesAsync();

            return NoContent();
        }


        public static string GenerateSessionToken(string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
        {
            int length = 10;

            // separates charSet into individual, unique characters... if duplicates exist, use .Distinct()
            var charArray = charSet.ToArray();

            // sets char array to length of 10
            char[] token = new char[length];

            // loop 10 times to grab random char from charArray, cryptographically generates random integer from 0 to charArray.Length, sets to token
            for (int i = 0; i < length; i++)
            {
                token[i] = charArray[RandomNumberGenerator.GetInt32(charArray.Length)];
            }

            // new string created from this array, string is returned
            return new string(token);
        }

    }
}