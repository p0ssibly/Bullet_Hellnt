using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(int newValue)
    {
        slider.value = newValue;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
