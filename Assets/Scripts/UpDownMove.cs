using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{

    public float speed;
    public float y_cor;

    // Start is called before the first frame update
    void Start()
    {
        y_cor = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 0.5f + y_cor;
        Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = pos;
    }
}
