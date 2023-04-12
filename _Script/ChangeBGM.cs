using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    public Vector2 size;
    public LayerMask whatIsLayer;
    public GameObject GM;
    bool GBMck = true;
    // Start is called before the first frame update
    void Start()
    {
        size = new Vector2(transform.localScale.x * 2.5f, transform.localScale.y * 2.5f);
        StartCoroutine("CheckingMapBGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator CheckingMapBGM()
    {
        while (GBMck)
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);

            if (hit == null)
            {
            }
            else
            {
                GM.GetComponent<ForBGM>().newchangeBGM();
                GBMck = false;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

}
