namespace JobHub.Models
{
    public class VagaCandidato
    {
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }
    }
}
