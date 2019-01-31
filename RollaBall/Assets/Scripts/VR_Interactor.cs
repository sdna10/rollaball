using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class VR_Interactor : MonoBehaviour

{
    public float lengthOfFocusTime = 2.0f;
    private float counter = 0.0f;
    private VR_Interactable selected = null;


    public LayerMask layerMask;
    // Update is called once per frame

    void Update()

    {



        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100.0f, Color.yellow);
        //counter += Time.deltaTime;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f, layerMask))

        {

            if (hit.transform != null)

            {

                var interactable = hit.transform.GetComponent<VR_Interactable>();

                if (interactable != null)

                {

                    if (interactable != selected)

                    {

                        if (selected != null)

                        {

                            selected.OnSelectExit();

                        }

                        selected = interactable;
                        //if (counter > lengthOfFocusTime)
                        //{
                            selected.OnSelectEnter();
                        //}

                    }

                    selected.InteractorPosition(hit.point);

                    if ((Input.GetAxis("XRI_Right_Trigger") > 0.5f) || (Input.GetAxis("XRI_Left_Trigger") > 0.5f))

                    {

                        selected.OnInteract();

                    }

                    return;

                }

            }

        }

        if (selected != null)

        {

            selected.OnSelectExit();

            selected = null;

        }

    }

}