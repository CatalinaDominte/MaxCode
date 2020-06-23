using System.Data.Entity.ModelConfiguration;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Persistence.EntityConfigurations
{
    public class PetStatusConfiguration : EntityTypeConfiguration<PetStatus>
    {
        public PetStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}