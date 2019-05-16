using System;

public class Evento
{
    public string nombreEvento;
    public string descripcionEvento;
    public string decision1;
    public string decision2;
    public string efectosDecision1;
    public string efectosDecision2;

    public Evento(string nombreEvento, string descripcionEvento,
            string decision1, string decision2,
            string efectosDecision1, string efectosDecision2) 
    {
        this.nombreEvento = nombreEvento;
        this.descripcionEvento = descripcionEvento;
        this.decision1 = decision1;
        this.decision2 = decision2;
        this.efectosDecision1 = efectosDecision1;
        this.efectosDecision2 = efectosDecision2;
    }

}
