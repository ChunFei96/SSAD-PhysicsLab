using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;

        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<Students> _studentsRepository;
        private readonly IRepository<Leaderboard> _leaderboardRepository;
        private readonly IRepository<Topic> _topicRepository;
        private readonly IRepository<GameTopic> _gameTopicRepository;
        private readonly IRepository<Level> _levelRepository;
        public UnitOfWork(EFDbContext context,
             IRepository<Users> usersRepository,
             IRepository<Students> studentsRepository,
             IRepository<Leaderboard> leaderboardRepository,
             IRepository<Topic> topicRepository,
             IRepository<GameTopic> gameTopicRepository,
             IRepository<Level> levelRepository)
        {
            _context = context;
            _usersRepository = usersRepository;
            _studentsRepository = studentsRepository;
            _leaderboardRepository = leaderboardRepository;
            _topicRepository = topicRepository;
            _gameTopicRepository = gameTopicRepository;
            _levelRepository = levelRepository;


        }

        public IRepository<Users> UsersRepository => _usersRepository;
        public IRepository<Students> StudentsRepository => _studentsRepository;
        public IRepository<Leaderboard> LeaderboardRepository => _leaderboardRepository;
        public IRepository<Topic> TopicRepository => _topicRepository;
        public IRepository<GameTopic> GameTopicRepository => _gameTopicRepository;
        public IRepository<Level> LevelRepository => _levelRepository;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
