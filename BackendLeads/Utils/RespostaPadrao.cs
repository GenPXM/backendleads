namespace BackendLeads.Utils
{
    public class RespostaPadrao
    {
        public int Codigo { get; set; }
        public string Resposta { get; set; }
        public object? Retorno { get; set; }
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Dados { get; private set; }

        public RespostaPadrao()
        {
            Codigo = 200;
            Resposta = "Ok";
            Retorno = null;
        }

        public RespostaPadrao(string resposta)
        {
            Codigo = 200;
            Resposta = resposta;
            Retorno = null;
        }

        public RespostaPadrao(int cod, string res)
        {
            Codigo = cod;
            Resposta = res;
            Retorno = null;
        }

        public RespostaPadrao(int cod, string res, object obj)
        {
            Codigo = cod;
            Resposta = res;
            Retorno = obj;
        }


        public void SetMensagem(string mensagem)
        {
            Resposta = mensagem;
        }

        public void SetMensagem(string mensagem, object data)
        {
            Resposta = mensagem;
            Retorno = data;
        }

        public void SetErroNoErede(string mensagem)
        {
            Codigo = 533;
            Resposta = mensagem;
        }

        public void SetBadRequest(object modelState)
        {
            Codigo = 400;
            Resposta = "Solicitação inválida";
            Retorno = modelState;
        }

        public void SetSemAcesso(string? mensagem = null)
        {
            Codigo = 403;
            Resposta = "Você não possui direito de acesso ao conteúdo";
            if (mensagem != null)
            {
                Resposta = mensagem;
            }
        }

        public void SetNaoEncontrado(string mensagem)
        {
            Codigo = 404;
            Resposta = mensagem;
        }

        public void SetCampoVazio(string campo)
        {
            Codigo = 616;
            Resposta = "Você deve informar o campo " + campo;
        }

        public void SetDataFornecimentoVazia()
        {
            Codigo = 617;
            Resposta = "Você deve informar o campo DataFornecimento";
        }

        public void SetCampoJaExiste(string mensagem)
        {
            Codigo = 626;
            Resposta = mensagem;
        }

        public void SetCampoIncorreto(string mensagem)
        {
            Codigo = 628;
            Resposta = mensagem;
        }

        public void SetCampoInvalido(string campo, string? explicacao = null)
        {
            Codigo = 636;
            Resposta = "O campo " + campo + " informado não é válido";
            if (explicacao != null)
            {
                Resposta += ". " + explicacao;
            }
        }

        public void SetSemEndereco()
        {
            Codigo = 637;
            Resposta = "Suas informações de Endereço estão desatualizadas";
        }

        public void SetChamadaInvalida(string? mensagem = null)
        {
            Codigo = 640;
            Resposta = "Chamada inválida";
            if (mensagem != null)
                Resposta += ". " + mensagem;
        }

        public void SetUsuarioDesativado()
        {
            Codigo = 646;
            Resposta = "O usuário está desativado";
        }

        public void SetLimitesExcedidos(string mensagem)
        {
            Codigo = 656;
            Resposta = mensagem;
        }

        public void SetErroInterno()
        {
            Codigo = 661;
            Resposta = "Erro interno durante o processamento";
        }

        public void SetErroInterno(string erro)
        {
            Codigo = 661;
            Resposta = "Erro interno durante o processamento. " + erro;
        }

        public void SetTempoExpirado()
        {
            Codigo = 671;
            Resposta = "Período de atualização de senha expirou";
        }

        public void SetTokenExpirado()
        {
            Codigo = 672;
            Resposta = "Você não está logado no sistema";
        }

        public void SetInadimplente(object dado)
        {
            Codigo = 676;
            Resposta = "O Cliente está inadimplente";
            Retorno = dado;
        }

        public void SetQuaseSucesso(string mensagem, object dado)
        {
            Codigo = 222;
            Resposta = Resposta + ". " + mensagem;
            Retorno = dado;
        }

        public void SetSucesso(string mensagem, object dado)
        {
            Codigo = 200;
            Resposta = Resposta + ". " + mensagem;
            Retorno = dado;
        }
        public void SetSuccess(string mensagem, object dado)
        {
            Sucesso = true;
            Mensagem = mensagem;
            Dados = dado;
        }
    }
}