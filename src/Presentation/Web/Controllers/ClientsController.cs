using AspNetCoreSpa.Application.Features.Clients.Queries.GetClientDetail;
using AspNetCoreSpa.Application.Features.Clients.Queries.GetClientList;
using AspNetCoreSpa.Application.Features.Clients.Commands.CreateClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Features.Clients.Commands.UpdateClient;
using AspNetCoreSpa.Application.Features.Clients.Commands.DeleteClient;

namespace AspNetCoreSpa.Web.Controllers
{
    public class ClientsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ClientsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetClientsListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDetailVm>> Get(string id)
        {
            var vm = await Mediator.Send(new GetClientDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateClientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateClientCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteClientCommand { Id = id });

            return NoContent();
        }
    }
}
