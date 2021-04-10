using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public float health = 1f;  
    [HideInInspector]
    public Image HealthBar;
    private bool isDie;
    
    //Анимация
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AddJustCurrntHealth(float heart)
    {
       health += heart;

        if (health >= 1)
            health = 1;
        HealthBar.fillAmount = health;    
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isDie = true;
            anim.SetBool("isDie", isDie);
            gameObject.GetComponent<PlayerMovements>().health = health;
        }
        HealthBar.fillAmount = health;
    }
}
