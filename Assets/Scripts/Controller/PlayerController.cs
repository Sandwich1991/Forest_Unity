using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    /**********************************************************************/
    // Fields
    
    // 이동 및 조작
    private Vector3 _desPos; // 플레이어 이동 목적지
    private Camera _camera;
    [SerializeField] private float _speed = 5f; // 이동 속도

    // 플레이어 애니메이션
    private Define.State _state = Define.State.Idle; // 플레이어 상태
    private Animator _animator;

    /**********************************************************************/
    // Methods
    
    // 마우스 이벤트 콜백을 받기 위한 메소드
    void OnMouse(Define.MouseEvent evt)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition); // 화면 지점에 해당하는 ray
        
        RaycastHit hit; // 레이캐스트를 받아올 변수
        Physics.Raycast(_camera.transform.position, ray.direction, out hit);

        if (hit.collider.gameObject.layer == (int)Define.Layer.Ground) // 지면을 클릭할 경우
        {
            _desPos = hit.point;
            _state = Define.State.Move;
        }
        
        else if (hit.collider.tag == "NPC" && evt == Define.MouseEvent.Click)
        {
            NPCController controller = hit.collider.GetComponent<NPCController>();
            controller.Greetings();
        }
    }
    
    void UpdateIdle()
    {
        // Idle 애니메이션 실행
        _animator.CrossFade("Idle", 0.05f);
    }
    
    void UpdateMove()
    {
        Vector3 vec = _desPos - transform.position; // 플레이어가 목적지까지 가야할 거리와 방향

        // 목적지에 도착하면 플레이어 상태 Idle로 변경
        if (vec.magnitude < 0.5f)
            _state = Define.State.Idle;
        else
        {
            if (Physics.Raycast(transform.position, vec, 1f, LayerMask.GetMask("Block")))
            {
                if (Input.GetMouseButton(0) == false)
                    _state = Define.State.Idle;
                return;
            }
            
            float dist = Math.Clamp(_speed * Time.deltaTime, 0, vec.magnitude); // 이동할 거리와 속도
            Vector3 dir = vec.normalized; // 이동할 방향
            
            // 플레이어 위치에 이동할 방향과 거리를 곱함
            transform.position += dir * dist; 
            
            // 플레이어를 목적지로 회전시킴
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            
            // 걷기 애니메이션 실행
            _animator.Play("Run");
        }
    }
    
    // 이동시 효과를 주기위한 메소드
    public void OnWalk()
    {
        Managers.Sound.Play("Sounds/FootStep/Step");
    }
    /**********************************************************************/
    // Game System
    void Start()
    {
        _camera = Camera.main; // 메인 카메라 불러옴
        _animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 불러옴

        Managers.Input.MouseAction += OnMouse; // 인풋 매니져를 통해 마우스 이벤트 콜백을 받음
    }
    
    void Update()
    {
        // 플레이어 상태를 실시간으로 확인
        switch (_state)
        {
            case Define.State.Idle:
                UpdateIdle();
                break;

            case Define.State.Move:
                UpdateMove();
                break;
        }
    }
}
