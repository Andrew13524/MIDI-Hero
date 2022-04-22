using Assets.Scripts.GameObjects.Scenes;
using Assets.Scripts.Input;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameObjects.Prefabs
{
    public class DeployableNotePrefab : NotePrefab
    {
        public Text TimingText;
        private bool IsHit => ActionBarPrefab.PressedNotes[(int)Key] == 1 && hitBox > 0;

        private Rigidbody rb;
        private Vector2 screenBounds;
        private HitBox hitBox;

        private void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            strongRed = new Color(Constants.STRONG_RED_R, Constants.STRONG_RED_G, Constants.STRONG_RED_B);
            strongBlue = new Color(Constants.STRONG_BLUE_R, Constants.STRONG_BLUE_G, Constants.STRONG_BLUE_B);

            rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            hitBox = 0;

            rb.velocity = new Vector3(0, -Constants.NOTE_SPEED);

            SetKey();
            SetColor();
        }
        private void Update()
        {
            if((transform.position.y < screenBounds.y * 2) || IsHit)
            {
                NoteHighway.LiveFeed.Enqueue(new Note(Key, hitBox));
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other) => hitBox++;
        private void OnTriggerExit(Collider other) => hitBox--;

        /// <summary>
        /// Sets the note's key value based on its position in the world.
        /// </summary>
        private void SetKey()
        {
            for (int i = 0; i < Constants.KEY_LENGTH; i++)
            {
                if (transform.position.x == (float)(i + Constants.NOTE_HORIZONTAL_OFFSET + (Constants.NOTE_HORIZONTAL_PADDING * i))) Key = (Key)i;
            }
        }
        /// <summary>
        /// Sets the color of the note based on its Key value.
        /// </summary>
        public override void SetColor()
        {
            if ((int)Key < Constants.KEY_LENGTH / 2)  meshRenderer.material.color = strongBlue;
            else                                      meshRenderer.material.color = strongRed;
        }
    }
}
