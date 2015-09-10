using System;
using System.Linq;
using UnityEngine;

namespace Assets.Core
{
    public class TouchInput : MonoBehaviour
    {
        public float MsBeforeLongPress;

        private DateTime _lastInputDown;
        private ComboHandler comboHandler;

        void Start()
        {
            comboHandler = GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<ComboHandler>();
        }

        // Update is called once per frame
        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                _lastInputDown = DateTime.Now;
            } else if (Input.GetMouseButtonUp(0))
            {
                var now = DateTime.Now;
                var span = (now - _lastInputDown).Milliseconds;
                comboHandler.DoPress(span > MsBeforeLongPress ? PressType.Long : PressType.Short);
            }

            // TODO PJT: This is just added for debugging
            if (Input.GetKeyDown(KeyCode.Space) || Input.touches.Length > 2)
            {
                comboHandler.StartCombo();
            }
        }
    }
}
