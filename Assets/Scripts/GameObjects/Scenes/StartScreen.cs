using Assets.Scripts.DataStorage;
using Assets.Scripts.GameObjects.Prefabs;
using Assets.Scripts.Input;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameObjects.Scenes
{
    public class StartScreen : MonoBehaviour
    {
        private List<Song> songs;
        private static int menuSceneLoad;
        void Start()
        {
            menuSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
            //GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundAudioPrefab>().PlayAudio();

            if (SongStorage.Songs.Count > 0)    songs = SongStorage.Songs;
            else                                songs = new List<Song>();
        }

        void Update()
        {
            if (UnityEngine.Input.anyKey)
            {
                LoadMenuScene();
            }
        }
        public void LoadMenuScene()
        {
            Menu.Songs = songs;
            SceneManager.LoadScene(menuSceneLoad);
        }
    }
}
