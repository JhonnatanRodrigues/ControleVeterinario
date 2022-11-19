using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.Vacinacoes;
using ControleVeterinario.Dominio.Vacinacoes.Dtos;

namespace ControleVeterinario.Aplicacao.Vacinacoes
{
    public class AplicVacinacao : IAplicVacinacao
    {
        private readonly IRepVacinacao _repVacinacao;
        private readonly IRepRFID _repRFID;

        public AplicVacinacao(IRepVacinacao repVacinacao, 
            IRepRFID repRFID)
        {
            _repVacinacao = repVacinacao;
            _repRFID = repRFID;
        }

        public void Aplicacao(AplicVacinacaoDto aplicVacinacaoDto)
        {
            try
            {
                if (aplicVacinacaoDto == null)
                    throw new Exception($"Não foi selecionado a vacinação.");

                var vacinacao = _repVacinacao.Where(x => x.Id == aplicVacinacaoDto.Id).FirstOrDefault();

                if (vacinacao == null)
                    throw new Exception($"Não foi encontrado nem uma vacinação do código {aplicVacinacaoDto.Id}.");

                if (!vacinacao.EmAplicacao)
                    throw new Exception($"Todas as doses da vacina '{vacinacao.TipoVacinacao}-({vacinacao.Id})' já foram aplicadas.");

                vacinacao.QuantDoseAplicada += aplicVacinacaoDto.QuantDoseAplicada;

                if (vacinacao.QuantDoseAplicada >= vacinacao.QuantDose)
                    vacinacao.EmAplicacao = false;

                _repVacinacao.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Inserir(NovaVacinacaoDto vacinacaoDto)
        {
            try
            {
                var vacinacao = new Vacinacao();

                vacinacao.Nova(vacinacaoDto);

                vacinacao.Validacao();

                vacinacao.RFID = _repRFID.Where(x => x.Id == vacinacaoDto.CodigoRfId && x.EmUso && x.Ativo).FirstOrDefault();

                if (vacinacao.RFID == null)
                    throw new Exception($"Não foi encontrado nem um RFID do código {vacinacaoDto.CodigoRfId}.");

                _repVacinacao.Inserir(vacinacao);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public List<Vacinacao> Listar()
        {
            return _repVacinacao.Listar();
        }
    }
}
