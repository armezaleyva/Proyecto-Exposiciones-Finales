using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    private int indexEvento;

    private int numeroAleatorio;

    Type t;

    // Start is called before the first frame update
    void Start()
    {
        txtBotonDecision1 = botonDecision1.GetComponentInChildren<Text>();
        txtBotonDecision2 = botonDecision2.GetComponentInChildren<Text>();

        botonDecision1.onClick.AddListener(Decision1);
        botonDecision2.onClick.AddListener(Decision2);

        Evento evento1 = new Evento(
            "Fé de la Ciudad",
            "El futuro de la ciudad está en tus manos, ¿eligirás el camino del bien o el camino del mal?",
            "Camino del bien",
            "Camino del mal",
            "EventosBien",
            "EventosMal"
        );

        listaEventos = new List<Evento>();
        listaEventos.Add(evento1);

        t = this.GetType();
        indexEvento = -1;

        CerrarEvento();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerEvento()
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        SiguienteEvento();
    }

    void SiguienteEvento() 
    {
        eventoActual = listaEventos[indexEvento]; 
        tituloEvento.text = eventoActual.nombreEvento;
        textoEvento.text = eventoActual.descripcionEvento;
        txtBotonDecision1.text = eventoActual.decision1;
        txtBotonDecision2.text = eventoActual.decision2;

        panel.SetActive(true);
    }

    void Decision1()
    {
        MethodInfo method = t.GetMethod(eventoActual.efectosDecision1);
        method.Invoke(this, null);
        CerrarEvento();
    }

    void Decision2()
    {
        MethodInfo method = t.GetMethod(eventoActual.efectosDecision2);
        method.Invoke(this, null);
        CerrarEvento();
    }

    void CerrarEvento() 
    {
        panel.SetActive(false);
        if (listaEventos[indexEvento + 1] != null) 
        {
            indexEvento++;
            StartCoroutine(TimerEvento());
        }
    }

    public void EventosBien() 
    {
        Evento evento2 = new Evento(
            "Trabajo para la Ciudad",
            "Has elegido ser una ciudad de bien, ¡ahora debes encaminar a tu ciudad a la prosperidad! ¡Debes decidir a que se dedicara tu ciudad!",
            "Producción de alimento y comercio",
            "Producción de objetos y comercio",
            "Placeholder",
            "Placeholder"
        );
        Evento evento3 = new Evento(
            "¡Hechizo Protector!",
            "Te diste cuenta que tu ciudad necesita ayuda para prosperar, ¡así que buscaste a un mago que hiciera un hechizo para apoyar a tu pueblo!",
            "Hechizo de Estabilidad",
            "Hechizo de Buena Fortuna",
            "Placeholder",
            "Placeholder"
        );
        Evento evento4 = new Evento(
            "Los Viajeros",
            "Tu ciudad está prosperando, por lo que muchos viajeros están llegado a la ciudad…",
            "Ofrecerles trabajo para que se queden",
            "Ofrecerles comida y estancia para que pasen la noche",
            "Placeholder",
            "Placeholder"
        );

        listaEventos.Add(evento2);
        listaEventos.Add(evento3);
        listaEventos.Add(evento4);
    }

    public void EventosMal() 
    {
        Evento evento2 = new Evento(
            "Maldición Eterna",
            "Has elegido ser una ciudad de bien, ¡ahora debes encaminar a tu ciudad a la prosperidad! ¡Debes decidir a que se dedicara tu ciudad!",
            "Producción de alimento y comercio",
            "Producción de objetos y comercio",
            "Placeholder",
            "Placeholder"
        );
        listaEventos.Add(evento2);
    }

    public void Placeholder()
    {
        print("I am a placeholder");
    }
}
