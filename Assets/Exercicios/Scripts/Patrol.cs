using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 10;

    int index = 0;

    public GameObject[] lstPoints;   

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPosition(), speed * Time.deltaTime);        
    }    

    Vector3 NextPosition()
    {
        Vector3 newPos = new Vector3(lstPoints[index].transform.position.x, transform.position.y, lstPoints[index].transform.position.z);        
        return newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            if(index <= lstPoints.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            StartCoroutine(BlinkPoint(other.gameObject));
        }
    }

    IEnumerator BlinkPoint(GameObject go)
    {
        go.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        go.gameObject.SetActive(true);
    }

}
