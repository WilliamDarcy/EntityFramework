using Adherent3_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adherent3_EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Création de l'entité. Le nom est donnée au moment de la création de la connexion avec SQL.
            associationEntities ent = new associationEntities(); 

            //On utilise la couche Data Layer pour s'interfacer avec la base
            AdherentDAL adhDAL = new AdherentDAL(ent);
            List<adherent> lesAdherents = adhDAL.GetAll();

            //Affichage dans une listview.
            foreach (var item in lesAdherents)
            {

                ListViewItem listItem = new ListViewItem(item.Nom);
                listItem.SubItems.Add(item.Prenom);
                listItem.SubItems.Add(item.Ville);
                listItem.SubItems.Add(item.CodePostal);
                listItem.SubItems.Add(item.DateNaissance.Value.ToShortDateString());
                listItem.SubItems.Add(item.typeadhesion1.Libelle);


                listViewAdherents.Items.Add(listItem);
            }

            //Exemple de récupération d'un adhérent
            adherent a = adhDAL.GetById(2);

            //Exemple de récupération de tous les adhérents
            List<adherent> l = adhDAL.GetAll();

            //Exemple de création d'un adhérent.
            adherent nouvelAdherent = new adherent();
            nouvelAdherent.Nom = "Marchandiau";

            adhDAL.Add(nouvelAdherent);

            //Une fois que vous avez ajouté ou supprimé des adhérents 
            //il faut appeler save pour sauvegarder les données dans la base.  
            adhDAL.Save();
            


        }
    }
}
