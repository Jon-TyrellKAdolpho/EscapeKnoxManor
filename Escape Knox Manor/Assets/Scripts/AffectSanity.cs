using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectSanity : MonoBehaviour
{
    public float amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sanity.instance.AffectSanity(amount);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sanity.instance.UnAffectSanity(amount);
        }
    }
}
