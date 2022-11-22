using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public GameObject user;
    public Camera cam;
    public LayerMask interactableLayerMask;
    public float interactDistance;
    Interactable interactable;
    public Image interactImage;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite defaultInteractIcon;
    public Vector2 defaultInteractIconSize;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance, interactableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false)
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                if (interactable.interactIcon != null)
                {
                    interactImage.sprite = interactable.interactIcon;
                    if (interactable.iconSize == Vector2.zero)
                    {
                        interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                    }
                    else
                    {
                        interactImage.rectTransform.sizeDelta = interactable.iconSize;
                    }
                }
                else
                {
                    interactImage.sprite = defaultInteractIcon;
                    interactImage.rectTransform.sizeDelta = defaultInteractIconSize;
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    if(interactable.GetComponent<AudioSource>() != null)
                    {
                        interactable.GetComponent<AudioSource>().Play();
                    }
                    interactable.interactor = this;
                    interactable.onInteract.Invoke();
                }
            }
            else
            {
                if (interactImage.sprite != defaultIcon)
                {
                    interactImage.sprite = defaultIcon;
                    interactImage.rectTransform.sizeDelta = defaultIconSize;
                }
            }
        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }
}
