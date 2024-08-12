using MediatR;


namespace GymManager.Application.Tickets.Command.AddTicket;

public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand>
{
    public async Task<Unit> Handle(AddTicketCommand request, CancellationToken cancellationToken)
    {
        //var ticket = new Ticket();
        //ticket.Name = request.Name;
        //zapis

        return Unit.Value;
    }
}
