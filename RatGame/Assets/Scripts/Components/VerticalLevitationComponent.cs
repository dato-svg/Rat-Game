using UnityEngine;

namespace Components
{
    public class VerticalLevitationComponent : MonoBehaviour
    {
        [SerializeField] private float frequency = 5f;
        [SerializeField] private float amplitude = 0.1f;
        [SerializeField] private bool randomize;
        
        private float _originalY;
        private Rigidbody2D _rigidbody2D;

        private float _seed;
        

        private void Awake()
        {
            Initialise();
            
        }

        private void Initialise()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _originalY = _rigidbody2D.position.y;
            if (randomize)
            {
                _seed = Random.value * Mathf.PI * 2;
            }
        }


        private void Update()
        {
            var pos = _rigidbody2D.position;
            pos.y = _originalY + Mathf.Sin(_seed + Time.time * frequency) * amplitude;
            _rigidbody2D.MovePosition(pos);
        }
    }
}
