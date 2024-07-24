using System.Collections;
using UnityEngine;

namespace Move
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private Transform leftPos;
        [SerializeField] private Transform rightPos;
        
        private Rigidbody2D _rigidbody2D;
        private Vector3 _currentTarget;

        private void Awake()
        {
           
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _currentTarget = leftPos.position; 
        }

        private void Start()
        {
          
            StartCoroutine(MoveState());
        }    

        private IEnumerator MoveState()
        {
            while (true)
            {
              
                MoveTowardsTarget(_currentTarget);

               
                if (Vector2.Distance(transform.position, _currentTarget) < 0.1f)
                {
                    _currentTarget = _currentTarget == leftPos.position ? rightPos.position : leftPos.position;
                    FlipDirection();
                }
                

                yield return null; 
            }
        }

        private void MoveTowardsTarget(Vector3 target)
        {
            
            Vector2 newPosition = Vector2.MoveTowards(_rigidbody2D.position, target, speed * Time.deltaTime);

            
            _rigidbody2D.MovePosition(newPosition);
        }
        
        private void FlipDirection()
        {
            Vector3 localScale = transform.localScale;
            
            localScale.x = transform.position.x < _currentTarget.x ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
}