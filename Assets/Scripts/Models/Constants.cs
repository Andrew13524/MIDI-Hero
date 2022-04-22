using Assets.Scripts.GameObjects;
using Assets.Scripts.GameObjects.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public enum HitBox { MISS, OKAY, GOOD, GREAT, PERFECT }
    public class Constants
    {
        public const int KEY_LENGTH = 8;

        // Positioning
        public const float NOTE_HEIGHT = 1;
        public const float NOTE_VERTICAL_PADDING = 15;
        public const float NOTE_LENGTH = 1;
        public const float NOTE_HORIZONTAL_OFFSET = -3.8f; 
        public const float NOTE_HORIZONTAL_PADDING = 0.1f;
        public const float NOTE_WIDTH = 1f;

        // Color codes
            // Reds
        public const float BASE_RED_R = 0.55f;
        public const float BASE_RED_G = 0.13f;
        public const float BASE_RED_B = 0.09f;
        public const float STRONG_RED_R = 1f;
        public const float STRONG_RED_G = 0.22f;
        public const float STRONG_RED_B = 0.14f;
            // Blues
        public const float BASE_BLUE_R = 0.05f;
        public const float BASE_BLUE_G = 0.19f;
        public const float BASE_BLUE_B = 0.45f;
        public const float STRONG_BLUE_R = 0.08f;
        public const float STRONG_BLUE_G = 0.4f;
        public const float STRONG_BLUE_B = 0.96f;

        // Preferences
        public const float NOTE_SPEED = 10f;
        public const float SONG_LENGTH_PADDING = 3f;
        public static float NOTE_SPAWN_POSITION_Y => (float)Math.Floor(NoteHighway.ScreenBounds.y + NOTE_VERTICAL_PADDING);
    }
}
