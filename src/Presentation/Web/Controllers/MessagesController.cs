using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Extensions;
using AspNetCoreSpa.Application.Features.Employees.Commands.DeleteEmployee;
using AspNetCoreSpa.Application.Features.Messages.Commands.CreateMessage;
using AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageDetail;
using AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList;
using AspNetCoreSpa.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Web.Controllers
{
    public class MessagesController : BaseController
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //public MessagesController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        //private readonly ClaimsPrincipal _user;
        //public MessagesController(IHttpContextAccessor httpContextAccessor)
        //{
        //    _user = httpContextAccessor.HttpContext.User;
        //}



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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create(int chatRoomId, string text)
        {
            var currentUser = new ApplicationUser { Id = 1.ToGuid(), Email = "admin@admin.com", };
            //var user = AspNetCoreSpa.STS.Areas.Identity.Pages.Account.ExternalLoginModel._loggedUser;
            //var userId = _userManager.GetUserId(HttpContext.User);
            await Mediator.Send(new CreateMessageCommand { ChatRoomId = chatRoomId, Text = text, MessageTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), UserName = currentUser.Email, UserId = currentUser.Id });
            
            return NoContent();
        }
    }
}
