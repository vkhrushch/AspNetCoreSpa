using MediatR;

namespace AspNetCoreSpa.Application.Features.CarExperts.Commands.DeleteCarExpert
{
    public class DeleteCarExpertCommand : IRequest
    {
        public int Id { get; set; }
    }
}
