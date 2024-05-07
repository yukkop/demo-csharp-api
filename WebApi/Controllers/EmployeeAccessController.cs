using Logic.Model.Dto.Employer;
using Logic.Model.Result.Shared;
using Logic.Model.Result.Shared.Obsolete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/employee-access")]
public class EmployeeAccessController
{
    // [HttpPatch("{code:guid}")]
    // public async Task<ActionResult<IHandler<EmployerResponseModel>>> GetAll()
    // {
    //     return await _logic.GetAll() switch {
    //         List<EmployerResponseModel> list => Ok(list),
    //         ListException<EmployerResponseModel> exception => Conflict(exception),
    //         _ => throw new InvalidOperationException("Unexpected result type from _logic.Add")
    //     };
    // }
    

    [HttpGet("{id:guid}/employed")]
    public async Task<ActionResult<IHandler<EmployerResponseModel>>> IsEmployed()
    {
        throw new NotImplementedException();
    }
}