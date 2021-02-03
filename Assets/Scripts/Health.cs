using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float healthMult = 5;

    public float CurrentHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth -= Time.deltaTime * healthMult;
    }

    public void AddHealth(float amount)
    {
        CurrentHealth = Mathf.Min(amount + CurrentHealth, maxHealth);
    }
}
