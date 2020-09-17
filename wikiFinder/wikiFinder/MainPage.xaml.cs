using Algorithmia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace wikiFinder
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btExecutar_Clicked(object sender, EventArgs e)
        {

            try
            {
                

                var input = "{"
                     + "  \"articleName\": \"" +eValor.Text + "\","
                     + "  \"lang\": \"pt\""
                     + "}";
                var client = new Client("simj7RmJMacrrqOxwKD9m41e3GI1");
                var algorithm = client.algo("web/WikipediaParser/0.1.2");
                algorithm.setOptions(timeout: 300); // optional
                var response = algorithm.pipeJson<dadosWikipedia>(input);

                dadosWikipedia dados = (dadosWikipedia)response.result;

                this.Navigation.PushAsync(new Pesquisa(dados));
            }

            catch(Exception erro)
            {

                DisplayAlert("Erro!", "Tente refinar os parâmetros de busca.", "OK");


            }
        }
    }
}
