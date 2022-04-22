using Assets.Scripts.GameObjects.Prefabs;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class SongTemplateArtistText : MonoBehaviour
    {
        private void Start()
        {
            var songTemplate = gameObject.GetComponentInParent(typeof(SongTemplatePrefab)) as SongTemplatePrefab;
            gameObject.GetComponent<TextMeshProUGUI>().text = songTemplate.Song.Artist;
        }
    }
}
