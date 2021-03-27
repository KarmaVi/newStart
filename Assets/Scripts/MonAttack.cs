//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MonAttack : MonoBehaviour
//{
//    public float Damage;
//    public Animator anim;
//    GameObject Monster;

    
//    private void Awake()
//    {
//        anim = GetComponent<Animator>();
//    }
//    private void Update()
//    {
//        StartCoroutine(AttackToMonster());
//    }
//    IEnumerator AttackToMonster()
//    {
//        if (Physics.Raycast(transform.position, transform.forward, out var hit, 1f))
//        {
//            var enemy = hit.transform.gameObject.GetComponent<MonsterAttack>();
//            enemy.transform.gameObject.GetComponent<MonsterAttack>().DamageMonster(Damage);
//            Debug.Log(enemy);
//        }
//        yield return new WaitForSeconds(3);
//    }
//}
