using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;  //pt Text


public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Text scoreTextLeft;
    public Text scoreTextRight;
    public Starter starter;
    private bool started = false;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    private BallController ballController;
    private Vector3 startingPosition;

    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    void Update()
    {
        if (this.started)
        { return; }

        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;  // abia acum se incepe codul
            this.starter.StartCountdown();
        }
    }

    public void StartGame()
    {
        this.ballController.Go();
    }



    public void ScoreGoalLeft()
    {
        UnityEngine.Debug.Log("Score Goal Right");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        UnityEngine.Debug.Log("Score Goal Left");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        //this.starter.StartCountdown();
    }

}
