using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;

namespace ControleVeterinario.Aplicacao.Alimentacoes
{
    public class AplicAlimentacao : IAplicAlimentacao
    {
        private readonly IRepRFID _repRFID;
        private readonly IRepCadastroAnimal _repCadastroAnimal;
        private readonly IRepAlimentacao _repAlimentacao;

        public AplicAlimentacao(IRepRFID repRFID, 
            IRepCadastroAnimal repCadastroAnimal, 
            IRepAlimentacao repAlimentacao)
        {
            _repRFID = repRFID;
            _repCadastroAnimal = repCadastroAnimal;
            _repAlimentacao = repAlimentacao;
        }

        public void FoiAlimentar(string idRfid)
        {
            try
            {
                var rfids = _repRFID.Where(x => x.CodigoRFID == idRfid && x.Ativo && x.EmUso).ToList();

                if (rfids == null || rfids.Count == 0)
                    throw new Exception($"Não foi encontrado nem um RFID do código '{idRfid}'");
                if (rfids.Count > 1)
                    throw new Exception($"Foi encontrado mais de um RFID do código '{idRfid}', ativo e em uso.");

                var animais = _repCadastroAnimal.Where(x => x.CodigoRfId == rfids.FirstOrDefault().Id).ToList();

                if (animais == null || animais.Count == 0)
                    throw new Exception($"Não foi encontrado nem um animal com o RFID '{idRfid}'");

                if (animais.Count > 1)
                    throw new Exception($"Foi encontrado mais de um animal utilizando o RFID '{idRfid}'.");

                _repAlimentacao.Inserir(new Alimentacao
                {
                    Animal = animais.FirstOrDefault(),
                    CodigoAnimal = animais.FirstOrDefault().Id,
                    DataHora_FoiCome = DateTime.Now,
                    DataHora_ParoCome = null,
                    ParoCome = false
                });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        }

        public void ParoAlimentar(string idRfid)
        {
            try
            {
                var rfids = _repRFID.Where(x => x.CodigoRFID == idRfid && x.Ativo && x.EmUso).ToList();

                if (rfids == null)
                    throw new Exception($"Não foi encontrado nem um RFID do código '{idRfid}'");
                if (rfids.Count > 1)
                    throw new Exception($"Foi encontrado mais de um RFID do código '{idRfid}', ativo e em uso.");

                var animais = _repCadastroAnimal.Where(x => x.CodigoRfId == rfids.FirstOrDefault().Id).ToList();

                if (animais.Count > 1)
                    throw new Exception($"Foi encontrado mais de um animal utilizando o RFID '{idRfid}'.");

                var alimentacao = _repAlimentacao.Where(x => x.CodigoAnimal == animais.FirstOrDefault().Id && !x.ParoCome).FirstOrDefault();

                if (alimentacao == null)
                    throw new Exception($"Não foi encontrado nem um registro do RFID {idRfid}, na fila de alimentação.");

                alimentacao.DataHora_ParoCome = DateTime.Now;
                alimentacao.ParoCome = true;

                _repAlimentacao.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Alimentacao> Listar()
        {
            return _repAlimentacao.Listar();
        }
    }
}
