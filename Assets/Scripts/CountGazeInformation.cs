// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;


namespace Tobii.XR.Examples.GettingStarted
{
    //Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
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


        //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
        public void GazeFocusChanged(bool hasFocus)
        {
            focus = hasFocus;
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                //startTime = System.DateTime.UtcNow;
                _targetColor = highlightColor;
                // PointCounterManager.gazeDur += 10;

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

                    if (firstGaze)
                    {
                        PointCounterManager.timeToFirstFixBlueCanvas = spawnDur;
                        firstGaze = false;
                    }

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

            }
            //If this object lost focus, fade the object's color to it's original color
            else
            {
                //endTime = System.DateTime.UtcNow;
                _targetColor = _originalColor;
                //System.TimeSpan diffTime = endTime - startTime;
                //PointCounterManager.gazeDur += diffTime.Milliseconds;
            }
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;


        }

        

        private void Update()
        {
            /*
            //This lerp will fade the color of the object
            if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
            {
                //_renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
            }
            else // old standard rendering pipline
            {
                //_renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
            }
            */

            

            if (focus)
            {

                tTime = Time.deltaTime;
                PointCounterManager.gazeDur += tTime;

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


            }
            

        }

        private void FixedUpdate()
        {
            
            
            spawnDur += Time.deltaTime;

            // Debug.Log("cam deg: " + CircularBubbleSpawner.getCameraDirectionDeg());

            // Debug.Log("foxrigid in FOV: " + isInFieldOfView(PeripheralSpawner.foxRigidAngle));
            // Debug.Log("foxmoving in FOV: " + isInFieldOfView(PeripheralSpawner.foxMovingAngle));
            // Debug.Log("fountain in FOV: " + isInFieldOfView(PeripheralSpawner.fountainAngle));
            // Debug.Log("lamp in FOV: " + isInFieldOfView(PeripheralSpawner.lampAngle));

            
            // sets variable to true that marks if object has been in FOV at least once
            if(isInFieldOfView(PeripheralSpawner.foxRigidAngle))
            {
                foxMovingInFOV = true;
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

        private bool isInFieldOfView(float angle)
        {
            float camDeg = CircularBubbleSpawner.getCameraDirectionDeg();
            float left = camDeg - 30f; 
            float right = camDeg + 30f;

            // Debug.Log("left: " + left);
            // Debug.Log("right: " + right);
            // Debug.Log("angle: " + angle);

            float diff = (camDeg - angle + 180f + 360f) % 360f - 180f;
            if(-30 <= diff && diff <= 30)
            {
                return true;
            }
            return false;
        }
    }
}
