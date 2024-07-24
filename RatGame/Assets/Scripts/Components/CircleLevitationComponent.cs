using UnityEngine;

namespace Components
{
    public class CircleLevitationComponent : MonoBehaviour
    {
        [SerializeField] private float frequency = 1f; 
        [SerializeField] private float radius = 1f;    

        private Rigidbody2D _rigidbody2D;
        private Vector2 initialPosition;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            initialPosition = _rigidbody2D.position;
        }

        private void Update()
        {
            float angle = Time.time * frequency * Mathf.PI * 2; 
            var pos = initialPosition;
            pos.x += Mathf.Cos(angle) * radius; 
            pos.y += Mathf.Sin(angle) * radius;
            _rigidbody2D.MovePosition(pos);
        }
        
        
        
    }
}