using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxPV(int pv)
    {
        slider.maxValue = pv;
        slider.value = pv;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetPv(int pv)
    {
        slider.value = pv;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
