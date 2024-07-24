using System;
using UnityEngine;

namespace Checker
{
    public abstract class MainChecker : MonoBehaviour
    {
        protected virtual void OnTriggerEnter2D(Collider2D other) { }

        protected virtual void OnTriggerExit2D(Collider2D other) { }

        protected virtual void OnTriggerStay2D(Collider2D other) { }

        protected virtual void OnCollisionEnter2D(Collision2D other) { }
        protected virtual void OnCollisionStay2D(Collision2D other) { }
        protected virtual void OnCollisionExit2D(Collision2D other) { }
        
    }
}
