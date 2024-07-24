using Checker;
using UnityEngine;

public class Portal : MainChecker
{
    [SerializeField] private GameObject secondPoint;
    
    
    
    protected override void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("IN Player");
        other.transform.parent.position = secondPoint.transform.position;
    }
    
    
    
}
