using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAppear : MonoBehaviour
{
    
    private GameObject _player;
    private GameObject _npc;
    private Camera _camera;
    private Animator _animator;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _npc = GameObject.Find("NPC");
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _animator = _camera.gameObject.GetComponent<Animator>();

        Managers.Event.SceneEnd += EventEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Managers.Event.CameraEventOn();
        _npc.transform.rotation = Quaternion.Slerp(_npc.transform.rotation,
            Quaternion.LookRotation((_player.transform.position - _npc.transform.position).normalized), 100 * Time.deltaTime);
        Managers.Event.CameraEventOn();
        
        // Todo
        _animator.Play("BearAppear");

    }

    void EventEnd()
    {
        Managers.Event.CameraEventOff();
    }
}
