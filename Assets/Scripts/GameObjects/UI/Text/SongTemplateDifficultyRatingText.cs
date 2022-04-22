using UnityEngine;
using TMPro;
using Assets.Scripts.GameObjects.Prefabs;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class SongTemplateDifficultyRatingText : MonoBehaviour
    {
        private void Start()
        {
            var songTemplate = gameObject.GetComponentInParent(typeof(SongTemplatePrefab)) as SongTemplatePrefab;
            gameObject.GetComponent<TextMeshProUGUI>().text = $"{songTemplate.Song.DifficultyRating}";
        }
    }
}