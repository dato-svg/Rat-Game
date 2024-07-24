using UnityEngine;

namespace Components
{
    public class DestroyComponent : MonoBehaviour
    {
        public void DestroyCurrentObject()
        {
            Destroy(gameObject);
        }
    }
}
