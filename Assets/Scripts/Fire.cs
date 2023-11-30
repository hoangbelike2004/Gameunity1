using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject DeadFire;
    private Animator animFire;
    public float TimeFire = 0;
    private float m_timefire;
    // Start is called before the first frame update
    void Start()
    {
        animFire = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_timefire += Time.deltaTime;
        if (m_timefire >= 2 && m_timefire <= 3)
        {
            FireStart();
            if (m_timefire >=2.9f)
            {
                m_timefire = TimeFire;
            }
        }
        else if(m_timefire < 2)
        {
            animFire.SetFloat("Firetime", m_timefire);
            DeadFire.SetActive(false);
        }
    }
    private void FireStart()
    {
        DeadFire.SetActive(true);
        animFire.SetFloat("Firetime", m_timefire);
    }
}
