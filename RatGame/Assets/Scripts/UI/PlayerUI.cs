using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Image HealthImage;
        [SerializeField] private TextMeshProUGUI CheeseCountText;
        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            ShowCheese();
        }

        public void ShowCheese()
        {
            CheeseCountText.text = _gameSession.playerData.Cheese.ToString();
        }



        public void ShowXP()
        {
            HealthImage.fillAmount = _gameSession.playerData.Health / 100;
            
        }


        private void Update()
        {
            ShowXP(); 
            ShowCheese();
        }
    }
}
