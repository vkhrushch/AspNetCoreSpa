using AspNetCoreSpa.Application.Features.CarExperts.Commands.CreateCarExpert;
using AspNetCoreSpa.Application.Features.CarExperts.Commands.DeleteCarExpert;
using AspNetCoreSpa.Application.Features.CarExperts.Commands.UpdateCarExpert;
using AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertDetail;
using AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Web.Controllers
{
    public class CarExpertController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CarExpertsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetCarExpertsListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CarExpertDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetCarExpertDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCarExpertCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateCarExpertCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCarExpertCommand { Id = id });

            return NoContent();
        }
    }
}
