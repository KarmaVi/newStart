﻿using UnityEngine;

public class MonSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _mon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Instantiate(_mon, transform.position, Quaternion.identity);
    }
}
