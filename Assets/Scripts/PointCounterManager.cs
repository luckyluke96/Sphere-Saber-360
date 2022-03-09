using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PointCounterManager : MonoBehaviour
{
    private Text PointCounterText;
    public static float points;
    public static float gazeDur;
    //public int points;

    // Start is called before the first frame update
    void Start()
    {
        // PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        // PointCounterText.text = "Punkte: ";

        


    }

    // Update is called once per frame
    void Update()
    {
        
        PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        PointCounterText.text = "Punkte: " + points.ToString();

        //PointCounterText.text = "gaze: " + gazeDur.ToString();


        
        // Debug.Log("Sign text: " + PointCounterText.text);

        /*
        string filePath = Application.persistentDataPath + "/test.txt";
        Debug.Log(filePath);
        File.WriteAllText("test.txt", "hallo test text");

        PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        PointCounterText.text = "path: " + filePath;
        */
    }
}
