using System.Threading.Tasks;
using AspNetCoreSpa.Application.Extensions;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList;
using AspNetCoreSpa.Application.Features.ChatRooms.Commands.CreateChatRoom;
using AspNetCoreSpa.Application.Features.ChatRooms.Commands.DeleteChatRoom;
using AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomList;
using AspNetCoreSpa.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCoreSpa.Web.Controllers
{
    public class ChatRoomsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ChatRoomsListVm>> GetAll()
        {
            var currentUser = new ApplicationUser { Id = 1.ToGuid(), Email = "admin@admin.com" };
            var currentUser1 = new ApplicationUser { Id = 2.ToGuid(), Email = "user@user.com" };
            var vm = await Mediator.Send(new GetChatRoomsListQuery { UserId = currentUser.Id});

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(string chatRoomName)
        {
            await Mediator.Send(new CreateChatRoomCommand { Name = chatRoomName });
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteChatRoomCommand { Id = id });
            return NoContent();
        }
    }
}
