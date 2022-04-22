using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI
{
    public class ArtistInputField : MonoBehaviour
    {
        public static string Artist;
        public TextMeshProUGUI inputFieldText;
        private void Start()
        {
            Artist = "";
        }
        private void Update()
        {
            if (inputFieldText.text != Artist && inputFieldText.text.Length > 0)
            {
                Artist = inputFieldText.text;
            }
        }
    }
}
