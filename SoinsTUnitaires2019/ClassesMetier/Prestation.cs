namespace ClassesMetier
{
    using System;

    /// <summary>
    /// Classe Prestation
    /// </summary>
    public class Prestation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Prestation"/> class.
        /// </summary>
        /// <param name="libelle">Libelle de la Prestation. </param>
        /// <param name="uneDateHeure">Date et heure de la Prestation. </param>
        /// <param name="unIntervenant">Untervenant qui a réalisé la Prestation. </param>
        public Prestation(string libelle, DateTime uneDateHeure, Intervenant unIntervenant)
        {
            this.Libelle = libelle;
            this.DateHeureSoin = uneDateHeure;
            this.UnIntervenant = unIntervenant;
        }

        /// <summary>
        /// Gets property du libelle de la prestation.
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Gets la date des soins.
        /// </summary>
        public DateTime DateHeureSoin { get; }

        /// <summary>
        /// Gets l'objet intervenant ayant réalisé la prestation.
        /// </summary>
        public Intervenant UnIntervenant { get; }

        /// <summary>
        /// fonction qui compare 2 dates au format DateHeure
        /// Attention ici, on ne compare que les dates.
        /// 2 dates seront égales si leur JJ/MM/AAAA  sont égaux, quelle que soit l'heure
        /// </summary>
        /// <param name="unePrestation"> Prestation qui va fournir la date à comparer. </param>
        /// <returns>
        ///     0 les dates sont égales
        ///     1 si la date de la prestation courante est postérieure à la date de la prestation unePrestation
        ///     -1 si la date de la prestation courante est antérieure à la date de la prestation unePrestation
        /// 
        /// </returns>
        public int CompareTo(Prestation unePrestation)
        {
            return this.DateHeureSoin.Date.CompareTo(unePrestation.DateHeureSoin.Date);
        }

        /// <summary>
        /// Sérialize un objet Prestation
        /// </summary>
        /// <returns>objet Prestation sérializé</returns>
        public override string ToString() => "\t" + this.Libelle + " - " + this.DateHeureSoin.ToString() + " - " + this.UnIntervenant;

        /// <summary>
        /// Effectue la somme de 2 nombres.
        /// </summary>
        /// <param name="a">entier1 à additionner. </param>
        /// <param name="b">entier2 à additionner. </param>
        /// <returns> entier égal à la somme des deux entiers passés en paramètre. </returns>
        public int SommePourRien(int a, int b)
        {
            return a + b;
        }
    }
}
