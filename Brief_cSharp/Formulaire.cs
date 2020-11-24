using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brief_cSharp
{
    public partial class Formulaire : Form
    {
         

       

        List<string> errors = new List<string>(8);

        public bool valider()
        {
            Regex rx_name = new Regex("^[a-zA-Z ]{3,}$");
            Regex rx_phone = new Regex("^[0][5-7][0-9]{8}$");
            Regex rx_mail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if ( (rx_name.IsMatch(txtnom.Text)) && (rx_name.IsMatch(txtPrenom.Text)) && (rx_phone.IsMatch(txtTel.Text)) && (rx_mail.IsMatch(txtEmail.Text)) && ValideDate(txtDate.Text) )
            {
                MessageBox.Show("valide");
                return true;
            }

            return false;
        }
        /*
        public bool validSpecialite (string spec)
        {
            
            if(spec.ToLower() == "c#" || spec.ToLower() == "jee" || spec.ToLower() == "back-end && front-end")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        */

       
        public void chargerPays (string pays )
        {
            cmbVille.Items.Clear();
            
            
            if (pays == "Maroc")
            {
                 
                string[] ville = new string[] { "Rabat", "Eljadida", "Casablanca", "Tanger" };
                for (int i = 0; i < ville.Length ; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }
                

            }
            else if(pays == "France")
            {
                 
                string[] ville = new string[] { "Paris", "Lyon", "Marseille", "Nice" };
                for (int i = 0; i < ville.Length; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }
                 
            }
            else if (pays == "USA")
            {
                
                string[] ville = new string[] { "Washinton DC", "New York", "Chicago", "Miami" };
                for (int i = 0; i < ville.Length; i++)
                {
                    cmbVille.Items.Add(ville[i]);
                }
                
            }
            cmbVille.SelectedIndex = 0;

        }
        public bool ValideDate(string date)
        {
            int jour = int.Parse(date[0].ToString() + date[1].ToString());

            int  mois = int.Parse(date[3].ToString() + date[4].ToString());

            int  annee = int.Parse(date.Substring(6, 4));
             
            if( annee>=1900 && annee <= 2002)
            {
                if(mois>=1 && mois<=12)
                {
                    if ((jour >= 1 && jour <= 31) && (mois == 1 || mois == 3 || mois == 5 || mois == 7 || mois == 8 || mois == 10 || mois == 12))
                    {
                        return true;
                    }
                    else if ((jour >= 1 && jour <= 30) && (mois == 4 || mois == 6 || mois == 9 || mois == 11))
                    {
                        return true; 
                    }
                    else if ((jour >= 1 && jour <= 28) && (mois == 2))
                    {
                        return true;
                    }
                    else if (jour == 29 && mois == 2 && (annee % 400 == 0 || (annee % 4 == 0 && annee % 100 != 0)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
      
        }
        public Formulaire()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Formulaire_Load(object sender, EventArgs e)
        {
            //error texts
            label9.Visible = false;

             // correct mark
            correct1.Visible = false;
            correct2.Visible = false;
            correct3.Visible = false;
            correct4.Visible = false;
            correct5.Visible = false;
            correct6.Visible = false;
            correct7.Visible = false;
            correct8.Visible = false;

            cmbPays.Items.Add("Maroc");
            cmbPays.Items.Add("France");
            cmbPays.Items.Add("USA");
            cmbPays.SelectedIndex = 0;

            cmbSpecialite.Items.Add("C#");
            cmbSpecialite.Items.Add("JEE");
            cmbSpecialite.Items.Add("Front-end & Back-end");

            cmbSpecialite.SelectedText = "C#";
     
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Regex rx_mail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (rx_mail.IsMatch(txtEmail.Text))
            {
                if ((errors.Contains("Email non valide")))
                {

                    errors.Remove("Email non valide");
                }
                correct6.Visible = true;
            }
            else
            {
                if (!(errors.Contains("Email non valide")))
                {
                    errors.Add("Email non valide");
                }
                correct6.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // valider();
            label9.Text = "Veuillez remplir les champs ";

            if (errors.Count == 0 && txtnom.Text != "" && txtPrenom.Text != "" && txtEmail.Text != "" && txtDate.Text != "" && txtTel.Text != "")
            {
                label9.Visible = false;
                

                MessageBox.Show("Félicitation tous les champs sont valides");
            }
            else
            {
                label9.Visible = true;
                foreach (var error in errors)
                {
                    label9.Text += "\n" + error;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string all_errors = "";
            foreach (var error in errors)
            {
                all_errors += error;
                
            }
            MessageBox.Show(all_errors);
            
        }

        private void cmbPays_SelectedIndexChanged(object sender, EventArgs e)
        {
             chargerPays ((cmbPays.SelectedItem).ToString());
        }

        private void txtnom_TextChanged(object sender, EventArgs e)
        {
            Regex rx_name = new Regex("^[a-zA-Z ]{3,}$");
            if(rx_name.IsMatch(txtnom.Text))
            {
                if ((errors.Contains("Nom non valide")))
                {

                    errors.Remove("Nom non valide");
                }
                
                correct1.Visible = true;
              
            }
            else
            {
                if(!(errors.Contains("Nom non valide")))
                {
                    errors.Add("Nom non valide");
                }
                
                correct1.Visible = false;
                 
            }
        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {
            Regex rx_name = new Regex("^[a-zA-Z ]{3,}$");
            if (rx_name.IsMatch(txtPrenom.Text))
            {
                if ((errors.Contains("Prenom non valide")))
                {

                    errors.Remove("Prenom non valide");
                }
                correct5.Visible = true;
            }
            else
            {
                if (!(errors.Contains("Prenom non valide")))
                {
                    errors.Add("Prenom non valide");
                }
                correct5.Visible = false;
            }
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            Regex rx_phone = new Regex("^[0][5-7][0-9]{8}$");
            if (rx_phone.IsMatch(txtTel.Text))
            {
                if ((errors.Contains("Telephone non valide")))
                {

                    errors.Remove("Telephone non valide");
                }
                correct3.Visible = true;
            }
            else
            {
                if (!(errors.Contains("Telephone non valide")))
                {
                    errors.Add("Telephone non valide");
                }
                correct3.Visible = false;
            }
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            if(txtDate.Text.Length==2 || txtDate.Text.Length == 5)
            {
                var insertText = "-";
                var selectionIndex = txtDate.SelectionStart;
                txtDate.Text = txtDate.Text.Insert(selectionIndex, insertText);
                txtDate.SelectionStart = selectionIndex + insertText.Length;

           
                    
            }

           
                if ((txtDate.Text).Length >= 10 && (txtDate.Text).Length < 11 && ValideDate(txtDate.Text)  )
                {
                    if ((errors.Contains("Date non valide")))
                    {

                        errors.Remove("Date non valide");
                    }

                    correct2.Visible = true;
                }
                else
                {
                    if (!(errors.Contains("Date non valide")))
                    {
                        errors.Add("Date non valide");
                    }
                    correct2.Visible = false;
                }

            }
             
         
    }
}
