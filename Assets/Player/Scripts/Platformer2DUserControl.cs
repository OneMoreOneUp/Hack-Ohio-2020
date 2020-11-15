using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public LayerFlip cameraFlipScript;
        public AudioSource crumpleSound;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private int invertedHor;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            invertedHor = 1;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cameraFlipScript.FlipCamera();
                crumpleSound.Play();
                //InvertHorizontal();
            }
        }


        private void FixedUpdate()
        {
            float h = invertedHor * CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }

        public void InvertHorizontal()
        {
            invertedHor *= -1;
        }
    }
}
