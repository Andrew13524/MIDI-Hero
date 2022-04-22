using Assets.Scripts.GameObjects.Prefabs;
using Assets.Scripts.GameObjects.Scenes;
using Assets.Scripts.GameObjects.UI;
using Assets.Scripts.Input;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GameObjects.Prefabs
{
    public enum Interface { NewUser, Playlist, CreateSong, FinishedSong }
    /// <summary>
    /// Located in MENU Scene. Handles the arcade screen and all of its children components.
    /// </summary>
    public class ArcadeScreenPrefab : MonoBehaviour
    {
        public GameObject NewUserInterface;
        public GameObject PlaylistInterface;
        public GameObject CreateSongInterface;
        public GameObject FinishedSongInterface;
        public static Interface? ActiveInterface;

        private string songFolderPath;

        private void Start()
        {
            if (ActiveInterface != null) SetActiveInterface(ActiveInterface);
            else SetActiveInterface(Interface.NewUser);
        }
        /// <summary>
        /// Depending on which interface is currently active, handle the click events.
        /// </summary>
        private void Update()
        {
            switch (ActiveInterface)
            {
                case Interface.NewUser:
                    if (NewUserInterfacePrefab.OKButtonClicked) HandleNewUserOKButton_Clicked();
                    break;
                case Interface.Playlist:
                    if (PlaylistInterfacePrefab.CreateSongButtonClicked) HandlePlaylistCreateSongButton_Clicked();
                    break;
                case Interface.CreateSong:
                    if (CreateSongInterfacePrefab.ConfirmButtonClicked) HandleCreateSongConfirmButton_Clicked();
                    if (CreateSongInterfacePrefab.CancelButtonClicked) HandleCreateSongCancelButton_Clicked();
                    if (CreateSongInterfacePrefab.SelectSongFromExplorerButtonClicked) HandleCreateSongSelectSongFromExplorerButton_Clicked();
                    break;
                case Interface.FinishedSong:
                    if (FinishedSongInterfacePrefab.OKButtonClicked) HandleFinishedSongOKButton_Clicked();
                    break;
            }
        }

        /// <summary>
        /// Sets active interface in the scene.
        /// </summary>
        /// <param name="infc">The interface to be set active within the scene</param>
        private void SetActiveInterface(Interface? infc)
        {
            ActiveInterface = infc;
            switch (ActiveInterface)
            {
                case Interface.NewUser:
                    NewUserInterface.SetActive(true);
                    PlaylistInterface.SetActive(false);
                    CreateSongInterface.SetActive(false);
                    FinishedSongInterface.SetActive(false);
                    break;
                case Interface.Playlist:
                    NewUserInterface.SetActive(false);
                    PlaylistInterface.SetActive(true);
                    CreateSongInterface.SetActive(false);
                    FinishedSongInterface.SetActive(false);
                    break;
                case Interface.CreateSong:
                    NewUserInterface.SetActive(false);
                    PlaylistInterface.SetActive(false);
                    CreateSongInterface.SetActive(true);
                    FinishedSongInterface.SetActive(false);
                    break;
                case Interface.FinishedSong:
                    NewUserInterface.SetActive(false);
                    PlaylistInterface.SetActive(false);
                    CreateSongInterface.SetActive(false);
                    FinishedSongInterface.SetActive(true);
                    break;
            }
        }

        /// <summary>
        /// Creating the new user, setting the input device, and setting Playlist as the current interface.
        /// </summary>
        private void HandleNewUserOKButton_Clicked()
        {
            NewUserInterfacePrefab.ResetClickEvents();

            new User(NameInputField.Name);
            new InputDevice(DeviceSelectPrefab.SelectedDevice);

            SetActiveInterface(Interface.Playlist);
        }
        /// <summary>
        /// Sets CreateSong as active interface.
        /// </summary>
        private void HandlePlaylistCreateSongButton_Clicked()
        {
            PlaylistInterfacePrefab.ResetClickEvents();
            SetActiveInterface(Interface.CreateSong);
        }
        /// <summary>
        /// Sets active interface to Playlist and loads NoteHighway Scene.
        /// </summary>
        private void HandleCreateSongConfirmButton_Clicked()
        {
            CreateSongInterfacePrefab.ResetClickEvents();
            SetActiveInterface(Interface.Playlist);

            Scenes.Menu.LoadNoteHighwayScene
            (
                new Song(TitleInputField.Title, ArtistInputField.Artist, CreateSongInterfacePrefab.AudioClip),
                         NoteHighwayState.RECORD
            );
        }
        /// <summary>
        /// Sets Playlist as the active interface.
        /// </summary>
        private void HandleCreateSongCancelButton_Clicked()
        {
            CreateSongInterfacePrefab.ResetClickEvents();
            SetActiveInterface(Interface.Playlist);
        }
        /// <summary>
        /// Prompts user to select a song file.
        /// </summary>
        private void HandleCreateSongSelectSongFromExplorerButton_Clicked()
        {
            CreateSongInterfacePrefab.ResetClickEvents();
            StartCoroutine(RetrieveAudioClipFromExplorer());
        }
        private void HandleFinishedSongOKButton_Clicked()
        {
            FinishedSongInterfacePrefab.ResetClickEvents();
            SetActiveInterface(Interface.Playlist);
        }

        /// <summary>
        /// Opens file location "Assets/SFX/Songs" and sends web request to retrieve the selected AudioClip by the user.
        /// </summary>
        /// <returns>Waits until Web Request is completed.</returns>
        private IEnumerator RetrieveAudioClipFromExplorer()
        {
            songFolderPath = EditorUtility.OpenFilePanel("Show all songs (.ogg)", "Assets/SFX/Songs", "ogg");

            UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + songFolderPath, AudioType.OGGVORBIS);

            yield return www.SendWebRequest();

            if (!(www.isNetworkError || www.isHttpError))
            {
                CreateSongInterfacePrefab.AudioClip = ((DownloadHandlerAudioClip)www.downloadHandler).audioClip;
            }
        }
    }
}
