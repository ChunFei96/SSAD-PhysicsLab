using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Game
{
    public interface IGameService
    {
        void SaveGameScore(string username, string topicname, string levelnumber, int score, int timecompleted);
    }
}
