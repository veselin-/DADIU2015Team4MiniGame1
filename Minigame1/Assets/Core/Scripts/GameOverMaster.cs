﻿using System.Net.Configuration;
using System.Security.Policy;
using Assets.Core.Scripts.Movement;
using UnityEngine;

namespace Assets.Core.Scripts
{
    public class GameOverMaster : MonoBehaviour
    {

        public GameObject Ground;
        public GameObject Hole;
        public GameObject FrontCylinder;
        public GameObject BackCylinder;

        public GameObject MainMenuButton;
        public GameObject RestartLevelButton;

        public GameObject NavButtingLeft;
        public GameObject NavButtingRight;


        private TouchInput _elephantMovement;

        private Transform _groundTransform;
        private Transform _holeTransform ;
        private bool _gameIsOver;

        void Start()
        {
            _groundTransform = Ground.GetComponent<Transform>();
            _elephantMovement = GetComponent<TouchInput>();
            Hole.GetComponent<SpriteRenderer>().enabled = false;
        }

        void Update () {
            if(_groundTransform.position.y < -0.27 && _gameIsOver) { 
                _groundTransform.Translate(Vector3.up * Time.deltaTime * VariableController.DieSpeed);
                _elephantMovement.Gameover();
                _holeTransform = Hole.GetComponent<Transform>();
            }
            else if (_gameIsOver)
            {
                _holeTransform.position = new Vector3(_elephantMovement.GetXPos(), _holeTransform.position.y, _holeTransform.position.z);
                StopSpawns();
            }
        }

        public void GameOver()
        {
            
            _gameIsOver = true;

        }

        private void StopSpawns()
        {
            FrontCylinder.SetActive(false);
            Hole.GetComponent<SpriteRenderer>().enabled = true;
            Camera.main.GetComponent<ShakeCam>().StopShaking();

            var clouds = FindObjectsOfType<CloudMovement>();
            foreach (var cloud in clouds)
            {
                cloud.enabled = false;
            }
            
            var obstacles = GameObject.FindGameObjectsWithTag(Constants.Tags.Obstacle);
            foreach (var obstacle in obstacles)
            {
                obstacle.GetComponent<obstacleMovement>().StopSpawning();
            }

            MainMenuButton.SetActive(true);
            RestartLevelButton.SetActive(true);
            Destroy(NavButtingLeft);
            Destroy(NavButtingRight);
        }

        public void RestartScene()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        public void MainMenu()
        {
            Application.LoadLevel(Constants.Scenes.MainMenuSceneName);
        }

    }
}
