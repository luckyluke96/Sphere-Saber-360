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
    public GameObject testObject;

    public static bool leftHandBonus = false;
        //public Transform[] points;
    //public float beat = 2;

    private float deg = 0;
    private int count = 0;
    private float increase = 0;
    private float rigRot = 0;
    private bool rigDegNotInit = true;
    private float hintSpawnDeg = 0;
    private float hintFreq = 30f; //frequence of spawning hints
    private float hintSpawnTime;
    private static float angle = 0;
    private static float radius = 6f;
    private bool lastShotHappend = false;
    private float gameDurationPerimeter = 360;
    private float gameDurationPerimeter180 = 180;
    private int numColors = 1;
    private int bubbleCounter = 0;
    private float time;
    private float gameDur = 120; //duration of game in seconds
    private float circGameDur;
    private bool maxHintsSpawned = false;
    private float rigDegree;
    private bool lastHint = false;


    // Start is called before the first frame update
    void Start()
    {
        
        
        transform.Rotate(0f, rigRot, 0f);

        //method, starttime, frequence in sec
        // InvokeRepeating("ShootBubblesGuide", 0f, 2f);

        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "LevelCircularSpawn")
        {
            InvokeRepeating("ShootBubblesGuide", 0f, 2f);
        }
        else if (currentSceneName == "LevelRandom")
        {
            InvokeRepeating("ShootBubblesRandom", 0f, 2f);
        }
        else if (currentSceneName == "LevelCircularSpawn180")
        {
            InvokeRepeating("ShootBubblesGuide180", 0f, 2f);
        }
        else if (currentSceneName == "LevelRandom180")
        {
            InvokeRepeating("ShootBubblesRandom180", 0f, 2f);
        }
        else if (currentSceneName == "LevelRandom180WOHints")
        {
            Debug.Log(currentSceneName);
            InvokeRepeating("ShootBubblesRandom180WOHints", 0f, 2f);
        }

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
            rigDegree = deg;
            hintSpawnDeg = deg;
            rigDegNotInit = false;
        }
    }

    /// <summary>
    /// Return direction of view in degree between 0 and 360
    /// </summary>
    /// <returns></returns>
    public static float getCameraDirectionDeg()
    {
        Camera camera = Camera.main;
        // Vector3 camPosition = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        float y = RigSpawner.rigDegree + camera.transform.localEulerAngles.y;
        // Debug.Log("Y: " + y);
        angle = (y * Mathf.PI * 2f / 360);
        // Vector3 newPos = new Vector3(Mathf.Sin(angle) * (radius-3), 2f, Mathf.Cos(angle) * (radius-3));
        // Instantiate(testObject, newPos, Quaternion.identity);
        return y;

    }

    // Update is called once per 

    void ShootBubblesGuide()
    {
        InitDeg();
        getCameraDirectionDeg();

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
            int bubbleType = Random.Range(0, numColors);
            if(bubbleType == 0)
            {
                PointCounterManager.countSpawnedRed++;
            }
            else if(bubbleType == 1)
            {
                if (!leftHandBonus)
                {
                    PointCounterManager.countSpawnedBlueBeforeLeft++;
                }
                else
                {
                    PointCounterManager.countSpawnedBlue++;
                }
            }
            else if(bubbleType == 2)
            {
                PointCounterManager.countSpawnedYellow++;
            }
            if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[bubbleType], newPos, Quaternion.identity);


            // Debug.Log("deg: " + deg + "hintSpawndeg: " + hintSpawnDeg);
            // spawn Hint Canvas if possible
            if (deg >= (hintSpawnDeg + 120))
            { 
                spawnHint();
            }

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
                PointCounterManager.countSpawnedRed++;
                if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

                Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, newPos, Quaternion.identity);

                if (deg >= (hintSpawnDeg + 120))
                {
                    spawnHint();
                }

                bubbleCounter++;
                count++;
                lastShotHappend = true;
            }
            
            
            
           
        }
    }

    void ShootBubblesGuide180()
    {
        InitDeg();
        getCameraDirectionDeg();

        if (deg <= (gameDurationPerimeter180 + rigRot))
        {


            deg += Random.Range(-30f, 60f);

            if (count >= 3 && (deg < (increase + 60)))
            {
                deg += 60;
                count = 0;
                increase = deg;
            }

            angle = (deg * Mathf.PI * 2f / 360);

            int bubbleType = Random.Range(0, numColors);
            if (bubbleType == 0)
            {
                PointCounterManager.countSpawnedRed++;
            }
            else if (bubbleType == 1)
            {
                PointCounterManager.countSpawnedBlue++;
            }
            else if (bubbleType == 2)
            {
                PointCounterManager.countSpawnedYellow++;
            }
            if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

            //Debug.Log("deg: " + deg);

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[bubbleType], newPos, Quaternion.identity);

            // Debug.Log("deg: " + deg + "hintSpawndeg: " + hintSpawnDeg);
            // spawn Hint Canvas if possible
            if (deg >= (hintSpawnDeg + 90))
            {
                spawnHint();
            }

            bubbleCounter++;
            count++;

        }
        else
        {
            if (!lastShotHappend)
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
                PointCounterManager.countSpawnedRed++;
                if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

                Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, newPos, Quaternion.identity);

                if (deg >= (hintSpawnDeg + 90))
                {
                    spawnHint();
                }

                bubbleCounter++;
                count++;
                lastShotHappend = true;
            }




        }
    }

    // bubbles spawn randomly in 360 degree
    void ShootBubblesRandom()
    {
        
        deg = Random.Range(0, 360);
        angle = (deg * Mathf.PI * 2f / 360);

        int bubbleType = Random.Range(0, numColors);
        if (bubbleType == 0)
        {
            PointCounterManager.countSpawnedRed++;
        }
        else if (bubbleType == 1)
        {
            PointCounterManager.countSpawnedBlue++;
        }
        else if (bubbleType == 2)
        {
            PointCounterManager.countSpawnedYellow++;
        }
        if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

        Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
        GameObject ball = Instantiate(spheres[bubbleType], newPos, Quaternion.identity);


        if (time > (hintSpawnTime + hintFreq))
        {
            spawnHint();
            hintSpawnTime = time;
        }

        bubbleCounter++;
        count++;

        if (time > gameDur)
        {
            if (!lastShotHappend)
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
                PointCounterManager.countSpawnedRed++;
                if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

                Vector3 lastPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, lastPos, Quaternion.identity);

                

                bubbleCounter++;
                count++;
                lastShotHappend = true;

                
            }
        }

        
    }



    void ShootBubblesRandom180()
    {
        InitDeg();

        getCameraDirectionDeg();

        float localDeg = 0;

        if (time <= gameDur)
        {
            localDeg = rigDegree + Random.Range(-90, 90);
            // Debug.Log("deg: " + localDeg);
            angle = (localDeg * Mathf.PI * 2f / 360);

            int bubbleType = Random.Range(0, numColors);
            
            if (bubbleType == 0)
            {
                PointCounterManager.countSpawnedRed++;
            }
            else if (bubbleType == 1)
            {
                if (!leftHandBonus)
                {
                    PointCounterManager.countSpawnedBlueBeforeLeft++;
                }
                else
                {
                    PointCounterManager.countSpawnedBlue++;
                }
                
            }
            else if (bubbleType == 2)
            {
                PointCounterManager.countSpawnedYellow++;
            }

            if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[bubbleType], newPos, Quaternion.identity);


            if (time > (hintSpawnTime + hintFreq))
            {
                spawnHint();
                hintSpawnTime = time;
            }

            bubbleCounter++;
            count++;
        }

        else
        {
            if (!lastShotHappend)
            {
                localDeg = rigDegree + Random.Range(-30, 30);

                if (count >= 3)
                {
                    localDeg += 60;
                    count = 0;
                    increase = localDeg;
                }

                angle = (localDeg * Mathf.PI * 2f / 360);


                //Debug.Log("deg: " + deg);
                PointCounterManager.countSpawnedRed++;
                if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

                Vector3 lastPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, lastPos, Quaternion.identity);



                bubbleCounter++;
                count++;
                lastShotHappend = true;


            }
        }
    }

    void ShootBubblesRandom180WOHints()
    {
        InitDeg();

        getCameraDirectionDeg();

        float localDeg = 0;

        if (time <= gameDur)
        {
            localDeg = rigDegree + Random.Range(-90, 90);
            // Debug.Log("deg: " + localDeg);
            angle = (localDeg * Mathf.PI * 2f / 360);

            PointCounterManager.countSpawnedRed++;
            if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

            Vector3 newPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
            GameObject ball = Instantiate(spheres[Random.Range(0, numColors)], newPos, Quaternion.identity);

            /*
            if (time > (hintSpawnTime + hintFreq))
            {
                spawnHint();
                hintSpawnTime = time;
            }
            */

            bubbleCounter++;
            count++;
        }

        else
        {
            if (!lastShotHappend)
            {
                localDeg = rigDegree + Random.Range(-30, 30);

                if (count >= 3)
                {
                    localDeg += 60;
                    count = 0;
                    increase = localDeg;
                }

                angle = (localDeg * Mathf.PI * 2f / 360);


                //Debug.Log("deg: " + deg);
                PointCounterManager.countSpawnedRed++;
                if (leftHandBonus) { PointCounterManager.countSpawnedLeftBonus++; };

                Vector3 lastPos = new Vector3(Mathf.Sin(angle) * radius, 2f, Mathf.Cos(angle) * radius);
                GameObject lastBall = Instantiate(lastSphere, lastPos, Quaternion.identity);



                bubbleCounter++;
                count++;
                lastShotHappend = true;


            }
        }


    }






void Update()
    {
        if(maxHintsSpawned)
        {
            Destroy(GameObject.FindGameObjectWithTag("HintCanvasYellow"));
        }
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        circGameDur += Time.deltaTime;
        PointCounterManager.durCircularGame += Time.deltaTime;
        //Debug.Log("circGameDur: " + circGameDur);
        //Debug.Log("PCM_gametime: " + PointCounterManager.durCircularGame);
    }

    void spawnHint()
    {
        float camDeg = getCameraDirectionDeg();
        angle = (camDeg * Mathf.PI * 2f / 360);
                float hintRadius = radius + 1;
        float height = Random.Range(1.5f, 2.5f);

        Vector3 newPos = new Vector3(Mathf.Sin(angle) * hintRadius, 2, Mathf.Cos(angle) * hintRadius);

        if (numColors == 1)
        {
            Instantiate(hintCanvasBlue, newPos, Quaternion.Euler(0f, camDeg, 0f));
            numColors++;
            PointCounterManager.angleBlueCanvas = angle;
        }
        else if (numColors == 2)
        {
            Instantiate(hintCanvasYellow, newPos, Quaternion.Euler(0f, camDeg, 0f));
            numColors++;
            Destroy(GameObject.FindGameObjectWithTag("HintCanvasBlue"));
            PointCounterManager.angleYellowCanvas = angle;
        }
        else if (numColors == 3)
        {
            

            if (!maxHintsSpawned)
            {
                //Destroy(GameObject.FindGameObjectWithTag("HintCanvasYellow"));
                Instantiate(hintCanvasLeftHand, newPos, Quaternion.Euler(0f, camDeg, 0f));
                
                leftHandBonus = true;
                maxHintsSpawned = true;
                
                
                PointCounterManager.angleLeftHandCanvas = angle;
            }
        }
        



        hintSpawnDeg = deg;

    }

}
