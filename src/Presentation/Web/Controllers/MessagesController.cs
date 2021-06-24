using AspNetCoreSpa.Application.Features.Messages.Commands.CreateMessage;
using AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageDetail;
using AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList;
using AspNetCoreSpa.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Linq;
using System.Collections.Generic;
using AspNetCoreSpa.Application.Abstractions;

namespace AspNetCoreSpa.Web.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly IUserInformation _users;
        public MessagesController(IUserInformation users)
        {
            _users = users;
        }

        [HttpGet]
        public async Task<ActionResult<MessageListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetMessageListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageListVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetMessageDetailQuery { Id = id });

            return Ok(vm);
        }
        public async Task<ActionResult<MessageListVm>> GetAllByRoom(int id)
        {
            var vm = await Mediator.Send(new GetMessageListQuery { RoomId = id });

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(int chatRoomId, string text, string userName)
        {
            var allUsers = _users.GetUsers();
            var currentUser = new ApplicationUser { Id = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)), Email = userName };
            var messageId = await Mediator.Send(new CreateMessageCommand { ChatRoomId = chatRoomId, Text = text, MessageTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), UserName = currentUser.Email, UserId = currentUser.Id });
            
            return Ok(messageId);
        }
    }
}
