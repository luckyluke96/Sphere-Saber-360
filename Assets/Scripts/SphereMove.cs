using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{

    private float deg = 0;

    // Start is called before the first frame update
    void Start()
    {
        deg = Random.Range(-180f, 180f);
        transform.Rotate(0f, deg, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        Vector3 camPosition = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 updatedPos = new Vector3(camPosition.x, camPosition.y - 0.4f, camPosition.z);
        // Debug.Log("cam x: " + camPosition.x + "cam z:" + camPosition.z);
        // Debug.Log("rotation: " + camera.transform.rotation.y);

        // Movement towards camposition
        transform.position = Vector3.MoveTowards(transform.position, updatedPos, Time.deltaTime * 0.8f);

        // Move towards center
        // Vector3 center = new Vector3(0, 0.6f, 0);
        // transform.position = Vector3.MoveTowards(transform.position, center, Time.deltaTime * 0.8f);


    }
}
