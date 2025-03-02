using KargoTakip.Application.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Edm;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;

namespace KargoTakip.WebApi.Controllers
{
    [Route("odata")]
    [ApiController]
    [EnableQuery]
    public class AppODataController(
      ISender sender) : ODataController
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EnableLowerCamelCase();
            builder.EntitySet<EmployeeGetAllQueryResponse>("employees");
            return builder.GetEdmModel();
        }

        [HttpGet("employees")]
        public async Task<IQueryable<EmployeeGetAllQueryResponse>> GetAllEmployees(CancellationToken cancellationToken)
        {
            var response = await sender.Send(new EmployeeGetAllQuery(), cancellationToken);
            return response;
        }
    }
}