// <copyright file="Dossier.cs" company="Benoît Roche Developments">
// Copyright (c) Benoît Roche Developments. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// classe Dossier.
    /// </summary>
    public class Dossier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// </summary>
        /// <param name="nomPatient">Nom du patient.</param>
        /// <param name="prenomPatient">Prénom du patient.</param>
        /// <param name="dateDeNaissance">Date de naissance du patient.</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance)
        {
            this.NomPatient = nomPatient;
            this.PrenomPatient = prenomPatient;
            this.DateDeNaissancePatient = dateDeNaissance;
            this.MesPrestations = new List<Prestation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// constructeur surchargé.
        /// Il comprend en plus un objet de la classe Prestation à rajouter dans la 
        /// collection _mesPrestations
        /// </summary>
        /// <param name="nomPatient">Nom du patient.</param>
        /// <param name="prenomPatient">Prénom du patient.</param>
        /// <param name="dateDeNaissance">Date de naissance du patient.</param>
        /// <param name="unePrestation">objet de la classe Prestation à rajouter.</param>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, Prestation unePrestation)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.MesPrestations.Add(unePrestation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dossier"/> class.
        /// constructeur surchargé
        /// Il comprend un onbjet Collection de Prestation.
        /// Il faudra affecter cette Collection à l'objet mesPrestations.
        /// <param name="nomPatient">Nom du patient.</param>
        /// <param name="prenomPatient">Prénom du patient.</param>
        /// <param name="dateDeNaissance">Date de naissance du patient.</param>
        /// <param name="desPrestations">Liste de prestations.</param>
        /// </summary>
        public Dossier(string nomPatient, string prenomPatient, DateTime dateDeNaissance, List<Prestation> desPrestations)
            : this(nomPatient, prenomPatient, dateDeNaissance)
        {
            this.MesPrestations = desPrestations;
        }

        /// <summary>
        /// Gets Nom du patient.
        /// </summary>
        public string NomPatient { get; }

        /// <summary>
        /// Gets Prénom du patient.
        /// </summary>
        public string PrenomPatient { get; }

        /// <summary>
        /// Gets Date de naissance du patient.
        /// </summary>
        public DateTime DateDeNaissancePatient { get; }

        /// <summary>
        /// Gets les prestations du dossier.
        /// </summary>
        internal List<Prestation> MesPrestations { get; }

        /// <summary>
        ///    Ajoute un objet de la classe Prestation à la collection _mesPrestations
        /// à noter qu'il faudra construire cet objet à partir des paramètres fournis
        /// </summary>
        /// <param name="unLibelle">libellé de la prestation.</param>
        /// <param name="uneDateHeure"> date de la prestation></param>
        /// <param name="unIntervenant">objet de la classe Intervenant, celui qui a fait la prestation</param>
        public void AjoutePrestation(string unLibelle, DateTime uneDateHeure, Intervenant unIntervenant)
        {
            this.MesPrestations.Add(new Prestation(unLibelle, uneDateHeure, unIntervenant));
        }

        /// <summary>
        /// retourne le npmbre de prestations du dossier effectuées
        /// par un intervenant externe 
        /// </summary>
        /// <returns>entier représentatnt le nb de prestations externes du dossier</returns>
        public short GetNbPrestationsExternes()
        {
            short nb = 0;
            foreach (Prestation unePrestation in this.MesPrestations)
            {
                if (unePrestation.UnIntervenant is IntervenantExterne)
                {
                    nb++;
                }
            }

            return nb;
        }

        /// <summary>
        /// Retourne le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée.
        /// On crée une collection de type LIST qui va contenir les dates de soins. On choisit LIST plutôt que Collection
        /// car LIST possède la méthode Contains qui va nous éviter d'écrire nous même la recherche de date existante dans la collection
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoins()
        {
            List<DateTime> lesDates = new List<DateTime>();
            foreach (Prestation unePrestation in this.MesPrestations)
            {
                if (!lesDates.Contains(unePrestation.DateHeureSoin.Date))
                {
                    lesDates.Add(unePrestation.DateHeureSoin.Date);
                }
            }

            return lesDates.Count;
        }

        /// <summary>
        /// Retourne aussi le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée.
        /// On va utiliser un delegate qui va se charger de retourner si deux dates de prestations sont égales ou non
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoinsV2()
        {

            if (this.MesPrestations.Count == 0)
            { // pas de prestation
                return 0;
            }
            else
            {
                // il faut trier les prestations par date de soin
                this.MesPrestations.Sort(delegate (Prestation prestation1, Prestation prestation2)
                {
                    return prestation1.DateHeureSoin.Date.CompareTo(prestation2.DateHeureSoin.Date);

                });
                Prestation oldPrestation = this.MesPrestations[0];
                int nb = 1;
                for (int i = 0; i < this.MesPrestations.Count; i++)
                {
                    if (this.MesPrestations[i].CompareTo(oldPrestation) != 0)
                    {
                        nb++;
                        oldPrestation = this.MesPrestations[i];
                    }
                }

                return nb;
            }
        }

        /// <summary>
        /// Retourne aussi le nombre de jours de soins comptabilisés pour le dossier. Il ne s'agit pas ici de déterminer
        ///  le nombre de prestations attachées à un dossier, mais le nombre de jours pour lesquels au moins 
        /// une prestation a été réalisée. 
        /// On va utiliser le langage LinQ qui va se charger de comptabiliser le nombres de dates de soins différentes
        /// parmi toutes les prestations.
        /// LinQ est une forme de SQL appliquée au objets.
        /// </summary>
        /// <returns>le nombre de jours où il y a eu au moins une prestation</returns>
        public int GetNbJoursSoinsV3()
        {
            // return mesPrestations.Select(x => DateTime.Parse(x.GetDateSoin())).Distinct().Count();
            return this.MesPrestations.Select(x => x.DateHeureSoin.Date).Distinct().Count();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string s = " -----Début dossier--------------";
            s += "\nNom: " + this.NomPatient + " Prenom: " + this.PrenomPatient + " Date de naissance: " + this.DateDeNaissancePatient.ToShortDateString();
            foreach (Prestation unePrestation in this.MesPrestations)
            {
                s += "\n" + unePrestation;
            }
            s += "\n -----Fin dossier--------------";

            return s;
        }
    }
}
