using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnOn : MonoBehaviour
{
    public GameObject window_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }





    public void ActiveOn()
    {
        window_obj.SetActive(true);
    }
    public void ActiveOff()
    {
        window_obj.SetActive(false);
    }
}
