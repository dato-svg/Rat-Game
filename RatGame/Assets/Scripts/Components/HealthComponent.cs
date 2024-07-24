using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float _health;
        

        public float Health => _health;

        [SerializeField] private UnityEvent OnDamage;
        [SerializeField] private UnityEvent OnDie;
        
        
        
        public void Damage(int damage)
        {
           
            if (_health > 0)
            {
                _health -= damage;
                OnDamage?.Invoke();
            }
            
            
            if (_health <= 0)
            {
                OnDie?.Invoke();
                Debug.Log("DIE");
            }
           
        }

        public void Heal(int heal)
        {
            _health += heal;
        }
        
    }
}
