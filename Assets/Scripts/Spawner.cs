using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that lets balls spawn. Not used in final game
/// </summary>
public class Spawner : MonoBehaviour
{

    public GameObject[] cubes;
    public GameObject[] spheres;
    public Transform[] points;
    public float beat = 1;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Debug.Log("cam from spawner: " + p);

        if (timer > beat)
        {
           
            GameObject sphere = Instantiate(spheres[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            sphere.transform.localPosition = Vector3.zero;
            sphere.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));

            timer -= beat;

        }

        timer += Time.deltaTime;
    }


}
