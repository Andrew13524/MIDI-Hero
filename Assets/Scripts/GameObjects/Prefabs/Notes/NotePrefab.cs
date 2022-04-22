using Assets.Scripts.Input;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    public abstract class NotePrefab : MonoBehaviour
    {
        public Key Key;

        public MeshRenderer meshRenderer;
        public Color baseRed;
        public Color strongRed;
        public Color baseBlue;
        public Color strongBlue;
        
        public abstract void SetColor();
    }
}
