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


    // Start is called before the first frame update

    public virtual void OnSelectEnter()

    {

        var meshRenderer = this.GetComponent<MeshRenderer>();

        if (meshRenderer != null)

        {

            previousMat = meshRenderer.material;

            meshRenderer.material = selectedMat;

        }
        
        selected = true;
        spotted = true;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("spotted", spotted);
        
    }



    public virtual void OnSelectExit()

    {

        var meshRenderer = this.GetComponent<MeshRenderer>();

        if (meshRenderer != null && previousMat != null)

        {

            meshRenderer.material = previousMat;

        }

        selected = false;
        spotted = false;
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("spotted", spotted);
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