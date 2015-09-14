﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core.Scripts.Movement
{
    public class TouchInput : MonoBehaviour
    {
		public float SecToLongPress = 0.3f;
		public Text HoldCounterText;
        public LayerMask LeftLayerMask;
        public LayerMask RightLayerMask;
        public GameObject Elephant;
        public float BoundaryDist;
        public static float Speed;

        public GameObject LeftButton;
        public GameObject RightButton;

        private float _lastInputDown;
        private ComboHandler _comboHandler;
		private float _timeCounter;

		private bool _firstClick = true;
		private bool _longPressDone;
		private float _startTime;
        private bool _pressingButton;

        private ButtonLook _leftButtonLook;
        private ButtonLook _rightButtonLook;


		private float span;

        void Start()
        {
            _comboHandler = GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<ComboHandler>();
			_comboHandler.StartCombo ();
            _leftButtonLook = LeftButton.GetComponent<ButtonLook>();
            _rightButtonLook = RightButton.GetComponent<ButtonLook>();

        }

        // Update is called once per frame
        void Update () {

            if(Input.touches.Length > 1)
                return;

            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hitColliderLeft = Physics2D.OverlapPoint(mousePosition, LeftLayerMask);
                var hitColliderRight = Physics2D.OverlapPoint(mousePosition, RightLayerMask);

                if (hitColliderLeft) {
                    _pressingButton = true;
                    GoLeft();
                }
                else if (hitColliderRight) {
                    _pressingButton = true;
                    GoRight();
                }
                else
                {
                    _pressingButton = false;
                    PoseInputDown();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (_pressingButton)
                {
                    _pressingButton = false;
                    _rightButtonLook.ButtonNotPressed();
                    _leftButtonLook.ButtonNotPressed();
                } else { 
                    PoseInputUp();
                }
            }
        }


        private void PoseInputDown()
        {
            if (_firstClick)
            {
                _startTime = Time.time;
                _firstClick = false;
            }

            if (_longPressDone) return;

            _timeCounter = Time.time;
            HoldCounterText.text = (_timeCounter - _startTime).ToString();

            span = (_timeCounter - _startTime);

            if (!(span > SecToLongPress)) return;

            _comboHandler.DoPress(PressType.Long);
            _longPressDone = true;
        }

        private void PoseInputUp()
        {
            if (!_longPressDone)
            {
                _comboHandler.DoPress(PressType.Short);
            }

            _firstClick = true;
            _longPressDone = false;
            _timeCounter = 0;

            HoldCounterText.text = string.Empty;
        }


        private void GoLeft()
        {
            _leftButtonLook.ButtonPressed();
            if (-BoundaryDist <= Elephant.transform.position.x)
            {
                Elephant.transform.Translate(Vector3.left * Time.deltaTime * Speed);
            }
        }

        private void GoRight()
        {
            _rightButtonLook.ButtonPressed();
            if (BoundaryDist >= Elephant.transform.position.x)
            {
                Elephant.transform.Translate(Vector3.right * Time.deltaTime * Speed);
            }
        }

    }
}