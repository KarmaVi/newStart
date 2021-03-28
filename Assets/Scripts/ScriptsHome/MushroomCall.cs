using UnityEngine;

public class MushroomCall : MonoBehaviour
{
    [SerializeField]
    private GameObject _mushroomCall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Instantiate(_mushroomCall, transform.position, Quaternion.identity);
        Debug.Log(transform.position);
    }
}
