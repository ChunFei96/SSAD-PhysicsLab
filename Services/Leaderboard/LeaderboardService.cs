using AutoMapper;
using DAL;
using System.Collections.Generic;

namespace Services.Leaderboard
{
    public partial class LeaderboardService : ILeaderboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaderboardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<DAL.Entities.Leaderboard> GetLeaderboard()
        {
            return _unitOfWork.LeaderboardRepository.GetAndInclude(null,null, x=> x.Topic);
        }
    }
}
