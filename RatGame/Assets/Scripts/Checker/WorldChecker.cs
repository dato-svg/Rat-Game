using Move;
using UnityEngine;

namespace Checker
{
    public class WorldChecker : MainChecker
    {
        private bool canJump;
        public bool CanJump => canJump;
        

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<World>() != null) canJump = true;
            gameObject.transform.parent.GetComponent<PlayerMovement>().FallParticle();
        }
        
        protected override void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<World>() != null) canJump = false;
        }
    }
}
