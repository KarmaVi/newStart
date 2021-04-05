using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;

    public void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
