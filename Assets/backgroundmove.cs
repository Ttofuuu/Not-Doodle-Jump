using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
    Material material;
    Vector2 movement;
    public Transform player;

    public Vector2 speed = new Vector2(0, 4f);
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 players = Camera.main.WorldToViewportPoint(player.position);
        if (players.y > 0.5f)
        {
            movement += speed * Time.deltaTime;
            material.mainTextureOffset = movement;
        }
    }
}
