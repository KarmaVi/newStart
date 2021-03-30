using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSave : MonoBehaviour
{
    private Animator anim;
    GameObject player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        float direction = Vector3.Distance(player.transform.position, transform.position);

    }
}
