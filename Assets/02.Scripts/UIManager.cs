using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager HealthManager;
    public Slider healthBar;
    public Text hpText;
    
    void Start()
    {
        HealthManager = FindObjectOfType<HealthManager>();
    }

    
    void Update()
    {
        healthBar.maxValue = HealthManager.maxHealth;
        healthBar.value = HealthManager.currentHealth;
        hpText.text = "HP :" + HealthManager.currentHealth + "/" + HealthManager.maxHealth;     
    }
}
