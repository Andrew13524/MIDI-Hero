using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Song
    {
        /// <summary>
        /// Length of song in seconds.
        /// </summary>
        public float Length => length;
        public string Title => title;
        public string Artist => artist;
        public bool IsCompleted => isCompleted;
        public int Score { get => score; set => score = value; }
        public int Streak { get => streak; set => streak = value; } 
        public int DifficultyRating => difficultyRating;
        public AudioClip AudioClip => audioClip;
        public Queue<Note> Notes => notes;

        private float length
        {
            get
            {
                try
                {
                    return Notes.Last().TimeStamp;
                }
                catch { return 0; }
            }
        }
        private int difficultyRating 
        { 
            get 
            {
                try
                {
                    return (int)((Notes.Count / length) * 10);
                }
                catch { return 0; }
            } 
        }

        private readonly string title;
        private readonly string artist;
        private readonly bool isCompleted;
        private int score;
        private int streak;
        private readonly AudioClip audioClip;
        private readonly Queue<Note> notes;
        

        public Song() 
        {
            isCompleted = false;
            score = 0;
            streak = 0;
            notes = new Queue<Note>(); 
        }
        public Song(string title, string artist, AudioClip audioClip, Queue<Note> notes)
        {
            this.title = title;
            this.artist = artist;
            this.audioClip = audioClip;
            this.notes = notes;
            isCompleted = false;
            score = 0;
            streak = 0;
        }
        public Song(string title, string artist, AudioClip audioClip)
        {
            this.title = title;
            this.artist = artist;
            this.audioClip = audioClip;
            isCompleted = false;
            score = 0;
            streak = 0;
            notes = new Queue<Note>();
        }
    }
}
