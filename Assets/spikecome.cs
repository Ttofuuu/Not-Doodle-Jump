using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikecome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x+Random.Range(-0.46f, -.46f), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
}
