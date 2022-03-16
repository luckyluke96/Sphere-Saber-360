// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;
using PathCreation;

namespace Tobii.XR.Examples.GettingStarted
    
{
    namespace PathCreation.Examples
    {
        //Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
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

            //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
            public void GazeFocusChanged(bool hasFocus)
            {

                //If this object received focus, fade the object's color to highlight color
                if (hasFocus)
                {
                    if (firstGaze)
                    {
                        PointCounterManager.timeToRecFox = spawnDur;
                        firstGaze = false;
                    }
                                          //_targetColor = highlightColor;
                    focused = true;
                }
                //If this object lost focus, fade the object's color to it's original color
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
                

                if ((pathCreator != null) && focused)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
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
