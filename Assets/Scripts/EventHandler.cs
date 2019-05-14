using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    [SerializeField]
    float tiempoDeEspera = 8;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Text textoEvento;
    List<Evento> listaEventos;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        Evento evento0 = new Evento(
            0,
            "ola",
            "avia una vez un wei",
            "imon",
            "nel"
        );
        Evento evento1 = new Evento(
            1,
            "hola",
            "havia una vez un wei",
            "himon",
            "nhehl"
        );

        listaEventos = new List<Evento>();
        listaEventos.Add(evento0);

        StartCoroutine(TimerEvento());
    }

    // Update is called once per frame
    void Update()
    {
        textoEvento.text = "Wereja";
    }

    IEnumerator TimerEvento()
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        GenerarEvento();
    }

    void GenerarEvento() 
    {
        print("xd");

    }
}
