using Components;
using UnityEngine;

namespace Checker
{
    public class AttackChecker : MainChecker
    {
        protected override void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("Try Find Box");
            if (other.GetComponent<HealthComponent>() != null)
            {
                Debug.Log(" Attacked Box");
                other.GetComponent<HealthComponent>().Damage(1);
                gameObject.SetActive(false);
            }
           
        }

       

       
    }
}
