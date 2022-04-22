using Assets.Scripts.GameObjects.Scenes;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. Interface that displays the playlist of songs, and is a child component of Arcade Screen.
    /// </summary>
    public class PlaylistInterfacePrefab : MonoBehaviour
    {
        public GameObject SongTemplate;
        public GameObject Content;

        public static bool CreateSongButtonClicked => createSongButtonClicked;
        private static bool createSongButtonClicked;
        private static int currentNumSongs;
        private void Start()
        {
            ResetClickEvents();
            currentNumSongs = 0;
        }
        private void Update()
        {
            if (Menu.Songs != null && Menu.Songs.Count > currentNumSongs)
            {
                currentNumSongs = Menu.Songs.Count;
                AddSongsToMenu();
            }
        }
        public static void ResetClickEvents()
        {
            createSongButtonClicked = false;
        }
        public void OnCreateSongButton_Clicked()
        {
            createSongButtonClicked = true;
        }

        /// <summary>
        /// Adds selectable songs to Menu within the playlist.
        /// </summary>
        private void AddSongsToMenu()
        {
            foreach (Song song in Menu.Songs)
            {
                var copy = Instantiate(SongTemplate);
                var songTemplate = copy.GetComponent<SongTemplatePrefab>();
                songTemplate.Song = song;
                copy.transform.SetParent(Content.transform, false);
            }
        }
    }
}
