using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    protected GameObject _player;
    protected PlayerController _playerController;
    protected GameObject _npc;
    protected NPCController _npcController;
    protected Camera _camera;
    protected Animator _cameraAnimator;
    protected GameObject _bear;
    protected Animator _bearAnimator;

    protected void Start()
    {
        init();
    }

    protected virtual void init()
    {
        _player = GameObject.Find("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _npc = GameObject.Find("NPC");
        _npcController = _npc.GetComponent<NPCController>();
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _cameraAnimator = _camera.gameObject.GetComponent<Animator>();
        _bear = GameObject.Find("Bear");
        _bearAnimator = _bear.GetComponent<Animator>();
    }

    protected abstract void OnTriggerEnter(Collider other);
}
