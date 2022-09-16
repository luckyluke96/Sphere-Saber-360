// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;


namespace Tobii.XR.Examples.GettingStarted
{
    /// <summary>
    /// Collects gaze and eye tracking data of the object
    /// </summary>
    public class CountGazeInformation : MonoBehaviour, IGazeFocusable
    {
        private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
        public Color highlightColor = Color.red;
        public float animationTime = 0.1f;
        
        private Renderer _renderer;
        private Color _originalColor;
        private Color _targetColor;
        private float timer;
        private float tTime;
        private bool focus;
        private System.DateTime startTime;
        private System.DateTime endTime;
        private float spawnDur;
        private bool firstGaze = true;

        private bool foxRigidInFOV = false;
        private bool foxMovingInFOV = false;
        private bool fountainInFOV = false;
        private bool lampInFOV = false;

        private float spawnDurFoxRigid;
        private float spawnDurFoxMoving;
        private float spawnDurFountain;
        private float spawnDurLamp;

        public void GazeFocusChanged(bool hasFocus)
        {
            focus = hasFocus;
            
            if (hasFocus)
            {
                _targetColor = highlightColor;

                if (gameObject.tag == "TestCube")
                {
                    
                }
                else if (gameObject.tag == "HintCanvasBlue")
                {
                    PointCounterManager.gazeCountBlueCanvas += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixBlueCanvas = spawnDur;
                        firstGaze = false;
                    }
                }
                else if (gameObject.tag == "HintCanvasYellow")
                {
                    PointCounterManager.gazeCountYellowCanvas += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixYellowCanvas = spawnDur;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "PointCounterCanvas")
                {
                    PointCounterManager.gazeCountPointCounterCanvas += 1;
  
                }
                else if (gameObject.tag == "BlueSphere")
                {
                    PointCounterManager.gazeCountBlueSphere += 1;

                }
                else if (gameObject.tag == "RedSphere")
                {
                    PointCounterManager.gazeCountRedSphere += 1;

                }
                else if (gameObject.tag == "YellowSphere")
                {
                    PointCounterManager.gazeCountYellowSphere += 1;

                }
                else if (gameObject.tag == "HintCanvasLeftHand")
                {
                    PointCounterManager.gazeCountLeftHandCanvas += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstHintCanvasLeftHand = spawnDur;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "FoxMoving")
                {
                    PointCounterManager.gazeCountFoxMoving += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixFoxMoving = spawnDurFoxMoving;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "FoxRigid")
                {
                    PointCounterManager.gazeCountFoxRigid += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixFoxRigid = spawnDurFoxRigid;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "Terrain")
                {
                    PointCounterManager.gazeCountTerrain += 1;

                }
                else if (gameObject.tag == "Lamp")
                {
                    PointCounterManager.gazeCountLamp += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixLamp = spawnDurLamp;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "Sparrow")
                {
                    PointCounterManager.gazeCountSparrow += 1;

                }
                else if (gameObject.tag == "Fountain")
                {
                    PointCounterManager.gazeCountFountain += 1;

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixFountain = spawnDurFountain;
                        firstGaze = false;
                    }

                }
                else if (gameObject.tag == "ModeACanvas")
                {
                    PointCounterManager.gazeCountModeACanvas += 1;


                }
                else if (gameObject.tag == "ModeBCanvas")
                {
                    PointCounterManager.gazeCountModeBCanvas += 1;


                }

            }
            else
            {
                _targetColor = _originalColor;
            }
        }

        private void Start()
        {
            // Uncomment to change color of object to red when focused
            /*
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;
            */
        }

        

        private void Update()
        {

            // Uncomment to change color of object to red when focused
            /*
            if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
            {
                _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
            }
            else // old standard rendering pipline
            {
                _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
            }
            */

            if (focus)
            {
                if (gameObject.tag == "TestCube")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDur += tTime;
                }
                else if (gameObject.tag == "HintCanvasBlue")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurBlueCanvas += tTime;
                }
                else if (gameObject.tag == "HintCanvasYellow")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurYellowCanvas += tTime;

                }
                else if (gameObject.tag == "PointCounterCanvas")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurPointCounterCanvas += tTime;

                }
                else if (gameObject.tag == "BlueSphere")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurBlueSphere += tTime;

                }
                else if (gameObject.tag == "RedSphere")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurRedSphere += tTime;

                }
                else if (gameObject.tag == "YellowSphere")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurYellowSphere += tTime;

                }
                else if (gameObject.tag == "HintCanvasLeftHand")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurLeftHandCanvas += tTime;

                }
                else if (gameObject.tag == "FoxRigid")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurFoxRigid += tTime;

                }
                else if (gameObject.tag == "FoxMoving")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurFoxMoving += tTime;

                }
                else if (gameObject.tag == "Terrain")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurTerrain += tTime;

                }
                else if (gameObject.tag == "Lamp")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurLamp += tTime;

                }
                else if (gameObject.tag == "Sparrow")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurSparrow += tTime;

                }
                else if (gameObject.tag == "Fountain")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurFountain += tTime;

                }
                else if (gameObject.tag == "ModeACanvas")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurModeACanvas += tTime;
                }
                else if (gameObject.tag == "ModeBCanvas")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDurModeBCanvas += tTime;
                }

                PointCounterManager.gazeDur += Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            
            spawnDur += Time.deltaTime;

            // sets variable to true that marks if object has been in FOV at least once
            if(isInFieldOfView(PeripheralSpawner.foxRigidAngle))
            {
                foxRigidInFOV = true;
            }
            if(isInFieldOfView(PeripheralSpawner.foxMovingAngle))
            {
                foxMovingInFOV = true;
            }
            if(isInFieldOfView(PeripheralSpawner.fountainAngle))
            {
                fountainInFOV = true;
            }
            if(isInFieldOfView(PeripheralSpawner.lampAngle))
            {
                lampInFOV = true;
            }

            if(foxMovingInFOV) { spawnDurFoxMoving += Time.deltaTime;  };
            if(foxRigidInFOV) { spawnDurFoxRigid += Time.deltaTime; };
            if(fountainInFOV) { spawnDurFountain += Time.deltaTime; };
            if(lampInFOV) { spawnDurLamp += Time.deltaTime; };
            
        }

        /// <summary>
        /// Checks if parameter angle is inside FOV range
        /// </summary>
        private bool isInFieldOfView(float angle)
        {
            float camDeg = CircularBubbleSpawner.getCameraDirectionDeg();
            // float left = camDeg - 30f; 
            // float right = camDeg + 30f;


            float diff = (camDeg - angle + 180f + 360f) % 360f - 180f;
            if(-30 <= diff && diff <= 30)
            {
                return true;
            }
            return false;
        }
    }
}
