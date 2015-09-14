using System;
using System.Threading;
using UnityEngine;
using Assets.Core;

namespace Assets.Characters.Elephant.Scripts
{
    public class AnimationControl : MonoBehaviour
    {

        private Material _material;
        private DateTime? _goBackToNeutral;

        // Use this for initialization
        void Start ()
        {
            _material = gameObject.GetComponent<Renderer>().material;
        }
	
        // Update is called once per frame
        void Update () {
            if (_goBackToNeutral.HasValue && _goBackToNeutral < DateTime.Now)
            {
                _goBackToNeutral = null;
                _material.color = Color.white;
            }
        }
        
        public void DidPose(int animationId)
        {
            _material.color = Color.green;
            ReturnToNeutral();
        }

        public void FailedPose()
        {
            _material.color = Color.red;
            ReturnToNeutral();
        }

        public void ReadyToPose()
        {
            CancelReturnToNeutral();
            _material.color = Color.yellow;
        }

        public void ReturnToNeutral()
        {
            _goBackToNeutral = DateTime.Now.AddSeconds(2);
        }

        public void CancelReturnToNeutral()
        {
            _goBackToNeutral = null;
        }

    }
}
