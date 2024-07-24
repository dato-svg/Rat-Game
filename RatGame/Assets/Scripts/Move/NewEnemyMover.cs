using System.Collections;
using UnityEngine;

namespace Move
{
    public class NewEnemyMover : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private float stopTime = 2f;
        
        [SerializeField] private Transform[] points;


        private Animator animator;
        private Transform currentPoint;
        private int currentIndex;
        private static readonly int Idle2 = Animator.StringToHash("Idle2");
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Attacked1 = Animator.StringToHash("Attacked");
        private static readonly int Die = Animator.StringToHash("TrueDie");


        private Coroutine _coroutine;

        private void Start()
        {
            animator = GetComponent<Animator>();
            _coroutine =  StartCoroutine(EnemyMover());;
           
        }


        public void Attacked()
        {
            animator.SetTrigger(Attacked1);
        }

        public void DieEnemy()
        {
            animator.SetBool(Idle2, false);
            animator.SetBool(Move, false);
            animator.SetBool(Die,true);
            GetComponent<Collider2D>().enabled = false;
            StopCoroutine(_coroutine);
        }

        private IEnumerator EnemyMover()
        {
            while (true)
            {
                if (transform.position == points[currentIndex].position)
                {
                    animator.SetBool(Idle2, true);
                    animator.SetBool(Move, false);
                    yield return new WaitForSeconds(stopTime);
                    currentIndex++;
                    if (currentIndex >= points.Length)
                    {
                        currentIndex = 0;
                    }
                }

                animator.SetBool(Idle2,false);
                animator.SetBool(Move,true);
                Vector3 targetPosition = points[currentIndex].position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

              
                if (targetPosition.x < transform.position.x)
                {
                    
                    FlipLeft();
                }
                else if (targetPosition.x > transform.position.x)
                {
                   
                    FlipRight();
                }
            
                yield return null;
            }
           
            
            
            yield return null;
        }


        
        private void FlipLeft()
        {
           
            var localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x) * -1; 
            transform.localScale = localScale;
        }

        private void FlipRight()
        {
           
            var localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
       
    }


