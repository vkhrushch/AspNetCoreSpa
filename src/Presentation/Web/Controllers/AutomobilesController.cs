using AspNetCoreSpa.Application.Features.Automobiles.Commands.CreateAutomobile;
using AspNetCoreSpa.Application.Features.Automobiles.Commands.DeleteAutomobile;
using AspNetCoreSpa.Application.Features.Automobiles.Commands.UpdateAutomobile;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Web.Controllers
{
    public class AutomobilesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<AutomobilesListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetAutomobilesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AutomobileDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetAutomobileDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateAutomobileCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateAutomobileCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAutomobileCommand { Id = id });

            return NoContent();
        }
    }
}
