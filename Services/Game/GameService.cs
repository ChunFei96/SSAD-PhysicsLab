using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Game
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void SaveGameScore(string username, string topicname, string levelnumber, int score, int timecompleted)
        {
            Users user = _unitOfWork.UsersRepository.Get(u => u.Username.Equals(username)).FirstOrDefault();
            Students student = _unitOfWork.StudentsRepository.Get(s => s.UserId == user.Id).FirstOrDefault();
            if (user != null)
            {
                var ss = Core.Expansion.Enum.GameTopic.Mass;
                Core.Expansion.Enum.GameTopic gameTopicEnum = (Core.Expansion.Enum.GameTopic)Enum.Parse(typeof(Core.Expansion.Enum.GameTopic), topicname);
                GameTopic gameTopic = _unitOfWork.GameTopicRepository.Get(g => g.GameTopicEnum == gameTopicEnum).FirstOrDefault();
                if(gameTopic != null)
                {
                    Level level = _unitOfWork.LevelRepository.Get(l => l.GameTopicId == gameTopic.Id).FirstOrDefault();
                    if(level != null)
                    {
                        if(!isRecordExist(student,level))
                        {
                            DAL.Entities.Leaderboard newRecord = new DAL.Entities.Leaderboard();
                            newRecord.LevelId = level.Id;
                            newRecord.StudentId = student.Id;
                            newRecord.Score = score;
                            newRecord.TimeCompleted = timecompleted;
                            newRecord.TrialCount = 1;

                            _unitOfWork.LeaderboardRepository.Insert(newRecord);
                            _unitOfWork.Commit();
                        }
                        else
                        {
                            DAL.Entities.Leaderboard existingRecord = _unitOfWork.LeaderboardRepository.Get(l => l.LevelId == level.Id && l.StudentId == student.Id).FirstOrDefault();

                            if(score > existingRecord.Score && timecompleted <= existingRecord.TimeCompleted)
                            {
                                existingRecord.Score = score;
                                existingRecord.TimeCompleted = timecompleted;
                                existingRecord.TrialCount += 1;

                                _unitOfWork.LeaderboardRepository.Update(existingRecord);
                                _unitOfWork.Commit();
                            }
                        }
                        
                    }
                }
            }
        }

        private bool isRecordExist(Students student, Level level)
        {
            DAL.Entities.Leaderboard record = _unitOfWork.LeaderboardRepository.Get(l => l.LevelId == level.Id && l.StudentId == student.Id).FirstOrDefault();
            if (record != null)
                return true;
            return false;
        }
    }
}
