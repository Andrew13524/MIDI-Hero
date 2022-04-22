using Assets.Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in MENU Scene. Logic for the initial Device selction (KEYBOARD, LAUNCHPAD, PIANO)
    /// </summary> 
    public class DeviceSelectPrefab : MonoBehaviour
    {
        /// <summary>
        /// Is a Device selected?
        /// </summary>
        public static bool IsSelected;
        public static Device SelectedDevice;
        public Button KeyboardSelectButton;
        public Button LaunchpadButton;
        public Button PianoButton;

        private TextMeshProUGUI keyboardSelectButtonText;
        private TextMeshProUGUI launchpadSelectButtonText;
        private TextMeshProUGUI pianoSelectButtonText;

        void Start()
        {
            keyboardSelectButtonText = KeyboardSelectButton.GetComponentInChildren<TextMeshProUGUI>();
            launchpadSelectButtonText = LaunchpadButton.GetComponentInChildren<TextMeshProUGUI>();
            pianoSelectButtonText = PianoButton.GetComponentInChildren<TextMeshProUGUI>();
            IsSelected = false;
        }

        public void OnKeyboardButton_Click() => HandleSelection(Device.Keyboard);
        public void OnLaunchpadButton_Click() => HandleSelection(Device.Launchpad);
        public void OnPianoButton_Click() => HandleSelection(Device.Piano);

        /// <summary>
        /// Handles the Device selection of the user.
        /// </summary>
        /// <param name="device">The Device the user selected</param>
        private void HandleSelection(Device device)
        {
            SelectedDevice = device;
            IsSelected = true;

            // Handling the text color of each button
            switch (SelectedDevice)
            {
                case Device.Keyboard:
                    keyboardSelectButtonText.color = Color.white;
                    launchpadSelectButtonText.color = Color.grey;
                    pianoSelectButtonText.color = Color.grey;
                    break;
                case Device.Launchpad:
                    keyboardSelectButtonText.color = Color.grey;
                    launchpadSelectButtonText.color = Color.white;
                    pianoSelectButtonText.color = Color.grey;
                    break;
                case Device.Piano:
                    keyboardSelectButtonText.color = Color.grey;
                    launchpadSelectButtonText.color = Color.grey;
                    pianoSelectButtonText.color = Color.white;
                    break;
            }
        }
    }
}
