using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = targetPosition + Time.deltaTime * speed * new Vector3(1, 0, 0);      
        this.gameObject.transform.position = targetPosition;
    }
}
