using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRB;
    private float powerMultiplier = 50;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(float power)
    {
        ballRB.AddForce(Vector3.up * power * powerMultiplier, ForceMode.Impulse);
    }
}
