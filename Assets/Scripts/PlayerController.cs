using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    
    public float forwardSpeed = 20f;
    public int lane = 0;
    public bool canStart = false;
    public bool canJump;
    public Vector3 laneforce;
    public float JumpForce;
    public static int coinCollected;
    Animator anim;

    [Header("UI Area")]
    public Text coinText;
    public GameObject playPanel;
    public GameObject gameOverPanel;
    public GameObject scorePanel;
    public Text finalCoinsText;
    public Text finalScoreText;
    public GameObject pausePanel;
    //public float smoothFactor = 20f;

    // Start is called before the first frame update
    void Start()
    {
        coinCollected = 0;
        playPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(false);
        canStart = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        lane = 0;
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCollected.ToString();
        if (canStart == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
            anim.Play("Running");
            laneChanger();
        }
        if (canJump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up * Time.deltaTime * JumpForce);
            }
        }
    }

    void laneChanger()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(lane == 0)
            {
                transform.position = transform.position - laneforce;
               // var targetPosition = transform.position - laneforce;
               // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
                lane = -1;
            }
            if(lane == 1)
            {
                transform.position = transform.position - laneforce;
              //  var targetPosition = transform.position - laneforce;
              //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
                lane = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lane == 0)
            {
                transform.position = transform.position + laneforce;
                //  var targetPosition = transform.position + laneforce;
                //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
                lane = 1;
            }
            if (lane == -1)
            {
                transform.position = transform.position + laneforce;
                // var targetPosition = transform.position + laneforce;
                // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
                lane = 0;
            }
            
        }
    }

    public void left()
    {
        if (lane == 0)
        {
            transform.position = transform.position - laneforce;
            // var targetPosition = transform.position - laneforce;
            // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
            lane = -1;
        }
        if (lane == 1)
        {
            transform.position = transform.position - laneforce;
            //  var targetPosition = transform.position - laneforce;
            //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
            lane = 0;
        }
    }

    public void Right()
    {
        if (lane == 0)
        {
            transform.position = transform.position + laneforce;
            //  var targetPosition = transform.position + laneforce;
            //  transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
            lane = 1;
        }
        if (lane == -1)
        {
            transform.position = transform.position + laneforce;
            // var targetPosition = transform.position + laneforce;
            // transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
            lane = 0;
        }
    }

    public void Jump()
    {
        if (canJump == false)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up * Time.deltaTime * JumpForce);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Track")
        {
            Debug.Log("Triggering");
            canJump = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Track")
        {
            Debug.Log("Triggering Exit");
            canJump = true;
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bogey" || collision.gameObject.tag == "Barricade")
        {
            Debug.Log("Die");
            canStart = false;
            anim.Play("FallingDown");
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        scorePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        finalCoinsText.text = coinCollected.ToString();
        finalScoreText.text = Score.score.ToString();
    }
    public void clickPlay()
    {
        playPanel.SetActive(false);
        canStart = true;
    }

    public void clickPause()
    {
        canStart = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
