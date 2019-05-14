public class Evento
{
    public int idEvento;
    public string nombreEvento;
    public string descripcionEvento;
    public string decision1;
    public string decision2;

    public Evento(int idEvento, string nombreEvento, string descripcionEvento,
            string decision1, string decision2) 
    {
        this.idEvento = idEvento;
        this.nombreEvento = nombreEvento;
        this.descripcionEvento = descripcionEvento;
        this.decision1 = decision1;
        this.decision2 = decision2;
    }
}
