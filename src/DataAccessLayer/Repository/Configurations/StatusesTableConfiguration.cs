using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class StatusesTableConfiguration : BaseTableConfiguration<StatusEntity, int>
    {
        public StatusesTableConfiguration() : base("Statuses")
        {
            Property(e => e.Name).IsRequired();
        }
    }
}
