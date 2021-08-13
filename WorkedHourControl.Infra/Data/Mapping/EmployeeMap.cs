using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class EmployeeMap : EntityBaseMap<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
