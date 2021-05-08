using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] positions;
    public int counterplatfotmposition;
    public GameObject platform;
    public float speed;
    public float distance;
    public float koef;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(platform.transform.position, positions[counterplatfotmposition].position) > distance)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, positions[counterplatfotmposition].position, (Vector3.Distance(platform.transform.position, positions[counterplatfotmposition].position)) / (speed * koef) * Time.deltaTime);
        }
        else
        {
            counterplatfotmposition++;
            if (counterplatfotmposition >= positions.Length)
                counterplatfotmposition = 0;
        }
    }
}
