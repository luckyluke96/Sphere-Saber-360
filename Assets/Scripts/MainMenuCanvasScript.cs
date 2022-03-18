using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PathCreation;

namespace PathCreation.Examples
{

    public class MainMenuCanvasScript : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public GameObject pathTraveller;
        public float speed = 1;
        public GameObject MenuCanvas;

        float distanceTravelled;
        bool runPath = false;

        public void StartLevelCircular()
        {
            SceneManager.LoadScene(1);
        }

        public void StartLevelRandom()
        {
            SceneManager.LoadScene(2);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void runFox()
        {
            
            runPath = true;
            Instantiate(MenuCanvas);
            GameObject.Find("Fox").GetComponent<Animator>().Play("Base Layer");
        }

        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(pathTraveller.transform.position);
        }

        private void Update()
        {
            if ((pathCreator != null) && runPath)
            {
                distanceTravelled += speed * Time.deltaTime;
                pathTraveller.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                pathTraveller.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        private void FixedUpdate()
        {
            
        }
    }
}
