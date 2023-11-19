using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext.Configurations
{
    public class SchoolSubjectEntityTypeConfiguration : IEntityTypeConfiguration<SchoolSubject>
    {
        public void Configure(EntityTypeBuilder<SchoolSubject> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Subject)
                .IsRequired();
        }
    }
}
