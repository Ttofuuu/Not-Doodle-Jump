using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMySelf : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 me = Camera.main.WorldToViewportPoint(transform.position);
        if (me.y < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
