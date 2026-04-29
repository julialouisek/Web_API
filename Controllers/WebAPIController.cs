using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Web_API.Models;
using Web_API.Models.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        private readonly WebAPIDbContext _ctx;
        public WebAPIController(WebAPIDbContext ctx)
        {
            _ctx = ctx;
        }

        //Uppgift 1 - hämta alla användare i systemet
        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<GetUserResponse>>> GetAll()
        {
            return Ok(await _ctx.Users
                .AsNoTracking()
                .Select(u => new GetUserResponse
                (
                    u.Id,
                    u.Name,
                    u.Phone
                ))
                .ToListAsync());
        }

        //Uppgift 2 - hämta alla intressen kopplade till en specifik användare
        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<GetInterestResponse>>> GetUserInterests(int id)
        {
            var interests = await _ctx.Users
                .Where(u => u.Id == id)
                .SelectMany(u => u.Interests)
                .AsNoTracking()
                .Select(i => new GetInterestResponse(i.Id, i.Name, i.Description))
                .ToListAsync();
            if (!interests.Any())
            {
                return NotFound($"User with id {id} does not exist");
            }
            return Ok(interests);
        }

        //Uppgift 3 - hämta alla länkar kopplade till en specifik användare
        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<GetLinkResponse>>> GetUserLinks(int id)
        {
            var links = await _ctx.Users
                .Where(u => u.Id == id)
                .SelectMany(u => u.Links)
                .AsNoTracking()
                .Select(l => new GetLinkResponse(l.Id, l.URL))
                .ToListAsync();
            if (!links.Any())
            {
                return NotFound($"User with id {id} does not exist");
            }
            return Ok(links);

        }

        //Uppgift 4 - koppla en användare till ett nytt intresse
        [HttpPost("{id}/interests/{interestId}")]
        public async Task<IActionResult> AddInterestToUser(int id, int interestId)
        {
            var user = await _ctx.Users
                .Include(u => u.Interests)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return NotFound($"User with id {id} does not exist");
            }


            var interest = await _ctx.Interests
                .FirstOrDefaultAsync(i => i.Id == interestId);

            if (interest is null)
            {
                return NotFound($"Interest with id {interestId} does not exist");
            }


            user.Interests.Add(interest);
            await _ctx.SaveChangesAsync();

            return Ok(new GetInterestResponse(interest.Id, interest.Name, interest.Description));
        }

        //Uppgift 5 - lägg till nya länkar för en specifik användare och ett specifikt intresse
        [HttpPost("{id}/interests/{interestId}/links")]
        public async Task<IActionResult> AddLinkToUser(int id, int interestId, CreateLinkRequest request)
        {
            var user = await _ctx.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return NotFound($"User with id {id} does not exist");
            }

            var interest = await _ctx.Interests
                .FirstOrDefaultAsync(i => i.Id == interestId);

            if (interest is null)
            {
                return NotFound($"Interest with id {interestId} does not exist");
            }

            var link = new Link
            {
                URL = request.URL,
                UserId = id,
                InterestId = interestId
            };

            await _ctx.Links.AddAsync(link);
            await _ctx.SaveChangesAsync();

            return Ok(new GetLinkResponse(link.Id, link.URL));
        }
        
    }
    
}