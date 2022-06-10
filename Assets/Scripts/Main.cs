using Lesson7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


            var str = "Какая-то строка";
            Debug.Log($"Кол-во символов \"а\" в строке \"{str}\": {str.CountSymbolWithLINQ('а')}");
            Debug.Log($"Кол-во символов \"а\" в строке \"{str}\": {str.CountSymbol('а')}");

            var intList = new List<int>{1, 2, 4, 6, 3, 3, 1, 2, 2, 9 };
            Debug.Log($"Частотный словарь в интовом массиве: {string.Join(", ", intList)}");
            var intRes = Lesson7.Lesson7.CountEachIntElement(intList).Select(x => $"[{x.Key}] = {x.Value}");
            Debug.Log($"Словарь: {string.Join(", ", intRes)}");


            var TList = new List<char> { '1', '2', '4', '6', '3', '3', '1', '2', '2', '9' };
            Debug.Log($"Частотный словарь в Т массиве: {string.Join(", ", TList)}");
            var TListRes = Lesson7.Lesson7.CountEachTElementWithLinq<char>(TList).Select(x => $"[{x.Key}] = {x.Value}");
            Debug.Log($"Словарь: {string.Join(", ", TListRes)}");

            var lTList = new List<char> { '1', '2', '4', '6', '3', '3', '1', '2', '2', '9' };
            Debug.Log($"Частотный словарь в Т массиве: {string.Join(", ", lTList)}");
            var lTListRes = Lesson7.Lesson7.CountEachTElementWithLinq<char>(lTList).Select(x => $"[{x.Key}] = {x.Value}");
            Debug.Log($"Словарь: {string.Join(", ", lTListRes)}");

            Lesson7.Lesson7.Task4();
            Lesson7.Lesson7.Task4WithDelegate();
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
