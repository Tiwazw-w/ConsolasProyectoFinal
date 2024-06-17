using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_controller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camholder;
    public float speed, sensibility, maxForce;
    public Vector2 move, look;
    private float lookrotation;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }
    
    private void Start()
    {
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        Move_();

    }
    void Move_()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocity_change = (targetVelocity - currentVelocity);
        velocity_change = new Vector3(velocity_change.x, 0, velocity_change.z);

        Vector3.ClampMagnitude(velocity_change, maxForce);
        rb.AddForce(velocity_change, ForceMode.VelocityChange);
    }
    private void Update()
    {
        
        transform.Rotate(Vector3.up * look.x * sensibility);

        lookrotation += (-look.y * sensibility);
        camholder.transform.eulerAngles = new Vector3(lookrotation, camholder.transform.eulerAngles.y, camholder.transform.eulerAngles.z);
    }
    private void LateUpdate()
    {
        
    }
}
