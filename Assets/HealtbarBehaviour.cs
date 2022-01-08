using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtbarBehaviour : MonoBehaviour
{
    public Image Health;
    public Color Low;
    public Color High;
    private Image fill;

    private void Awake()
    {
        fill = GameObject.Find("Health").GetComponent<Image>();
    }

    public void SetHealth(float health, float maxHealth)
    {
        Health.gameObject.SetActive(health < maxHealth);
        fill.fillAmount = health / maxHealth;
        //fill.color = Color.Lerp(Low, High, fill.fillAmount);
    }
}
