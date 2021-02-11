using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float healthMult = 5;
    public Slider slider;
    public bool destroyOnDeath = false;
    public GameObject destroyObj;

    public float CurrentHealth { get; set; }
    public bool IsDead { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.Instance != null)
        {
            if(Game.Instance.State == Game.eState.GAME)
            {
                AddHealth(-Time.deltaTime * healthMult);
                if(slider != null)
                {
                    slider.value = CurrentHealth / maxHealth;
                }

                if(CurrentHealth <= 0 && !IsDead)
                {
                    IsDead = true;
                    if(destroyObj != null)
                    {
                        Instantiate(destroyObj, transform.position, transform.rotation);
                    }
                    if(destroyOnDeath)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        else
        {
            AddHealth(-Time.deltaTime * healthMult);
            if (slider != null)
            {
                slider.value = CurrentHealth / maxHealth;
            }

            if (CurrentHealth <= 0 && !IsDead)
            {
                IsDead = true;
                if (destroyObj != null)
                {
                    Instantiate(destroyObj, transform.position, transform.rotation);
                }
                if (destroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void AddHealth(float amount)
    {
        CurrentHealth = Mathf.Clamp(amount + CurrentHealth, 0, maxHealth);
    }
}
