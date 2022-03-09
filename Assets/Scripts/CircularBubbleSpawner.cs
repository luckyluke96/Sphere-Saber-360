using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircularBubbleSpawner : MonoBehaviour
{

   
    public GameObject[] spheres;
    public GameObject hintCanvasBlue;
        //public Transform[] points;
    //public float beat = 2;
    private float deg = 0;
    private int count = 0;
    private float increase = 0;
    private float rigRot = 0;
    private bool rigDegNotInit = true;
    private float hintSpawnDeg = 0;
    private float angle = 0;
    private float radius = 10f;



    // Start is called before the first frame update
    void Start()
    {
        

        transform.Rotate(0f, rigRot, 0f);

        //method, starttime, frequence in sec
        InvokeRepeating("ShootBubbles", 0f, 2f);
        
    }

    void InitDeg()
    {
        if (rigDegNotInit)
        {
            GameObject rig = GameObject.Find("XR Origin");
            //rigSpawner = rig.GetComponent<RigSpawner>();

            rigRot = RigSpawner.rigDegree;
            // Debug.Log("deg from rigspawner: " + rigRot);

            deg += rigRot;
            hintSpawnDeg = deg;
            rigDegNotInit = false;
        }
    }

    // Update is called once per 

    void ShootBubbles()
    {
        InitDeg();


        if (deg <= (360 + rigRot))
        {

            

            deg += Random.Range(-30f, 60f);

            if (count >= 3 && (deg < (increase + 60)))
            {
                deg += 60;
                count = 0;
                increase = deg;
            }

            angle = (deg * Mathf.PI * 2f / 360);


            Debug.Log("deg: " + deg);

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[Random.Range(0, spheres.Length)], newPos, Quaternion.identity);

            // spawn Hint Canvas if possible
            spawnHint();

            count++;
           
        }
        else
        {
            SceneManager.LoadScene(0);

        }
    }

    void Update()
    {

    }

    void spawnHint()
    {
        if(deg >= (hintSpawnDeg + 120))
        {
            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            Instantiate(hintCanvasBlue, newPos, Quaternion.Euler(0f, deg, 0f));

            hintSpawnDeg = deg;
        }
    }

}
