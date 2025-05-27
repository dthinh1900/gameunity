using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai : MonoBehaviour
{
    float m_speedwai =2;
    float huong=1;
    float x1;
    float x2;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tdg = transform.position;
        x1 = tdg.x - 1;
        x2 = tdg.x + 2;
    }


    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x <= x1)
        {
            huong = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(transform.position.x >= x2)
        {
            huong = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        float buoc = huong * m_speedwai * Time.deltaTime;
        transform.position = transform.position + new Vector3(buoc, 0, 0);
    }
}
