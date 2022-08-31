using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigSpawner : MonoBehaviour
{
    public static float rigDegree = 0;
    public GameObject spawnManager;
    
    void Start()
    {
        Instantiate(spawnManager);
        // rigDegree = Random.Range(0, 360); Uncomment if rig should spawn in random direction
        rigDegree = 0;
        transform.Rotate(0f, rigDegree, 0f);
        // Debug.Log("rig spawner deg: "+ rigDegree);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
