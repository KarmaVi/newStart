using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMonsterPlayer : MonoBehaviour
{
    private Vector3 direction;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        direction = player.transform.position;
        transform.position = direction * Time.deltaTime;
        Debug.Log(direction);
    }
}

