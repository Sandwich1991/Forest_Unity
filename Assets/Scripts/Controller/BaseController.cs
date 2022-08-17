using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    
    // 이동 및 조작
    [SerializeField] public Vector3 _desPos; // 플레이어 이동 목적지
    [SerializeField] protected Camera _camera; // 메인 카메라
    [SerializeField] public float _speed = 5f; // 이동 속도

    // 플레이어 애니메이션
    [SerializeField] protected Define.State _state = Define.State.Idle; // 현재 상태
    [SerializeField] protected Animator _animator; // 애니메이터
    
    // 상태 프로퍼티
    public virtual Define.State State
    {
        get
        { return _state; }
        set
        {
            _state = value;
            switch (State)
            {
                case Define.State.Idle:
                    _animator.CrossFade("Idle", 0.05f);
                    break;
                
                case Define.State.Move:
                    _animator.Play("Run");
                    break;
            }
        }
    }

    /**********************************************************************/
    // Game System
    protected abstract void init();
    private void Start()
    {
        init();
    }

    private void Update()
    {
        // state를 실시간으로 확인
        switch (State)
        {
            case Define.State.Idle:
                UpdateIdle();
                break;
            
            case Define.State.Move:
                UpdateMove();
                break;
        }
    }

    /**********************************************************************/
    // Methods

    protected virtual void UpdateIdle() {}
    
    protected virtual void UpdateMove() {}
    
    public virtual void MoveTo(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }
    
    public virtual void OnWalk()
    {
        Managers.Sound.Play("Sounds/FootStep/Step");
    }
}
