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

    public Vector3 position_nomal;

    public float checkX_f, checkY_f, checkR_f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CheckingOrder");
        //position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);

    }

    private void OnEnable()
    {
        position_nomal = new Vector3(transform.position.x - checkX_f, transform.position.y - checkY_f, transform.position.z);
        StopCoroutine("CheckingOrder");
        StartCoroutine("CheckingOrder");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, size);
    }

    IEnumerator CheckingOrder()
    {
        while (time_i == 1)
        {
            Collider2D hit;

            hit = Physics2D.OverlapBox(position_nomal, size, 0, whatIsLayer);
            
            if (hit == null)
            {

            }
            else
            {
                if (IsUp_b)
                {
                    changeOrder_obj.GetComponent<SpriteRenderer>().sortingOrder = 13;
                }
                else
                {
                    changeOrder_obj.GetComponent<SpriteRenderer>().sortingOrder = 7;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }




}
