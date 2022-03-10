﻿// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

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
            
            //This lerp will fade the color of the object
            if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
            {
                _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
            }
            else // old standard rendering pipline
            {
                _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
            }

            

            if (focus)
            {
                
                // tTime = Time.deltaTime;
                // PointCounterManager.gazeDur += tTime;

                if(gameObject.tag == "TestCube")
                {
                    tTime = Time.deltaTime;
                    PointCounterManager.gazeDur += tTime;
                }

                /*
                if (gameObject.tag == "HintCanvasBlue")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurBlueCanvas += tTime;
                }
                else if (gameObject.tag == "HintCanvasYellow")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurYellowCanvas += tTime;

                }
                else if (gameObject.tag == "PointCounterCanvas")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurPointCounterCanvas += tTime;

                }
                else if (gameObject.tag == "BlueSphere")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurBlueSphere += tTime;

                }
                else if (gameObject.tag == "RedSphere")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurRedSphere += tTime;

                }
                else if (gameObject.tag == "YellowSphere")
                {
                    // tTime += Time.deltaTime;
                    PointCounterManager.gazeDurYellowSphere += tTime;

                }
                */
                
            }
            

        }

        private void FixedUpdate()
        {
            /*
            Debug.Log("OldTimer: " + timer);
            float delta = Time.deltaTime;
            PointCounterManager.timer = PointCounterManager.timer + delta;
            timer += delta;

            Debug.Log("DeltaTime: " + delta);
            Debug.Log("FixedUpdate: " + timer);
            Debug.Log("PointerCoutnerTimer: " + PointCounterManager.timer);
            */

            

        }
    }
}
