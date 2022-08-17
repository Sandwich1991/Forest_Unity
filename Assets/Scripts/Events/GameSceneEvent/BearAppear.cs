using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAppear : BaseEvent
{

    protected override void OnTriggerEnter(Collider other)
    {
        // 이벤트 상태 변경
        Managers.Event.EventState.Invoke(Define.AnimationEvent.BearAppear);
        
        // 플레이어 위치 변경 및 NPC 바라보기
        _playerController.State = Define.State.Idle;
        _playerController.MoveTo(new Vector3(55f, 0f, 59f));
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation,
            Quaternion.LookRotation((_npc.transform.position - _player.transform.position).normalized),
            100 * Time.deltaTime);
        
        // NPC -> 플레이어 바라보기
        NPCController npcController = _npc.GetComponent<NPCController>();
        _npc.transform.rotation = Quaternion.Slerp(_npc.transform.rotation,
            Quaternion.LookRotation((_player.transform.position - _npc.transform.position).normalized), 100 * Time.deltaTime);
        
        // 카메라 애니메이션 실행
        _cameraAnimator.Play("MeetNPC");
        StartCoroutine("SceneStart");
    }

    IEnumerator SceneStart()
    {
        yield return new WaitForSeconds(6f);
        // 애니메이션 이벤트에서 쓸 스프라이트 로드
        Sprite bearSprite = Managers.Resource.Load<Sprite>("Art/Icons/Bear");
        Sprite exMarkSprite = Managers.Resource.Load<Sprite>("Art/Icons/ExMark");
        
        // 플레이어와 NPC 대화
        Managers.Chat.Says(_npc, exMarkSprite, 3f);
        yield return new WaitForSeconds(3f);
        Managers.Chat.Says(_npc, bearSprite, 3f);
        yield return new WaitForSeconds(3f);
        Managers.Chat.Says(_player, exMarkSprite, 3f);
        yield return new WaitForSeconds(7.5f);
        _bearAnimator.Play("Roar");
        yield return new WaitForSeconds(1.5f);
        _bearAnimator.Play("Idle");


        gameObject.SetActive(false);
    }
}
