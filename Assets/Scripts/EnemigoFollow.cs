using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollow : MonoBehaviour
{
    public Animator animator;

    public float Rango;
    public LayerMask Jugador;
    bool Alerta;
    public Transform MirarJugador;
    public float Velocidad;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
       Alerta =Physics.CheckSphere(transform.position,Rango,Jugador);

        if (Alerta == true)
        {
            Vector3 PosicionJugador = new Vector3(MirarJugador.position.x, transform.position.y, MirarJugador.position.z);
            transform.LookAt(PosicionJugador);
            transform.position=Vector3.MoveTowards(transform.position,PosicionJugador, Velocidad*Time.deltaTime);
            SprintJump();
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Rango);
    }

    public void Idle()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("SprintJump", false);
        animator.SetBool("SprintSlide", false);
    }

    public void Walk()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
        animator.SetBool("SprintJump", false);
        animator.SetBool("SprintSlide", false);
    }

    public void SprintJump()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("SprintJump", true);
        animator.SetBool("SprintSlide", false);
    }

    public void SprintSlide()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("SprintJump", false);
        animator.SetBool("SprintSlide", true);
    }
}
