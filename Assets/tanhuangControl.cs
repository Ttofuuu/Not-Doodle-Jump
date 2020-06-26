using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanhuangControl : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x+Random.Range(-0.52f, 0.52f), transform.position.y, transform.position.z);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&collision.gameObject.GetComponent<Rigidbody2D>().velocity.y<0)
        {
            anim.SetBool("touched", true);
        }
    }

    void KeepBounced()
    {
        anim.SetBool("bounced", true);
    }
}
