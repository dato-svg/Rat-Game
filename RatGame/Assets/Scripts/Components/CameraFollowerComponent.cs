using System;
using UnityEngine;

namespace Components
{
    public class CameraFollowerComponent : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothness;
        [SerializeField] private Vector3 offset;


        private void LateUpdate()
        {
            Vector3 targetPosition = target.position + offset; 
            
        
            Vector3 currentPosition = transform.position;

           
            float newX = Mathf.Lerp(currentPosition.x, targetPosition.x, smoothness * Time.deltaTime);

         
            transform.position = new Vector3(newX, targetPosition.y, currentPosition.z);
        }



    }
}
