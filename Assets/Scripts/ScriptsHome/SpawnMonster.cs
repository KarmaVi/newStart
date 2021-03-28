using System.Collections;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    private float Randx;
    private float Randz;
    
    [SerializeField]
    private GameObject _monster;
    
    private void Start()
    {
        StartCoroutine("DoCheck");
    }
    private void Update()
    {
        Randx = Random.Range(-23f, 23f);
        Randz = Random.Range(-23f, 23f);
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            Instantiate(_monster, new Vector3(Randx, 0.516f, Randz), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
