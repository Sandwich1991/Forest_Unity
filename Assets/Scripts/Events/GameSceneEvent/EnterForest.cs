using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForest : MonoBehaviour
{
    private GameObject _player;
    private Camera _camera;
    private Animator _animator;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _animator = _camera.gameObject.GetComponent<Animator>();

        Managers.Event.SceneEnd += EventEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        Managers.Event.CameraEventOn();
        _animator.Play("ForestEnter");
    }

    void EventEnd()
    {
        Managers.Event.CameraEventOff();
        Destroy(gameObject);
    }
}
