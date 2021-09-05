using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider sanityBar;
    public Gradient Gradient;
    public Image Fill;

    public void SetMaxSanity(float sanity)
    {
        sanityBar.maxValue = sanity;
        sanityBar.value = sanity;
        Fill.color = Gradient.Evaluate(1f);
    }

    public void UpdateSanity(float sanity)
    {
        sanityBar.value = sanity;

        Fill.color = Gradient.Evaluate(sanityBar.normalizedValue);
    }

}
