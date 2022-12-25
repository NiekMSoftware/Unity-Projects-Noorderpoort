using UnityEngine;

public class PlayerRemoteControl : MonoBehaviour
{
    BasicCarController playerInput;
    public float forwards;
    public float turn;

    public Rigidbody rb;
    //[Header("Checkpoint Checker")]
    //public GameObject[] checkPoints;
    //public GameObject currentCheckPoint;
    //public int checkPointCounter = 0;
    void Awake()
    {
        playerInput = GetComponent<BasicCarController>();
        // NextCheckPoint();
    }
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            forwards = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            turn = Input.GetAxisRaw("Horizontal");
        }

        playerInput.ChangeSpeed(forwards);
        playerInput.Turn(turn);
    }
    //public GameObject NextCheckPoint()
    //{
    //    checkPointCounter++;
    //    if (checkPointCounter == checkPoints.Length)
    //    {
    //        checkPointCounter = 1;
    //    }
    //    currentCheckPoint = checkPoints[checkPointCounter];
    //    return currentCheckPoint;
    //}
}
