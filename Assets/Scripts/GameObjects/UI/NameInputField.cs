using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI
{
    public class NameInputField : MonoBehaviour
    {
        public static string Name;
        public TextMeshProUGUI inputFieldText;
        private void Start()
        {
            Name = "";
        }
        private void Update()
        {
            if (inputFieldText.text != Name && inputFieldText.text.Length > 0)
            {
                Name = inputFieldText.text;
            }
        }
    }
}
