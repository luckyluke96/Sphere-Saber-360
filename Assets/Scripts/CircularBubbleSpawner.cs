using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircularBubbleSpawner : MonoBehaviour
{

   
    public GameObject[] spheres;
    public GameObject hintCanvasBlue;
    public GameObject hintCanvasYellow;
    public GameObject backToMenuCanvas;
    public GameObject lastSphere;
    public GameObject hintCanvasLeftHand;

    public static bool leftHandBonus = false;
        //public Transform[] points;
    //public float beat = 2;

    private float deg = 0;
    private int count = 0;
    private float increase = 0;
    private float rigRot = 0;
    private bool rigDegNotInit = true;
    private float hintSpawnDeg = 0;
    private float angle = 0;
    private float radius = 6f;
    private bool lastShotHappend = false;
    private float gameDurationPerimeter = 720;
    private int numColors = 1;
    private int bubbleCounter = 0;



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


        if (deg <= (gameDurationPerimeter + rigRot))
        {

            
            deg += Random.Range(-30f, 60f);

            if (count >= 3 && (deg < (increase + 60)))
            {
                deg += 60;
                count = 0;
                increase = deg;
            }

            angle = (deg * Mathf.PI * 2f / 360);


            //Debug.Log("deg: " + deg);

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[Random.Range(0, numColors)], newPos, Quaternion.identity);


            // spawn Hint Canvas if possible
            spawnHint();

            bubbleCounter++;
            count++;
           
        }
        else
        {
            if(!lastShotHappend)
            {
                deg += Random.Range(-30f, 60f);

                if (count >= 3 && (deg < (increase + 60)))
                {
                    deg += 60;
                    count = 0;
                    increase = deg;
                }

                angle = (deg * Mathf.PI * 2f / 360);


                //Debug.Log("deg: " + deg);

                Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, newPos, Quaternion.identity);

                bubbleCounter++;
                count++;
                lastShotHappend = true;
            }
            
            
            
           
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

            if(numColors == 1)
            {
                Instantiate(hintCanvasBlue, newPos, Quaternion.Euler(0f, deg, 0f));
                numColors++;
            }
            else if(numColors == 2)
            {
                Instantiate(hintCanvasYellow, newPos, Quaternion.Euler(0f, deg, 0f));
                numColors++;
            }
            else if(numColors == 3)
            {
                Instantiate(hintCanvasLeftHand, newPos, Quaternion.Euler(0f, deg, 0f));
                leftHandBonus = true;
            }
            
            

            hintSpawnDeg = deg;
        }
    }



    

}
