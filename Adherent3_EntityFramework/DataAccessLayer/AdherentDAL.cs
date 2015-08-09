using Adherent3_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adherent3_EntityFramework
{
    class AdherentDAL
    {
        private associationEntities context;

        public AdherentDAL(associationEntities assocEnt)
        {
            context = assocEnt;
        }
        
        /// <summary>
        /// Ajoute un adhérent du contexte
        /// </summary>
        /// <param name="unAdherent"></param>
        public void Add(adherent unAdherent)
        {
            context.adherent.Add(unAdherent);
        }
        
        
        /// <summary>
        /// Supprime un adherent du contexte
        /// </summary>
        /// <param name="unAdherent"></param>
        public void Delete(int id)
        {
            adherent unAdherent = context.adherent.Find(id);
            context.adherent.Remove(unAdherent);

        }

        /// <summary>
        /// Retourne tous les adhérents de la table
        /// </summary>
        /// <returns>tous les adhérents</returns>
        public List<adherent> GetAll()
        {
            return context.adherent.ToList();
        }

        /// <summary>
        /// Retourne un adhérent
        /// </summary>
        /// <param name="id">id de l'adhérent</param>
        /// <returns>un adhérent</returns>
        public adherent GetById(int id)
        {
            return context.adherent.Find(id);
           

        }
        /// <summary>
        /// Sauvegarde toutes les modifications apportées au contexte.
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
