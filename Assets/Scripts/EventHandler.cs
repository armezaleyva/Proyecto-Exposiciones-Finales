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
    float rimPower = 4;
    [SerializeField]
    GameObject ciudad;
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

    [SerializeField]
    ParticleSystem particulasDinero;

    private Text txtBotonDecision1;
    private Text txtBotonDecision2;

    private List<Evento> listaEventos;
    private Evento eventoActual;
    private int indexEvento;

    private Renderer rendererCiudad;
    private Material materialCiudad;

    Type t;

    // Start is called before the first frame update
    void Start()
    {
        txtBotonDecision1 = botonDecision1.GetComponentInChildren<Text>();
        txtBotonDecision2 = botonDecision2.GetComponentInChildren<Text>();

        botonDecision1.onClick.AddListener(Decision1);
        botonDecision2.onClick.AddListener(Decision2);

        rendererCiudad = ciudad.GetComponent<Renderer>();
        materialCiudad = rendererCiudad.material;

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
        if (indexEvento + 1 < listaEventos.Count) 
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
            "ParticulasDinero"
        );
        Evento evento3 = new Evento(
            "¡Hechizo Protector!",
            "Te diste cuenta que tu ciudad necesita ayuda para prosperar, ¡así que buscaste a un mago que hiciera un hechizo para apoyar a tu pueblo!",
            "Hechizo de Estabilidad",
            "Hechizo de Buena Fortuna",
            "RimAmarillo",
            "RimVerde"
        );
        Evento evento4 = new Evento(
            "Los Viajeros",
            "Tu ciudad está prosperando, por lo que muchos viajeros están llegado a la ciudad…",
            "Ofrecerles trabajo para que se queden",
            "Ofrecerles comida y estancia temporal",
            "Placeholder",
            "Placeholder"
        );
        Evento evento5 = new Evento(
            "La Enfermedad",
            "¡Una enfermedad se está esparciendo por la ciudad, hay que hacer algo!",
            "Buscar una cura",
            "Traer médicos a que los curen",
            "RimAzulOscuro",
            "Placeholder"
        );
        Evento evento6 = new Evento(
            "Justicia",
            "Un grupo de bandidos fue detenido en tu ciudad, es hora de la justicia.",
            "Servicio comunitario",
            "Exiliarlos de la ciudad",
            "Placeholder",
            "Placeholder"
        );
        Evento evento7 = new Evento(
            "El Legado",
            "Con el paso del tiempo ya no podrás seguir al mando de la ciudad y debe haber un sucesor. ¡Elige con sabiduría!",
            "Alguien de tu familia",
            "Que decida la gente",
            "Placeholder",
            "Placeholder"
        );
        

        listaEventos.Add(evento2);
        listaEventos.Add(evento3);
        listaEventos.Add(evento4);
        listaEventos.Add(evento5);
        listaEventos.Add(evento6);
        listaEventos.Add(evento7);

        RimAzul();
    }

    public void EventosMal() 
    {
        Evento evento2 = new Evento(
            "Maldición Eterna",
            "¡Has decidido traerle mal a la ciudad. Hora de causar sufrimiento! ¡Comenzemos con una maldición!",
            "Maldición de Vergüenza",
            "Maldición de Sufrimiento",
            "RimVerdeClaro",
            "RimMorado"
        );
        Evento evento3 = new Evento(
            "Contrato",
            "Has contratado a un grupo de bandidos para atacar a la ciudad, ¿que es lo que harán?",
            "Robar pertenencias",
            "Diezmar su fuente de alimento",
            "ResetRim",
            "Placeholder"
        );
        Evento evento4 = new Evento(
            "Esclavistas",
            "Has traído a un grupo de ricos en busca de esclavos para que compren a los que habitan en la ciudad.",
            "Vender a los niños",
            "Vender a las niñas",
            "Placeholder",
            "Placeholder"
        );
        Evento evento5 = new Evento(
            "Enfermedad",
            "¿Todavía no se largan? Bueno, ¡Llenemos la ciudad de enfermedad!",
            "¡Todos sufrirán de lepra!",
            "¡El cólera acabará con ellos!",
            "RimAmarillo",
            "RimNaranja"
        );
        Evento evento6 = new Evento(
            "Falsas Esperanzas",
            "Tu plan final requiere de que haya personas viviendo en tu ciudad, así que decides curar los males que afectan a tu ciudad.",
            "Revertir todos los males...por ahora...",
            "Revertir todos los males...por ahora...",
            "RimAzul",
            "RimAzul"
        );
        Evento evento7= new Evento(
            "El mal de los males",
            "Tu plan ha funcionado. ¡Ahora destruye tu ciudad y termina con la vida de aquellos que la habitan!",
            "¡Lluvia de Sangre!",
            "¡Quemar la ciudad!",
            "Placeholder",
            "Placeholder"
        );
        listaEventos.Add(evento2);
        listaEventos.Add(evento3);
        listaEventos.Add(evento4);
        listaEventos.Add(evento5);
        listaEventos.Add(evento6);
        listaEventos.Add(evento7);

        RimRojo();
    }

    public void ParticulasDinero()
    {
        particulasDinero.Play();
    }

    public void RimAzul()
    {
        materialCiudad.SetFloat("_Rim", rimPower);
        materialCiudad.SetColor("_RimColor", Color.blue);
    }

    public void RimRojo()
    {
        materialCiudad.SetFloat("_Rim", rimPower);
        materialCiudad.SetColor("_RimColor", Color.red);
    }
    
    public void RimAmarillo()
    {
        materialCiudad.SetFloat("_Rim", rimPower);
        materialCiudad.SetColor("_RimColor", Color.yellow);
    }

    public void RimVerde()
    {
        materialCiudad.SetFloat("_Rim", rimPower);
        materialCiudad.SetColor("_RimColor", Color.green);
    }

    public void RimAzulOscuro()
    {
        Color azulOscuro;
        if (ColorUtility.TryParseHtmlString("#003366", out azulOscuro))
        {
            materialCiudad.SetFloat("_Rim", rimPower);
            materialCiudad.SetColor("_RimColor", azulOscuro);
        }
    }

    public void RimMorado()
    {
        materialCiudad.SetFloat("_Rim", rimPower);
        materialCiudad.SetColor("_RimColor", Color.magenta);
    }

    public void RimVerdeOscuro()
    {
        Color verdeOscuro;
        if (ColorUtility.TryParseHtmlString("#006400", out verdeOscuro))
        {
            materialCiudad.SetFloat("_Rim", rimPower);
            materialCiudad.SetColor("_RimColor", verdeOscuro);
        }
    }

    public void RimVerdeClaro()
    {
        Color verdeClaro;
        if (ColorUtility.TryParseHtmlString("#00FF00", out verdeClaro))
        {
            materialCiudad.SetFloat("_Rim", rimPower);
            materialCiudad.SetColor("_RimColor", verdeClaro);
        }
    }

    public void RimNaranja()
    {
        Color naranja;
        if (ColorUtility.TryParseHtmlString("#ffa500", out naranja))
        {
            materialCiudad.SetFloat("_Rim", rimPower);
            materialCiudad.SetColor("_RimColor", naranja);
        }
    }

    public void ResetRim()
    {
        materialCiudad.SetFloat("_Rim", 10);
        materialCiudad.SetColor("_RimColor", Color.black);
    }

    public void Placeholder()
    {
        print("I am a placeholder");
    }
}
