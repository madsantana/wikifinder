using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace wikiFinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pesquisa : ContentPage
    {
        public Pesquisa()
        {
            InitializeComponent();
        }

        public Pesquisa(dadosWikipedia dados)
        {
            InitializeComponent();
            lTitulo.Text = dados.title;
            GetImages(dados);
            //iImagem.Source = dados.images[0];
            eDados.Text = dados.content;

        }

        public void GetImages(dadosWikipedia dados)
        {
            string imagem = "";
            int i = 0;
            while (i < dados.images.Length && imagem == "")
            {

                if (dados.images[i].IndexOf("jpg") > 0)
                {

                    imagem = dados.images[i];
                    Image image = new Image { Source = imagem, HeightRequest = 300 };
                    sImagens.Children.Add(image);
                }

                i++;

            } 

        }
    }
}