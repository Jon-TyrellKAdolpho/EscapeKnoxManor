using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Door : MonoBehaviour
{
    public DoorSideCheck front;
    public DoorSideCheck back;
    AnimationHandler animationHandler;
    Interactable interactable;
    public bool locked;
    public bool right;

    
    public UnityEvent ifLocked;
    public UnityEvent ifUnlocked;

    private void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        interactable = GetComponent<Interactable>();

        if(right == true)
        {
            animationHandler.SetBoolTrue("Right");
        }
    }
    public void TryInteract()
    {
        if(locked == true)
        {
            Locked();
            
        }
        else
        {
            Unlocked();
        }
    }   

    public void SetLock(bool value)
    {
        locked = value;
    }
    void Locked()
    {
        ifLocked.Invoke();
    }
    void Unlocked()
    {
        if (front.inTrigger.Contains(interactable.interactor.user.GetComponent<Collider>()))
        {
            animationHandler.SetBoolTrue("Front");
        }
        if (back.inTrigger.Contains(interactable.interactor.user.GetComponent<Collider>()))
        {
            animationHandler.SetBoolFalse("Front");
        }
        ifUnlocked.Invoke();
    }
}
