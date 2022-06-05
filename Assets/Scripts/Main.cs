using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private Reference _reference;
       
        private InputController _inputController;
        private ListExecuteObject _interactiveObjects;

        private CameraController _cameraController;
        private PlayerController _playerController;
        private BonusController _bonusController;
        private UIController _uiController;

        private MainCamera _camera;

        [SerializeField]
        private GameObject _playerGameObject;
        private Player _player;

        
        [SerializeField]
        private Button _restartButton;

        void Awake()
        {
            _reference = new Reference();
            _player = _playerGameObject.GetComponent<Player>();
            _camera = _reference.MainCamera.GetComponent<MainCamera>();

            _uiController = new UIController(_restartButton);
            _inputController = new InputController(_playerGameObject.GetComponent<Unit>());
            _cameraController = new CameraController(_camera, _playerGameObject.GetComponent<Unit>());
            _playerController = new PlayerController(_player, _uiController);
            _bonusController = new BonusController(_playerController, _uiController);

            _interactiveObjects = new ListExecuteObject();
            _interactiveObjects.Add(_inputController);
            _interactiveObjects.Add(_cameraController);

            InitiateBonuses();
        }

        private void InitiateBonuses()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is Bonus b)
                    _bonusController.AddBonus(b);
            }
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
