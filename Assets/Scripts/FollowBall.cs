using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    private GameObject ball;
    private Vector3 offset = new Vector3 (-15, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            transform.position = ball.transform.position - offset;
        }
    }

    public void setNewBall(GameObject newBall)
    {
        ball = newBall;
    }
}
