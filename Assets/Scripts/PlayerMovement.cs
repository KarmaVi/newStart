using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private int _speed = 5;
    private GameObject player;
    private int speedRotation = 3;
    private int jumpSpeed = 5;
    public GameObject LeverRotation;
    Transform rotate;
    private GameObject lever;

    private void Start()
    {
        lever = GameObject.FindWithTag("Lever");
        player = (GameObject)this.gameObject;
        rotate = LeverRotation.GetComponent<Transform>();
    }

    private void Update()
    {
        float direction = lever.transform.position.x - transform.position.x;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(Vector3.down * speedRotation);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(Vector3.up * speedRotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position += player.transform.up * jumpSpeed * Time.deltaTime;
        }

        if ((Input.GetMouseButtonDown(1)) && (Mathf.Abs(direction) < 1))
            rotate.rotation = Quaternion.Euler(0, 0, -19);
        
    }
}
