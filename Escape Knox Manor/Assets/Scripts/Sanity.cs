using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
public class Sanity : MonoBehaviour
{
    public Gradient sanityGradient;
    public Gradient reverseGradient;
    public TextMeshProUGUI sanityText;
    public Image fill;

    public static Sanity instance;
    public float maxSanity;
    public Slider sanitySlider;
    public float recoveryTime;

    public float affectAmount;
    bool insane;
    public UnityEvent onInsane;
    private void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        sanitySlider.minValue = 0;
        sanitySlider.maxValue = maxSanity;
        sanitySlider.value = maxSanity;
        fill.color = sanityGradient.Evaluate(1f);
    }
    public void AffectSanity(float value)
    {
        affectAmount += value;
    }
    public void UnAffectSanity(float value)
    {
        affectAmount -= value;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(sanitySlider.value < sanitySlider.maxValue / 4)
            {
                sanitySlider.value += 1f;
            }
            else
            {
                sanitySlider.value += .25f;
            }
            fill.color = sanityGradient.Evaluate(sanitySlider.normalizedValue);
            RenderSettings.ambientLight = sanityGradient.Evaluate(sanitySlider.normalizedValue);
        }
        if(affectAmount != 0)
        {
            sanitySlider.value += affectAmount * Time.deltaTime;
            if (sanitySlider.value == 0)
            {
                if(insane != true)
                {
                    onInsane.Invoke();
                    insane = true;
                }
                
            }
        }
        else
        {
            if(sanitySlider.value > 0)
            {
                sanitySlider.value -= 1f * Time.deltaTime;

            }
        }
        fill.color = sanityGradient.Evaluate(sanitySlider.normalizedValue);
        RenderSettings.ambientLight = sanityGradient.Evaluate(sanitySlider.normalizedValue);
        sanityText.color = reverseGradient.Evaluate(sanitySlider.normalizedValue);

    }
}
