using System.Collections;
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
        pathAllHighscores = Path.Combine(pathAllHighscores, "allHighscorelogs_" + "test" + ".csv");
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
            string columnString = "DateTime;" + "Points;" + "Game_Level;" + "Rig_Deg;" +
                "Gaze_Dur_Blue_Canvas;" + "Gaze_Dur_Yellow_Canvas;" + "Gaze_Point_Counter_Canvas;" + "Gaze_Dur_LeftHand_Canvas;" +
                "Gaze_Dur_Total;" + "Gaze_Dur_RedSphere;" + "Gaze_Dur_BlueSphere;" + "Gaze_Dur_YellowSphere;" +
                "Gaze_Dur_FoxMoving;" + "Gaze_Dur_FoxRigid;" + "Gaze_Dur_Terrain;" + "Gaze_Dur_Lamp;" +
                "Gaze_Dur_Sparrow;" + "Gaze_Dur_Fountain;" +
                "Gaze_Count_Blue_Canvas;" + "Gaze_Count_Yellow_Canvas;" + "Gaze_Count_Pointer_Canvas;" +
                "Gaze_Count_Blue_Sphere;" + "Gaze_Count_Red_Sphere;" + "Gaze_Count_Yellow_Sphere;" +
                "GazeCount_FoxMoving;" + "Gaze_Count_Fox_Rigid;" + "Gaze_Count_Terrain;" + "Gaze_Count_Lamp;" +
                "Gaze_Counter_Sparrow;" + "Gaze_Counter_Fountain;" +
                "TimeToRecFox;" + "TimeToFirstFixBlueCanvas;" + "TimeToFirstFixYellowCanvas;" +
                "Circular_Game_Dur;" + 
                "Hit_Red_Counter;" + "Hit_Blue_Counter;" + "Hit_Yellow_Counter;" + "Hit_Left;" +
                "Spawned_Red;" + "Spawned_Blue;" + "Spawned_Yellow;" + "Spawned_Left" + "\n";
            string logString = DateTime.Now + ";" + PointCounterManager.points + ";" + PointCounterManager.gameLevel + ";" + PointCounterManager.rigDeg +
                ";" + PointCounterManager.gazeDurBlueCanvas + ";" + PointCounterManager.gazeDurYellowCanvas + ";" + PointCounterManager.gazeDurPointCounterCanvas + ";" + PointCounterManager.gazeDurLeftHandCanvas +
                ";" + PointCounterManager.gazeDur + ";" + PointCounterManager.gazeDurRedSphere + ";" + PointCounterManager.gazeDurBlueSphere + ";" + PointCounterManager.gazeDurYellowSphere +
                ";" + PointCounterManager.gazeDurFoxMoving + ";" + PointCounterManager.gazeDurFoxRigid + ";" + PointCounterManager.gazeDurTerrain + ";" + PointCounterManager.gazeDurLamp +
                ";" + PointCounterManager.gazeDurSparrow + ";" + PointCounterManager.gazeCountFountain +
                ";" + PointCounterManager.gazeCountBlueCanvas + ";" + PointCounterManager.gazeCountYellowCanvas + ";" + PointCounterManager.gazeCountPointCounterCanvas +
                ";" + PointCounterManager.gazeCountBlueSphere + ";" + PointCounterManager.gazeCountRedSphere + ";" + PointCounterManager.gazeCountYellowSphere +
                ";" + PointCounterManager.gazeCountFoxMoving + ";" + PointCounterManager.gazeCountFoxRigid + ";" + PointCounterManager.gazeCountTerrain + ";" + PointCounterManager.gazeCountLamp +
                ";" + PointCounterManager.gazeCountSparrow + ";" + PointCounterManager.gazeCountFountain + 
                ";" + PointCounterManager.timeToRecFox + ";" + PointCounterManager.timeToFirstFixBlueCanvas + ";" + PointCounterManager.timeToFirstFixYellowCanvas +
                ";" + PointCounterManager.durCircularGame +
                ";" + PointCounterManager.countHitRed + ";" + PointCounterManager.countHitBlue + ";" + PointCounterManager.countHitYellow + ";" + PointCounterManager.countHitLeftBonus +
                ";" + PointCounterManager.countSpawnedRed + ";" + PointCounterManager.countSpawnedBlue + ";" + PointCounterManager.countSpawnedYellow + ";" + PointCounterManager.countSpawnedLeftBonus;


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
