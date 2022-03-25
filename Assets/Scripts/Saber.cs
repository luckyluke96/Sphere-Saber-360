using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;
    public AudioSource destroySound;
    private GameObject pointCounterManager;
    public GameObject backToMenuCanvas;


    // Start is called before the first frame update
    void Start()
    {
        destroySound = GetComponent<AudioSource>();
        pointCounterManager = GameObject.Find("PointCounterManager");
        
        // pointCounterManagerScript = pointCounterManager.GetComponent<PointCounterManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //PointCounterManager.points += 0.0001f;
        
        if( Physics.Raycast(transform.position, transform.forward, out hit, 1, layer) && (hit.transform.tag == "BlueSphere"
            || hit.transform.tag == "RedSphere"
            || hit.transform.tag == "YellowSphere"
            || hit.transform.tag == "GreenSphere"
            || hit.transform.tag == "LastSphere"))
        {
            
            
            
            if(Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                if (hit.transform.tag == "BlueSphere")
                {
                    // pointCounterManager.GetComponent<PointCounterManager>().points -= 20;
                    PointCounterManager.points -= 20f;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                    }

                }
                else if (hit.transform.tag == "RedSphere")
                {
                    PointCounterManager.points += 20f;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                    }
                }
                else if (hit.transform.tag == "YellowSphere")
                {
                    PointCounterManager.points += 100f;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                    }
                }
                else if (hit.transform.tag == "LastSphere")
                {
                    PointCounterManager.points += 20f;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                    }
                    //StartCoroutine(wait(3));
                    //Instantiate(backToMenuCanvas);

                    DataCollection.LogGameData();
                    SceneManager.LoadScene(0);
                    
                }
                destroySound.Play();
                Destroy(hit.transform.gameObject);

                // string filePath = Application.persistentDataPath + "/test.txt";
                // File.WriteAllText("test.txt", "hallo test text");



            }
            
            
            
            //Destroy(hit.transform.gameObject);
        }
        previousPos = transform.position;
    }

    IEnumerator wait(float seconds) { yield return new WaitForSeconds(5); }
}
