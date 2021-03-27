using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace bot_IG
{
    static public class Instagram // classe estatica = nao precisa ser instanciada para ser usada
    {
        public static Profile GetProfileByUser(string username)
        {
            var profile = new Profile(username);
            string url = @"https://www.instagram.com/" + username;
            string markup;

            using (WebClient wc = new WebClient())
            {
                markup = wc.DownloadString(url); // acessa o html do site 
            }

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(markup); //carrega o html no objeto criado com a biblioteca 

            var list = html.DocumentNode.SelectNodes("//meta"); // cria uma lista com todos os elementos meta

            foreach(var node in list) //checa os nos no array, caso ele tenha a mesma property do nome requisitado
            {                         //pega-se o conteudo do no
                string property = node.GetAttributeValue("property", ""); // procura um no com o atributo property

                if (property == "al:ios:app_name")
                    profile.IosAppName = node.GetAttributeValue("content", "");

                if (property == "al:ios:app_store_id")
                    profile.IosAppId = node.GetAttributeValue("content", "");

                if (property == "al:ios:url")
                    profile.IosUrl = node.GetAttributeValue("content", "");

                if (property == "al:android:app_name")
                    profile.AndroidAppName = node.GetAttributeValue("content", "");

                if (property == "al:android:app_store_id")
                    profile.AndroidAppId = node.GetAttributeValue("content", "");

                if (property == "al:android:url")
                    profile.AndroidUrl = node.GetAttributeValue("content", "");

                if (property == "og:type")
                    profile.Type = node.GetAttributeValue("content", "");

                if (property == "og:image")
                    profile.Image = node.GetAttributeValue("content", "");

                if (property == "og:title")
                    profile.Title = node.GetAttributeValue("content", "");

                if (property == "og:description")
                    profile.Description = node.GetAttributeValue("content", "");

                if (property == "og:url")
                    profile.Url = node.GetAttributeValue("content", "");
            }
            return profile; 
        }
    }
}
