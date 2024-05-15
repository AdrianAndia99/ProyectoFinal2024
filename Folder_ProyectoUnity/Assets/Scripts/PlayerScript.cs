using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //private Vector2 movimiento;
    private Animator animator;
    private Rigidbody rb;

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public float x, y;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

   /* public void OnMove(InputAction.CallbackContext context)
    {
        movimiento = context.ReadValue<Vector2>();
    }*/

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0,0,y * Time.deltaTime * velocidadMovimiento);

        animator.SetFloat("VelX",x);
        animator.SetFloat("VelY", y);
    }
}