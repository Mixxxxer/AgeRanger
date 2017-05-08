using AgeRanger.Interfaces.Data.Repositories;

namespace AgeRanger.Domain.Services
{
    public interface IRangeService
    {
    }

    public class RangeService : IRangeService
    {
        private readonly IRangeRepository rangeRepository;

        public RangeService(IRangeRepository rangeRepository)
        {
            this.rangeRepository = rangeRepository;
        }
    }
}
