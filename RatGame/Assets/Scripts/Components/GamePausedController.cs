using System;
using UnityEngine;

namespace Components
{
    public class GamePausedController : MonoBehaviour
    {
        [SerializeField] private GameObject joystick;

        [SerializeField] private GameObject BackMusic;
        [SerializeField] private GameObject activeIcon;
        [SerializeField] private GameObject pausedIcon;
        
        [field: SerializeField] private bool GameActive { get; set; }

        private void Start()
        {
            BackMusic = GameObject.Find("BackGroundMusic");
        }

        private void Update()
        {
            if (GameActive)
            {
                BackMusic.GetComponent<AudioSource>().Pause();
                joystick.SetActive(false);
                pausedIcon.SetActive(true);
                activeIcon.SetActive(false);
                Time.timeScale = 0.000001f;
            }
            else
            {
                if ( BackMusic.GetComponent<AudioSource>().isPlaying)
                {
                    Debug.Log("nothing");
                }
                else
                {
                    BackMusic.GetComponent<AudioSource>().Play();
                }
               
                joystick.SetActive(true);
                pausedIcon.SetActive(false);
                activeIcon.SetActive(true);
                Time.timeScale = 1f;
            }
        }

        public void ActiveGame(bool active)
        {
            GameActive = active;
        }
    }
}
