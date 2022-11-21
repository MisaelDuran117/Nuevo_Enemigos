using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_2 : MonoBehaviour
{
    [SerializeField]
    GameObject Spawner;

    [SerializeField]
    float Espera;

    [SerializeField]
    float Rango;

    [SerializeField]
    LayerMask Jugador;

    int cont = 0;
    bool Alerta;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",0,Espera);
    }

    public void Spawn()
    {
        Alerta = Physics.CheckSphere(transform.position, Rango, Jugador);
        if (Alerta == true)
        {

            Vector3 randomPosition=new Vector3(Random.Range(425,485),0,Random.Range(377,430));

            GameObject nuevo = Instantiate(Spawner,randomPosition,transform.rotation);
            cont = cont + 1;
            nuevo.name = "Bandido_" + cont.ToString();
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere.
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, Rango);
    }
}
