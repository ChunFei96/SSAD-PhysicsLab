using AutoMapper;
using DAL;
using System.Collections.Generic;
using Core.Expansion.Enum;

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

        public List<DAL.Entities.Leaderboard> GetLeaderboard(GameType TopicName)
        {
            return _unitOfWork.LeaderboardRepository.GetAndInclude(l => l.Type == TopicName, null, x=> x.Topic, x=> x.Topic.Student, x=> x.Topic.Student.User);
        }
    }
}
