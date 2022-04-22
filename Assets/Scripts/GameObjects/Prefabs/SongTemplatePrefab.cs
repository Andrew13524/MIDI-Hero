using Assets.Scripts.GameObjects.Scenes;
using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. A clickable object within the playlist that contains a song.
    /// </summary>
    public class SongTemplatePrefab : MonoBehaviour
    {
        public Song Song = new Song();

        public void OnClick()
        {
            // Creating a copy of the queue so that Note Highway doesnt dequeue the original queue
            var notes = new Queue<Note>();
            foreach (Note note in Song.Notes)
            {
                notes.Enqueue(note);
            }
            Song copy = new Song(Song.Title, Song.Artist, Song.AudioClip, notes);
            Menu.LoadNoteHighwayScene(copy, NoteHighwayState.PLAY);
        }
    }
}
