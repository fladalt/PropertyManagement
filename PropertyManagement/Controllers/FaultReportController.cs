using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Application.DTOs;
using PropertyManagement.Application.Interfaces;
using Microsoft.Identity.Web;

namespace PropertyManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultReportController : ControllerBase
    {
        private readonly IFaultReportService _service;
        private readonly ISMSNotifyer _notifier;

        public FaultReportController(IFaultReportService service, ISMSNotifyer notifier)
        {
            _service = service;
            _notifier = notifier;
        }

        [HttpGet]
        [Authorize(Roles = "Resident,PropertyManager")]
        public async Task<IActionResult> GetAllFaultReports()
        {
            var oid = User.FindFirst(ClaimConstants.ObjectId)?.Value;

            if (oid == null)
                return Unauthorized();

            if (User.IsInRole("PropertyManager"))
            {
                return Ok(await _service.GetAllFaultReports(null));
            }

            return Ok(await _service.GetAllFaultReports(oid));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Resident,PropertyManager")]
        public async Task<IActionResult> GetFaultReportFromId(int id)
        {
            var oid = User.FindFirst(ClaimConstants.ObjectId)?.Value;

            if (oid == null)
                return Unauthorized();

            if (User.IsInRole("PropertyManager"))
            {
                var result = await _service.GetFaultReportFromId(id, null);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            else
            {
                var result = await _service.GetFaultReportFromId(id, oid);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Resident,PropertyManager")]
        public async Task<IActionResult> CreateFaultReport(CreateFaultReportDTO faultReportRequest)
        {
            var oid = User.FindFirst(ClaimConstants.ObjectId)?.Value;

            if (oid == null)
                return Unauthorized();

            await _service.CreateFaultReport(faultReportRequest, oid);

            await _notifier.Notify("Hey new report!");

            return Created();
        }

        [HttpPut]
        [Authorize(Roles = "PropertyManager")]
        public async Task<IActionResult> UpdateFaultReport(UpdateFaultReportDTO faultReportRequest)
        {
            var oid = User.FindFirst(ClaimConstants.ObjectId)?.Value;

            if (oid == null)
                return Unauthorized();

            var result = await _service.UpdateFaultReport(faultReportRequest);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "PropertyManager")]
        public async Task<IActionResult> DeleteFaultReport(int id)
        {
            var oid = User.FindFirst(ClaimConstants.ObjectId)?.Value;

            if (oid == null)
                return Unauthorized();

            var result = await _service.DeleteFaultReport(id);
            if (result == true)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
