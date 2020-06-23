using System.Data.Entity.ModelConfiguration;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Persistence.EntityConfigurations
{
    public class AnimalTypeConfiguration : EntityTypeConfiguration<AnimalType>
    {
        public AnimalTypeConfiguration()
        {
            Property(p => p.Type).IsRequired().HasMaxLength(255);
        }
    }
}