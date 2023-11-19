using Microsoft.EntityFrameworkCore;

namespace Wilgnne.Agenda.Infra.DbContext
{
    public class AgendaContext(DbContextOptions<AgendaContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
    }
}
