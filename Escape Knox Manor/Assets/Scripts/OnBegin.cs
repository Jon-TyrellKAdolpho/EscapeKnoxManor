using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnBegin : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent onAwake;
    public UnityEvent onEnable;

    void Start()
    {
        onStart.Invoke();
    }
    private void Awake()
    {
        onAwake.Invoke();
    }
    private void OnEnable()
    {
        onEnable.Invoke();
    }
}
