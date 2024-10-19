using Azure;
using FullStackDemo.ApplicationService.DTOs.Common;
using FullStackDemo.ApplicationService.DTOs.MobileSuits;
using FullStackDemo.ApplicationService.Queries.Interfaces.IMobileSuits;
using FullStackDemo.ApplicationService.Queries.QueryModels.MobileSuits;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSuitController : ControllerBase
    {
        private readonly IMobileSuitQueryHandler _mobileSuitQueryHandler;

        public MobileSuitController(IMobileSuitQueryHandler mobileSuitQueryHandler) { 
            _mobileSuitQueryHandler = mobileSuitQueryHandler;
        }

        // GET: api/MobileSuitController/GetMobileSuitsPaginated?start=0&length=5
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMobileSuitsPaginated([FromQuery] GetMobileSuitPaginatedQuery data)
        {
            ApiBodyDto response = new ApiBodyDto();

            // Ensure the search parameter is not null or empty; set to empty string if it is
            if (string.IsNullOrEmpty(data.search))
            {
                data.search = "";
            }

            try
            {
                // Call the query handler to get the paginated Mobile Suits data
                var res = await _mobileSuitQueryHandler.HandleGetMobileSuitPaginated(data);

                // Populate the response DTO with the results
                response.TotalCount = res.TotalCount; // Set the total count of items
                response.Data = res.Data; // Set the list of Mobile Suits
            }
            catch {
                // Return an appropriate error response (e.g., 500 Internal Server Error)
                return StatusCode(500, new { message = "An error occurred while retrieving data." });
            }

            // Return a successful response with the data
            return Ok(response);
        }

        // GET api/<MobileSuitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MobileSuitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MobileSuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MobileSuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
