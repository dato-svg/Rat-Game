using System;
using UnityEngine;

namespace Move
{
    public class CloudMovement : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.position -= new Vector3(-0.02f,0,0);
        }
    }
}
