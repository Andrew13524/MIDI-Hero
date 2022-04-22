using Assets.Scripts.GameObjects.UI;
using Assets.Scripts.Input;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. Is the interface used to collect inital user input, and is a child component of Arcade Screen.
    /// </summary>
    public class NewUserInterfacePrefab : MonoBehaviour
    {
        public static bool OKButtonClicked => okButtonClicked;
        private static bool okButtonClicked;
        private void Start()
        {
            ResetClickEvents();
        }
        public static void ResetClickEvents() => okButtonClicked = false;
        public void OnOKButton_Clicked() => okButtonClicked = NameInputField.Name != null && DeviceSelectPrefab.IsSelected;
    }
}
