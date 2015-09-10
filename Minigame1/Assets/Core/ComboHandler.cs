using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Core
{
    public class ComboHandler : MonoBehaviour
    {

        void Start()
        {
            StartCombo();
        }

        private List<PressType> _currentPresses;
        private List<PressType> _currentGoal;

        public GameObject Player;

        public void DoPress(PressType press)
        {
            Debug.Log("Pressed: " + press);
            if (NextGoalPress() == press)
            {
                _currentPresses.Add(press);

                if (_currentPresses.Count != _currentGoal.Count) return;
                Debug.Log("Goal reached");
                StartCombo();
            }
            else
            {
                StartCombo();
            }
        }

        public PressType NextGoalPress()
        {
            return _currentGoal[_currentPresses.Count];
        }

        public void StartCombo()
        {
            _currentPresses = new List<PressType>();
            var combos = Constants.Combos;
            var index = new System.Random().Next(0, combos.Count);
            _currentGoal = combos[index];
            Debug.Log(_currentGoal[0] + " " + _currentGoal[1] + " " + _currentGoal[2]);
        }
    }


    public enum PressType
    {
        Short, Long
    }
}
