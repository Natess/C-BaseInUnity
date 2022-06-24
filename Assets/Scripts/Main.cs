using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObject _interactiveObjects;

        private CameraController _cameraController;
        [SerializeField]
        private GameObject _cameraGameObjects;
        private MainCamera _camera;

        [SerializeField]
        private GameObject _playerGameObject;
        private Player _player;

        private BonusManager _bonusManager;

        void Awake()
        {
            _inputController = new InputController(_playerGameObject.GetComponent<Unit>());
            _cameraController = new CameraController(_cameraGameObjects.GetComponent<MainCamera>(), _playerGameObject.GetComponent<Unit>());

            _interactiveObjects = new ListExecuteObject();
            _interactiveObjects.Add(_inputController);
            _interactiveObjects.Add(_cameraController);

            _player = _playerGameObject.GetComponent<Player>();
            _camera = _cameraGameObjects.GetComponent<MainCamera>();

            _bonusManager = new BonusManager(_player, _camera);
            InitiateBonuses();
        }

        private void InitiateBonuses()
        {
            _bonusManager.InitiateBadBonusesGameOver(FindObjectsOfType<BadBonusGameOver>());
            _bonusManager.InitiateBadBonusesSpeed(FindObjectsOfType<BadBonusSpeed>());
            _bonusManager.InitiateGoodBonusesSpeed(FindObjectsOfType<GoodBonusSpeed>());
            _bonusManager.InitiateGoodBonusesAddPoints(FindObjectsOfType<GoodBonusAddPoints>());

        }

        void Update()
        {
            foreach (IExecute item in _interactiveObjects)
            {
                if (item == null)
                    continue;

                item.Update();
            }
        }
    }
}
