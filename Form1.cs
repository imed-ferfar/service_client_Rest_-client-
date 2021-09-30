using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client1_Csharp.utils;

namespace Client1_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblResult.Text = "";
           // Refresh();  //Invalidate();

            string reslt;
            DateTime myDate = DateTime.Parse(DTP.Text);
            int annee = myDate.Year;
            try
            {
                Refresh();
                reslt = DemandeService.EnvoyerDemande(annee);
                lblResult.ForeColor = Color.Green;
                Cursor.Current = Cursors.Default;
            }
            catch (AggregateException ex)
            {
                MessageBox.Show("Désolé, on n’arrive pas à se connecter au serveur, veuillez réessayer svp.",
                    "Echéc de connexion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reslt = "Connexion au serveur a été échouée ☹ !!!";
                lblResult.ForeColor = Color.Red;
                Console.WriteLine("Plus de détails : \n" + ex.Message);
                
            }   
            Cursor.Current = Cursors.Default;
            lblResult.Text = reslt;
        }
    }
}
