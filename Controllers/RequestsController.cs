using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRSNetWeb.Models;

namespace PRSNetWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PrsdbContext _context;

        public RequestsController(PrsdbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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
        // PUT: api/Requests/submit-review/5
        [HttpPut("submit-review/{id}")]
        public Request SubmitRequest(int id)
        {
            Request request = _context.Requests.Find(id);
            if (request.Total >= 50) {
                request.Status = "APPROVED";
            }
            else
            {
                request.Status = "REVIEW";
            }

            _context.SaveChanges();
            return request;
        }
        // PUT: api/Requests/approve/5
        [HttpPut("approve/{id}")]
        public Request ApproveRequest(int id)
        {
            Request request = _context.Requests.Find(id);
            request.Status = "APPROVED";

            _context.SaveChanges();
            return request;
        }
        // PUT: api/Requests/list-review/5
        [HttpGet("list-review/{id}")]
        public List<Request> ListRequestReview(int id)
        {
            List<Request> requestList = _context.Requests.Where(x => x.UserId != id && x.Status == "REVIEW").ToList();

            return requestList;
        }
        //PUT: api/Requests/reject/5
        [HttpPut("reject/{id}")]
        public Request RequestReject(int id, Request request)
        {
            if (request.ReasonForRejection == null)
            {
                request.Status = "REJECTED";
                _context.Entry(request).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return request;
        }
        //POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> CreateRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id,  }, request);
        }
        //DELETE: api/Requests/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(r => r.Id == id);
        }
        // PUT: api/Requests/5
        
    }
}
