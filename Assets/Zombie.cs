using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField]
    private int m_StartHealth = 1;

    [SerializeField]
    private float m_MovementSpeed = 10f;

    private bool m_IsMoving = true;

    private Vector3 m_Target;

    private Rigidbody m_Body;

    private Animator m_Anim;

    private int m_CurrentHealth;

    private void Awake()
    {
        m_Target = Camera.main.transform.position;

        m_Anim = GetComponent<Animator>();
        m_Body = GetComponent<Rigidbody>();
        m_CurrentHealth = m_StartHealth;

        transform.LookAt(Camera.main.transform);
    }

    private void Update()
    {
        if (m_IsMoving)
        {
            Vector3 movement = (m_Target - transform.position).normalized * m_MovementSpeed * Time.deltaTime;
            m_Body.MovePosition(transform.position + movement);
        }
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        if (m_CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gun>() == null) return;

        m_IsMoving = false;
        m_Anim.SetBool("isAttacking", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Gun>() == null) return;

        m_IsMoving = true;
        m_Anim.SetBool("isAttacking", false);
    }

    private void Die()
    {
        m_IsMoving = false;
        m_Anim.SetTrigger("deathTrigger");
        GetComponent<Collider>().enabled = false;
        m_Body.isKinematic = true;
        Destroy(gameObject, 3f);
    }
}
