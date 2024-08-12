using MediatR;


namespace GymManager.Application.Tickets.Command.AddTicket;

public class AddTicketCommand : IRequest
{
    public string Name { get; set; }
}
