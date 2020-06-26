using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    private float dampTime = 0.5f;

    // Update is called once per frame
    public void Update()
    {
        if (target)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, pos.z));
            Vector3 destination = transform.position + delta;
            destination.x = 0;
            if (destination.y > transform.position.y)
            {
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }
        
    }
    private void FixedUpdate()
    {
       
    }
}
