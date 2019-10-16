// <copyright file="Intervenant.cs" company="Benoît Roche Developments">
// Copyright (c) Benoît Roche Developments. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// classe Intervenant.
    /// </summary>
    public class Intervenant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Intervenant"/> class.
        /// </summary>
        /// <param name="nom">nom de l'intervenant</param>
        /// <param name="prenom">prénom de l'intervenant</param>
        public Intervenant(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.LesPrestations = new Collection<Prestation>();
        }

        /// <summary>
        /// Gets nom de l'intervenant.
        /// </summary>
        public string Nom { get; }

        /// <summary>
        /// Gets prénom de l'intervenant.
        /// </summary>
        public string Prenom { get; }

        /// <summary>
        /// Gets or sets nom de l'intervenant.
        /// </summary>
        public Collection<Prestation> LesPrestations { get; set; }

        /// <summary>
        /// Sérialisation de l'objet Intervenant.
        /// </summary>
        /// <returns> une chaine </returns>
        public override string ToString()
        {
            return "Intervenant : " + this.Nom + " - " + this.Prenom;
        }

        /// <summary>
        /// ajoute une prestation à la collection.
        /// </summary>
        /// <param name="prestation">objet Prestation</param>
        public void AjoutePrestation(Prestation prestation)
        {
            this.LesPrestations.Add(prestation);
        }
    }
}
