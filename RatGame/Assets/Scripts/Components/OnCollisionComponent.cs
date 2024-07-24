using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class OnCollisionComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
      
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                onEnter?.Invoke();
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                onExit?.Invoke();
            }
        }
        
    }
}
