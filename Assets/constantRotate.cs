using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantRotate : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        StartCoroutine(timelapse());
    }
    private void Update()
    {
        transform.eulerAngles += Vector3.up * rotateSpeed*Time.deltaTime;
    }
    IEnumerator timelapse()
    {
        yield return new WaitForSeconds(15f);
        Destroy(transform.gameObject);
    }
}
