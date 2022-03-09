using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafetySphereScript : MonoBehaviour
{
    public GameObject backToMenuCanvas;
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
        if(other.tag == "RedSphere" || other.tag == "BlueSphere")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag == "LastSphere")
        {
            
            Destroy(other.gameObject);
            
            StartCoroutine(wait(10));
            //Instantiate(backToMenuCanvas);
            SceneManager.LoadScene(0);

        }
    }

    IEnumerator wait(float seconds) { yield return new WaitForSeconds(5); }

}
