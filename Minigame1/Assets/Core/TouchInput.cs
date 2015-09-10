using System;
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
        }
    }
}
