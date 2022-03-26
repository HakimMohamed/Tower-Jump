using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Fill;
    public void SetMaxBoost(float boost)
    {
        slider.maxValue = boost;
        slider.value = boost;
        Fill.color = gradient.Evaluate(1f);
    }
     public  void setboost(float boost)
    {
        slider.value = boost;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
