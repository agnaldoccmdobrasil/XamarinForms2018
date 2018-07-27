using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            // TODO - Lógica do programa


            // TODO - Validações


            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    // TODO = Buscar serviço
                    Endereco end = ViaCEPServico.BuscaEnderecoViaCep(cep);
                    if (end != null)
                        RESULTADO.Text = string.Format("Endereço: {0} - {1} - {2}/{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    else
                        DisplayAlert("ERRO", "Oendereço não foi encontrado para o CEP informado: " + cep, "OK");
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            string msg = "";

            
            if (cep.Length != 8)
            {
                msg = "CEP deve ter 8 caracteres\n";
                valido = false;
            }

            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                msg = msg + "\n" + "CEP deve conter apenas números";
                valido = false;
            }

            if (!valido)
                DisplayAlert("Atenção", msg, "OK");
                
            return valido;
        }
	}
}
