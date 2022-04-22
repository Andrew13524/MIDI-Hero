using Assets.Scripts.GameObjects.Prefabs;
using Assets.Scripts.GameObjects.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameObjects.UI
{
    public class RecordingText : MonoBehaviour
    {
        public GameObject RecordingCircle;
        private bool isRecordingCircleActive;

        void Start()
        {
            if (NoteHighway.NoteHighwayState != NoteHighwayState.RECORD)
                gameObject.SetActive(false);
            else
            {

                isRecordingCircleActive = true;
                gameObject.SetActive(true);
                StartCoroutine(ToggleRecordingCircle());
            }
        }

        private IEnumerator ToggleRecordingCircle()
        {
            while (NoteHighway.NoteHighwayState == NoteHighwayState.RECORD)
            {
                yield return new WaitForSeconds(1);
                isRecordingCircleActive = !isRecordingCircleActive;
                RecordingCircle.SetActive(isRecordingCircleActive);
            }
        }
    }
}
