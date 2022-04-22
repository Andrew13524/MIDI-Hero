using System;
using TMPro;
using UnityEngine;
using Assets.Scripts.GameObjects.Prefabs;
namespace Assets.Scripts.GameObjects.UI.Text
{
    public class TimerText : MonoBehaviour
    {
        private void Update()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = $"{Math.Round(TimerPrefab.CurrentTime, 2)}";
        }
    }
}
