using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Game objects
    [SerializeField] GameObject ball;
    [SerializeField] FollowBall cameraScript;

    //UI stuff
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] TextMeshProUGUI livText;
    [SerializeField] Slider powerSlider;
    [SerializeField] Button launchButton;
    [SerializeField] GameObject gameOverUI;

    //variables
    private Vector3 ballPos = new Vector3(0, 4.923f, 5.613f);
    private int lives = 3;
    private int score = 0;
    private float power = 0;
    private float powerRate = 0.7f;
    private bool increasePower = true;
    public bool isLaunching = true;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = Camera.main.GetComponent<FollowBall>();
        scoreText.text = "Score: " + score;
        liveText.text = "Lives: " + lives;
        SpawnNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (increasePower)
        {
            power += powerRate * Time.deltaTime;
        }
        else
        {
            power -= powerRate * Time.deltaTime;
        }
        //Switch power direction
        if (power >= 1)
        {
            power = 1;
            increasePower = false;
        }
        else if (power <= 0)
        {
            power = 0;
            increasePower = true;
        }

        powerSlider.value = power;
    }

    public void increaseScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score: " + score;
    }

    public void decreaseLive()
    {
        lives--;
        liveText.text = "Lives: " + lives;
        if (lives <= 0 ) 
        {
            gameOverUI.gameObject.SetActive(true);
        }
        else
        {
            SpawnNewBall();
            launchButton.gameObject.SetActive(true);
            powerSlider.gameObject.SetActive(true);
            isLaunching = true;
        }
    }

    void SpawnNewBall()
    {
        ball = Instantiate(ball, ballPos, ball.transform.rotation);
        cameraScript.setNewBall(ball);
    }

    public void Fire()
    {
        ball.GetComponent<Ball>().Fire(power);
        isLaunching = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
