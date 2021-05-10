using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject tmp=GameObject.FindGameObjectWithTag("Resources");
        if (other.tag == "Player")
        {
            tmp.GetComponent<ResourceManagerScript>().coin++;
            Destroy(this.gameObject);
        }
    }
}
