using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] private float delaySpawn;


    private void Start()
    {
        InvokeRepeating(nameof(Spawn),0,delaySpawn);
    }

    private void Spawn()
    {
        Instantiate(clouds[Random.Range(0, clouds.Length)]
            , new Vector3(transform.position.x, Random.Range(minY, maxY))
            , Quaternion.identity);
    }
}
