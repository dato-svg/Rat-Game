using System;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    [SerializeField] private GameObject GameOverCanvas;
    private AudioSource _audio;
    [SerializeField] private AudioClip clip;
    private GameSession gameSession;
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        GameOverCanvas = GameObject.Find("ReloadGame");
        GameOverCanvas.SetActive(false);
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (gameSession.playerData.Health <= 0)
        {
            GameOverCanvas.SetActive(true);
            gameObject.SetActive(false);
            Debug.Log("hihihih");
            _audio.PlayOneShot(clip);
        }
    }
}
