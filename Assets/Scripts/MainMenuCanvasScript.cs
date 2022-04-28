using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PathCreation;



    public class MainMenuCanvasScript : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public GameObject pathTraveller;
        public float speed = 1;
        public GameObject MenuCanvas;
        public GameObject ExplanationA;
        public GameObject ExplanationB;
    public GameObject TakeOffHMDCanvas;
        public static bool takeOffHMD = false;


        float distanceTravelled;
        bool runPath = false;

        public void StartLevelCircular180()
        {
            SceneManager.LoadScene(1);
        }

        public void StartLevelCircular360()
        {
            SceneManager.LoadScene(2);
        }

        public void StartLevelRandom180()
        {
            SceneManager.LoadScene(3);
        }

        public void StartLevelRandom()
        {
            SceneManager.LoadScene(4);
        }

        public void StartLevelWOHints()
        {
            SceneManager.LoadScene(5);
        }


        public void ExitGame()
        {
            Application.Quit();
        }

        public void runFox()
        {
            
            runPath = true;
            Instantiate(MenuCanvas);
            GameObject.Find("Fox").GetComponent<Animator>().SetBool("isRunning", true);
            GameObject.Find("Fox").GetComponent<Animator>().SetBool("isSitting", false);
        }

        public void BackToMainMenu()
        {
            Instantiate(MenuCanvas);
            Destroy(GameObject.FindGameObjectWithTag("ModeExplanationCanvas"));
        }

        public void ShowExplanationA()
        {
            Instantiate(ExplanationA);
            Destroy(GameObject.FindGameObjectWithTag("MainMenuCanvas"));
        }

        public void ShowExplanationB()
        {
            Instantiate(ExplanationB);
            Destroy(GameObject.FindGameObjectWithTag("MainMenuCanvas"));
        }


        public void Start()
        {
            if (takeOffHMD)
            {
                Instantiate(TakeOffHMDCanvas);
                Destroy(GameObject.FindGameObjectWithTag("MainMenuCanvas"));
                takeOffHMD = false;
            }
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(pathTraveller.transform.position);
            // Debug.Log(distanceTravelled);
        }

        private void Update()
        {
            /* DEBUGGING
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("Tab");
                runFox();

                
            }
            */

            Debug.Log(distanceTravelled);
            if ((pathCreator != null) && runPath)
            {
                distanceTravelled += speed * Time.deltaTime;
                pathTraveller.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                pathTraveller.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            }

            if(distanceTravelled > 19f)
            {
                GameObject.Find("Fox").GetComponent<Animator>().SetBool("isRunning", false);
                GameObject.Find("Fox").GetComponent<Animator>().SetBool("isSitting", true);
            }
        }

        private void FixedUpdate()
        {
            
        }

        
    }

