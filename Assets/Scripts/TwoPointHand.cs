using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointHand : MonoBehaviour
{
    [SerializeField]
    TimescaleController TimescaleController;
    bool L_Hend = false, R_Hand = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "L_hand")
        {
            L_Hend = true;
            Debug.Log("L");
        }
        if (other.tag == "R_hand")
        {
            Debug.Log("L");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("-=--------------------------------------------------------------------------gg" + collision.gameObject.name);
        if (collision.gameObject.tag == "L_hand")
        {
            L_Hend = true;
            Debug.Log("L");
        }
        if (collision.gameObject.tag == "R_hand")
        {
            R_Hand = true;
            Debug.Log("L");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "L_hand")
        {
            L_Hend = false;
            Debug.Log("L");
        }
        if (collision.gameObject.tag == "R_hand")
        {
            R_Hand = false;
            Debug.Log("L");
        }
    }
    private void Update()
    {
        if(L_Hend && R_Hand)
        {
            TimescaleController.Pause();
        }
        else
        {
            TimescaleController.Unpause();
        }
    }
}
