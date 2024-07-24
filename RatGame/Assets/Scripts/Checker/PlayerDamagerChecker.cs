using Components;
using Move;
using UnityEngine;

namespace Checker
{
    public class PlayerDamagerChecker : MonoBehaviour
    {
        [SerializeField] private int damage;
        private GameSession gameSession;
        private GameObject joystickCanvas;
        
        private void Start()
        {
            gameSession = FindObjectOfType<GameSession>();
            joystickCanvas = GameObject.Find("JoystickCanvas");
        }
        
        
        private void OnCollisionEnter2D(Collision2D other1)
        {
            if (other1.gameObject.TryGetComponent(out PlayerMovement player))
            {
                HealthComponent playerHealth = GameObject.Find("Rat").GetComponent<HealthComponent>();
                if (playerHealth.Health > 0)
                {
                    player.Jump(5);
                    gameSession.playerData.Health -= damage;
                    
                    playerHealth.Damage(damage);
                } 
                
                if(playerHealth.Health <= 0)
                {
                    player.DieAnimation();
                    player.enabled = false;
                    joystickCanvas.SetActive(false);
                    
                }
                
                
            }
        }
    }
}
