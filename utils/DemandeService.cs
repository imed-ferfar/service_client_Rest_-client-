using Client1_Csharp.utils.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client1_Csharp.utils
{
    public class DemandeService
    {
        public static string EnvoyerDemande(int Annee)
        {
            string reslt = "vide",
                    hosteName = SetInfos.DisplayLocalHostName(),
                    userName = SetInfos.LocalUserName();
            DateTime timeStamp = SetInfos.GetTimeStamp();
            Demande dem = new Demande();
            dem.Host = hosteName;
            dem.User = userName;
            dem.TimeStamp = timeStamp;
            dem.Year = Annee;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58204/api/");
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("demande", dem);
                responseTask.Wait();

                var resultat = responseTask.Result;
                if (resultat.IsSuccessStatusCode)
                {
                    var readTask = resultat.Content.ReadAsAsync<Demande>();
                    readTask.Wait();
                    var retour = readTask.Result;
                    //Console.WriteLine("oui : "+retour.Message);
                    reslt = retour.Message;
                }
            }

            return reslt;
        }
    }
}


