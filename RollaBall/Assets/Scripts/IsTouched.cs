using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouched : MonoBehaviour
{

    public Animator m_anim; 
    // Start is called before the first frame update
    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        m_anim.SetBool("touching", true);
    }

    private void OnTriggerExit(Collider other)
    {
        m_anim.SetBool("touching", false);
    }

}
