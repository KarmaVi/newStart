using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster gm;

    public void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameMaster>();

        var newPosition = new Vector3(PlayerPrefs.GetFloat("posX"), -0.01f, 0.673f);
        transform.position = newPosition;
        //transform.position = gm.lastCheckPointPos;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
