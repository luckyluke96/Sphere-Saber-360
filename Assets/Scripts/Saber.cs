using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;
    public AudioSource destroySound;
    private GameObject pointCounterManager;


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
            || hit.transform.tag == "GreenSphere"))
        {
            
            
            
            if(Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                if (hit.transform.tag == "BlueSphere")
                {
                    // pointCounterManager.GetComponent<PointCounterManager>().points -= 20;
                    PointCounterManager.points -= 20f;
                }
                else if (hit.transform.tag == "RedSphere")
                {
                    PointCounterManager.points += 20f;
                }
                else if (hit.transform.tag == "YellowSphere")
                {
                    PointCounterManager.points += 100f;
                }
                destroySound.Play();
                Destroy(hit.transform.gameObject);

                string filePath = Application.persistentDataPath + "/test.txt";
                File.WriteAllText("test.txt", "hallo test text");



            }
            
            
            
            //Destroy(hit.transform.gameObject);
        }
        previousPos = transform.position;
    }
}
