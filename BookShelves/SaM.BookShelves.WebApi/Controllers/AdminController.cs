using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaM.BookShelves.Common.Routes;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.ViewModels;

namespace SaM.BookShelves.WebApi.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        private readonly ILibrariensService _librariensService;

        public AdminController(IOfficeService officeService, ILibrariensService librariensService)
        {
            _officeService = officeService;
            _librariensService = librariensService;
        }

        [HttpGet(RoutesApi.Admin.GetAllOffices)]
        public async Task<IActionResult> GetAllOffices()
        {
            var res = await _officeService.GetAllOffices();

            return Ok(res);
        }

        [HttpGet(RoutesApi.Admin.GetAllLibrariens)]
        public async Task<IActionResult> GetAllLibrariens()
        {
            var res = await _librariensService.GetAllLibrariens();

            var a = res;

            return Ok(res);
        }

        [HttpPost(RoutesApi.Admin.AddOffice)]
        public async Task<IActionResult> AddOffice([FromForm]OfficeViewModel model)
        {
            var addOfficeResponse = await _officeService.AddOffice(model);

            if (!addOfficeResponse.Result)
            {
                return BadRequest(new ResponseViewModel
                {
                    Message = addOfficeResponse.Message
                });
            }
            else
            {
                return Ok(new ResponseViewModel
                {
                    Message = addOfficeResponse.Message
                });
            }
        }

        [HttpDelete(RoutesApi.Admin.DeleteOffice)]
        public IActionResult Delete(string officeId)
        {
            _officeService.DeleteOfficeById(officeId);

            return Ok();
        }

        [HttpPost(RoutesApi.Admin.UpdateOffice)]
        public IActionResult UpdateAccount([FromForm]OfficeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = _officeService.UpdateOffice(model);

                if (result.Result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest(new ResponseViewModel()
                {
                    Result = false,
                    Message = "Not Valid!"
                });
            }
        }

        [HttpPost(RoutesApi.Admin.GetSearchOffice)]
        public IActionResult GetSearchOffice([FromForm] string termSearchOffice)
        {
            var res = _officeService.GetSearchOffice(termSearchOffice);

            return Ok(res);
        }
    }
}