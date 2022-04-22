using Assets.Scripts.GameObjects.Scenes;
using Assets.Scripts.Models;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class ScoreText : MonoBehaviour
    {
        private void Update()
        {
            if (NoteHighway.NoteHighwayState != NoteHighwayState.PLAY)
                gameObject.SetActive(false);
            gameObject.GetComponent<TextMeshProUGUI>().text = $"Score {NoteHighway.Song.Score}";
        }
    }
}
