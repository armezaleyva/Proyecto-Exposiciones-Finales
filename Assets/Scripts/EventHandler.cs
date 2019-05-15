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
    Text tituloEvento;
    [SerializeField]
    Text textoEvento;
    [SerializeField]
    Button botonDecision1;
    [SerializeField]
    Button botonDecision2;

    private Text txtBotonDecision1;
    private Text txtBotonDecision2;

    private List<Evento> listaEventos;
    private Evento eventoActual;

    private int numeroAleatorio;

    // Start is called before the first frame update
    void Start()
    {
        txtBotonDecision1 = botonDecision1.GetComponentInChildren<Text>();
        txtBotonDecision2 = botonDecision2.GetComponentInChildren<Text>();

        botonDecision1.onClick.AddListener(Decision1);
        botonDecision2.onClick.AddListener(Decision2);

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
        listaEventos.Add(evento1);

        CerrarEvento();
        textoEvento.text = "Wereja";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerEvento()
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        GenerarEvento();
    }

    void GenerarEvento() 
    {
        if (eventoActual != null) 
        {
            listaEventos.RemoveAt(numeroAleatorio);
        }

        if (listaEventos.Count > 0) 
        {
            print("xd");
            numeroAleatorio = Stats.rng.Next(listaEventos.Count);
            eventoActual = listaEventos[numeroAleatorio]; 

            tituloEvento.text = eventoActual.nombreEvento;
            textoEvento.text = eventoActual.descripcionEvento;
            txtBotonDecision1.text = eventoActual.decision1;
            txtBotonDecision2.text = eventoActual.decision2;

            panel.SetActive(true);
        }
    }

    void Decision1()
    {
        print("decision izq");
        CerrarEvento();
    }

    void Decision2()
    {
        print("decision der");
        CerrarEvento();
    }

    void CerrarEvento() 
    {
        panel.SetActive(false);
        StartCoroutine(TimerEvento());
    }
}
