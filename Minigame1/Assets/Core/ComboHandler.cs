using System.Collections.Generic;
using Assets.Characters.Elephant.Scripts;
using UnityEngine;

namespace Assets.Core
{
    public class ComboHandler : MonoBehaviour
    {
        public GameObject Player;
        public GameObject BackGround;

        private List<PressType> _currentPresses;
        private List<PressType> _currentGoal;
        private int _goalId = -1;
        private AnimationControl _playerAnimationControl;
        private BGControl control;
        

        void Start()
        {
            _playerAnimationControl = Player.GetComponent<AnimationControl>();
            control = BackGround.GetComponent<BGControl>();
        }

        public void DoPress(PressType press)
        {
            if (_goalId < 0) return;

            Debug.Log("Pressed: " + press);
            if (NextGoalPress() == press)
            {
                _currentPresses.Add(press);

                if (_currentPresses.Count != _currentGoal.Count) return;
                _playerAnimationControl.DidPose(_goalId);
                ScoreSystem.poseComplete = true;
                _goalId = -1;
                control.EnableMovement();
            }
            else
            {
                _playerAnimationControl.FailedPose();
                ScoreSystem.poseFail = true;
                _goalId = -1;
                control.EnableMovement();
            }
        }

        public PressType NextGoalPress()
        {
            return _currentGoal[_currentPresses.Count];
        }

        public void StartCombo()
        {
            // Reset current presses 
            _currentPresses = new List<PressType>();

            // Choose new goal
            var combos = Constants.Combos;
            _goalId = new System.Random().Next(0, combos.Count);
            _currentGoal = combos[_goalId];
            
            // Print goal
            Debug.Log(_currentGoal[0] + " " + _currentGoal[1] + " " + _currentGoal[2]);
            _playerAnimationControl.ReadyToPose();

            control.DisableMovement();
        }
    }


    public enum PressType
    {
        Short, Long
    }
}
