using DAL.Entities;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Users> UsersRepository { get; }
        IRepository<Students> StudentsRepository { get; }
        IRepository<Leaderboard> LeaderboardRepository { get; }
        IRepository<Topic> TopicRepository { get; }
        IRepository<GameTopic> GameTopicRepository { get; }
        IRepository<Level> LevelRepository { get; }
        void Commit();
    }
}
