using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour
{
    public GameObject prefabFrutaCortada;

    public void CrearFrutaCortada()
    {
        GameObject inst = (GameObject)Instantiate(prefabFrutaCortada, transform.position, transform.rotation);

        Rigidbody[] rbsDeCortados = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsDeCortados)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        FindObjectOfType<GameManager>().aumentarPuntaje();
    

        Destroy(inst.gameObject, 5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e = collision.GetComponent<Espada>();

        if (!e)
        {
            return;
        }

        CrearFrutaCortada();
    }
}
