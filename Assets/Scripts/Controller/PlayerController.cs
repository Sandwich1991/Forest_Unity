using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseController
{
    /**********************************************************************/
    // Fields
    
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
            State = Define.State.Move;
        }
        
        else if (hit.collider.tag == "NPC" && evt == Define.MouseEvent.Click)
        {
            NPCController controller = hit.collider.GetComponent<NPCController>();
            controller.Greetings();
        }
    }
    
    protected override void UpdateMove()
    {
        Vector3 vec = _desPos - transform.position; // 플레이어가 목적지까지 가야할 거리와 방향

        // 목적지에 도착하면 플레이어 상태 Idle로 변경
        if (vec.magnitude < 0.5f)
            State = Define.State.Idle;
        else
        {
            if (Physics.Raycast(transform.position, vec, 1f, LayerMask.GetMask("Block")))
            {
                if (Input.GetMouseButton(0) == false)
                    State = Define.State.Idle;
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
    
    /**********************************************************************/
    // Game System
    protected override void init()
    {
        Managers.Input.MouseAction += OnMouse; // 인풋 매니져를 통해 마우스 이벤트 콜백을 받음
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _animator = GetComponent<Animator>();
    }
}
