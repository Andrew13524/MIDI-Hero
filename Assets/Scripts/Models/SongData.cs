using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public struct SongData
    {
        public string Title;
        public bool IsCompleted;
        public int HighScore;
        public int LongestStreak;

        public SongData(string title, bool isCompleted, int highScore, int longestStreak)
        {
            Title = title;
            IsCompleted = isCompleted;
            HighScore = highScore;
            LongestStreak = longestStreak;
        }
        public SongData(Song song)
        {
            Title = song.Title;
            IsCompleted = song.IsCompleted;
            HighScore = song.Score;
            LongestStreak = song.Streak;
        }
    }
}
