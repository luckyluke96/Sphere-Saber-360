using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PointCounterManager : MonoBehaviour
{
    private Text PointCounterText;
    private Text TimerText;

    public static float points;
    public static float timer;

    public static float gazeDur;
    public static float gazeDurBlueCanvas;
    public static float gazeDurYellowCanvas;
    public static float gazeDurPointCounterCanvas;
    public static float gazeDurBlueSphere;
    public static float gazeDurRedSphere;
    public static float gazeDurYellowSphere;
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
        TimerText = GameObject.Find("TimerText").GetComponent<Text>();

        // PointCounterText.text = "Punkte: " + points.ToString();
        // gazeDur += gazeDurBlueCanvas + gazeDurYellowCanvas + gazeDurPointCounterCanvas + gazeDurBlueSphere + gazeDurRedSphere + gazeDurYellowSphere;

        PointCounterText.text = "gaze: " + gazeDur.ToString() + "ms";

        timer += Time.deltaTime;
        TimerText.text = "time: " + timer.ToString() + "ms";
            

        
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
