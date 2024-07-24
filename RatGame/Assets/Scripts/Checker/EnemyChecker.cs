using System;
using Components;
using Move;
using UnityEngine;

namespace Checker
{
    public class EnemyChecker : MainChecker
    {
        [SerializeField] private int damage;

        private GameSession _gameSession;


        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
        }


        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerMovement>() != null)
            {
                other.gameObject.GetComponent<HealthComponent>().Damage(damage);
                _gameSession.playerData.Health -= damage;
                other.gameObject.GetComponent<PlayerMovement>().Jump(5);
            }
        }
    }
}
