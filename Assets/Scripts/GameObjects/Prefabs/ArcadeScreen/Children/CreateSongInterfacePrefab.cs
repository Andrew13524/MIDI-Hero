using Assets.Scripts.GameObjects.UI;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. Is the interface used when creating a new song, and is a child component of Arcade Screen.
    /// </summary>
    public class CreateSongInterfacePrefab : MonoBehaviour
    {
        public static AudioClip AudioClip;
        public static bool ConfirmButtonClicked => confirmButtonClicked;
        public static bool CancelButtonClicked => cancelButtonClicked;
        public static bool SelectSongFromExplorerButtonClicked => selectSongFromExplorerButtonClicked;
        
        private static bool confirmButtonClicked;
        private static bool cancelButtonClicked;
        private static bool selectSongFromExplorerButtonClicked;

        private void Start()
        {
            ResetClickEvents();
        }
        public static void ResetClickEvents()
        {
            confirmButtonClicked = false;
            cancelButtonClicked = false;
            selectSongFromExplorerButtonClicked = false;
        }

        public void OnConfirmButton_Clicked() => confirmButtonClicked = TitleInputField.Title != null || ArtistInputField.Artist != null || AudioClip != null;
        public void OnCancelButton_Clicked() => cancelButtonClicked = true;
        public void OnSelectSongFromExplorerButton_Clicked() => selectSongFromExplorerButtonClicked = true;
    }
}
