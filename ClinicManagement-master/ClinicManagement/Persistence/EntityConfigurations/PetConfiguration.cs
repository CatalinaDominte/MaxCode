using System.Data.Entity.ModelConfiguration;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Persistence.EntityConfigurations
{
    public class PetConfiguration : EntityTypeConfiguration<Pet>
    {
        public PetConfiguration()
        {
            Property(p => p.TypeId).IsRequired();
            Property(p => p.OwnerName).IsRequired().HasMaxLength(255);
            Property(p => p.Phone).IsRequired().HasMaxLength(255);
            Property(p => p.Address).IsRequired().HasMaxLength(255);
            Property(p => p.Age).IsRequired();
            Property(p => p.Token).IsRequired();
            HasMany(p => p.Appointments)
                .WithRequired(a => a.Pet)
                .WillCascadeOnDelete(false);
        }
    }
}