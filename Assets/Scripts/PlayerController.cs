using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    private Vector3 _input; // vettore in input

    void GatherInput()
    {
        // zero sull'asse y perchè li non ci muoviamo
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
        Look();
    }

    void Look()
    {
        // se non mettiamo questa questa cosa la rotazione verrà applicata anche quando abbiamo quel vector3 uguale a 0
        // quindi quando non abbiamo input
        if (_input != Vector3.zero)
        {
            // angolo relativo tra dove siamo e dove vogliamo essere 
            var relative = (transform.position + _input) - transform.position;
            // trasformiamo questa cosa in una rotazione
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = rot;

        }
    }
}
