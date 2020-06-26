using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHorizontal : MonoBehaviour
{
    Vector3 origin;
    Vector3 movement;
    float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        speed = (float)1 + Time.timeSinceLevelLoad * (float)0.09;
        speed = Mathf.Min(speed, 3f);
        movement = new Vector3(speed, 0, 0);
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
        if (Mathf.Abs(transform.position.x) >= 3.5f)
        {
            movement.x *= -1f;
        }
        transform.position += movement * Time.deltaTime;
    }

}

