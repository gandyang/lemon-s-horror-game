using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // 플레이어의 캐릭터를 관찰하고 이를 감지하면 게임을 재시작하는 역할을 나타냅니다. 


    public Transform player; //JohnLemon의 위치에 접근
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;

    void OnTriggerEnter (Collider other)
    {
        if(other.transform == player){
            m_IsPlayerInRange = true;
        }
    }

    void OndTriggerExit (Collider other){
        if(other.transform == player){
            m_IsPlayerInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerInRange)
        {
        Vector3 direction = player.position - transform.position + Vector3.up;
        Ray ray = new Ray (transform.position, direction);
        RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                       gameEnding.CaughtPlayer ();
                }
            }
        }
    }
}
