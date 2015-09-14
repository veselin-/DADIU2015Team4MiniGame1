using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using Assets.Core;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Characters.Elephant.Scripts
{
    public class AnimationControl : MonoBehaviour
    {

        private Material _material;
        private DateTime? _goBackToNeutral;

        public Image Image;
        public Sprite[] PoseIcons;

        public void PickAnimation()
        {
            //We choose a poseIndex based on the animations/icons we have.
            int poseIndex = Random.Range(0, PoseIcons.Length);

            //We set the image of the animation at the top of the screen
            Image.sprite = PoseIcons[poseIndex];
        
            //We need to pick the animation here!
        }


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
