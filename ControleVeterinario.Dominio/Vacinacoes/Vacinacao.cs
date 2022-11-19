using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.Vacinacoes.Dtos;

namespace ControleVeterinario.Dominio.Vacinacoes
{
    public class Vacinacao
    {
        public Vacinacao()
        {
            RFID = new RFID();
            EmAplicacao = true;
        }
        public int Id { get; set; }
        public int CodigoRfId { get; set; }
        public DateTime DataInicioAplicacao { get; set; }
        public DateTime? DataUltimaDoseAplicada { get; set; }
        public decimal QuantDose { get; set; }
        public decimal QuantDoseAplicada { get; set; }
        public string TipoVacinacao { get; set; }
        public bool EmAplicacao { get; set; }

        public RFID RFID { get; set; }

        public void Nova(NovaVacinacaoDto vacinacaoDto)
        {
            CodigoRfId = vacinacaoDto.CodigoRfId;
            DataInicioAplicacao = vacinacaoDto.DataInicioAplicacao;
            DataUltimaDoseAplicada = null;
            QuantDose = vacinacaoDto.QuantDose;
            QuantDoseAplicada = 0m;
            TipoVacinacao = vacinacaoDto.TipoVacinacao;
            EmAplicacao = true;

            RFID = new RFID();
        }

        public void Validacao()
        {
            if (CodigoRfId == null || CodigoRfId == 0)
                throw new Exception($"Não foi informado o RFID.");

            if(DataInicioAplicacao == null)
                throw new Exception($"Não foi informado a data de início da aplicação.");

            if(QuantDose == null || QuantDose == 0)
                throw new Exception($"Não foi informado a quantidade de dose da vacina.");

            if(TipoVacinacao == null || TipoVacinacao.Trim().Length == 0)
                throw new Exception($"Não foi informado a vacinação.");
        }

    }
}
