using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterForest : BaseEvent
{
    protected override void OnTriggerEnter(Collider other)
    {
        Managers.Event.EventState.Invoke(Define.AnimationEvent.EnterForest);
        
        _player.GetComponent<PlayerController>().State = Define.State.Idle;
        _cameraAnimator.Play("ForestEnter");
        gameObject.SetActive(false);
    }
}
