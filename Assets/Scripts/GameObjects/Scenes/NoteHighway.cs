using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Assets.Scripts.Models;
using Assets.Scripts.Input;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.GameObjects.Prefabs;

namespace Assets.Scripts.GameObjects.Scenes
{
    public enum NoteHighwayState { PLAY, RECORD }
    public class NoteHighway : MonoBehaviour
    {
        public GameObject NotePrefab;
        public AudioSource AudioSource;

        public static NoteHighwayState NoteHighwayState;
        public static Song Song;
        public static int Health;
        public static int HitNotes;
        public static int MissedNotes;
        public static byte[] lastPressedNotes;
        public static byte[] PressedNotes;
        public static Vector2 ScreenBounds;
        /// <summary>
        /// Refers to the live feed of current notes being discarded of within the scene. 
        /// </summary>
        public static Queue<Note> LiveFeed;

        /// <summary>
        /// Distance notes travel.
        /// </summary>
        private float lookAhead;
        /// <summary>
        /// Time (in seconds) of how long it takes for each note to reach the ActionBar.
        /// </summary>
        private float delay;
        /// <summary>
        /// The ID for the Menu Scene.
        /// </summary>
        private int menuSceneLoad;

        private Dictionary<HitBox, int> ScoreValue = new Dictionary<HitBox, int>()
        {
            { HitBox.MISS, 0 },
            { HitBox.OKAY, 10 },
            { HitBox.GOOD, 25 },
            { HitBox.GREAT, 50 },
            { HitBox.PERFECT, 100 }
        };
        
        private void Start()
        {
            // Resetting score
            Song.Streak = 0;
            Song.Score = 0;
            MissedNotes = 0;
            HitNotes = 0;
            lastPressedNotes = new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
            LiveFeed = new Queue<Note>();

            menuSceneLoad = SceneManager.GetActiveScene().buildIndex - 1;
            GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundAudioPrefab>().StopAudio();
            ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            
            lookAhead = (float)Math.Abs(ActionBarPrefab.ActionNoteY) + (float)Math.Abs(Constants.NOTE_SPAWN_POSITION_Y); // distance notes travel
            delay = lookAhead / Constants.NOTE_SPEED;

            AudioSource.clip = Song.AudioClip;

            StartCoroutine(PlayAudioFromStart());

            if (NoteHighwayState == NoteHighwayState.PLAY)
                StartCoroutine(DeployNotes());
        }

        private void Update()
        {
            PressedNotes = InputDevice.PressedNotes();

            if(NoteHighwayState == NoteHighwayState.RECORD)
            {
                Record();
                if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)) FinishRecording();
            }
            else if(NoteHighwayState == NoteHighwayState.PLAY)
            {
                HandleFeed();
                if (TimerPrefab.CurrentTime >= Song.Length || UnityEngine.Input.GetKeyDown(KeyCode.Escape)) 
                    StartCoroutine(FinishPlaying());
            }
        }

        /// <summary>
        /// Handles the finalization of the recording process.
        /// </summary>
        public void FinishRecording()
        {
            Menu.Songs.Add(Song);
            LoadMenuScene(Interface.Playlist);
        }

        /// <summary>
        /// Updates stats and returns to menu.
        /// </summary>
        private IEnumerator FinishPlaying()
        {
            // Display dialogue with stats
            // Save stats
            User.UpdateScores(new SongData(Song));
            yield return new WaitForSeconds(Constants.SONG_LENGTH_PADDING);
            LoadMenuScene(Interface.FinishedSong);
        }
        private void LoadMenuScene(Interface infc)
        {
            if (infc == Interface.FinishedSong) FinishedSongInterfacePrefab.Song = Song;
            ArcadeScreenPrefab.ActiveInterface = infc;
            SceneManager.LoadScene(menuSceneLoad);
        }
        /// <summary>
        /// Used in PLAY mode. Reads LiveFeed and determines whether the user hit or missed a note.
        /// </summary>
        private void HandleFeed()
        {
            while (LiveFeed.Any())
            {
                Note note = LiveFeed.Dequeue();

                if (note.HitBox != HitBox.MISS) OnHit(note);
                else                            OnMiss();
            }
        }
        /// <summary>
        /// Used in PLAY mode. If the user hits a note, adds to HitNotes, Combo, and Score.
        /// </summary>
        /// <param name="note">Takes in the note that the player hit.</param>
        private void OnHit(Note note)
        {
            HitNotes++;
            Song.Streak++;
            Song.Score += ScoreValue[note.HitBox] * Song.Streak;
        }
        /// <summary>
        /// Used in PLAY mode. If the user misses a note, adds to MissedNotes and resets Combo.
        /// </summary>
        private void OnMiss()
        {
            MissedNotes++;
            Song.Streak = 0;
        }
        /// <summary>
        /// Used in PLAY mode. Deploys the notes from the queue within a Song.
        /// </summary>
        /// <returns>Waits for a specificed amount of seconds in-between deploying each note.</returns>
        private IEnumerator DeployNotes()
        {
            while (Song.Notes.Any())
            {
                var note = Song.Notes.Dequeue();
                yield return new WaitForSeconds(Math.Abs(note.TimeStamp - TimerPrefab.CurrentTime));

                NotePrefab.transform.position = new Vector3(
                    (float)note.Key + Constants.NOTE_HORIZONTAL_OFFSET + (Constants.NOTE_HORIZONTAL_PADDING * (float)note.Key),
                    Constants.NOTE_SPAWN_POSITION_Y,
                    0);
                
                Instantiate(NotePrefab);
            }
        }
        /// <summary>
        /// Used in RECORD mode. Records the user input and saves their input into Notes. Must be called every frame.
        /// </summary>
        private void Record()
        {
            for (int i = 0; i < PressedNotes.Length; i++)
            {
                if (PressedNotes[i] == 1)
                {
                    if (lastPressedNotes[i] == 0)
                    {
                        Song.Notes.Enqueue(new Note((Key)i, TimerPrefab.CurrentTime - delay));
                    }
                }
                lastPressedNotes[i] = PressedNotes[i];
            }
        }
        /// <summary>
        /// Plays the audio for a song from the beginning.
        /// </summary>
        /// <returns>Waits for the delay (in seconds) before starting the audio.</returns>
        private IEnumerator PlayAudioFromStart()
        {
            yield return new WaitForSeconds(delay);
            AudioSource.Stop();
            AudioSource.Play();
        }
    }
}
