using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    private GameObject _particle;
    


    public void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _particle.Play();
            gm.lastCheckPointPos = transform.position;
            PlayerPrefs.SetFloat("posX", transform.position.x);
            PlayerPrefs.SetFloat("posY", transform.position.y);
            PlayerPrefs.SetFloat("posZ", transform.position.z);
        }
    }
}
