using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PeripheralSpawner : MonoBehaviour
{
    public GameObject foxRigid;
    public GameObject foxMoving;
    public GameObject fountain;
    public GameObject lamp;

    Vector3[] positions = { new Vector3(-13.14f, 0.109f, 2f), new Vector3(13.47f, 0.112f, 2.35f), new Vector3(11.75f, 0.24f, 9.46f), new Vector3(-13.47f, 0.712f, 6.94f) };

    // Start is called before the first frame update
    void Start()
    {
        int lim = positions.Length;
        for(int i = 0; i < positions.Length; i++)
        {
            int index = Random.Range(0, positions.Length);
            Vector3 pos = positions[index];
            lim--;
            positions[index] = positions[lim];
            positions[lim] = pos;
            Debug.Log(positions[0]+","+positions[1]+","+positions[2]+","+positions[3]);
        }

        foxRigid.transform.position = positions[0];
        foxRigid.transform.Rotate(0f, Random.Range(0, 360), 0f);
        foxMoving.transform.position = positions[1];
        foxMoving.transform.Rotate(0f, Random.Range(0, 360), 0f); 
        fountain.transform.position = positions[2];
        lamp.transform.position = positions[3];

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
