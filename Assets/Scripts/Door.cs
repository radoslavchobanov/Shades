using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opened;

    private Animator animator;

    private void Awake() 
    {
        opened = false;

        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", true);
        }
    }
    private void OnTriggerExit(Collider collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", false);
        }
    }
}
