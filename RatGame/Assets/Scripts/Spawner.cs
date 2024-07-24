using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnerList> spawnerList;
    
    
    public GameObject particle;

    public void Spawn(string name)
    {
        foreach (var prefab in spawnerList)
        {
            if (prefab.ID == name)
            {
                particle = Instantiate(prefab.prefabs, transform.position, Quaternion.identity);
            }
            
        }
    }
    
}

[Serializable]
public class SpawnerList
{
    public string ID;
    public GameObject prefabs;
}
