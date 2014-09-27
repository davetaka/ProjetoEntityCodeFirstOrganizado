using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Framework
{
    public class Resultado
    {
        private bool sucesso;
        private string mensagem;

        public bool Sucesso
        {
            get { return sucesso; }
        }

        public string Mensagem
        {
            get { return mensagem; }
        }

        public Resultado(string mensagemOk)
        {
            sucesso = true;
            mensagem = mensagemOk;
        }

        public void ErroExecucao(string mensagemErro)
        {
            sucesso = false;
            mensagem = mensagemErro;
        }
    }
}
