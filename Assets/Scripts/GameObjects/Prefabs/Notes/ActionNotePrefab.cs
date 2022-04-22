using Assets.Scripts.Input;
using Assets.Scripts.Models;

using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in NOTEHIGHWAY Scene. Is the player-controlled notes at the bottom of the screen.
    /// </summary>
    public class ActionNotePrefab : NotePrefab
    {
        private Color baseColor;
        private Color strongColor;

        private void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            baseRed = new Color(Constants.BASE_RED_R, Constants.BASE_RED_G, Constants.BASE_RED_B);
            strongRed = new Color(Constants.STRONG_RED_R, Constants.STRONG_RED_G, Constants.STRONG_RED_B);
            baseBlue = new Color(Constants.BASE_BLUE_R, Constants.BASE_BLUE_G, Constants.BASE_BLUE_B);
            strongBlue = new Color(Constants.STRONG_BLUE_R, Constants.STRONG_BLUE_G, Constants.STRONG_BLUE_B);

            SetColor();
        }
        private void Update()
        {
            if (IsPressed()) OnPress();
            else             OnRelease();
        }
        public bool IsPressed() => InputDevice.PressedNotes()[(int)Key] == 1;
        public void OnPress() => meshRenderer.material.color = strongColor;
        public void OnRelease() => meshRenderer.material.color = baseColor;

        /// <summary>
        /// Sets the values for baseColor and pressedColor based on the current ActionNote's Key value.
        /// </summary>
        public override void SetColor()
        {
            if ((int)Key < Constants.KEY_LENGTH / 2)
            {
                baseColor = baseBlue;
                strongColor = strongBlue;
            }
            else
            {
                baseColor = baseRed;
                strongColor = strongRed;
            }
        }
    }
}
