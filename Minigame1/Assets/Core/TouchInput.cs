using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core
{
    public class TouchInput : MonoBehaviour
    {
		public float secToLongPress = 0.3f;
		public Text HoldCounterText;

        private float _lastInputDown;
        private ComboHandler comboHandler;
		private float _timeCounter;

		private bool _firstClick = true;
		private bool _longPressDone = false;
		private float _startTime;

		private float span;

        void Start()
        {
            comboHandler = GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<ComboHandler>();
        }

        // Update is called once per frame
        void Update () {


            if (Input.GetMouseButton (0)) {

				if (_firstClick) {
					_startTime = Time.time;
					_firstClick = false;
				}

				if (!_longPressDone)
				{
					_timeCounter = Time.time;
					HoldCounterText.text = (_timeCounter - _startTime).ToString();
										
					span = (_timeCounter - _startTime);
					Debug.Log (span);
					if (span > secToLongPress) {
						comboHandler.DoPress (PressType.Long);
						_longPressDone = true;
						Debug.Log ("LONG PRESS");

					}
				}
			}


               // _lastInputDown = DateTime.Now;
				//longPressDone = true;
             

			if (Input.GetMouseButtonUp(0))
            {
				if(!_longPressDone)
				{
					comboHandler.DoPress(PressType.Short);
					Debug.Log("SHORT PRESS");
				}

				_firstClick = true;
				_longPressDone = false;
				_timeCounter = 0;

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
			/*
			if (Input.GetKeyDown(KeyCode.Space) || Input.touches.Length > 2)
            {
                comboHandler.StartCombo();
            }
            */
        }
    }
}
