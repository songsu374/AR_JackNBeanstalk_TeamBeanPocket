using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator anim;
    public float m_fSpeed = 3.0f;
    public float moveSpeed = 7f;
    Vector3 m_vecTarget;

    RaycastHit Hit; 
    float TurnSpeed; 
    Quaternion dr;

    Vector3 Click;
    bool is_touch = false;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        m_vecTarget = transform.position;
        TurnSpeed = 10f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            is_touch = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                m_vecTarget = hit.point;
                m_vecTarget.y = transform.position.y;
                anim.SetTrigger("Walking");

                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit);
                Click = Hit.point;
                dr = Quaternion.LookRotation((Click - transform.position).normalized);
                dr.x = 0; 
                dr.z = 0;         // 캐릭터 기울기 방지
            }
        }
        if (is_touch==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_vecTarget, m_fSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, dr, TurnSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - m_vecTarget.x) < 0.1f  &&
                Mathf.Abs(transform.position.z - m_vecTarget.z) < 0.1f
                )
            {
                is_touch = false;
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Climbing")
        {
            anim.SetTrigger("Climbing");
            transform.position += Vector3.up * 5 * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Idle");
    }*/
}

