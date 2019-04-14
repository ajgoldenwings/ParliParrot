using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MembershipRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MembershipRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipRequest>>> GetMembershipRequests()
        {
            return await _context.MembershipRequests.ToListAsync();
        }

        // GET: api/MembershipRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipRequest>> GetMembershipRequest(int id)
        {
            var membershipRequest = await _context.MembershipRequests.FindAsync(id);

            if (membershipRequest == null)
            {
                return NotFound();
            }

            return membershipRequest;
        }

        // PUT: api/MembershipRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembershipRequest(int id, MembershipRequest membershipRequest)
        {
            if (id != membershipRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(membershipRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MembershipRequests
        [HttpPost]
        public async Task<ActionResult<MembershipRequest>> PostMembershipRequest(MembershipRequest membershipRequest)
        {
            _context.MembershipRequests.Add(membershipRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembershipRequest", new { id = membershipRequest.Id }, membershipRequest);
        }

        // DELETE: api/MembershipRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MembershipRequest>> DeleteMembershipRequest(int id)
        {
            var membershipRequest = await _context.MembershipRequests.FindAsync(id);
            if (membershipRequest == null)
            {
                return NotFound();
            }

            _context.MembershipRequests.Remove(membershipRequest);
            await _context.SaveChangesAsync();

            return membershipRequest;
        }

        private bool MembershipRequestExists(int id)
        {
            return _context.MembershipRequests.Any(e => e.Id == id);
        }
    }
}
