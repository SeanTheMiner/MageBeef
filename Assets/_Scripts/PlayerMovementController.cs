using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    /*

    private Rigidbody rb;
    public int speed;
    

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

  
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (moveHorizontal != 0f || moveVertical != 0f) {
            rb.AddForce(movement * speed);
        }
        else {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        
    } //End FixedUpdate()

    */




    //public class example : MonoBehaviour {
        //Variables
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update() {

        CharacterController controller = GetComponent<CharacterController>();
      
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
            
        moveDirection *= speed;
            
        controller.Move(moveDirection * Time.deltaTime);

    } //End Update()
    








} //End PlayerMovementController
