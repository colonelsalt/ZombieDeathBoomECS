using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject m_BloodEffect;

    [SerializeField]
    private Transform m_CrossHairImage;

    [SerializeField]
    private AudioClip[] m_GunSounds;

    private Camera m_Camera;

    private AudioSource m_Audio;

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
        m_Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        m_CrossHairImage.position = Input.mousePosition;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        m_Audio.PlayOneShot(m_GunSounds[Random.Range(0, m_GunSounds.Length)]);
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            Rigidbody hitBody = hit.rigidbody;
            if (hitBody != null)
            {
                hitBody.AddForce((hit.point - transform.position).normalized * 100f);
            }
            Zombie hitZombie = hit.transform.GetComponent<Zombie>();
            if (hitZombie != null)
            {
                hitZombie.TakeDamage(1);
                Instantiate(m_BloodEffect, hit.point, Quaternion.identity);
            }
        }
    }
}
