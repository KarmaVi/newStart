using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToMonsters : MonoBehaviour
{
    private Animator anim;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public LayerMask mask;
    bool isAttack = false;
    GameObject MonsterAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackToMonster());
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
        anim.SetBool("isAttack", isAttack);
    }

    IEnumerator AttackToMonster()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
        {
            var enemy = hit.transform.gameObject.GetComponent<MonsterAttack>();
            enemy.transform.gameObject.GetComponent<MonsterAttack>().DamageMonster(damage);
        }
        yield return new WaitForSeconds(3);
    }
}
