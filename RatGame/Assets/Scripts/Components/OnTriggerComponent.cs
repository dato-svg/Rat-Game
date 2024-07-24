using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnTriggerComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                onEnter?.Invoke();
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                onExit?.Invoke();
            }
        }
    }
}
