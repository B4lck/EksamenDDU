using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRegister : MonoBehaviour
{
    public string TargetTag;
    public Animator Animator;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 100f))
        {
            if (hit.transform.CompareTag(TargetTag))
            {
                Animator.SetTrigger("OpenUI");
            } else
            {
                Animator.SetTrigger("CloseUI");
            }
        } 
        else
        {
            Animator.SetTrigger("CloseUI");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, (transform.up * 4) + transform.position);
    }

}
