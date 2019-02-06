using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class VR_Interactable : MonoBehaviour

{

    protected Material previousMat = null;

    protected Vector3 interactorHitPosition = Vector3.zero;

    protected bool selected = false;
    private bool spotted;
    private bool touching;
    public Animator m_Animator;
    public Collider cam;
    public Collider whale;
    public float lengthOfFocusTime = 2.0f;
    private float counter = 0.0f;


    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (selected)
        {
            counter += Time.deltaTime;
            if (counter > lengthOfFocusTime)
            {
                m_Animator.SetBool("spotted", true);
                counter = 0.0f;
            }

        }
        else
        {
            counter = 0.0f;
            m_Animator.SetBool("spotted", false);
        }
    }

    public virtual void OnSelectEnter()

    {
       
        var meshRenderer = this.GetComponent<MeshRenderer>();

        if (meshRenderer != null)

        {

            previousMat = meshRenderer.material;

            meshRenderer.material = selectedMat;

        }
       
           selected = true;
        
        
    }



    public virtual void OnSelectExit()

    {

        var meshRenderer = this.GetComponent<MeshRenderer>();

        if (meshRenderer != null && previousMat != null)

        {

            meshRenderer.material = previousMat;

        }

        selected = false;
       }





    public virtual void InteractorPosition(Vector3 position)

    {

        interactorHitPosition = position;
        
    }



    public virtual void OnInteract()

    {
        return;

    }



    public Material selectedMat = null;

}