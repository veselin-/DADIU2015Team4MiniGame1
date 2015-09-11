using System.Collections.Generic;
using Assets.Characters.Elephant.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Core
{
	public class ComboHandler : MonoBehaviour
	{
		public GameObject Player;
		public GameObject BackGround;
		public float TapTapTapFrequency = 50f;
		public Text GoalText;
		
		public GameObject PoseButton;
		
		private List<PressType> _currentPresses;
		private List<PressType> _currentGoal;
		private int _goalId = -1;
		private AnimationControl _playerAnimationControl;
		private BGControl _control;
		private bool _isCalledInThisFrame;
		
		private bool _isFirstPose = true;
		
		void Start()
		{
			_playerAnimationControl = Player.GetComponent<AnimationControl>();
			_control = BackGround.GetComponent<BGControl>();
		}
		
		public void DoPress(PressType press)
		{
			if (_isCalledInThisFrame)
			{
				_isCalledInThisFrame = false;
				return;
			}
			
			Debug.Log (_goalId);
			
			if (_goalId < 0) return;
			
			Debug.Log("Pressed: " + press);
			if (NextGoalPress() == press)
			{
				_currentPresses.Add(press);
				
				if (_currentPresses.Count != _currentGoal.Count) return;
				PoseSucceeded();
			}
			else
			{
				PoseFailed();
			}
		}
		
		public PressType NextGoalPress()
		{
			return _currentGoal[_currentPresses.Count];
		}
		
		public void StartCombo()
		{
			
			_isCalledInThisFrame = true;
			
			// Reset current presses 
			_currentPresses = new List<PressType>();
			
			// Choose new goal
			var combos = Constants.Combos;
			
			if (!_isFirstPose) {
				int random = Random.Range (0, 100);
				
				if(random <= TapTapTapFrequency)
				{
					_goalId = 0;
					_currentGoal = combos [_goalId];
				}
				else
				{
					_goalId = new System.Random().Next(1, combos.Count);
					_currentGoal = combos[_goalId];
				}
				
			} else {
				_goalId = 0;
				_currentGoal = combos [_goalId];
				_isFirstPose = false;
			}
			PoseButton.SetActive(false);
			
			// Print goal
			GoalText.text = "Goal:";
			foreach (var goal in _currentGoal)
			{
				GoalText.text += " " + goal;
			}
			_playerAnimationControl.ReadyToPose();
			
			_control.DisableMovement();
		}
		
		public void PoseFailed()
		{
			_playerAnimationControl.FailedPose();
			ScoreSystem.poseFail = true;
			
			Reset();
		}
		
		public void PoseSucceeded()
		{
			_playerAnimationControl.DidPose(_goalId);
			ScoreSystem.poseComplete = true;
			
			Reset();
		}
		
		public void Reset()
		{
			_goalId = -1;
			_control.EnableMovement();
			GoalText.text = "";
			PoseButton.SetActive(true);
		}
	}
	
	
	public enum PressType
	{
		Short, Long
	}
}
