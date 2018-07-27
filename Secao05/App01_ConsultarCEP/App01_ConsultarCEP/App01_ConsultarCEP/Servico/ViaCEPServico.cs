﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static readonly string enderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViaCep(string cep)
        {
            string novoEnderecoURL = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep == null)
                return null;
            else
                return end;
        }
    }
}
