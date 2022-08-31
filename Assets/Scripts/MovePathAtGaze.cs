// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;
using PathCreation;

namespace Tobii.XR.Examples.GettingStarted
    
{
    namespace PathCreation.Examples
    {
        // not used in final game
        public class MovePathAtGaze : MonoBehaviour, IGazeFocusable
        {
            private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
            public Color highlightColor = Color.red;
            public float animationTime = 0.1f;
            public PathCreator pathCreator;
            public EndOfPathInstruction endOfPathInstruction;
            public float speed = 1;
            float distanceTravelled;

            private Renderer _renderer;
            private Color _originalColor;
            private Color _targetColor;
            private bool focused = false;
            private float spawnDur;
            private bool firstGaze = true;
            private bool pathEnd = false;

            // Check if object is focused
            public void GazeFocusChanged(bool hasFocus)
            {
                if (hasFocus)
                {
                    if (firstGaze)
                    {
                        PointCounterManager.timeToRecFox = spawnDur;
                        firstGaze = false;
                        GameObject.Find("Fox").GetComponent<Animator>().SetBool("isRunning", true);
                    }
                                          
                    focused = true;
                }
               
                else
                {
                    _targetColor = _originalColor;
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
                
                if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
                {
                    _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
                }
                else // old standard rendering pipline
                {
                    _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
                }

                // let object run along path
                if ((pathCreator != null) && focused)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                }

                Debug.Log("distanceGaze: " + distanceTravelled);
                Debug.Log("isRunning: " + GameObject.Find("Fox").GetComponent<Animator>().GetBool("isRunning"));
                Debug.Log("isSitting: " + GameObject.Find("Fox").GetComponent<Animator>().GetBool("isSitting"));

                if (distanceTravelled > 19f)
                { 
                    if(pathEnd == false)
                    {
                        GameObject.Find("Fox").GetComponent<Animator>().SetBool("isRunning", false);
                        GameObject.Find("Fox").GetComponent<Animator>().SetBool("isSitting", true);
                        pathEnd = true;
                    }
                }
            }

            void OnPathChanged()
            {
                distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
            }

            private void FixedUpdate()
            {
                spawnDur += Time.deltaTime;
            }
        }
    }
}
