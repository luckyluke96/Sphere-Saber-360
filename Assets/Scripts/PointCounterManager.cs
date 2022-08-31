using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Stores eye tracking and game data
/// </summary>
public class PointCounterManager : MonoBehaviour
{
    private Text PointCounterText;
    private Text GazeCounterText;
    private Text TimerText;

    public static float points;
    public static float timer;
    public static float rigDeg;
    public static string gameLevel;

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
    public static float gazeDurSparrow;
    public static float gazeDurFountain;
    public static float gazeDurModeACanvas;
    public static float gazeDurModeBCanvas;

    public static float timeToRecFox;
    public static float timeToFirstFixBlueCanvas;
    public static float timeToFirstFixYellowCanvas;
    public static float timeToFirstHintCanvasLeftHand;
    public static float timeToFirstFixFoxMoving;
    public static float timeToFirstFixFoxRigid;
    public static float timeToFirstFixLamp;
    public static float timeToFirstFixFountain;


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
    public static int gazeCountSparrow;
    public static int gazeCountFountain;
    public static int gazeCountModeACanvas;
    public static int gazeCountModeBCanvas;

    public static int countHitRed;
    public static int countHitBlue;
    public static int countHitYellow;
    public static int countHitLeftBonus;

    public static int countSpawnedRed;
    public static int countSpawnedBlue;
    public static int countSpawnedBlueBeforeLeft;
    public static int countSpawnedYellow;
    public static int countSpawnedLeftBonus;

    public static Vector3 positionFoxRigid;
    public static Vector3 positionFoxMoving;
    public static Vector3 positionFountain;
    public static Vector3 positionLamp;

    public static float angleFoxRigid;
    public static float angleFoxMoving;
    public static float angleFountain;
    public static float angleLamp;

    public static float angleBlueCanvas;
    public static float angleYellowCanvas;
    public static float angleLeftHandCanvas;

    public static float durCircularGame;

    void Start()
    {
        // PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        // PointCounterText.text = "Punkte: ";

        if (SceneManager.GetActiveScene().name == "LevelCircularSpawn")
        {
            gameLevel = "LevelCircularSpawn";
        }
        else if (SceneManager.GetActiveScene().name == "LevelRandom")
        {
            gameLevel = "LevelRandom";
        }
        else if (SceneManager.GetActiveScene().name == "LevelCircularSpawn180")
        {
            gameLevel = "LevelCircularSpawn180";
        }
        else if (SceneManager.GetActiveScene().name == "LevelRandom180")
        {
            gameLevel = "LevelRandom180";
        }
        else if (SceneManager.GetActiveScene().name == "LevelRandom180WOHints")
        {
            gameLevel = "LevelRandom180WOHints";
        }
    }

    void Update()
    {
        
        PointCounterText = GameObject.Find("PointCounterText").GetComponent<Text>();
        PointCounterText.text = "Punkte: " + points.ToString();

    }

    /// <summary>
    /// Reset stored data after game
    /// </summary>
    public static void resetVariables()
    {
        points = 0;
        timer = 0;
        rigDeg = 0;
        gameLevel = ""; 

        gazeDur = 0;
        gazeDurBlueCanvas = 0;
        gazeDurYellowCanvas = 0;
        gazeDurPointCounterCanvas = 0;
        gazeDurBlueSphere = 0;
        gazeDurRedSphere = 0;
        gazeDurYellowSphere = 0;
        gazeDurLeftHandCanvas = 0;
        gazeDurFoxMoving = 0;
        gazeDurFoxRigid = 0;
        gazeDurTerrain = 0;
        gazeDurLamp = 0;
        gazeDurSparrow = 0;
        gazeDurFountain = 0;

        timeToRecFox = 0;
        timeToFirstFixBlueCanvas = 0;
        timeToFirstFixYellowCanvas = 0;
        timeToFirstHintCanvasLeftHand = 0;
        timeToFirstFixFoxMoving = 0;
        timeToFirstFixFoxRigid = 0;
        timeToFirstFixLamp = 0;
        timeToFirstFixFountain = 0;

        gazeCountBlueCanvas = 0;
        gazeCountYellowCanvas = 0;
        gazeCountPointCounterCanvas = 0;
        gazeCountBlueSphere = 0;
        gazeCountRedSphere = 0;
        gazeCountYellowSphere = 0;
        gazeCountLeftHandCanvas = 0;
        gazeCountFoxMoving = 0;
        gazeCountFoxRigid = 0;
        gazeCountTerrain = 0;
        gazeCountLamp = 0;
        gazeCountSparrow = 0;
        gazeCountFountain = 0;

        countHitRed = 0;
        countHitBlue = 0;
        countHitYellow = 0;
        countHitLeftBonus = 0;

        countSpawnedRed = 0;
        countSpawnedBlue = 0;
        countSpawnedYellow = 0;
        countSpawnedLeftBonus = 0;

        positionFoxRigid = new Vector3(0,0,0);
        positionFoxMoving = new Vector3(0, 0, 0);
        positionFountain = new Vector3(0, 0, 0);
        positionLamp = new Vector3(0, 0, 0);

        angleFoxRigid = 0;
        angleFoxMoving = 0;
        angleFountain = 0;
        angleLamp = 0;

        angleBlueCanvas = 0;
        angleYellowCanvas = 0;
        angleLeftHandCanvas = 0;

        durCircularGame = 0;
    }
}
