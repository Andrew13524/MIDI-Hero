using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.DataStorage;
using Assets.Scripts.GameObjects;
using Assets.Scripts.GameObjects.Prefabs;

namespace Assets.Scripts.GameObjects.Scenes
{
    public class Menu : MonoBehaviour
    {
        public static List<Song> Songs = new List<Song>();

        private static int noteHighwaySceneLoad;

        void Start()
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundAudioPrefab>().PlayAudio();
            noteHighwaySceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

        public static void LoadNoteHighwayScene(Song song, NoteHighwayState noteHighwayState)
        {
            NoteHighway.Song = song;
            NoteHighway.NoteHighwayState = noteHighwayState;
            SceneManager.LoadScene(noteHighwaySceneLoad);
        }
    }
}
