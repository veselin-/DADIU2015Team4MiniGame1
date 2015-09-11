using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core
{
    public class TouchInput : MonoBehaviour
    {
        public float SecondsBeforeLongPress;
		public Text HoldCounterText;

        private float _lastInputDown;
        private ComboHandler comboHandler;
		private float _timeCounter;
		private float _startTime;

		public bool firstClick = true;
		public bool longPressDone = false;

		private float span;

        void Start()
        {
            comboHandler = GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<ComboHandler>();
        }

        // Update is called once per frame
        void Update () {


            if (Input.GetMouseButton(0))
            {
			
				if(firstClick)
				{
					_startTime = Time.time;
					firstClick = false;
				}

				_timeCounter = Time.time;
				HoldCounterText.text = _timeCounter.ToString();
				span = (_timeCounter - _startTime);
				if(span > SecondsBeforeLongPress && !longPressDone)
				{
					comboHandler.DoPress(PressType.Long);
					longPressDone = true;
					Debug.Log("LONG PRESS");

				}


               // _lastInputDown = DateTime.Now;
				//longPressDone = true;
            } 

			if (Input.GetMouseButtonUp(0))
            {
				if(!longPressDone)
				{
					comboHandler.DoPress(PressType.Short);
					Debug.Log("SHORT PRESS");
				}

				firstClick = true;
				longPressDone = false;
				HoldCounterText.text = string.Empty;


				/*
                var now = DateTime.Now;
                var span = (now - _lastInputDown).Milliseconds;
				if(span > MsBeforeLongPress)
				{

					comboHandler.DoPress(PressType.Long);
				}
				else
				{
					comboHandler.DoPress(PressType.Short);
				}
				*/

                //comboHandler.DoPress(span > MsBeforeLongPress ? PressType.Long : PressType.Short);
            }

	
            // TODO PJT: This is just added for debugging
            if (Input.GetKeyDown(KeyCode.Space) || Input.touches.Length > 2)
            {
                comboHandler.StartCombo();
            }
        }
    }
}
