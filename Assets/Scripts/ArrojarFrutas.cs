using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrojarFrutas : MonoBehaviour
{

    public GameObject[] FrutasParaArrojar;
    public GameObject bomba;
    public float esperaMinima = 0.3f;
    public float esperaMaxima = 1f;
    public float fuerzaMinima = 12f;
    public float fuerzaMaxima = 17f;
    public Transform[] lugaresLanzamientos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Arrojador());
    }

    private IEnumerator Arrojador()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(esperaMinima, esperaMaxima));

            Transform t = lugaresLanzamientos[Random.Range(0, lugaresLanzamientos.Length)];

            GameObject go = null;

            float p = Random.Range(0, 100);

            if (p < 10)
            {
                go = bomba;
            }else
            {
                go = FrutasParaArrojar[Random.Range(0, FrutasParaArrojar.Length)];
            }

            GameObject fruta = Instantiate(go, t.position, t.rotation);

            fruta.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(fuerzaMinima,fuerzaMaxima), ForceMode2D.Impulse);  

            Destroy(fruta, 5);
        }
    }

   
}
