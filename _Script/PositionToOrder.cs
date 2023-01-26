using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionToOrder : MonoBehaviour
{
    int time_i=1;
    public Vector2 size;
    public LayerMask whatIsLayer;
    public GameObject changeOrder_obj;

    public bool IsUp_b;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CheckingOrder");
    }

    private void OnEnable()
    {
        StartCoroutine("CheckingOrder");
    }


    IEnumerator CheckingOrder()
    {
        while (time_i == 1)
        {

            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, whatIsLayer);
            
            if (hit == null)
            {

            }
            else
            {
                if (IsUp_b)
                {
                    changeOrder_obj.GetComponent<SpriteRenderer>().sortingOrder = 11;
                }
                else
                {
                    changeOrder_obj.GetComponent<SpriteRenderer>().sortingOrder = 9;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }




}
