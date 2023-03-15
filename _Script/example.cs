using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour
{
    public Animator boatAni;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("boatAnimation", 2f);
    }

    void boatAnimation()
    {
        boatAni.Play("ani_boat_up");
        StartCoroutine("Action_go");

    }


    IEnumerator Action_go()
    {
        Vector3 destination = new Vector3(13, transform.position.y, 0);
        transform.position =
            Vector3.MoveTowards(transform.position, destination, 2.5f * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }
}
