using AutoMapper;
using DAL;
using System.Collections.Generic;
using Core.Expansion.Enum;
using System.Linq;

namespace Services.Leaderboard
{
    public partial class LeaderboardService : ILeaderboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaderboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DAL.Entities.Leaderboard> GetLeaderboard(GameTopic TopicName)
        {
            DAL.Entities.GameTopic gameTopic = _unitOfWork.GameTopicRepository.Get(g => g.GameTopicEnum == TopicName).FirstOrDefault();

            if(gameTopic != null)
            {
                List<DAL.Entities.Level> levels = _unitOfWork.LevelRepository.Get(l => l.GameTopicId == gameTopic.Id).ToList();
                if(levels != null && levels.Count() > 0)
                {
                    return _unitOfWork.LeaderboardRepository.GetAndInclude(l => levels.Contains(l.Level), null, x => x.Level, x => x.Level.GameTopic, x => x.Student,  x => x.Student.User);
                }
            }
            return null;
        }
    }
}
