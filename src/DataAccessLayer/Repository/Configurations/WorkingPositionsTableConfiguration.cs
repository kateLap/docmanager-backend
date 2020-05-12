using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class WorkingPositionsTableConfiguration : BaseTableConfiguration<WorkingPositionEntity, int>
    {
        public WorkingPositionsTableConfiguration() : base("WorkingPositions")
        {
            Property(e => e.Name).IsRequired();
        }
    }
}
