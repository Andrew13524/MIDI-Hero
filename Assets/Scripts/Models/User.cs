using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class User
    {
        public static string Name;
        public static Dictionary<string, bool> IsCompleted;
        public static Dictionary<string, int> HighScore;
        public static Dictionary<string, int> LongestStreak;
        public static bool IsLoggedIn => isLoggedIn;
        private static bool isLoggedIn;
        public User()
        {
            Name = "";
            isLoggedIn = false;
            IsCompleted = new Dictionary<string, bool>();
            HighScore = new Dictionary<string, int>();
            LongestStreak = new Dictionary<string, int>();
        }
        public User(string name)
        {
            Name = name;
            isLoggedIn = true;
            IsCompleted = new Dictionary<string, bool>();
            HighScore = new Dictionary<string, int>();
            LongestStreak = new Dictionary<string, int>();
        }
        public static void UpdateScores(SongData songData)
        {
            if (SongExists(songData))
            {
                if (songData.IsCompleted   && !IsCompleted[songData.Title])      IsCompleted[songData.Title]   = songData.IsCompleted;
                if (songData.HighScore      > HighScore[songData.Title])         HighScore[songData.Title]     = songData.HighScore;
                if (songData.LongestStreak  > LongestStreak[songData.Title])     LongestStreak[songData.Title] = songData.LongestStreak;
            }
            else
            {
                IsCompleted.Add  (songData.Title, songData.IsCompleted);
                HighScore.Add    (songData.Title, songData.HighScore);
                LongestStreak.Add(songData.Title, songData.LongestStreak);
            }
        }
        public static bool SongExists(SongData songData)
        {
            if (IsCompleted.ContainsKey(songData.Title)) return true;
            else return false;
        }
    }
    
}
