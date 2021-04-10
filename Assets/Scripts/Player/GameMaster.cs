using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameMaster : MonoBehaviour
{
    [HideInInspector]
    public static GameMaster instance;
    [HideInInspector]
    public Vector3 lastCheckPointPos;
   
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
}
