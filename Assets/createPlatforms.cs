using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPlatforms : MonoBehaviour
{
    public Rigidbody2D rb;
    public List<GameObject> platforms = new List<GameObject>();

    float currenty;
    float delta;
    public int spikenums;
    int easytime;

    private Vector3 spawnposition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currenty = rb.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        updateeztime();
        delta = rb.position.y - currenty;
        float distance = (1 + Time.timeSinceLevelLoad * 0.03f);
        distance = Mathf.Min(distance, 1.6f);
        if(delta > Random.Range(1.48f*distance, 2.7f*distance))
        {
            currenty = rb.position.y;
            delta = 0f;
            spawnposition = transform.position;
            SpawnPlatforms();
        }
    }

    public void updateeztime()
    {
        if (Time.timeSinceLevelLoad > 60f)
        {
            easytime = 0;
        }
        else if (Time.timeSinceLevelLoad > 40f)
        {
            easytime = 2;
        }
        else if(Time.timeSinceLevelLoad > 20f)
        {
            easytime = 4;
        }
        else
        {
            easytime = 5;
        }
    }

    public void SpawnPlatforms()
    {
        int nums = Random.Range(0, 2);
        if(nums == 1)
        {
            int index = Random.Range(0, platforms.Count - spikenums - easytime);
            spawnposition.x = Random.Range(-3.5f, 3.5f);
            GameObject newPlatform = Instantiate(platforms[index], spawnposition, Quaternion.identity);
            return;
        }
        else
        {
            int index = Random.Range(0, platforms.Count - spikenums -easytime);
            int ave = Random.Range(0, 2);
            if(ave == 1)
            {
                spawnposition.x = Random.Range(-3.5f, -1f);
                GameObject newPlatform = Instantiate(platforms[index], spawnposition, Quaternion.identity);
                spawnposition.x = Random.Range(1f, 3.5f);
            }
            else
            {
                spawnposition.x = Random.Range(1f, 3.5f);
                GameObject newPlatform = Instantiate(platforms[index], spawnposition, Quaternion.identity);
                spawnposition.x = Random.Range(-3.5f, -1f);
            }
            spawnposition.y += Random.Range(-0.4f, 0.4f);
            int av1 = Random.Range(0, 2);
            if (av1 == 1 && easytime<=4)
            {
                int index2 = Random.Range(platforms.Count - spikenums, platforms.Count);
                GameObject newPlatform2 = Instantiate(platforms[index2], spawnposition, Quaternion.identity);
            }
            else
            {
                int index2 = Random.Range(0, platforms.Count - spikenums-easytime);
                GameObject newPlatform2 = Instantiate(platforms[index2], spawnposition, Quaternion.identity);
            }
            return;
        }
        
        
    }
}
