using Assets.Scripts.GameObjects.Prefabs;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class LongestStreakText : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = $"Longest Streak: {User.LongestStreak[FinishedSongInterfacePrefab.Song.Title]}";
        }
    }
}