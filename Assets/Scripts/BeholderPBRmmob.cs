//using UnityEngine;

//public class BeholderPBRmmob : MonoBehaviour
//{
//    GameObject player;

//    private void Awake()
//    {
//        player = GameObject.FindWithTag("Player");
//    }
//    private void Update()
//    {
//        float direction = player.transform.position.x - transform.position.x;
//        Vector3 pos = transform.position;
//        if (Mathf.Abs(direction) < 2)
//        {
//            pos.x += Mathf.Sign(direction) * Time.deltaTime;
            
//        }
//        //else
//        //{
//        //    pos = new Vector3(Mathf.PingPong(Time.time, 4.0f), 0, 0);
//        //}
//        transform.position = pos;

//    }
//}
