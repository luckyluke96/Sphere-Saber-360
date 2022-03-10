﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class DataCollection : MonoBehaviour
{
    
    private string content;

    private static string pathAllHighscores;
    private string fileName;
    private bool columnNames;

    void Start()
    {
       SetUpPaths();
        
    }

    public void SetUpPaths()
    {
        // dieser Pfad befindet sich unter C/User/Name/AppData/LocalLow/GameName auf Windows, und unter Android/Data/AppName auf der Oculus 
        pathAllHighscores = @"" + Application.persistentDataPath + "/logs/";
        Debug.Log(pathAllHighscores);
        Directory.CreateDirectory(pathAllHighscores);
        //pathAllHighscores = Path.Combine(pathAllHighscores, "allHighscorelogs" + Configuration.Instance.playerID + ".csv");
        pathAllHighscores = Path.Combine(pathAllHighscores, "allHighscorelogs" + "test" + ".csv");
    }


    public static void LogGameData()
    {
        // if (Configuration.Instance.collectData)
        if(true)
        {
            /*
            string columnString = "LOG" + "\t" + "UserID" + "\t" + "SessionID" + "\t" + "Levels_Played" + "\t" + "Levels_Played_In_Session" + "\t" + "Level" + "\t" + "Level_Length" +
             "\t" + "Correct_Bubbles" + "\t" + "Wrong Bubbles" + "\t" + "Missed_Bubbles" + "\t" + "Total_Possibly_Correct_Bubbles" + "\t" + "Total_Possibly_Wrong_Bubbles" + "\t" + "Total_Amount_Of_Bubbles" +
              "\t" + "Obstacles_Touched" + "\t" + "Total_Obstacles" + "\t" + "Time_In_This_Run" + "\t" + "Correct_Bubbles_This_Round" + "\t" + "Wrong_Bubbles_This_Round" + "\t" + "Missed_Bubbles_This_Round"+ "\t" + "Obstacles_Touched_This_Round" + "\t" + "Correct_Bubbles_In_Tutorial" + "\t" + "Wrong_Bubbles_In_Tutorial" + "\t" + "Missed_Bubbles_In_Tutorial" + "\t" + "Obstacles_Touched_In_Tutorial" + "\t" + "Time_In_Game" +
             "\t" + "Score" + "\t" + "Head_Movement" + "\t" + "Right_Hand_Movement" + "\t" + "Left_Hand_Movement" + "\t" + "Right_Hand_Above_Head" + "\t" + "Right_Hand_Above_Head_Time" + "\t" + "Left_Hand_Above_Head" + "\t" + "Left_Hand_Above_Head_Time"
             + "\t" + "Mode" + "\t" + "Bubble_Rounds" + "\t" + "Bubble_Rounds_This_Round" + "\t" + "Dif_For_This_Level" + "\t" + "Condition" + "\t" + "Perfect_Bubble_Distance" + "\n";

            string logString = now + "\t" + Configuration.Instance.playerID + "\t" + Configuration.Instance.sessionID + "\t" + GameDataManager.Instance.levelsPlayedCount + "\t" + GameDataManager.Instance.levelsPlayedInSessionCount + "\t" + LevelManager.Instance.currentLevel.ToString() + "\t" + Configuration.Instance.levelLength + "\t" +
                         GameDataManager.Instance.correctBubbles + "\t" + GameDataManager.Instance.wrongBubbles + "\t" + GameDataManager.Instance.missedBubbles + "\t" + GameDataManager.Instance.possiblyCorrectBubbles + "\t" + GameDataManager.Instance.possiblyWrongBubbles + "\t" + GameDataManager.Instance.possibleBubbles + "\t" +
                         GameDataManager.Instance.numberOfObstaclesTouched + "\t" + GameDataManager.Instance.possibleObstacles + "\t" + Mathf.Round(GameDataManager.Instance.timeInRound) + "\t" + GameDataManager.Instance.correctBubblesThisRound + "\t" + GameDataManager.Instance.wrongBubblesThisRound + "\t" + GameDataManager.Instance.missedBubblesThisRound + "\t" + GameDataManager.Instance.numberOfObstaclesTouchedThisRound + "\t" + GameDataManager.Instance.correctBubblesInTutorial + "\t" + GameDataManager.Instance.wrongBubblesInTutorial + "\t" + GameDataManager.Instance.missedBubblesInTutorial + "\t" + GameDataManager.Instance.numberOfObstaclesTouchedInTutorial + "\t" + Mathf.Round(GameDataManager.Instance.totalTimeInGame) + "\t" +
                         HighScore.Instance.score + "\t" + headMovement + "\t" + rightHandMovement + "\t" + leftHandMovement + "\t" + rightHandMovementAboveHead + "\t" + rightHandAboveHeadTime + "\t" + leftHandMovementAboveHead + "\t" + leftHandAboveHeadTime
                         + "\t" + TimePressureStudyLogic.Instance.currentMode.ToString() + "\t" + GameDataManager.Instance.amountOfFinishedBubbleRounds + "\t" + GameDataManager.Instance.amountOfFinishedBubbleRoundsThisRound + "\t" + Configuration.Instance.resetDistanceBetweenBubbles + "\t" + TimePressureStudyLogic.Instance.currentCondition.ToString() + "\t" + ((float) Configuration.Instance.levelLength / GameDataManager.Instance.amountOfFinishedBubbleRounds);
            */
            string columnString = "Points," + "Gaze_Dur_Blue_Canvas," + "Gaze_Dur_Yellow_Canvas," + "Gaze_Point_Counter_Canvas," +
                "Gaze_Dur_Total,"  + "Gaze_Dur_RedSphere," + "Gaze_Dur_BlueSphere," + "Gaze_Dur_YellowSphere\n";
            string logString = PointCounterManager.points + "," + PointCounterManager.gazeDurBlueCanvas + "," + PointCounterManager.gazeDurYellowCanvas + "," + PointCounterManager.gazeDurPointCounterCanvas +
                "," + PointCounterManager.gazeDur + "," + PointCounterManager.gazeDurRedSphere + "," + PointCounterManager.gazeDurBlueSphere + "," + PointCounterManager.gazeDurYellowSphere;
            
            // add column names only when file is created the first time -> das hier überschreibt alles
            if (!File.Exists(pathAllHighscores))
            {
                File.WriteAllText(pathAllHighscores, columnString);
                
            }
            // always save data recorded during one run -> das hier hängt Text unten an eine Datei an
            using (StreamWriter sw = File.AppendText(pathAllHighscores))
            {
                sw.WriteLine(logString);
            }
        }
    }

    public void AddContent(string newContent)
    {
        content += newContent;
    }
}