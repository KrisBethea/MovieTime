using Interfaces;

namespace Services
{
    public class TicketService : ITicketService
    {

        private ILogger<TicketService> _logger;

        public TicketService(ILogger<TicketService> logger)
        {
            this._logger = logger;
        }
    }
}
