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
        pathAllHighscores = @"" + Application.persistentDataPath + "/logs/";
        Debug.Log(pathAllHighscores);
        Directory.CreateDirectory(pathAllHighscores);
        
        pathAllHighscores = Path.Combine(pathAllHighscores, "allHighscorelogs_"+ "test" + ".csv");
    }


    public static void LogGameData()
    {
        
        if(true)
        {
            
            string columnString = "ID;"+ "DateTime;" + "Points;" + "Game_Level;" + "Rig_Deg;" +
                "Gaze_Dur_Blue_Canvas;" + "Gaze_Dur_Yellow_Canvas;" + "Gaze_Point_Counter_Canvas;" + "Gaze_Dur_LeftHand_Canvas;" +
                "Gaze_Dur_Total;" + "Gaze_Dur_RedSphere;" + "Gaze_Dur_BlueSphere;" + "Gaze_Dur_YellowSphere;" +
                "Gaze_Dur_FoxMoving;" + "Gaze_Dur_FoxRigid;" + "Gaze_Dur_Terrain;" + "Gaze_Dur_Lamp;" +
                "Gaze_Dur_Fountain;" + "Gaze_Dur_ModeACanvas;" + "Gaze_Dur_ModeBCanvas;" +
                "Gaze_Count_Blue_Canvas;" + "Gaze_Count_Yellow_Canvas;" + "Gaze_Count_Pointer_Canvas;" +
                "Gaze_Count_Blue_Sphere;" + "Gaze_Count_Red_Sphere;" + "Gaze_Count_Yellow_Sphere;" +
                "GazeCount_FoxMoving;" + "Gaze_Count_Fox_Rigid;" + "Gaze_Count_Terrain;" + "Gaze_Count_Lamp;" +
                "Gaze_Counter_Fountain;" + "Gaze_Count_ModeACanvas;" + "Gaze_Count_ModeBCanvas;" +
                "TimeToFirstFixBlueCanvas;" + "TimeToFirstFixYellowCanvas;" + "TimeToFirstHintCanvasLeftHand;" +
                "TimeToFixFoxMoving;" + "timeToFirstFixFoxRigid;" + "timeToFirstFixLamp;" + "timeToFirstFixFountain;" +
                "Circular_Game_Dur;" + 
                "Hit_Red_Counter;" + "Hit_Blue_Counter_Before_Left;" + "Hit_Yellow_Counter;" + "Hit_Left;" +
                "Spawned_Red;" + "Spawned_Blue_Before_Left;" + "Spawned_Blue;" + "Spawned_Yellow;" + "Spawned_Left;" +
                "AngleFoxRigid;" + "AngleFoxMoving;" + "AngleFountain;" + "AngleLamp;" +
                "positionFoxRigid;" + "positionFoxMoving;" + "positionFountain;" + "positionLamp;" +
                "AngleBlueCanvas;" + "AngleYellowCanvas;" + "AngleLeftHandCanvas;" +
                "\n";
            string logString = "******;" + DateTime.Now.ToString() + ";" + PointCounterManager.points.ToString() + ";" + PointCounterManager.gameLevel.ToString() + ";" + PointCounterManager.rigDeg.ToString() +
                ";" + PointCounterManager.gazeDurBlueCanvas.ToString() + ";" + PointCounterManager.gazeDurYellowCanvas.ToString() + ";" + PointCounterManager.gazeDurPointCounterCanvas.ToString() + ";" + PointCounterManager.gazeDurLeftHandCanvas.ToString() +
                ";" + PointCounterManager.gazeDur.ToString() + ";" + PointCounterManager.gazeDurRedSphere.ToString() + ";" + PointCounterManager.gazeDurBlueSphere.ToString() + ";" + PointCounterManager.gazeDurYellowSphere.ToString() +
                ";" + PointCounterManager.gazeDurFoxMoving.ToString() + ";" + PointCounterManager.gazeDurFoxRigid.ToString() + ";" + PointCounterManager.gazeDurTerrain.ToString() + ";" + PointCounterManager.gazeDurLamp.ToString() +
                ";" + PointCounterManager.gazeDurFountain.ToString() + ";" + PointCounterManager.gazeDurModeACanvas.ToString() + ";" + PointCounterManager.gazeDurModeBCanvas.ToString() +
                ";" + PointCounterManager.gazeCountBlueCanvas.ToString() + ";" + PointCounterManager.gazeCountYellowCanvas.ToString() + ";" + PointCounterManager.gazeCountPointCounterCanvas.ToString() +
                ";" + PointCounterManager.gazeCountBlueSphere.ToString() + ";" + PointCounterManager.gazeCountRedSphere.ToString() + ";" + PointCounterManager.gazeCountYellowSphere.ToString() +
                ";" + PointCounterManager.gazeCountFoxMoving.ToString() + ";" + PointCounterManager.gazeCountFoxRigid.ToString() + ";" + PointCounterManager.gazeCountTerrain.ToString() + ";" + PointCounterManager.gazeCountLamp.ToString() +
                ";" + PointCounterManager.gazeCountFountain.ToString() + ";" + PointCounterManager.gazeCountModeACanvas.ToString() + ";" + PointCounterManager.gazeCountModeBCanvas.ToString() +
                ";" + PointCounterManager.timeToFirstFixBlueCanvas.ToString() + ";" + PointCounterManager.timeToFirstFixYellowCanvas.ToString() + ";" + PointCounterManager.timeToFirstHintCanvasLeftHand.ToString() +
                ";" + PointCounterManager.timeToFirstFixFoxMoving.ToString() + ";" + PointCounterManager.timeToFirstFixFoxRigid.ToString() + ";" + PointCounterManager.timeToFirstFixLamp.ToString() + ";" + PointCounterManager.timeToFirstFixFountain.ToString() +
                ";" + PointCounterManager.durCircularGame.ToString() + 
                ";" + PointCounterManager.countHitRed.ToString() + ";" + PointCounterManager.countHitBlue.ToString() + ";" + PointCounterManager.countHitYellow.ToString() + ";" + PointCounterManager.countHitLeftBonus.ToString() +
                ";" + PointCounterManager.countSpawnedRed.ToString() + ";" + PointCounterManager.countSpawnedBlueBeforeLeft + ";" + PointCounterManager.countSpawnedBlue.ToString() + ";" + PointCounterManager.countSpawnedYellow.ToString() + ";" + PointCounterManager.countSpawnedLeftBonus.ToString() +
                ";" + PointCounterManager.angleFoxRigid.ToString() + ";" + PointCounterManager.angleFoxMoving.ToString() + ";" + PointCounterManager.angleFountain.ToString() + ";" + PointCounterManager.angleLamp.ToString() + 
                ";" + PointCounterManager.positionFoxRigid.ToString() + ";" + PointCounterManager.positionFoxMoving.ToString() + ";" + PointCounterManager.positionFountain.ToString() + ";" + PointCounterManager.positionLamp.ToString() +
                ";" + PointCounterManager.angleBlueCanvas.ToString() + ";" + PointCounterManager.angleYellowCanvas.ToString() + ";" + PointCounterManager.angleLeftHandCanvas.ToString()
                
                ;

            // add column names only when file is created
            if (!File.Exists(pathAllHighscores))
            {
                File.WriteAllText(pathAllHighscores, columnString);
                
            }
            // always save data recorded during one run
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
