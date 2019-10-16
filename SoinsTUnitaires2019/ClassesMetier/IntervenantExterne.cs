// <copyright file="IntervenantExterne.cs" company="Benoît Roche Developments">
// Copyright (c) Benoît Roche Developments. All rights reserved.
// </copyright>

namespace ClassesMetier
{
    /// <summary>
    /// Classe IntervenantExterne inherits from Intervenant
    /// </summary>
    public class IntervenantExterne : Intervenant
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IntervenantExterne"/> class.
        /// </summary>
        /// <param name="nom">Nom de l'intervenant externe.</param>
        /// <param name="prenom"> prénom de l'intervenant externe.</param>
        /// <param name="specialite">spécialitéde l'intervenant externe.</param>
        /// <param name="adresse">adressede l'intervenant externe.</param>
        /// <param name="tel">téléphone de l'intervenant externe</param>
        public IntervenantExterne(string nom, string prenom, string specialite, string adresse, string tel) : base(nom, prenom)
        {
            this.Specialite = specialite;
            this.Adresse = adresse;
            this.Tel = tel;
        }

        /// <summary>
        /// gets Spécialité.
        /// </summary>
        public string Specialite { get; }

        /// <summary>
        /// gets Adresse.
        /// </summary>
        public string Adresse { get; }

        /// <summary>
        /// gets Tel.
        /// </summary>
        public string Tel { get; }



        /// <summary>
        /// sérialize un objet de la classe IntervenantExterne.
        /// </summary>
        /// <returns>l'objet IntervenantExterne sérializé.</returns>
        public override string ToString()
        {
            return base.ToString() + " Spécialité : " + this.Specialite + "\n\t\t  " + this.Adresse + " - " + this.Tel;
        }
    }
}
