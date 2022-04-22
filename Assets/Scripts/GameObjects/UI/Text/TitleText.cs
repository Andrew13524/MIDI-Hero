using Assets.Scripts.GameObjects.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class TitleText : MonoBehaviour
    {
        private void Start()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = $"{NoteHighway.Song.Title} - {NoteHighway.Song.Artist}";
        }
    }
}
