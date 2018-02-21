using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public GameController gameController;       // Reference to the GameController object.
    public float m_Speed = 12f;                 // How fast the boat moves forward and back.
    public float m_TurnSpeed = 180f;            // How fast the boat turns in degrees per second.

    private Rigidbody rb;                       // Reference used to move the boat.
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void Update() {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }


    private void Move() {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
    }


    private void Turn() {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);

    }


    //default unity3D function to detect collision
    void OnTriggerEnter(Collider other) {
        //if there is collision
        if (other.gameObject.CompareTag("Pick Up")) {
            //become invisible
            other.gameObject.SetActive(false);
			gameController.AddScore();
        }
    }


}
