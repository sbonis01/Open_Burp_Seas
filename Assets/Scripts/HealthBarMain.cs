﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBarMain : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int kills;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        kills = 0;
    }
    public void FixedUpdate()
    {
        ScoreText.SetText(kills.ToString());
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
  public void setHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
