using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    public Shader _shader;
    private Camera _camera;

    void Awake()
    {
        _shader = Shader.Find("Unlit/Texture");
        _camera = GetComponent<Camera>();

        if (_shader)
            _camera.SetReplacementShader(_shader, "RenderType");
    }

    private void OnDisable()
    {
        _camera.ResetReplacementShader();   
    }
}

