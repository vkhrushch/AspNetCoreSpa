using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
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
        private readonly IUserInformation _users;
        public ChatRoomsController(IUserInformation users)
        {
            _users = users;
        }

        [HttpGet]
        public async Task<ActionResult<ChatRoomsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetChatRoomsListQuery { UserId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)) });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(string chatRoomName, string[] participantNames)
        {
            var paticipants = _users.GetUsers().Where(i => participantNames.Contains(i.Value)).ToDictionary(k=>k.Key,v=>v.Value);
            await Mediator.Send(new CreateChatRoomCommand { Name = chatRoomName, Participents = paticipants });
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<string[]>> GetAllChatRoomUsers()
        {
            return Ok(_users.GetUsers().Values.ToArray());
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
