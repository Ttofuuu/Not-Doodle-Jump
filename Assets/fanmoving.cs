using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanmoving : MonoBehaviour
{
    Vector3 origin;
    Vector3 movement;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        movement =new Vector3(0,speed,0);
    }

    private void FixedUpdate()
    {
        Vector3 me = Camera.main.WorldToViewportPoint(transform.position);
        if (me.y < 0f)
        {
            Destroy(this.gameObject);
        }
        Moving();
    }

    void Moving()
    {
        if (transform.position.y > origin.y + 3f || transform.position.y < origin.y - 3f)
        {
            movement.y *= -1f;
        }

        transform.position += movement * Time.deltaTime;
    }

}
