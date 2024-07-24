using System;
using System.Collections;
using System.Threading.Tasks;
using Checker;
using Components;
using UnityEngine;

namespace Move
{
    [RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
    public class PlayerMovement : MonoBehaviour, IMovable, IJump
    {
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private Animator animator;
        [SerializeField] private WorldChecker worldChecker;
        [SerializeField] private AttackChecker attackChecker;
        [SerializeField] private CoolDown _coolDown;
        [SerializeField] private AudioClip[] _clips;
        
        [SerializeField] private float speed;
        [SerializeField] private float jumpSpeed;

        private AudioSource _audio;
        private GameSession gameSession;
        private HealthComponent health;
        private Spawner spawner;
        
        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Jump1 = Animator.StringToHash("Jump");
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attacked1 = Animator.StringToHash("Attacked");
       

        private void Start()
        {
            Initialise();
        }

        private void Initialise()
        {
            _audio = GetComponent<AudioSource>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            health = GetComponent<HealthComponent>();
            gameSession = FindObjectOfType<GameSession>();
            spawner = GetComponent<Spawner>();

        
        }

        private void FixedUpdate()
        {
            Movement();
            
        }

      


        private IEnumerator AttackDeactivator()
        {
            _audio.PlayOneShot(_clips[1]);
            attackChecker.gameObject.SetActive(true);
            animator.SetTrigger(Attack1);
            yield return new WaitForSeconds(0.2f);
            attackChecker.gameObject.SetActive(false);
        }
       


        private void MovementAnimation()
        {
            
            if (fixedJoystick.Horizontal != 0)
            {
                animator.SetBool(Move,true);
            }
            else
            {
                animator.SetBool(Move,false); 
            }
        }

        
        
        public void Movement()
        {
            rigidbody2D.velocity = new Vector2(fixedJoystick.Horizontal *  speed, rigidbody2D.velocity.y);
            MovementAnimation();
           
           
            if (fixedJoystick.Horizontal > 0)
            {
                transform.localScale = new Vector3(3,3,3);
                MoveParticle();
            }

            if (fixedJoystick.Horizontal < 0)
            {
                transform.localScale = new Vector3(-3,3,3);
                MoveParticle();
            }
           
           
        }
        
        
        
        public void Jump(float jumpForce)
        {
            _audio.PlayOneShot(_clips[0]);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpForce);
            animator.SetTrigger(Jump1);
            JumpParticle();
    
        }
        
        public void TryJump()
        {
            if (worldChecker.CanJump)
            {
                Jump(jumpSpeed);
            }
        }
        
        public void Attack()
        {
            if (_coolDown.IsReady)
            {
                StartCoroutine(AttackDeactivator());
                _coolDown.Reset();
            }
           
        }

        public void DieAnimation()
        {
            animator.SetTrigger(Die);
        }

        public void Attacked()
        {
            animator.SetTrigger(Attacked1);
        }


        public void HealthTake()
        {
            health.Heal(20);
            gameSession.playerData.Health += 20;
        }

        public void SpeedChange()
        {
            speed += 2.5f;
        }

        private  void MoveParticle()
        {
            if ( spawner.particle == null)
            {
                spawner.Spawn("Move");
                spawner.particle.transform.localScale = transform.localScale;
            }
           
        }
        
        
     
        
        private void JumpParticle()
        {
            spawner.Spawn("Jump");
        }
        
        public void FallParticle()
        {
            spawner.Spawn("Fall");
        }

        public void DamageData(int damage)
        {
            gameSession.playerData.Health -= damage;
        }
        
        
    }
}