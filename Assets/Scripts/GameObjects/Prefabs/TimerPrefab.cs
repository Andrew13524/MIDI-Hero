using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Located in NOTE HIGHWAY Scene. Keeps track of the current timestamp of the song.
    /// </summary>
    public class TimerPrefab : MonoBehaviour
    {
        public static float CurrentTime;
        static bool isTimerOn;

        private void Start()
        {
            CurrentTime = .0f;

            StartTimer();
        }

        private void Update()
        {
            if (isTimerOn)
            {
                CurrentTime += Time.deltaTime;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                Restart();
        }

        public void Restart()
        {
            CurrentTime = 0;
        }

        public static void StartTimer()
        {
            isTimerOn = true;
        }

        public static void StopTimer()
        {
            isTimerOn = false;
        }
    }
}
