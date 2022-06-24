using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Vector3 _shift;
    Camera _camera;

    private void Awake()
    {
        _shift = new Vector3(-3, 3, 0);
        _camera = GetComponent<Camera>();
    }

    public void Move(Transform outTransdorm)
    {
        transform.position = outTransdorm.position + _shift + outTransdorm.forward * 0.15f;
    }

    internal void GameOverHandler(string name, Color color)
    {
        _camera.fieldOfView = 100f;
        _camera.backgroundColor = color;
    }
}
