using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSliding : MonoBehaviour
{
    public float min=1f;
    public float max=5f;
    // Start is called before the first frame update
    void Start()
    {
        min=transform.position.x;
        max=transform.position.x+3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        transform.position =new Vector3(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y, transform.position.z);
    }
}
