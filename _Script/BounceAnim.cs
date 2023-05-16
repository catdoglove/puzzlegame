using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnim : MonoBehaviour
{
    float time = 0;
    public float _size = 1;

    public float _upSizeTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= _upSizeTime)
        {
            transform.localScale = Vector3.one * (_size + _size * time);
        }
        else if (time <= _upSizeTime*2)
        {
            transform.localScale = Vector3.one * (2*_size * _upSizeTime + _size - time * _size);
        }
        else
        {
            transform.localScale = Vector3.one * _size;
        }
        time += Time.deltaTime;
        
    }

    public void resetAnim()
    {
        time = 0;
    }

}
