using System.Threading.Tasks;
using AspNetCoreSpa.Application.Features.Games.Commands.CreateGame;
using AspNetCoreSpa.Application.Features.Games.Commands.DeleteGame;
using AspNetCoreSpa.Application.Features.Games.Commands.UpdateGame;
using AspNetCoreSpa.Application.Features.Games.Queries.GetGameDetail;
using AspNetCoreSpa.Application.Features.Games.Queries.GetGamesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.Web.Controllers
{
    public class GamesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GamesListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetGamesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GameDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetGameDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateGameCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateGameCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGameCommand { Id = id });

            return NoContent();
        }
    }
}
