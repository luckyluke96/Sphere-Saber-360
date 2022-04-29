using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafetySphereScript : MonoBehaviour
{
    public GameObject backToMenuCanvas;
    public GameObject explosionRed;
    public GameObject explosionBlue;
    public GameObject explosionYellow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger: "+other.tag);
        if(other.tag == "RedSphere" || other.tag == "BlueSphere" || other.tag == "YellowSphere")
        {
            /*
            switch(other.tag)
            {
                case "RedSphere": Instantiate(explosionRed, other.gameObject.transform.position, Quaternion.identity);
                    break;
                case "BlueSphere": Instantiate(explosionBlue, other.gameObject.transform.position, Quaternion.identity);
                    break;
                case "YellowSphere": Instantiate(explosionYellow, other.gameObject.transform.position, Quaternion.identity);
                    break;
            }*/

            
            if(other.tag == "RedSphere")
            {
                Instantiate(explosionRed, other.gameObject.transform.position, Quaternion.identity);
            }
            else if(other.tag == "BlueSphere")
            {
                Instantiate(explosionBlue, other.gameObject.transform.position, Quaternion.identity);
                PointCounterManager.points += 20f;
            }
            else if (other.tag == "YellowSphere")
            {
                Instantiate(explosionYellow, other.gameObject.transform.position, Quaternion.identity);
            }
            
            PointCounterManager.points -= 20f;
            Destroy(other.gameObject);
        }
        else if (other.tag == "LastSphere")
        {
            
            Destroy(other.gameObject);
            DataCollection.LogGameData();

            MainMenuCanvasScript.takeOffHMD = true;

            //StartCoroutine(wait(10));
            //Instantiate(backToMenuCanvas);
            SceneManager.LoadScene(0);

        }
    }

    IEnumerator wait(float seconds) { yield return new WaitForSeconds(5); }

}
