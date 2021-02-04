using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float healthMult = 5;
    public Slider slider;
    public float CurrentHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        AddHealth(-Time.deltaTime * healthMult);
        slider.value = CurrentHealth / maxHealth;
    }

    public void AddHealth(float amount)
    {
        CurrentHealth = Mathf.Clamp(amount + CurrentHealth, 0, maxHealth);
    }
}
