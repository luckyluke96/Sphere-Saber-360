using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject PointCounterCanvas;
    public GameObject CircularBubbleSpawner;

    private float radius = 9f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(CircularBubbleSpawner);

        float deg = RigSpawner.rigDegree;
        PointCounterManager.rigDeg = deg;
        
        float angle = (deg * Mathf.PI * 2f / 360);
        Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 3f, Mathf.Cos(angle) * radius);

        Instantiate(PointCounterCanvas, newPos, Quaternion.Euler(0f, deg, 0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
