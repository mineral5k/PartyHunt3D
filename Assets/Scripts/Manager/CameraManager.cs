using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    IEnumerator Quake()
    {
        Vector3 curPos = transform.position;
        rb.velocity = transform.forward*5;
        yield return new WaitForSeconds(1.4f);
        rb.velocity = Vector3.zero;
        transform.position = curPos;
    }

    public void CameraMove()
    {
        StartCoroutine(Quake());
    }
}
