using System.Collections;
using UnityEngine;


public class MonsterAttack : MonoBehaviour
{
    private float damage = 0.1f;
    public Animator anim;
    float health = 1f;
    GameObject player;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); 
    }

    private void Update()
    {
        float direction = Vector3.Distance(player.transform.position, transform.position);
        if ((Mathf.Abs(direction) < 4) && health > 0)
        {
            StartCoroutine(AttackToPlayer());
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
        if (player.GetComponent<PlayerMovements>().health <= 0)
        {
            anim.SetBool("Victory", true);
        }
        if (health <= 0)
        {
            health = 0;
            anim.SetBool("Dizzy", true);
            anim.SetBool("isDie", true);
        }
        Debug.Log(health);
    }
    IEnumerator AttackToPlayer()
    {
        anim.SetBool("isAttack", true);
        player.GetComponent<PlayerMovements>().Damage(damage);
        yield return new WaitForSeconds(3);
    }

    public void DamageMonster(float damage)
    {
        health -= damage * Time.deltaTime;

        anim.SetBool("isAttack", true);
        if (health > 0)
        {
            health -= damage * Time.deltaTime;
        }
    }
}
