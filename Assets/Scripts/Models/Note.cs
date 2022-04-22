using Assets.Scripts.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class Note
    {
        public float TimeStamp;
        public Key Key;
        public HitBox HitBox;

        public Note () { }
        public Note(Key key, float timeStamp)
        {
            Key = key;
            TimeStamp = timeStamp;
        }
        public Note(Key key, HitBox hitBox)
        {
            Key = key;
            HitBox = hitBox;
        }
    }
}
