using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public float health = 1f;  
    [HideInInspector]
    public Image HealthBar;
    [HideInInspector]
    public float fill;
    [HideInInspector]
    private float _curHealth = 1f;
    public float damage;
    bool isDie = false;

    //Анимация
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        if (health < 1) health = 1;
        _curHealth = health;
    }

    public void AddJustCurrntHealth(float heart)
    {
       health += heart;    
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isDie = true;
            anim.SetBool("isDie", isDie);
        }
        HealthBar.fillAmount = health;
    }
}
