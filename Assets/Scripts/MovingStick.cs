using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStick : MonoBehaviour
{
    private GameManager gameManager;
    private float boundaryTop = 3.75f;
    private float boundaryBottom = 2.75f;
    private bool movingUp = true;
    [SerializeField] Vector3 speed = new Vector3 (0, 0.88f, 0);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isLaunching)
        {
            //Move the stick up and down
            if (movingUp)
            {
                transform.position += speed * Time.deltaTime;
            }
            else
            {
                transform.position -= speed * Time.deltaTime;
            }
            //Reverse direction if boundary reached
            if (transform.position.y > boundaryTop)
            {
                movingUp = false;
            }
            if (transform.position.y < boundaryBottom)
            {
                movingUp = true;
            }
        }
    }
}
