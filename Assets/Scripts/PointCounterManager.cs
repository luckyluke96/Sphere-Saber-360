using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PointCounterManager : MonoBehaviour
{
    private Text PointCounterText;
    private Text GazeCounterText;
    private Text TimerText;

    public static float points;
    public static float timer;
    public static float rigDeg;

    public static float gazeDur;
    public static float gazeDurBlueCanvas;
    public static float gazeDurYellowCanvas;
    public static float gazeDurPointCounterCanvas;
    public static float gazeDurBlueSphere;
    public static float gazeDurRedSphere;
    public static float gazeDurYellowSphere;
    public static float gazeDurLeftHandCanvas;
    public static float gazeDurFoxMoving;
    public static float gazeDurFoxRigid;
    public static float gazeDurTerrain;
    public static float gazeDurLamp;

    public static float timeToRecFox;
    public static float timeToFirstFixBlueCanvas;

    public static int gazeCountBlueCanvas;
    public static int gazeCountYellowCanvas;
    public static int gazeCountPointCounterCanvas;
    public static int gazeCountBlueSphere;
    public static int gazeCountRedSphere;
    public static int gazeCountYellowSphere;
    public static int gazeCountLeftHandCanvas;
    public static int gazeCountFoxMoving;
    public static int gazeCountFoxRigid;
    public static int gazeCountTerrain;
    public static int gazeCountLamp;

    public static float durCircularGame;
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
        
        //GazeCounterText = GameObject.Find("PointCounterTextStable").GetComponent<Text>();
        //TimerText = GameObject.Find("TimerText").GetComponent<Text>();

        PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        PointCounterText.text = "Punkte: " + points.ToString();
        // gazeDur = gazeDurBlueCanvas + gazeDurYellowCanvas + gazeDurPointCounterCanvas + gazeDurBlueSphere + gazeDurRedSphere + gazeDurYellowSphere;

        // GazeCounterText.text = "redbubble " + gazeDurRedSphere.ToString() + "ms\nbluesphere " + gazeDurBlueSphere.ToString();

        // timer += Time.deltaTime;
        // TimerText.text = "time: " + timer.ToString() + "s";
            

        
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
