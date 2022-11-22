using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSideCheck : MonoBehaviour
{
    [HideInInspector]
    public List<Collider> inTrigger;

    
    private void OnTriggerEnter(Collider other)
    {
        inTrigger.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger.Remove(other);
    }
}
