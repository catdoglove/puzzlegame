using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{


    public GameObject main_obj;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Animation>().Play();

    }

    private void OnEnable()
    {
        //this.transform.position = main_obj.transform.position;
        this.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
