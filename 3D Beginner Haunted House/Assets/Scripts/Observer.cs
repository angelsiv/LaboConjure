﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    private bool m_IsPlayerInRange;

    public GameEnding gameEnding;

    private void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    if(tag == "Ghost")
                    {
                        GetComponentInParent<Animator>().SetBool("IsChasing", true);
                    }
                    else
                    {
                        gameEnding.CaughtPlayer();
                    }
                }
            }
        }
        else
        {
            if(tag == "Ghost")
            {
                GetComponentInParent<Animator>().SetBool("IsChasing", false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
