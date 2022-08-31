using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Functions of saber
/// </summary>
public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;
    public AudioSource destroySound;
    private GameObject pointCounterManager;
    public GameObject backToMenuCanvas;

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

                    if (!CircularBubbleSpawner.leftHandBonus)
                    {
                        PointCounterManager.countHitBlue++;
                    }
                   
                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                        PointCounterManager.countHitLeftBonus++;
                    }
                    else if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Right"))
                    {
                        PointCounterManager.points -= 100f;
                    }
                    else
                    {
                        PointCounterManager.points -= 20f;
                    }

                }
                else if (hit.transform.tag == "RedSphere")
                {
                    
                    PointCounterManager.countHitRed++;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.points += 150f;
                        PointCounterManager.countHitLeftBonus++; 
                    }
                    else if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Right"))
                    {
                        PointCounterManager.points -= 100f;
                    }
                    else
                    {
                        PointCounterManager.points += 20f;
                    }
                }
                else if (hit.transform.tag == "YellowSphere")
                {
                    
                    PointCounterManager.countHitYellow++;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.countHitLeftBonus++;
                        PointCounterManager.points += 150f;
                    }
                    else if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Right"))
                    {
                        PointCounterManager.points -= 100f;
                    }
                    else
                    {
                        PointCounterManager.points += 100f;
                    }
                }
                else if (hit.transform.tag == "LastSphere")
                {
                    
                    PointCounterManager.countHitRed++;

                    if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Left"))
                    {
                        PointCounterManager.countHitLeftBonus++;
                        PointCounterManager.points += 150f;
                    }
                    else if (CircularBubbleSpawner.leftHandBonus && (gameObject.tag == "Right"))
                    {
                        PointCounterManager.points -= 100f;
                    }
                    else
                    {
                        PointCounterManager.points += 20f;
                    }
                    //StartCoroutine(wait(3));
                    //Instantiate(backToMenuCanvas);

                    DataCollection.LogGameData();
                    PointCounterManager.resetVariables();

                    MainMenuCanvasScript.takeOffHMD = true;
                   
                    SceneManager.LoadScene(0);
                }
                destroySound.Play();
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position;
    }

    IEnumerator wait(float seconds) { yield return new WaitForSeconds(5); }
}
