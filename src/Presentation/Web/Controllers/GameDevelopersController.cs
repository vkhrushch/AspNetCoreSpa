using System.Threading.Tasks;
using AspNetCoreSpa.Application.Features.GameDevelopers.Commands.CreateGameDeveloper;
using AspNetCoreSpa.Application.Features.GameDevelopers.Commands.DeleteGameDeveloper;
using AspNetCoreSpa.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper;
using AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDeveloperDetail;
using AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDevelopersList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.Web.Controllers
{
    public class GameDevelopersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GameDevelopersListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetGameDevelopersListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GameDeveloperDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetGameDeveloperDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateGameDeveloperCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateGameDeveloperCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGameDeveloperCommand { Id = id });

            return NoContent();
        }
    }
}
