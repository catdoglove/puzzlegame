using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHandler : MonoBehaviour
{

    public GameObject char_obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        char_obj.SetActive(false);
    }
    
}
