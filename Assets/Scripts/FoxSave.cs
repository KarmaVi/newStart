using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSave : MonoBehaviour
{
    private Animator anim;
    private GameObject player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Vector3.Distance(player.transform.position, transform.position);

    }
}
