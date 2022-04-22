using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameObjects.UI
{
    public class TitleInputField : MonoBehaviour
    {
        public static string Title;
        public TextMeshProUGUI inputFieldText;
        private void Start()
        {
            Title = "";
        }
        private void Update()
        {
            if (inputFieldText.text != Title && inputFieldText.text.Length > 0)
            {
                Title = inputFieldText.text;
            }
        }
    }
}
