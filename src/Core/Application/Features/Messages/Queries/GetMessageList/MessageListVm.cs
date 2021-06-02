using System.Collections.Generic;


namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList
{
    public class MessageListVm
    {
        public IList<MessageLookupDto> Messages { get; set; }
    }
}
