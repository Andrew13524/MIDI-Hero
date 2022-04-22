using Assets.Scripts.GameObjects.Scenes;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class TimingText : MonoBehaviour
    {
        private TextMeshProUGUI timing;
        private void Start()
        {
            if (NoteHighway.NoteHighwayState != NoteHighwayState.PLAY)
                gameObject.SetActive(false);
            timing = gameObject.GetComponent<TextMeshProUGUI>();
            timing.text = "";
            timing.faceColor = Color.white;
        }
        private void Update()
        {
            if (NoteHighway.LiveFeed.Any())
                timing.text = $"{NoteHighway.LiveFeed.Last().HitBox}";
        }
    }
}
