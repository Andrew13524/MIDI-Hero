using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. Is the interface that showcases the users preformance on a Song. Is a child component of Arcade Screen.
    /// </summary>
    public class FinishedSongInterfacePrefab : MonoBehaviour
    {
        public static Song Song;
        public static bool OKButtonClicked => okButtonClicked;
        private static bool okButtonClicked;
        private void Start()
        {
            ResetClickEvents();
        }
        public static void ResetClickEvents() => okButtonClicked = false;
        public void OnOKButton_Clicked() => okButtonClicked = true;
    }
}
