using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportIssues.Domain.Poco;
using PassportIssues.Services.Abstractions;

namespace PassportIssues.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        protected readonly IApplicationFormService _service;

        public ApplicationFormController(IApplicationFormService service)
        {
            _service = service;
        }

        [HttpPost("/FillForm")]
        public async Task<IActionResult> PostFormAsync(FormModel Model)
        {
            try
            {
                var result = await _service.AddAsync(Model);
                if (result.ToString() != null)
                    return await Task.FromResult(Ok(result));
                return await Task.FromResult(BadRequest("Form Couldn't applyed"));
            }
            catch (Exception)
            {

                throw new Exception("Form Couldn't applyed");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationsFormsAsync()
        {

            var result = await _service.GetAllAsync();
            if (result != null)
                return await Task.FromResult(Ok(result));
            return await Task.FromResult(Ok("Database is Empty"));

        }
    }
}
