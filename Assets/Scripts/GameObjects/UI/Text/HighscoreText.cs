using Assets.Scripts.GameObjects.Prefabs;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GameObjects.UI.Text
{
    public class HighscoreText : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = $"Highscore: {User.HighScore[FinishedSongInterfacePrefab.Song.Title]}";
        }
    }
}
