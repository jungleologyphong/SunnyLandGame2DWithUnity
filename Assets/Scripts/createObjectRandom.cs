using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createObjectRandom : MonoBehaviour
{
    public GameObject createObject;
    public GameObject startIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }
    IEnumerator Create()
    {
        yield return new WaitForSeconds(3f);
        Vector3 temp = startIndex.transform.position;
        temp.x = Random.Range(50f, 0f);
        Instantiate(createObject, temp, Quaternion.identity);
        StartCoroutine(Create());
    }
}
